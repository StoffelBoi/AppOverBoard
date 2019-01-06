using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUp : MonoBehaviour
{
    public Button btnTapToStart;
    // Use this for initialization
    void Start()
    {
        btnTapToStart.onClick.AddListener(btnToConnection);
    }
    void OnEnable()
    {
        btnTapToStart.gameObject.GetComponent<Animation>().Play();
    }
   
    void btnToConnection()
    {
        UIManager.Instance.Connection();
    }
}
