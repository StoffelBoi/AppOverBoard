using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

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
    public Canvas canvasWin;
    public Canvas canvasLoss;
    public Canvas canvasDraw;
    public Canvas canvasItems;
    public Canvas canvasMenu;
    public Canvas canvasRules;

    public GameObject StartUpController;
    public GameObject ConnectionController;
    public GameObject RoleSelectionController;
    public GameObject WaitingController;
    public GameObject BoardAssemblyController;
    public GameObject PrivatePlayerController;
    public GameObject MovementController;
    public GameObject PlaceController;
    public GameObject WinController;
    public GameObject LossController;
    public GameObject DrawController;
    public GameObject ItemsController;
    public GameObject MenuController;
    public GameObject RulesController;

    public static UIManager Instance;
    // Use this for initialization

    void Awake()
    {

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DisableEverything();
        StartUp();
    }


    public void RestartScene()
    {
        MyNetManager.Instance.StopHosting();
        UnityEngine.Networking.NetworkManager.Shutdown();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
        canvasWin.enabled = false;
        canvasLoss.enabled = false;
        canvasDraw.enabled = false;
        canvasItems.enabled = false;
        canvasMenu.enabled = false;
        canvasRules.enabled = false;
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
        WinController.SetActive(false);
        LossController.SetActive(false);
        DrawController.SetActive(false);
        ItemsController.SetActive(false);
        MenuController.SetActive(false);
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
        GameState.Instance.boardGenerated = false;
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
        GameState.Instance.boardGenerated = true;
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

    public void Win()
    {
        DisableEverything();
        canvasWin.gameObject.SetActive(true);
        canvasWin.enabled = true;
        WinController.SetActive(true);
        //WinController.GetComponent<Win>().enabled = true;
    }

    public void Loss()
    {
        DisableEverything();
        canvasLoss.gameObject.SetActive(true);
        canvasLoss.enabled = true;
        LossController.SetActive(true);
        //LossController.GetComponent<Loss>().enabled = true;
    }

    public void Draw()
    {
        DisableEverything();
        canvasDraw.gameObject.SetActive(true);
        canvasDraw.enabled = true;
        DrawController.SetActive(true);
        //DrawController.GetComponent<Loss>().enabled = true;
    }

    public void Rules()
    {
        DisableEverything();
        canvasContents.gameObject.SetActive(true);
        canvasContents.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesPlace1()
    {
        DisableEverything();
        canvasRulesPlaces1.gameObject.SetActive(true);
        canvasRulesPlaces1.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesPlace2()
    {
        DisableEverything();
        canvasRulesPlaces2.gameObject.SetActive(true);
        canvasRulesPlaces2.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesPlace3()
    {
        DisableEverything();
        canvasRulesPlaces3.gameObject.SetActive(true);
        canvasRulesPlaces3.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesPlace4()
    {
        DisableEverything();
        canvasRulesPlaces4.gameObject.SetActive(true);
        canvasRulesPlaces4.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesEvil1()
    {
        DisableEverything();
        canvasRulesEvil1.gameObject.SetActive(true);
        canvasRulesEvil1.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesEvil2()
    {
        DisableEverything();
        canvasRulesEvil2.gameObject.SetActive(true);
        canvasRulesEvil2.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesEvil3()
    {
        DisableEverything();
        canvasRulesEvil3.gameObject.SetActive(true);
        canvasRulesEvil3.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesEvil4()
    {
        DisableEverything();
        canvasRulesEvil4.gameObject.SetActive(true);
        canvasRulesEvil4.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesGood1()
    {
        DisableEverything();
        canvasRulesGood1.gameObject.SetActive(true);
        canvasRulesGood1.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesGood2()
    {
        DisableEverything();
        canvasRulesGood2.gameObject.SetActive(true);
        canvasRulesGood2.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesWinCon()
    {
        DisableEverything();
        canvasRulesWinCondition.gameObject.SetActive(true);
        canvasRulesWinCondition.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesHints()
    {
        DisableEverything();
        canvasRulesHints.gameObject.SetActive(true);
        canvasRulesHints.enabled = true;
        RulesController.SetActive(true);
    }

    public void RulesMovement()
    {
        DisableEverything();
        canvasRulesMovement.gameObject.SetActive(true);
        canvasRulesMovement.enabled = true;
        RulesController.SetActive(true);
    }

    public void OpenItems()
    {
        canvasItems.gameObject.SetActive(true);
        canvasItems.enabled = true;
        ItemsController.SetActive(true);
    }

    public void CloseItems()
    {
        canvasItems.gameObject.SetActive(false);
        canvasItems.enabled = false;
        ItemsController.SetActive(false);
    }

    public void OpenMenu()
    {
        canvasMenu.gameObject.SetActive(true);
        canvasMenu.enabled = true;
        MenuController.SetActive(true);
    }
    public void CloseMenu()
    {
        canvasMenu.gameObject.SetActive(false);
        canvasMenu.enabled = false;
        MenuController.SetActive(false);
    }

    public void OpenRules()
    {
        canvasRules.gameObject.SetActive(true);
        canvasRules.enabled = true;
        RulesController.SetActive(true);
    }

    public void CloseRules()
    {
        canvasRules.gameObject.SetActive(false);
        canvasRules.enabled = false;
        RulesController.SetActive(false);
    }
}


