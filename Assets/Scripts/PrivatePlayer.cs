using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivatePlayer : MonoBehaviour {

    public Text txtFacts;
    public Text txtChar;
    public Text txtTime;
    public Text txtMoney;
    public Text txtSolved;
    public Text txtUnsolved;
    public Image imgChar;

    public Button btnTurn;
    public Text btnTurnText;
    public Button btnMenu;
    public Button btnGuess;
    public Button btnItems;

    public Sprite mcay;
    public Sprite fields;
    public Sprite cooper;
    public Sprite osswald;
    public Sprite larsen;
    public Sprite edmond;

    private Player player;
    public int playerID;
    private string character;
    private string villain;
    void OnEnable()
    {
        txtFacts.fontSize = 69;
        btnMenu.onClick.RemoveAllListeners();
        btnMenu.onClick.AddListener(btnToMenu);
        btnGuess.onClick.RemoveAllListeners();
        btnGuess.onClick.AddListener(btnToGuess);

        player = GameState.Instance.localPlayer.GetComponent<Player>();
        playerID = player.id;

        character = GameState.Instance.roles[playerID];
        villain = GameState.Instance.criminalRole;
        Sprite portrait=mcay;
        string name = "";
        switch (character)
        {
            case "Doctor":
                portrait = mcay;
                name+= "Dr.Moe McKay\nDoktor";
                break;
            case "Police":
                portrait = fields;
                name += "Felicity Fields\nPolizistin";
                break;
            case "Detective":
                portrait = cooper;
                name += "Collin Cooper\nDetektiv";
                break;
            case "Psychic":
                portrait = osswald;
                name += "Olivia Osswald\nWahrsagerin";
                break;
            case "Psychologist":
                portrait = larsen;
                name += "Laura Larsen\nPsychologin";
                break;
            case "Reporter":
                portrait = edmond;
                name += "Eric Edmond\nReporter";
                break;
        }
        

        

        string infos = "";
        infos +=
            "Fakten:\n\nPerson:\t"+ GameState.Instance.placeFact[playerID] +
            "\n\nVerbrecher:\t"+ GameState.Instance.playerFact[playerID]+
            "\n\nZielort:\t"+ GameState.Instance.roleFact[playerID];

        if (GameState.Instance.criminal == character)
        {
            txtFacts.fontSize = 53;
            btnGuess.interactable = false;
            name += "\n" + villain;
            infos = "Nicht aktivierte Zielorte:\n\n";
            for (int i = 0; i<3-GameState.Instance.activatedQuestPlaces; i++)
            {
                infos += (i+1)+". Zielort:" + translatePlace(GameState.Instance.questPlaces[i]) + "\n\n";
            }
            infos += "Verbrechensort:" + translatePlace(GameState.Instance.targetPlace);
        }
        string money = "";
        string solveds = "";
        string unsolveds = "";
        if (GameState.Instance.money[playerID]<10)
        {
            money += "0";
        }
        if (GameState.Instance.solvedHints[playerID] < 10)
        {
            solveds += "0";
        }
        if (GameState.Instance.unsolvedHints[playerID] < 10)
        {
            unsolveds += "0";
        }
        money += GameState.Instance.money[playerID];
        solveds += GameState.Instance.solvedHints[playerID];
        unsolveds += GameState.Instance.unsolvedHints[playerID].ToString();
        txtMoney.text = money;
        txtSolved.text = solveds;
        txtUnsolved.text = unsolveds;
        txtFacts.text = infos;
        txtChar.text = name;
        imgChar.sprite = portrait;
    }
    void btnToGuess()
    {
        GameState.Instance.localPlayer.GetComponent<Player>().SetIsGuessing(GameState.Instance.localPlayer.GetComponent<Player>().id, true);
        UIManager.Instance.Place();
    }
    void btnToMenu()
    {
        UIManager.Instance.Rules();
    }

    void Update()
    {
        if (GameState.Instance.playerState[playerID] == "Movement")
        {
            btnTurnText.text = "Bewegung";
            btnTurn.interactable = true;
            btnTurn.onClick.RemoveAllListeners();
            btnTurn.onClick.AddListener(btnToMovement);
            if (GameState.Instance.criminal != GameState.Instance.roles[GameState.Instance.localPlayer.GetComponent<Player>().id])
            {
                btnGuess.interactable = true;
            }
            else
            {
                btnGuess.interactable = false;
            }
           
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
            txtTime.text = GameState.Instance.elapsedTime;
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

    string translatePlace(int place)
    {
        string s = "Straße";
        switch (place)
        {
            case 1:
                s = "Stadtplatz";

                break;
            case 2:
                s = "Park";

                break;
            case 3:
                s = "Krankenhaus";

                break;
            case 4:
                s = "Bank";

                break;
            case 5:
                s = "Parlament";

                break;
            case 6:
                s = "Friedhof";

                break;
            case 7:
                s = "Gefängnis";

                break;
            case 8:
                s = "Kasino";

                break;
            case 9:
                s = "Internet Cafe";

                break;
            case 10:
                s = "Bahnhof";

                break;
            case 11:
                s = "Armee Laden";

                break;
            case 12:
                s = "Shopping Center";

                break;
            case 13:
                s = "Schrottplatz";

                break;
            case 14:
                s = "Bibliothek";

                break;
            case 15:
                s = "Labor";

                break;
            case 16:
                s = "Italiener";

                break;
            case 17:
                s = "Hafen";

                break;
            case 18:
                s = "Bar";

                break;
        }
        return s;
    }
}
