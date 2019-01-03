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
    public  List<string> roles;
    public  List<int[]> currentPlace;
    public  int[,] board;
   
    public  SyncListInt money;
    public  List<int> solvedHints;
    public  List<int> unsolvedHints;
    public  List<int> trueSolveds;
    public  List<int> trueUnsolveds;
    public  List<int[,]> notFoundTrue;
    public  List<int[,]> notFoundFalse;
    public  List<List<string>> items;

    public  List<int> solvedFacts;
    public  List<string> playerFact;
    public  List<string> roleFact;
    public  List<string> placeFact;

    public  int targetPlace;
    public  int currentTurn;
    public  bool planted = false; // Variable fuer bio-terrorist wenn er seine bombe platziert hat
    public  List<int> questPlaces;
    public  int activatedQuestPlaces;
    public  List<int> isDisabled;
    public  List<bool> isManipulated;
    public  bool bigTrapUsed;
    public  List<bool> skillUsed;
    public  List<bool> usedEnergyDrink;



    public  List<int> infernoTraps;
    public  List<int> drMortifierTraps;
    public  List<int> phantomTraps;
    public  List<int> fascultoTraps;

    public  List<string> activeTraps;


    public  List<string> lastTransaction;
    public  List<string> lastAction;
    public  List<int> quarantined;
    public  List<string> playerState;

    

    public  List<bool> playerWin;
    public  List<bool> playerLost;

   
    
    void Awake() {
  
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        selectedRoles = 0;
        elapsedSeconds = 0;
        elapsedTime = "";
        targetTime = false;
        playerCount = 0;
        connectedPlayer = 0;
        roles = new List<string>();
        board = new int[6, 7];
        currentTurn= 0;
        currentPlace = new List<int[]>();
        money = new SyncListInt();
        solvedHints = new List<int>();
        unsolvedHints = new List<int>();
        items = new List<List<string>>();

        solvedFacts = new List<int>();
        placeFact = new List<string>();
        roleFact = new List<string>();
        playerFact = new List<string>();

        trueSolveds = new List<int>();
        trueUnsolveds = new List<int>();
        notFoundTrue = new List<int[,]>();
        notFoundFalse = new List<int[,]>();
        questPlaces = new List<int>();
        activatedQuestPlaces = 0;
        isDisabled = new List<int>();
        isManipulated = new List<bool>();
        bigTrapUsed = false;
        skillUsed = new List<bool>();
        usedEnergyDrink = new List<bool>();
        infernoTraps = new List<int>();
        drMortifierTraps = new List<int>();
        phantomTraps = new List<int>();
        fascultoTraps = new List<int>();
        activeTraps = new List<string>();
        quarantined = new List<int>();
        lastTransaction = new List<string>();
        lastAction = new List<string>();
        playerState = new List<string>();
        draw = false;
        criminalWin = false;
        playerWin = new List<bool>();
        playerLost = new List<bool>();
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
