using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class FinalWinChecker : NetworkBehaviour
{

    [SerializeField] private List<NetworkObject> zones;


    [SerializeField] private bool xWon;
    [SerializeField] private bool oWon;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            zones.Add(child.GetComponent<NetworkObject>());
        }
    }

    // Update is called once per frame
    void Update()
    {

        //CHECK IF HORIZ IS O
        if (zones[0].GetComponent<LargerGameScript>().isO && zones[1].GetComponent<LargerGameScript>().isO && zones[2].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        else if (zones[3].GetComponent<LargerGameScript>().isO && zones[4].GetComponent<LargerGameScript>().isO && zones[5].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        else if (zones[6].GetComponent<LargerGameScript>().isO && zones[7].GetComponent<LargerGameScript>().isO && zones[8].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        //CHECK IF HORIZ IS X
        else if (zones[0].GetComponent<LargerGameScript>().isX && zones[1].GetComponent<LargerGameScript>().isX && zones[2].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }
        else if (zones[3].GetComponent<LargerGameScript>().isX && zones[4].GetComponent<LargerGameScript>().isX && zones[5].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }
        else if (zones[6].GetComponent<LargerGameScript>().isX && zones[7].GetComponent<LargerGameScript>().isX && zones[8].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }
        //CHECK IF VERTS IS X
        else if (zones[0].GetComponent<LargerGameScript>().isX && zones[3].GetComponent<LargerGameScript>().isX && zones[6].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }
        else if (zones[1].GetComponent<LargerGameScript>().isX && zones[4].GetComponent<LargerGameScript>().isX && zones[7].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }
        else if (zones[2].GetComponent<LargerGameScript>().isX && zones[5].GetComponent<LargerGameScript>().isX && zones[8].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }
        //CHECK IF VERTS IS O
        else if (zones[0].GetComponent<LargerGameScript>().isO && zones[3].GetComponent<LargerGameScript>().isO && zones[6].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        else if (zones[1].GetComponent<LargerGameScript>().isO && zones[4].GetComponent<LargerGameScript>().isO && zones[7].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        else if (zones[2].GetComponent<LargerGameScript>().isO && zones[5].GetComponent<LargerGameScript>().isO && zones[8].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        //CHECK IF DIAG IS O
        else if (zones[0].GetComponent<LargerGameScript>().isO && zones[4].GetComponent<LargerGameScript>().isO && zones[8].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        else if (zones[2].GetComponent<LargerGameScript>().isO && zones[4].GetComponent<LargerGameScript>().isO && zones[6].GetComponent<LargerGameScript>().isO)
        {
            oWon = true;
        }
        //CHECK IF DIAG IS x
        else if (zones[0].GetComponent<LargerGameScript>().isX && zones[4].GetComponent<LargerGameScript>().isX && zones[8].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }
        else if (zones[2].GetComponent<LargerGameScript>().isX && zones[4].GetComponent<LargerGameScript>().isX && zones[6].GetComponent<LargerGameScript>().isX)
        {
            xWon = true;
        }

    }
}
