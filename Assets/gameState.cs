using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameState : MonoBehaviour {
    public static int playerCount;
    public static List<string> roles;
    public static int[] board;
    // Use this for initialization
    void Start() {
        playerCount = 0;
        roles = new List<string>();


    }
   
	// Update is called once per frame
	void Update () {
        
        Debug.Log("PlayerCount: " + playerCount);
        foreach(string s in roles)
        {
            Debug.Log(s);
        }
       
	}
}
