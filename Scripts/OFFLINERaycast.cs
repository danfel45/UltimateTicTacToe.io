using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OFFLINERaycast : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;

    [SerializeField] OFFLINEGameManager gm;

    [SerializeField] private PlayerControls playerControls;


    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
    }

    private void RayCast()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.value.x, Mouse.current.position.value.y, 1000));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Square"))
            {
                gm.onSquare = true;
            }
            else
            {
                gm.onSquare = false;
            }
        }
        else
        {
            gm.onSquare = false;
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
