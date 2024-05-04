using UnityEngine;
using System.Collections.Generic;
using Unity.Netcode;

public class ConnectedClientsLister : MonoBehaviour
{
    void ListConnectedClients()
    {
        foreach (var client in NetworkManager.Singleton.ConnectedClients)
        {
            ulong clientId = client.Key;
            NetworkObject playerObject = client.Value.PlayerObject;
            //string playerName = playerObject.gameObject.name; // Or retrieve player name from player object

            Debug.Log($"Client ID: {clientId}");
        }
    }

    void Start()
    {
        // Call the method to list connected clients when needed
        //ListConnectedClients();
    }
}
