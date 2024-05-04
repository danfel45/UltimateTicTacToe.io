using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour
{
    
    public bool isO = false;
    public bool isX = false;

    [SerializeField] GameManager gm;

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
        
    }



    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "X")
        {
            isX = true;
            gm.SetZoneActive(this.transform.name);

        }

        if(other.gameObject.tag == "O")
        {
            isO = true;
            gm.SetZoneActive(this.transform.name);
        }
    }
}
