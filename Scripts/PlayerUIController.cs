using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text turnText;

    [SerializeField] private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.xTurn)
        {
            turnText.text = "X Turn";
        }
        else
        {
            turnText.text = "O Turn";
        }
    }
}
