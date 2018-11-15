using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public static int playerCount;
    public static List<string> roles;
    public static List<int[]> currentPlace;
    public static int[,] board;
    public static string criminal;
    public static string criminalRole;
    public static List<int> money;
    public static List<int> solvedHints;
    public static List<int> unsolvedHints;
    public static List<List<string>> items;
    public static List<string> playerFact;
    public static List<string> roleFact;
    public static List<string> placeFact;
    public static List<int> trueSolveds;
    public static List<int> trueUnsolveds;
    public static int targetPlace;
    public static int currentTurn;

    public static bool planted = false; // Variable fuer bio-terrorist wenn er seine bombe platziert hat
    
    // Use this for initialization
   
    void Start() {
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

    }
   
	// Update is called once per frame
	void Update () {
        Debug.Log("currentTurn: " + currentTurn);

    }
}
