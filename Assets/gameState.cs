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
    public static int targetPlace;
    public static int currentTurn;
    // Use this for initialization
    void Start() {
        playerCount = 0;
        roles = new List<string>();
        board = new int[6, 7];
        currentTurn= 0;
        currentPlace = new List<int[]>();
    }
   
	// Update is called once per frame
	void Update () {
    }
}
