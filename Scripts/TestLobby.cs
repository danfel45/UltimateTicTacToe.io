using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Netcode;
using TMPro;


public class TestLobby : NetworkBehaviour
{

    private Lobby hostLobby;
    private Lobby joinedLobby;
    private float heartbeatTimer;
    private float lobbyUpdateTimer;

    private string playerName;

    [SerializeField] private GameObject createButton;
    [SerializeField] private GameObject joinButton;

    [SerializeField] private GameObject playerIDText;

    [SerializeField] private GameObject waitingText;

    private async void Start()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);

        };

        playerIDText.GetComponent<TMP_Text>().text = AuthenticationService.Instance.PlayerId;

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
        playerName = "Test" + UnityEngine.Random.Range(10, 99);
        Debug.Log(playerName);

        waitingText.SetActive(false);
    }

    private void Update()
    {
        HandleLobbyHeartbeat();
        HandleLobbyPollForUpdates();

        //PrintLobby(hostLobby);
    }

    private async void HandleLobbyHeartbeat()
    {
        if(hostLobby != null)
        {
            heartbeatTimer -= Time.deltaTime;
            if(heartbeatTimer < 0f)
            {
                float heartbeatTimerMax = 15;
                heartbeatTimer = heartbeatTimerMax;

                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
            }
        }
    }

    private async void HandleLobbyPollForUpdates()
    {
        if (joinedLobby != null)
        {
            lobbyUpdateTimer -= Time.deltaTime;
            if (lobbyUpdateTimer < 0f)
            {
                float lobbyUpdateTimerMax = 1.1f;
                lobbyUpdateTimer = lobbyUpdateTimerMax;

                Lobby lobby = await LobbyService.Instance.GetLobbyAsync(joinedLobby.Id);
                joinedLobby = lobby;
            }
        }
    }


    public async void CreateLobby()
    {
        try
        {
            string lobbyName = "MyLobby";
            int maxPlayers = 2;

            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = false,
                Player = GetPlayer()
            };

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

            hostLobby = lobby;
            joinedLobby = hostLobby;

            Debug.Log("Created Lobby!" + lobby.Name);

            createButton.SetActive(false);
            joinButton.SetActive(false);
            waitingText.SetActive(true);

            NetworkManager.Singleton.StartHost();
            Debug.Log("HOST");

        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    private async void ListLobbies()
    {
        try
        {
            QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();

            Debug.Log("Lobbies found: " + queryResponse.Results.Count);
            foreach (Lobby lobby in queryResponse.Results)
            {
                Debug.Log(lobby.Name);
            }
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }


    private async void JoinLobbyByCode(string code)
    {
        try
        {
            JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions
            {
                Player = GetPlayer()
            };
            Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(code, joinLobbyByCodeOptions);

            joinedLobby = lobby;
            
            NetworkManager.Singleton.StartClient();
            Debug.Log("CLIENT");
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    
    public async void JoinByLobbyId()
    {
        try
        {
            JoinLobbyByIdOptions joinLobbyByIdOptions = new JoinLobbyByIdOptions
            {
                Player = GetPlayer()
            };

            QueryResponse queryResponse = await Lobbies.Instance.QueryLobbiesAsync();

            await Lobbies.Instance.JoinLobbyByIdAsync(queryResponse.Results[0].Id, joinLobbyByIdOptions);

            createButton.SetActive(false);
            joinButton.SetActive(false);
            waitingText.SetActive(true);

            NetworkManager.Singleton.StartClient();
            Debug.Log("CLIENT");

        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    public async void QuickJoinLobby()
    {
        try {

           
            await LobbyService.Instance.QuickJoinLobbyAsync();

            createButton.SetActive(false);
            joinButton.SetActive(false);
            waitingText.SetActive(true);

        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    private Player GetPlayer()
    {
        return new Player
        {

            Data = new Dictionary<string, PlayerDataObject> { { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) } }
        };
    }

    private async void LeaveLobby()
    {

        try
        {
            await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId);

        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }

    }

    private void PrintLobby(Lobby lobby)
    {
        Debug.Log("Players in Lobby: " + lobby.Name);
        foreach(Player player in lobby.Players)
        {
            Debug.Log(player.Data["PlayerName"].Value);
        }
    }
}
