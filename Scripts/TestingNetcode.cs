using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
public class TestingNetcode : MonoBehaviour
{
    [SerializeField] private Button clientButton;
    [SerializeField] private Button hostButton;
    private void Awake()
    {
        clientButton.onClick.AddListener(() =>
        {
            Debug.Log("CLIENT");
            NetworkManager.Singleton.StartClient();
            clientButton.gameObject.SetActive(false);
            hostButton.gameObject.SetActive(false);
        });

        hostButton.onClick.AddListener(() =>
        {
            Debug.Log("HOST");
            NetworkManager.Singleton.StartHost();
            hostButton.gameObject.SetActive(false);
            clientButton.gameObject.SetActive(false);
        });

    }


      
    

}
