using UnityEngine;
using Unity.Netcode;

public class SceneSwitchManager : NetworkBehaviour
{
    public GameObject playerPrefab; // Prefab of the player object to spawn

    private GameObject hostObj;
    private GameObject clientObj;

    void Start()
    {
        if (IsServer)
        {
           
            SpawnPlayer();
            
        }
        else
        {
            SpawnPlayerObjectsServerRpc();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    void SpawnPlayerObjectsServerRpc()
    {
        // Spawn player objects on the server and replicate to clients
        NetworkManager.SpawnManager.InstantiateAndSpawn(playerPrefab.GetComponent<NetworkObject>(), 0, false,false,false,this.transform.position, Quaternion.identity);
    }

    void SpawnPlayer()
    {
        NetworkManager.SpawnManager.InstantiateAndSpawn(playerPrefab.GetComponent<NetworkObject>(), 0, false, false, false, this.transform.position, Quaternion.identity);
        
    }
}
