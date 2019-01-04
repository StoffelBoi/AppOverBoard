using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivatePlayer : MonoBehaviour {

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

    public Button btnTurn;
    public Text btnTurnText;
    public Button btnRules;
    public Button btnGuess;

    private Player player;
    public int playerID;
    private string character;
    private string villainRole = "";
    private string target = "";
    private int targetTime = -1;
    /*rivate int money;
    private int solved;
    private int unsolved;
    private List<string> items;
    private string playerFact;
    private string roleFact;
    private string placeFact;
    public int trueSolved;
    public int trueUnsolved;

    private List<int> knownFacts;

    public bool timeWindowThief = false; //boolean fuer Meisterdieb ob er sein objektiv ausfuehren kann
    public bool timeWindowCultist = false; //boolean fuer Kultist ob er sein objektiv ausfuehren kann*/

    void OnEnable()
    {
        btnRules.onClick.RemoveAllListeners();
        btnRules.onClick.AddListener(btnToRules);
        btnGuess.onClick.RemoveAllListeners();
        btnGuess.onClick.AddListener(btnToGuess);
        txt_villainPlain.enabled = false;
        txt_villain.enabled = false;
        txt_TargetPlain.enabled = false;
        txt_target.enabled = false;
        player = GameState.Instance.localPlayer.GetComponent<Player>();

        playerID = player.id;
        character = GameState.Instance.roles[playerID];
        txt_char.text = character;

        txt_money.text = GameState.Instance.money[playerID].ToString();

        txt_solved.text = GameState.Instance.solvedHints[playerID].ToString();

        txt_unsolved.text = GameState.Instance.unsolvedHints[playerID].ToString();

        txt_placeFact.text = GameState.Instance.placeFact[playerID];
        txt_playerFact.text = GameState.Instance.playerFact[playerID];
        txt_roleFact.text = GameState.Instance.roleFact[playerID];

        

        if (GameState.Instance.criminal == character)
        {
            btnGuess.interactable = false;
            

            txt_villainPlain.enabled = true;
            txt_villain.enabled = true;
            txt_TargetPlain.enabled = true;
            txt_target.enabled = true;
            

            txt_villain.text = GameState.Instance.criminalRole;

            switch (GameState.Instance.targetPlace)
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

            txt_target.text = target;

            switch (villainRole)
            {
                case "Inferno":
                    targetTime = 50;
                    break;
                case "Dr.Mortifier":
                    targetTime = 10;
                    break;
                case "Phantom":
                    targetTime = 20;
                    break;
                case "Fasculto":
                    targetTime = 40;
                    break;
            }

            //InvokeRepeating("UpdateTime", 60, 60);
            //txt_time.text = targetTime.ToString();
        }

    }
    void btnToGuess()
    {
        GameState.Instance.playerState[GameState.Instance.currentTurn] = "Guessing";
        UIManager.Instance.Place();
    }
    void btnToRules()
    {
        Debug.Log("hello");
        UIManager.Instance.Rules();
    }

    void Update()
    {
        if(GameState.Instance.playerState[playerID]== "Guessing")
        {
            btnTurn.onClick.RemoveAllListeners();
            btnTurn.onClick.AddListener(btnToGuess);
            btnTurnText.text = "Verhaften";
            btnTurn.interactable = true;
            btnGuess.gameObject.SetActive(false);
        }
        else if (GameState.Instance.playerState[playerID] == "Movement")
        {
            btnTurnText.text = "Bewegung";
            btnTurn.interactable = true;
            btnTurn.onClick.RemoveAllListeners();
            btnTurn.onClick.AddListener(btnToMovement);
        }
        else if(GameState.Instance.playerState[playerID] == "Action")
        {
            btnTurnText.text = "Aktion";
            btnTurn.interactable = true;
            btnTurn.onClick.RemoveAllListeners();
            btnTurn.onClick.AddListener(btnToPlace);
        }
        else
        {
            btnTurnText.text = "Warten";
            btnTurn.interactable = false;
            btnTurn.onClick.RemoveAllListeners();
            btnGuess.interactable = false;
        }
        if (isActiveAndEnabled)
        {
            txt_time.text = GameState.Instance.elapsedTime;
        }
    }

    void btnToPlace()
    {
        UIManager.Instance.Place();
    }

    void btnToMovement()
    {
        UIManager.Instance.Movement();
    }

    /*public void UpdateTime()
    {
        targetTime--;
        txt_time.text = targetTime.ToString();
    
        if(targetTime == 0 && villainRole == "Inferno")
        {
            //umleitung zu unentschieden screen
        }

        else if(villainRole == "Dr.Mortifier")
        {
            if(GameState.Instance.planted)
            {
                if(targetTime == 0)
                {
                    //umleitung zu unentschieden
                }
            }
            else
            {
                targetTime++;
            }
        }

        else if(villainRole == "Phantom")
        { 
            if(targetTime == 0 && !timeWindowThief)
            {
                targetTime = 5;
                timeWindowThief = true;
            }

            else if(targetTime == 0 && timeWindowThief)
            {
                targetTime = 20;
                timeWindowThief = false;
            }
        }

        else if(villainRole == "Fasculto")
        {
            if(targetTime == 0 && !timeWindowCultist)
            {
                timeWindowCultist = true;
                targetTime = 20;
            }
            else if(targetTime == 0 && timeWindowCultist)
            {
                //umleitung zu unentschieden
            }
        }
    }

    //Methode zu updaten des Geldes schickt Geld dass hinzugefuegt wird (bzw negativer Wert wenn Geld abgezogen wird
    public void UpdateMoney(int money)
    {
        this.money += money;
        txt_money.text = this.money.ToString();
    }

    public void UpdateSolved(int amount)
    {
        solved += amount;
        txt_solved.text = solved.ToString();
    } 

    public void UpdateUnsolved(int amount)
    {
        unsolved += amount;
        txt_unsolved.text = unsolved.ToString();
    }

    public void UpdateTrueSolved(int amount)
    {
        System.Random rn = new System.Random();

        for(int i = 0; i < amount; i++)
        {
            trueSolved += 1;
            if(trueSolved % 3 == 0)
            {
                int next = rn.Next(1, 4);

                while(knownFacts.Contains(next))
                {
                    next = rn.Next(1, 4);
                }

                switch(next)
                {
                    case 1:
                        UpdatePlayerFact();
                        knownFacts.Add(next);
                        break;
                    case 2:
                        UpdateRoleFact();
                        knownFacts.Add(next);
                        break;
                    case 3:
                        UpdatePlaceFact();
                        knownFacts.Add(next);
                        break;
                }
            }
        }
    }

    public void UpdateTrueUnsolved(int amount)
    {
        trueUnsolved += amount;
    }

    public void AddItem(string itemToAdd)
    {
        items.Add(itemToAdd);

        foreach(string item in items)
        {
            txt_items.text += item;
            txt_items.text += "\n"; 
        }
    }

    public void RemoveItem(string itemToRemove)
    {
        items.Remove(itemToRemove);

        foreach (string item in items)
        {
            txt_items.text += item;
            txt_items.text += "\n";
        }
    }

    private void UpdatePlayerFact()
    {
        playerFact = GameState.Instance.criminal;
        txt_playerFact.text = playerFact;
    }

    private void UpdateRoleFact()
    {
        roleFact = GameState.Instance.criminalRole;
        txt_roleFact.text = roleFact;
    }

    private void UpdatePlaceFact()
    {
        switch (GameState.Instance.targetPlace)
        {
            case 1:
                placeFact = "Stadtplatz";
                break;
            case 2:
                placeFact = "Park";
                break;
            case 4:
                placeFact = "Bank";
                break;
            case 5:
                placeFact = "Parlament";
                break;
            case 6:
                placeFact = "Friedhof";
                break;
            case 7:
                placeFact = "Gefängnis";
                break;
            case 8:
                placeFact = "Kasino";
                break;
            case 12:
                placeFact = "Shopping Center";
                break;
        }

        txt_placeFact.text = placeFact;
    }
	*/
}
