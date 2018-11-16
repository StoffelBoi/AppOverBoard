using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUpScreen : MonoBehaviour
{
    public Canvas startUpCanvas;
    public Canvas connectionCanvas;
    public Canvas roleSelectionCanvas;
    public Canvas waitingCanvas;
    public Canvas boardAssemblyCanvas;
    public Canvas privatPlayerCanvas;
    public Canvas movementCanvas;
    public GameObject connectionController;
    public GameObject roleSelectionController;
    public GameObject waitingController;
    public GameObject boardAssemblyController;
    public GameObject privatPlayerController;
    private StartUpScreen scriptStartUpScreen;
    private SelectPlayerCount scriptSelectPlayerCount;
    private RoleSelection scriptRoleSelection;
    private PlayerCount scriptPlayerCount;
    private BoardAssembly scriptBoardAssembly;
    private PrivatPlayer scriptPrivatPlayer;
    private Movement scriptMovement;

    // Use this for initialization
    void Start()
    {
        scriptStartUpScreen = this.GetComponent<StartUpScreen>();
        scriptSelectPlayerCount = connectionController.GetComponent<SelectPlayerCount>();

        connectionCanvas.enabled = false;
        roleSelectionCanvas.enabled = false;
        waitingCanvas.enabled = false;
        boardAssemblyCanvas.enabled = false;
        privatPlayerCanvas.enabled = false;
        movementCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startUpCanvas.enabled = false;
            connectionCanvas.enabled = true;
            scriptSelectPlayerCount.enabled = true;
            scriptStartUpScreen.enabled = false;
        }



     
        //if (Input.touchCount > 0)
        //{
        //    if (Input.GetTouch(0).phase == TouchPhase.Ended)
        //   {
        //        startUp.enabled = false;
        //        connection.enabled = true;
        //    }
        //}
    }
}
