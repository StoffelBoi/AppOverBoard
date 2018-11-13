using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCount : MonoBehaviour {

    public Text txt_playerCount;
    public int maxPlayer = 0; //updaten mit connection
    public int currentPlayer = 0; //updaten mit connection

    // Use this for initialization
    void Start () {
        txt_playerCount.text = currentPlayer + "/" + maxPlayer;
	}

    // Update is called once per frame
    void Update() {
        txt_playerCount.text = currentPlayer + "/" + maxPlayer;

    }
}
