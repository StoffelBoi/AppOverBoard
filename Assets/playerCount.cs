using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCount : MonoBehaviour {

    public Text txt_playerCount;
    private int maxPlayer = 0; //updaten mit connection
    private int currentPlayer = 0; //updaten mit connection
    public Canvas waiting;
    public Canvas boardAssembly;

    public GameObject boardAssemblyController;

    private PlayerCount scriptPlayerCount;
    private BoardAssembly scriptBoardAssembly;

    // Use this for initialization
    private void Awake()
    {
        scriptPlayerCount =this.GetComponent<PlayerCount>();
        scriptPlayerCount.enabled = false;
    }
    void Start () {
        txt_playerCount.text = currentPlayer + "/" + maxPlayer;
       
        scriptBoardAssembly = boardAssemblyController.GetComponent<BoardAssembly>();
    }

    // Update is called once per frame
    void Update() {
        txt_playerCount.text = currentPlayer + "/" + maxPlayer;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            waiting.enabled = false;
            boardAssembly.enabled = true;
            scriptBoardAssembly.enabled = true;
            scriptPlayerCount.enabled = false;
        }

    }
}
