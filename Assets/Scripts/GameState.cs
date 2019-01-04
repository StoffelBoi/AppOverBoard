using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GameState : NetworkBehaviour {

    public static GameState Instance;

    public GameObject localPlayer;

    [SyncVar]
    public int playerCount;

    public SyncListInt questPlaces = new SyncListInt();

    public SyncListString playerState = new SyncListString();

    public SyncListString roles=new SyncListString();

    public SyncListInt money= new SyncListInt();

    public SyncListInt solvedHints = new SyncListInt();

    public SyncListInt unsolvedHints = new SyncListInt();

    public SyncListInt trueSolveds = new SyncListInt();

    public SyncListInt trueUnsolveds = new SyncListInt();

    public SyncListInt isDisabled = new SyncListInt();

    public SyncListBool isManipulated = new SyncListBool();
   
    public SyncListBool skillUsed = new SyncListBool();

    public SyncListString lastTransaction = new SyncListString();

    public SyncListString lastAction = new SyncListString();
 
    public SyncListInt solvedFacts = new SyncListInt();

    public SyncListString playerFact = new SyncListString();

    public SyncListString roleFact = new SyncListString();

    public SyncListString placeFact = new SyncListString();

    public SyncListBool playerWin = new SyncListBool();

    public SyncListBool playerLost = new SyncListBool();

    public SyncListString activeTraps = new SyncListString();

    public SyncListInt infernoTraps = new SyncListInt();

    public SyncListInt drMortifierTraps = new SyncListInt();

    public SyncListInt phantomTraps = new SyncListInt();

    public SyncListInt fascultoTraps = new SyncListInt();

    public SyncListInt quarantined = new SyncListInt();

    public SyncListBool usedEnergyDrink = new SyncListBool();

    //manually networked with rpcs
    public int connectedPlayer;
    public int selectedRoles;
    public bool targetTime;
    public int elapsedSeconds;
    public string elapsedTime;
    public bool draw;
    public bool criminalWin;
    public string criminal;
    public string criminalRole;
    public int targetPlace;
    public int currentTurn;
    public int activatedQuestPlaces;
    public bool planted = false;
    public bool bigTrapUsed;
    public List<int[]> currentPlace;
    public List<int[,]> notFoundTrue;
    public List<int[,]> notFoundFalse;
    public int[,] board;
    public List<List<string>> items= new List<List<string>>();

    void Awake()
    {

        selectedRoles = 0;
        elapsedSeconds = 0;
        elapsedTime = "";
        targetTime = false;
        playerCount = 0;
        connectedPlayer = 0;
        board = new int[6, 7];
        currentTurn = 0;
        currentPlace = new List<int[]>();
        notFoundTrue = new List<int[,]>();
        notFoundFalse = new List<int[,]>();
        activatedQuestPlaces = 0;
        bigTrapUsed = false;
        draw = false;
        criminalWin = false;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void Start() {
        
        for (int i = 0; i<6; i++)
        {
            playerState.Add(""); 
            roles.Add("");
            money.Add(0);
            solvedHints.Add(0);
            unsolvedHints.Add(0);
            trueSolveds.Add(0);
            trueUnsolveds.Add(0);
            isDisabled.Add(0);
            isManipulated.Add(false);
            skillUsed.Add(false);
            lastTransaction.Add("Nichts");
            lastAction.Add("Nichts");
            solvedFacts.Add(0);
            placeFact.Add("");
            roleFact.Add("");
            playerFact.Add("");
            playerWin.Add(false);
            playerLost.Add(false);
            currentPlace.Add(new int[] { 2, 3 });
            items.Add(new List<string>());
            int[,] notFoundTrueArray = new int[6, 7];
            int[,] notFoundFalseArray = new int[6, 7];
            int[,] boardArray = new int[6, 7];
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 7; k++)
                {
                    notFoundTrueArray[j, k] = 0;
                    notFoundFalseArray[j, k] = 0;
                    boardArray[j, k] = 0;
                }
            }
            notFoundTrue.Add(notFoundTrueArray);
            notFoundFalse.Add(notFoundFalseArray);
            board = boardArray;
        }
        for (int i = 0; i < 19; i++)
        {
            infernoTraps.Add(0);
            drMortifierTraps.Add(0);
            phantomTraps.Add(0);
            fascultoTraps.Add(0);
            activeTraps.Add("Safe");
            quarantined.Add(0);
        }
    }



}
