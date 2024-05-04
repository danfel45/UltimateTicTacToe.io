using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class WinChecker : NetworkBehaviour

{
    
    [SerializeField] private List<NetworkObject> zones;

    [SerializeField] private GameManager gm;

    [SerializeField] private LargerGameScript largeGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            zones.Add(child.GetComponent<NetworkObject>());
        }

        largeGame = GetComponentInParent<LargerGameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //CHECKS IF HORIZONTALS ARE ALL O
        if (zones[0].GetComponent<ZoneScript>().isO && zones[1].GetComponent<ZoneScript>().isO && zones[2].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;
        }
        else if (zones[3].GetComponent<ZoneScript>().isO && zones[4].GetComponent<ZoneScript>().isO && zones[5].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;
        }
        else if (zones[6].GetComponent<ZoneScript>().isO && zones[7].GetComponent<ZoneScript>().isO && zones[8].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;


        }
        //CHECKS IF HORIZONTALS ARE ALL X
        else if (zones[0].GetComponent<ZoneScript>().isX && zones[1].GetComponent<ZoneScript>().isX && zones[2].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;


        }
        else if (zones[3].GetComponent<ZoneScript>().isX && zones[4].GetComponent<ZoneScript>().isX && zones[5].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;

        }
        else if (zones[6].GetComponent<ZoneScript>().isX && zones[7].GetComponent<ZoneScript>().isX && zones[8].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;

        }
        //CHECKS IF VERTICALS ARE ALL X
        else if (zones[0].GetComponent<ZoneScript>().isX && zones[3].GetComponent<ZoneScript>().isX && zones[6].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;

        }
        else if (zones[1].GetComponent<ZoneScript>().isX && zones[4].GetComponent<ZoneScript>().isX && zones[7].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;

        }
        else if (zones[2].GetComponent<ZoneScript>().isX && zones[5].GetComponent<ZoneScript>().isX && zones[8].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;

        }
        //CHECKS IF VERTICALS ARE O
        else if (zones[0].GetComponent<ZoneScript>().isO && zones[3].GetComponent<ZoneScript>().isO && zones[6].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;

        }
        else if (zones[1].GetComponent<ZoneScript>().isO && zones[4].GetComponent<ZoneScript>().isO && zones[7].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;

        }
        else if (zones[2].GetComponent<ZoneScript>().isO && zones[5].GetComponent<ZoneScript>().isO && zones[8].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;

        }
        //CHECKS IF DIAGONALS ARE O
        else if (zones[0].GetComponent<ZoneScript>().isO && zones[4].GetComponent<ZoneScript>().isO && zones[8].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;

        }
        else if (zones[6].GetComponent<ZoneScript>().isO && zones[4].GetComponent<ZoneScript>().isO && zones[2].GetComponent<ZoneScript>().isO)
        {
            largeGame.isO = true;

        }
        //CHECKS IF DIAGONALS ARE X
        else if (zones[0].GetComponent<ZoneScript>().isX && zones[4].GetComponent<ZoneScript>().isX && zones[8].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;

        }
        else if (zones[6].GetComponent<ZoneScript>().isX && zones[4].GetComponent<ZoneScript>().isX && zones[2].GetComponent<ZoneScript>().isX)
        {
            largeGame.isX = true;

        }
    }




}
