using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Canvas canvasStartUp;
    public Canvas canvasConnection;
    public Canvas canvasRoleSelection;
    public Canvas canvasWaiting;
    public Canvas canvasBoardAssembly;
    public Canvas canvasPrivatePlayer;
    public Canvas canvasMovement;
    public Canvas canvasPlace;
    public Canvas canvasContents;
    public Canvas canvasRulesPlaces1;
    public Canvas canvasRulesPlaces2;
    public Canvas canvasRulesPlaces3;
    public Canvas canvasRulesPlaces4;
    public Canvas canvasRulesEvil1;
    public Canvas canvasRulesEvil2;
    public Canvas canvasRulesEvil3;
    public Canvas canvasRulesEvil4;
    public Canvas canvasRulesGood1;
    public Canvas canvasRulesGood2;
    public Canvas canvasRulesWinCondition;
    public Canvas canvasRulesHints;
    public Canvas canvasRulesMovement;

    public GameObject StartUpController;
    public GameObject ConnectionController;
    public GameObject RoleSelectionController;
    public GameObject WaitingController;
    public GameObject BoardAssemblyController;
    public GameObject PrivatePlayerController;
    public GameObject MovementController;
    public GameObject PlaceController;
    public GameObject RulesController;

    public static UIManager Instance;
    // Use this for initialization

    void Awake () {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DisableEverything();
        StartUp();
	}

    public void DisableEverything()
    {
        canvasStartUp.enabled = false;
        canvasConnection.enabled = false;
        canvasRoleSelection.enabled = false;
        canvasWaiting.enabled = false;
        canvasBoardAssembly.enabled = false;
        canvasPrivatePlayer.enabled = false;
        canvasMovement.enabled = false;
        canvasPlace.enabled = false;
        canvasContents.enabled = false;
        canvasRulesPlaces1.enabled = false;
        canvasRulesPlaces2.enabled = false;
        canvasRulesPlaces3.enabled = false;
        canvasRulesPlaces4.enabled = false;
        canvasRulesEvil1.enabled = false;
        canvasRulesEvil2.enabled = false;
        canvasRulesEvil3.enabled = false;
        canvasRulesEvil4.enabled = false;
        canvasRulesGood1.enabled = false;
        canvasRulesGood2.enabled = false;
        canvasRulesWinCondition.enabled = false;
        canvasRulesHints.enabled = false;
        canvasRulesMovement.enabled = false;

        /*
        StartUpController.GetComponent<StartUp>().enabled = false;
        ConnectionController.GetComponent<Connection>().enabled = false;
        RoleSelectionController.GetComponent<RoleSelection>().enabled = false;
        WaitingController.GetComponent<Waiting>().enabled = false;
        BoardAssemblyController.GetComponent<BoardAssembly>().enabled = false;
        PrivatePlayerController.GetComponent<PrivatePlayer>().enabled = false;
        MovementController.GetComponent<Movement>().enabled = false;
        PlaceController.GetComponent<Place>().enabled = false;
        RulesController.GetComponent<Rules>().enabled = false;
        */


        StartUpController.SetActive(false);
        ConnectionController.SetActive(false);
        RoleSelectionController.SetActive(false);
        WaitingController.SetActive(false);
        BoardAssemblyController.SetActive(false);
        PrivatePlayerController.SetActive(false);
        MovementController.SetActive(false);
        PlaceController.SetActive(false);
        RulesController.SetActive(false);
    }

    public void StartUp()
    {
        DisableEverything();
        canvasStartUp.gameObject.SetActive(true);
        canvasStartUp.enabled = true;
        StartUpController.SetActive(true);
        //StartUpController.GetComponent<StartUp>().enabled = true;
    }

    public void Connection()
    {
        DisableEverything();
        canvasConnection.gameObject.SetActive(true);
        canvasConnection.enabled = true;
        ConnectionController.SetActive(true);
        //ConnectionController.GetComponent<Connection>().enabled = true;
    }

    public void RoleSelection()
    {
        DisableEverything();
        canvasRoleSelection.gameObject.SetActive(true);
        canvasRoleSelection.enabled = true;
        RoleSelectionController.SetActive(true);
        //RoleSelectionController.GetComponent<RoleSelection>().enabled = true;
    }

    public void Waiting()
    {
        DisableEverything();
        canvasWaiting.gameObject.SetActive(true);
        canvasWaiting.enabled = true;
        WaitingController.SetActive(true);
        //WaitingController.GetComponent<Waiting>().enabled = true;
    }

    public void BoardAssembly()
    {
        DisableEverything();
        canvasBoardAssembly.gameObject.SetActive(true);
        canvasBoardAssembly.enabled = true;
        BoardAssemblyController.SetActive(true);
        //BoardAssemblyController.GetComponent<BoardAssembly>().enabled = true;
    }

    public void PrivatePlayer()
    {
        DisableEverything();
        canvasPrivatePlayer.gameObject.SetActive(true);
        canvasPrivatePlayer.enabled = true;
        PrivatePlayerController.SetActive(true);
        //PrivatePlayerController.GetComponent<PrivatePlayer>().enabled = true;
    }

    public void Movement()
    {
        DisableEverything();
        canvasMovement.gameObject.SetActive(true);
        canvasMovement.enabled = true;
        MovementController.SetActive(true);
        //MovementController.GetComponent<Movement>().enabled = true;
    }

    public void Place()
    {
        DisableEverything();
        canvasPlace.gameObject.SetActive(true);
        canvasPlace.enabled = true;
        PlaceController.SetActive(true);
        //PlaceController.GetComponent<Place>().enabled = true;
    }

    //@TODO Make RulesLogic
    public void Rules()
    {
        DisableEverything();
    }
}
