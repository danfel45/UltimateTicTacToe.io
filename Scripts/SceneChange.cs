using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class SceneSwitcher : NetworkBehaviour
{
    //public string nextSceneName; // Name of the scene to switch to

    // Method to switch scene for all players
    public void SwitchScene()
    {
        if (!IsServer) return; // Only execute on the server

        // Load the next scene across the network
        NetworkManager.SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    // Method to call when players are ready to switch scene (e.g., triggered by lobby host)
    public void StartGame()
    {
        if (IsServer)
        {
            // Server triggers scene switch for all clients
            SwitchScene();
        }
        else
        {
            // If not server, request server to switch scene
            SubmitSwitchSceneRequestServerRpc();
        }
    }

    // ServerRPC to handle scene switch request from non-server clients
    [ServerRpc]
    private void SubmitSwitchSceneRequestServerRpc()
    {
        SwitchScene();
    }
}
