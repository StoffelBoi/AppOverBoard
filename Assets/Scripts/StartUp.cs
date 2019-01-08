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
    void btnToConnection()
    {
        UIManager.Instance.Connection();
    }
}
