using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivatPlayer : MonoBehaviour {

    public Text txt_char;
    public Text txt_villainPlain;
    public Text txt_villain;
    public Text txt_TargetPlain;
    public Text txt_target;
    public Text txt_TimePlain;
    public Text txt_time;
    public Text txt_money;
    public Text txt_solved;
    public Text txt_unsolved;
    public Text txt_items;
    public Text txt_playerFact;
    public Text txt_roleFact;
    public Text txt_placeFact;

    private int playerID;
    private string character;
    private string villainRole = "";
    private string target = "";
    private string targetTime = "";
    private int money;
    private int solved;
    private int unsolved;
    private List<string> items;
    private string playerFact;
    private string roleFact;
    private string placeFact;



    // Use this for initialization
    void Start () {
        txt_villainPlain.enabled = false;
        txt_villain.enabled = false;
        txt_TargetPlain.enabled = false;
        txt_target.enabled = false;
        txt_TimePlain.enabled = false;
        txt_time.enabled = false;

        playerID = GameState.playerCount;
        GameState.playerCount++;

        character = GameState.roles[playerID];
        txt_char.text = character;

        if(GameState.criminal == character)
        {
            txt_villainPlain.enabled = true;
            txt_villain.enabled = true;
            txt_TargetPlain.enabled = true;
            txt_target.enabled = true;
            txt_TimePlain.enabled = true;
            txt_time.enabled = true;

            villainRole = GameState.criminalRole;
            txt_villain.text = villainRole;

            switch (GameState.targetPlace)
            {
                case 1:
                    target = "Stadtplatz";
                    break;
                case 2:
                    target = "Park";
                    break;
                case 4:
                    target = "Bank";
                    break;
                case 5:
                    target = "Parlament";
                    break;
                case 6:
                    target = "Friedhof";
                    break;
                case 7:
                    target = "Gefängnis";
                    break;
                case 8:
                    target = "Kasino";
                    break;
                case 12:
                    target = "Shopping Center";
                    break;
            }
        }


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
