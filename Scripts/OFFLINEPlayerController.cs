using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OFFLINEPlayerController : MonoBehaviour
{
    [SerializeField] private PlayerControls playerControls;

    [SerializeField] private OFFLINEGameManager gm;
    
    [SerializeField] private GameObject xPrefab;
    [SerializeField] private GameObject oPrefab;

    private void Awake()
    {
        playerControls = new PlayerControls();

        playerControls.Gameplay.Click.performed += ctx => Click();


    }

    // Update is called once per frame
    void Update()
    {
        PlacePiece();
    }

    private void PlacePiece()
    {

    }

    void Click()
    {
        if(gm.onSquare)
        {
            if (gm.xTurn)
            {
                Vector3 mousePos = new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y, 3f); ;

                var worldPos = Camera.main.ScreenToWorldPoint(mousePos);


                Instantiate(xPrefab, worldPos, Quaternion.identity);
            }
            else
            {
                Vector3 mousePos = new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y, 3f);

                var worldPos = Camera.main.ScreenToWorldPoint(mousePos);


                Instantiate(oPrefab, worldPos, Quaternion.identity);
            }

            gm.xTurn = !gm.xTurn;
            gm.turnTimer = gm.turnLength;
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

