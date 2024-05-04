using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class LightController : NetworkBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Transform activeZone;
    [SerializeField] private GameObject lightPrefab;
    private NetworkObject instantiatedLight;

    private void Start()
    {
        
    }

  
    

    private void Update()
    {
        // Update the position of the light based on the active zone
        foreach (LargerGameScript zone in gm.largerGames)
        {
            if (zone.isActive)
            {
                activeZone = zone.gameObject.transform;
            }
        }

        Vector3 pos = new Vector3(activeZone.position.x, activeZone.position.y, activeZone.position.z - 5);

        // Check if already spawned
        if (instantiatedLight == null)
        {
            // Instantiate the light prefab locally on the server
            GameObject lightGO = Instantiate(lightPrefab, Vector3.zero, Quaternion.identity);
            // Get the NetworkObject component from the instantiated GameObject
            instantiatedLight = lightGO.GetComponent<NetworkObject>();
            // Spawn the light GameObject on the network
            instantiatedLight.Spawn();
        }

        
        // Set the position of the light GameObject
        if (instantiatedLight != null)
        {
            instantiatedLight.transform.position = pos;
        }
    }


    private void SpawnLight()
    {

    }

    


  
}
