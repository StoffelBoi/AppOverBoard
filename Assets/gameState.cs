using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public static int playerCount;
    public static List<string> roles;
    public static List<int[]> currentPlace;
    public List<int[]> currentPlaceView;
    public static int[,] board;
    public int[,] boardView;
    public static string criminal;
    public static string criminalRole;
    public static List<int> money;
    public static List<int> solvedHints;
    public static List<int> unsolvedHints;
    public static List<int> trueSolveds;
    public static List<int> trueUnsolveds;
    public static List<int[,]> notFoundTrue;
    public static List<int[,]> notFoundFalse;
    public static List<List<string>> items;
    public static List<string> playerFact;
    public static List<string> roleFact;
    public static List<string> placeFact;
    public static int targetPlace;
    public static int currentTurn;
    public int currentTurnView;
    public static bool planted = false; // Variable fuer bio-terrorist wenn er seine bombe platziert hat
    public static List<int> questPlaces;
    public static int activatedQuestPlaces;
    public static List<int> isDisabled;
    public static List<bool> isManipulated;
    public static bool bigTrapUsed;
    public static List<bool> skillUsed;
    public static List<bool> usedEnergyDrink;
    public static List<string> traps;
    public static List<string> lastTransaction;
    public static List<string> lastAction;
    public static List<int> quarantined;

    void Awake() {
        playerCount = 0;
        roles = new List<string>();
        board = new int[6, 7];
        currentTurn= 0;
        currentPlace = new List<int[]>();
        money = new List<int>();
        solvedHints = new List<int>();
        unsolvedHints = new List<int>();
        items = new List<List<string>>();
        placeFact = new List<string>();
        roleFact = new List<string>();
        placeFact = new List<string>();
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
        traps = new List<string>();
        quarantined = new List<int>();
        lastTransaction = new List<string>();
        lastAction = new List<string>();
        for (int i = 0; i < 19; i++)
        {
            traps.Add("Safe");
            quarantined.Add(0);
        }
    }
   
	void Update () {
        boardView = board;
        currentPlaceView = currentPlace;
        currentTurnView = currentTurn;
    }
}
