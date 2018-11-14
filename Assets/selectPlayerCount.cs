using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPlayerCount : MonoBehaviour {
    public Dropdown dd;
    public Canvas connection;
    public Canvas roleSelection;
    public GameObject roleSelectionController;
    private SelectPlayerCount scriptSelectPlayerCount;
    private RoleSelection scriptRoleSelection;
 
    private void Awake()
    {
        scriptSelectPlayerCount = this.GetComponent<SelectPlayerCount>();
        scriptSelectPlayerCount.enabled = false;

    }
    // Use this for initialization
    void Start () {
        scriptRoleSelection = roleSelectionController.GetComponent<RoleSelection>();
    }
	
	// Update is called once per frame
	void Update () {
        switch (dd.value)
        {

            case 1:
               GameState.playerCount = 3;
                connection.enabled = false;
                roleSelection.enabled = true;
                scriptRoleSelection.enabled = true;
                scriptSelectPlayerCount.enabled = false;
                break;
            case 2:
                GameState.playerCount = 4;
                connection.enabled = false;
                roleSelection.enabled = true;
                scriptRoleSelection.enabled = true;
                scriptSelectPlayerCount.enabled = false;
                break;

            case 3:
                GameState.playerCount = 5;
                connection.enabled = false;
                roleSelection.enabled = true;
                scriptRoleSelection.enabled = true;
                scriptSelectPlayerCount.enabled = false;
                break;

            case 4:
                GameState.playerCount = 6;
                connection.enabled = false;
                roleSelection.enabled = true;
                scriptRoleSelection.enabled = true;
                scriptSelectPlayerCount.enabled = false;
                break;
        }
	}
}
