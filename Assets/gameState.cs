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

    }
   
	// Update is called once per frame
	void Update () {
        if (board != null)
        {
            Debug.Log("Mainsquare: "+board[2, 3]);
        }
        if (playerCount != 0)
        {
            Debug.Log("PlayerCount: " + playerCount);
        }
        foreach(string s in roles)
        {
            Debug.Log(s);
        }
        if (criminalRole != null)
        {
            Debug.Log("criminalrole: " + criminalRole);
        }
        if (criminal != null)
        {
            Debug.Log("criminal: " + criminal);
        }
        if (targetPlace != 0)
        {
            Debug.Log("targetPlace: " + targetPlace);
        }

    }
}
