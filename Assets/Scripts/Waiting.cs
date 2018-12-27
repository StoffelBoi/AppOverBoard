using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waiting : MonoBehaviour {

    public Text playerCount;
    public Text txtWaiting;
    public static Waiting Instance;
	void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void OnEnable()
    {
        txtWaiting.text = "IP Adress: " + MyNetManager.Instance.LocalIPAddress()+"\nWaiting for Players:";
    }
	// Update is called once per frame
	void Update () {
        playerCount.text=(GameState.Instance.connectedPlayer+"/" + GameState.Instance.playerCount);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.RoleSelection();
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                UIManager.Instance.RoleSelection();
            }
        }
    }
}
