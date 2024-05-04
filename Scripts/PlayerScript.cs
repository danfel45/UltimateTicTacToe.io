using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : NetworkBehaviour
{
    [SerializeField] private PlayerControls playerControls;

    public bool isX;
    public bool isO;

    [SerializeField] private GameObject xObject;
    [SerializeField] private GameObject oObject;

    [SerializeField] private GameManager gm;


    [SerializeField] private TMP_Text xIndicatorUI;
    [SerializeField] private TMP_Text oIndicatorUI;

    [SerializeField] private GameObject turnTextUI;

    Ray ray;
    RaycastHit hit;

    [SerializeField] private bool onSquare;

    //[SerializeField] private GameObject colliders;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Click.performed += ctx => Click();

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();


        turnTextUI = GameObject.Find("TurnText");

        gm.FindClientRole();
        
    }



    // Update is called once per frame
    void Update()
    {
        if(IsOwner)
        {
            RaycastServerRpc();

            

        }

        





    }

    private void OnMouseOver()
    {
        Debug.Log(gameObject.name);
    }



    private void PlacePiece(Vector3 mousePos)
    {
        if(IsLocalPlayer)
        {
            

            clientSpawnPieceServerRpc(mousePos);
            
        }

        
    }

    private void Click()
    {
        Vector3 mousePos = new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y,35.5f);

        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        PlacePiece(worldPos);
    }

    private void hostSpawnPiece(Vector3 pos)
    {
        NetworkManager.SpawnManager.InstantiateAndSpawn(xObject.gameObject.GetComponent<NetworkObject>(), 0, false, false, false, pos, Quaternion.identity);
        gm.xTurn = !gm.xTurn;
    }


    [ServerRpc]
    private void clientSpawnPieceServerRpc(Vector3 pos)
    {

        
        
            if (isX)
            {
                if (gm.xTurn && !gm.gameEnded)
                {
                    NetworkManager.SpawnManager.InstantiateAndSpawn(xObject.gameObject.GetComponent<NetworkObject>(), 0, false, false, false, pos, Quaternion.identity);
                    gm.xTurn = !gm.xTurn;
                    //hit.collider.gameObject.GetComponent<ZoneScript>().isX = true;
                    //hit.collider.gameObject.GetComponent<NetworkObject>().Despawn();
                }

            }
            else if (isO)
            {
                if (!gm.xTurn && !gm.gameEnded)
                {
                    NetworkManager.SpawnManager.InstantiateAndSpawn(oObject.gameObject.GetComponent<NetworkObject>(), 0, false, false, false, pos, Quaternion.identity);
                    gm.xTurn = !gm.xTurn;
                    //hit.collider.gameObject.GetComponent<ZoneScript>().isO = true;
                    //hit.collider.gameObject.GetComponent<NetworkObject>().Despawn();
                }

            }

        
        
        
        
    }


    [ServerRpc]
    private void RaycastServerRpc()
    {
        if(IsOwner)
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y, 10));
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.tag == "Square")
                {
                    onSquare = true;
                    //hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    onSquare = false;
                }
            }
        }
        
    }


    

    



private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

}
