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

    //manually networked with rpcs
    public List<int> questPlaces = new List<int>();

    public List<string> playerState = new List<string>();

    public List<string> roles =new List<string>();

    public List<int> money = new List<int>();

    public List<int> solvedHints = new List<int>();

    public List<int> unsolvedHints = new List<int>();

    public List<int> trueSolveds = new List<int>();

    public List<int> trueUnsolveds = new List<int>();

    public List<int> isDisabled = new List<int>();

    public List<bool> isHintManipulated = new List<bool>();

    public List<bool> isMovementManipulated = new List<bool>();
   
    public List<bool> skillUsed = new List<bool>();

    public List<string> lastTransaction = new List<string>();

    public List<string> lastAction = new List<string>();
 
    public List<int> solvedFacts = new List<int>();

    public List<string> playerFact = new List<string>();

    public List<string> roleFact = new List<string>();

    public List<string> placeFact = new List<string>();

    public List<bool> playerWin = new List<bool>();

    public List<bool> playerLost = new List<bool>();

    public List<string> activeTraps = new List<string>();

    public List<int> infernoTraps = new List<int>();

    public List<int> drMortifierTraps = new List<int>();

    public List<int> phantomTraps = new List<int>();

    public List<int> fascultoTraps = new List<int>();

    public List<int> quarantined = new List<int>();

    public List<bool> usedEnergyDrink = new List<bool>();

    public List<int[]> currentPlace = new List<int[]>();

    public List<int[,]> notFoundTrue = new List<int[,]>();

    public List<int[,]> notFoundFalse = new List<int[,]>();

    public List<List<string>> items = new List<List<string>>();

    public List<bool> isGuessing = new List<bool>();

    public List<bool> readyToPlay = new List<bool>();

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
   
    public int[,] board;
   

    void Awake()
    {
        restartAwake();
    }
    void Start() {
        restartStart();
    }
    void restartAwake()
    {
        selectedRoles = 0;
        elapsedSeconds = 0;
        elapsedTime = "0:00:00";
        targetTime = false;
        playerCount = 0;
        connectedPlayer = 0;
        board = new int[7, 6];
        currentTurn = 0;
        activatedQuestPlaces = 0;
        bigTrapUsed = false;
        draw = false;
        criminalWin = false;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void restartStart()
    {

        for (int i = 0; i < 6; i++)
        {
            readyToPlay.Add(false);
            playerState.Add("");
            roles.Add("");
            money.Add(0);
            solvedHints.Add(0);
            unsolvedHints.Add(0);
            trueSolveds.Add(0);
            trueUnsolveds.Add(0);
            isDisabled.Add(0);
            isMovementManipulated.Add(false);
            isHintManipulated.Add(false);
            skillUsed.Add(false);
            lastTransaction.Add("Nichts");
            lastAction.Add("Nichts");
            solvedFacts.Add(0);
            placeFact.Add("");
            roleFact.Add("");
            playerFact.Add("");
            playerWin.Add(false);
            playerLost.Add(false);
            isGuessing.Add(false);
            currentPlace.Add(new int[] { 3, 2 });
            items.Add(new List<string>());
            int[,] notFoundTrueArray = new int[7, 6];
            int[,] notFoundFalseArray = new int[7, 6];
            int[,] boardArray = new int[7, 6];
            for (int j = 0; j < 7; j++)
            {
                for (int k = 0; k < 6; k++)
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
