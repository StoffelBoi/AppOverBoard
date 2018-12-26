using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviour {
    public Dropdown dropdownCount;
    // Use this for initialization
    

	// Update is called once per frame
	void Update () {
        switch (dropdownCount.value)
        {
            case 1:
               GameState.playerCount = 3;
                UIManager.Instance.RoleSelection();
                break;
            case 2:
                GameState.playerCount = 4;
                UIManager.Instance.RoleSelection();
                break;

            case 3:
                GameState.playerCount = 5;
                UIManager.Instance.RoleSelection();
                break;

            case 4:
                GameState.playerCount = 6;
                UIManager.Instance.RoleSelection();
                break;
        }
	}
}
