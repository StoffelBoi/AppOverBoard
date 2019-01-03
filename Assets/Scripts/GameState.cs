using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GameState : NetworkBehaviour {

    public static GameState Instance;

    public GameObject localPlayer;

    [SyncVar]
    public int playerCount;
    [SyncVar]
    public int connectedPlayer;
    [SyncVar]
    public int selectedRoles;
    [SyncVar]
    public bool targetTime;
    [SyncVar]
    public int elapsedSeconds;
    [SyncVar]
    public string elapsedTime;
    [SyncVar]
    public bool draw;
    [SyncVar]
    public bool criminalWin;
    [SyncVar]
    public string criminal;
    [SyncVar]
    public string criminalRole;

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

    
    

    public  int targetPlace;
    public  int currentTurn;
    public  bool planted = false; // Variable fuer bio-terrorist wenn er seine bombe platziert hat
    public  int activatedQuestPlaces;

    public  bool bigTrapUsed;
    public  List<bool> usedEnergyDrink;



    public  List<int> infernoTraps;
    public  List<int> drMortifierTraps;
    public  List<int> phantomTraps;
    public  List<int> fascultoTraps;

    public  List<string> activeTraps;

    public  List<int> quarantined;


    public List<int[]> currentPlace;
    public List<int[,]> notFoundTrue;
    public List<int[,]> notFoundFalse;
    public List<List<string>> items;
    public int[,] board;

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
        items = new List<List<string>>();
        notFoundTrue = new List<int[,]>();
        notFoundFalse = new List<int[,]>();
        activatedQuestPlaces = 0;
        bigTrapUsed = false;
        usedEnergyDrink = new List<bool>();
        infernoTraps = new List<int>();
        drMortifierTraps = new List<int>();
        phantomTraps = new List<int>();
        fascultoTraps = new List<int>();
        activeTraps = new List<string>();
        quarantined = new List<int>();
        draw = false;
        criminalWin = false;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void Start() {
        for(int i = 0; i<6; i++)
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
