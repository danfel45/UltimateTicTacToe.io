using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class LargerGameScript : NetworkBehaviour
{
    public bool isActive = false;

    public bool zoneWon = false;
    public bool isO = false;
    public bool isX = false;

    [SerializeField] private GameObject oObject;
    [SerializeField] private GameObject xObject;


    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isX && !zoneWon)
        {
            NetworkManager.SpawnManager.InstantiateAndSpawn(xObject.gameObject.GetComponent<NetworkObject>(), 0, false, false, false, new Vector3(transform.position.x, transform.position.y, transform.position.z -10), Quaternion.identity);
            zoneWon = true;
        }
        else if(isO && !zoneWon)
        {
            NetworkManager.SpawnManager.InstantiateAndSpawn(oObject.gameObject.GetComponent<NetworkObject>(), 0, false, false, false, new Vector3(transform.position.x, transform.position.y, transform.position.z - 10), Quaternion.identity);
            zoneWon = true;
        }

        


    }


    



}
