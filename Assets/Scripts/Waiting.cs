using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waiting : MonoBehaviour {

    public Text playerCount;

	
	// Update is called once per frame
	void Update () {
        playerCount.text=("0/" + GameState.playerCount);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.BoardAssembly();
        }
    }
}
