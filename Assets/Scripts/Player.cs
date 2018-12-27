using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    public int id;
	// Use this for initialization
	void Start () {
        
        if (isLocalPlayer)
        {
            gameObject.name = "local";
            GameState.Instance.localPlayer = gameObject;
            id = GameState.Instance.connectedPlayer;
            ConnectedPlayerUp();
            UIManager.Instance.Waiting();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ConnectedPlayerUp()
    {
        if (isServer)
        {
            GameState.Instance.connectedPlayer++;
        }
        else
        {
            CmdConnectedPlayerUp();
        }
    }
    [Command]
    public void CmdConnectedPlayerUp()
    {
        GameState.Instance.connectedPlayer++;
    }

}
