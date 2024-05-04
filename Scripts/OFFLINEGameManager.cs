using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OFFLINEGameManager : MonoBehaviour
{

    public bool onSquare;

    private int turn;

    public bool xTurn;

    public float turnLength = 10;
    public float turnTimer;

    [SerializeField] private TMP_Text turnTextUI;
    [SerializeField] private TMP_Text timerUI;

     

    private void Awake()
    {
        turn = Random.Range(0, 1);
        if (turn == 1)
        {
            xTurn = true;
        }
        else
        {
            xTurn = false;
        }
        turnTimer = turnLength;
    }

    // Update is called once per frame
    void Update()
    {
        TurnTimer();
        UIManager();
    }


    void TurnTimer()
    {
        turnTimer -= Time.deltaTime;
        if(turnTimer < 0f)
        {
            turnTimer = turnLength;
            xTurn = !xTurn;
        }

        timerUI.text = Mathf.Floor(turnTimer).ToString();
        
    }

    void UIManager()
    {
        if(xTurn)
        {
            turnTextUI.text = "X Turn";
        }
        else
        {
            turnTextUI.text = "O Turn";
        }
    }
}
