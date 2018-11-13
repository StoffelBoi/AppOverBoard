using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectPlayerCount : MonoBehaviour {
    public Dropdown dd;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        switch (dd.value)
        {

            case 1:
               gameState.playerCount = 3;
                SceneManager.LoadScene("RoleSelection");
                break;
            case 2:
                gameState.playerCount = 4;
                SceneManager.LoadScene("RoleSelection");
                break;

            case 3:
                gameState.playerCount = 5;
                SceneManager.LoadScene("RoleSelection");
                break;

            case 4:
                gameState.playerCount = 6;
                SceneManager.LoadScene("RoleSelection");
                break;
        }
	}
}
