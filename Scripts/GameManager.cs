using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    public bool xTurn;

    public List<PlayerScript> playerList;

    private int rand;

    public bool gameEnded;

    [SerializeField] private GameObject gameOverText;

    [SerializeField] public List<LargerGameScript> largerGames;

    private float testTimer = 2;

    
    
    // Start is called before the first frame update
    void Start()
    {
        //NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;

        rand = Random.Range(0,1);

        xTurn = true;
    }

    private void Awake()
    {
        gameEnded = false;

        foreach(Transform child in transform)
        {
            largerGames.Add(child.GetComponent<LargerGameScript>());
        }

        int rand = Random.Range(0, 8);
        foreach (LargerGameScript zone in largerGames)
        {
            if(largerGames.IndexOf(zone) == rand)
            {
                zone.isActive = true;
            }
            
        }

        //NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;

        //FindClientRole();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(gameEnded)
        {
            GameEndServerRpc();
        }


        
           
        

        
        
    }

    public void SetZoneActive(string zoneName)
    {
        foreach(LargerGameScript zone in largerGames)
        {
            if(zone.name == zoneName)
            {
                zone.isActive = true;
            }
            else
            {
                zone.isActive = false;
            }
        }
    }

    
    
    

    public void FindClientRole()
    {
        
        foreach (var client in NetworkManager.Singleton.ConnectedClients)
        {
            ulong clientId = client.Key;
            NetworkObject playerObject = client.Value.PlayerObject;
            //string playerName = playerObject.gameObject.name; // Or retrieve player name from player object

            Debug.Log($"Client ID: {clientId}");

            
            //PlayerScript ps = playerObject.gameObject.GetComponent<PlayerScript>();
           
        }
    }

    


    [ServerRpc]
    private void GameEndServerRpc()
    {
        gameOverText.SetActive(true);
    }



}
