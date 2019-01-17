using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivatePlayer : MonoBehaviour
{

    public Text txtFacts;
    public Text txtChar;
    public Text txtTime;
    public Text txtMoney;
    public Text txtSolved;
    public Text txtUnsolved;
    public Image imgChar;
    public Image BG;

    public Button btnTurn;
    public Text btnTurnText;
    public Button btnMenu;
    public Button btnGuess;
    public Button btnItems;
    public Button btnHide;

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

    public Image TargetTimeTextPanel;
    public Text TargetTimeText;
    public Image TargetTimeClockPanel;

    public Image ClockBG;
    public Image ClockMask;
    public Image ClockProgress;

    public Sprite Green;
    public Sprite Red;

    public Image TargetTimePanel;
    public Image TargetTime;

    public Image btnTurnColor;
    public Image btnGuessColor;

    public Sprite green;
    public Sprite red;

    public Canvas canvasHide;

    public bool vibration;


    public Sprite street;
    public Sprite mainsquare;
    public Sprite park;
    public Sprite hospital;
    public Sprite bank;
    public Sprite parliament;
    public Sprite cementary;
    public Sprite prison;
    public Sprite casino;
    public Sprite internetcafe;
    public Sprite trainstation;
    public Sprite armyshop;
    public Sprite shoppingcenter;
    public Sprite junkyard;
    public Sprite library;
    public Sprite laboratory;
    public Sprite italienrestaurant;
    public Sprite harbor;
    public Sprite bar;

    void OnEnable()
    {
        if (GameState.Instance.playerState[playerID] != "Movement")
        {
            vibration = true;
        }
        txtFacts.fontSize = 69;
        BG.sprite = GetSprite();
        canvasHide.gameObject.SetActive(false);
        btnHide.onClick.RemoveAllListeners();
        btnHide.onClick.AddListener(btnOpenHide);
        btnMenu.onClick.RemoveAllListeners();
        btnMenu.onClick.AddListener(btnToMenu);
        btnGuess.onClick.RemoveAllListeners();
        btnGuess.onClick.AddListener(btnToGuess);
        btnItems.onClick.RemoveAllListeners();
        btnItems.onClick.AddListener(UIManager.Instance.OpenItems);
        player = GameState.Instance.localPlayer.GetComponent<Player>();
        playerID = player.id;
        TargetTimeClockPanel.gameObject.SetActive(false);
        TargetTimeTextPanel.gameObject.SetActive(false);
        TargetTimePanel.gameObject.SetActive(false);
        btnGuess.gameObject.SetActive(true);
        character = GameState.Instance.roles[playerID];
        villain = GameState.Instance.criminalRole;
        Sprite portrait = mcay;
        string name = "";
        switch (character)
        {
            case "Doctor":
                portrait = mcay;
                name += "Dr.Moe McKay\nDoktor";
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
            "Fakten:\n\nPerson:\t" + GameState.Instance.roleFact[playerID] +
            "\n\nVerbrecher:\t" + GameState.Instance.playerFact[playerID] +
            "\n\nZielort:\t" + GameState.Instance.placeFact[playerID];

        if (GameState.Instance.criminal == character)
        {
            txtFacts.fontSize = 53;
            btnGuess.gameObject.SetActive(false);
            TargetTimeClockPanel.gameObject.SetActive(true);
            TargetTimeTextPanel.gameObject.SetActive(true);
            TargetTimePanel.gameObject.SetActive(true);

            name += "\n" + villain;
            infos = "Nicht aktivierte Zielorte:\n\n";
            for (int i = 0; i < 3 - GameState.Instance.activatedQuestPlaces; i++)
            {
                infos += (i + 1) + ". Zielort:" + translatePlace(GameState.Instance.questPlaces[i]) + "\n\n";
            }
            infos += "Verbrechensort:" + translatePlace(GameState.Instance.targetPlace);
            switch (GameState.Instance.criminalRole)
            {
                case "Inferno":
                    TargetTimeText.text = "Innerhalb von 50min";
                    break;
                case "Dr.Mortifier":
                    TargetTimeText.text = "Nach Verbrechen: in 10min 5 Felder entfernt";
                    break;
                case "Phantom":
                    TargetTimeText.text = "Alle 20min für 5min";
                    break;
                case "Fasculto":
                    TargetTimeText.text = "Nach 40min für 20min";
                    break;
            }
        }
        string money = "";
        string solveds = "";
        string unsolveds = "";
        if (GameState.Instance.money[playerID] < 10)
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
        UIManager.Instance.OpenMenu();
    }

    void Update()
    {
        if (GameState.Instance.targetTime)
        {
            TargetTime.sprite = Green;
        }
        else
        {
            TargetTime.sprite = Red;
        }
        if (GameState.Instance.playerState[playerID] == "Movement")
        {
            if (vibration == true)
            {
                vibration = false;
                Handheld.Vibrate();
            }
            btnTurnText.fontSize = 110;
            btnTurnText.text = "Bewegung";
            btnTurn.interactable = true;
            btnTurnColor.sprite = green;
            btnGuessColor.sprite = green; btnGuessColor.sprite = green;
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
        else if (GameState.Instance.playerState[playerID] == "Action")
        {
           
            btnTurnColor.sprite = green;
            btnGuessColor.sprite = green;
            btnTurnText.fontSize = 110;
            btnTurnText.text = "Aktion";
            btnTurn.interactable = true;
            btnTurn.onClick.RemoveAllListeners();
            btnTurn.onClick.AddListener(btnToPlace);
        }
        else
        {
            btnTurnColor.sprite = red;
            btnGuessColor.sprite = red;
            btnTurnText.fontSize = 60;
            btnTurnText.text = "Warten auf\n"+getName(GameState.Instance.roles[GameState.Instance.currentTurn]);
            btnTurn.interactable = false;
            btnTurn.onClick.RemoveAllListeners();
            btnGuess.interactable = false;
        }
        if (isActiveAndEnabled)
        {
            txtTime.text = GameState.Instance.elapsedTime;

            if (GameState.Instance.roles[playerID] == GameState.Instance.criminal)
            {
                switch (GameState.Instance.criminalRole)
                {
                    case "Inferno":
                        ClockBG.sprite = Red;
                        ClockProgress.sprite = Green;

                        float infernoProgress = (float)1034 - (float)((float)1034 / (float)50 * (float)((float)50 - (float)((float)GameState.Instance.elapsedSeconds / (float)60)));
                        ClockMask.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)infernoProgress, 0);
                        break;
                    case "Dr.Mortifier":
                        if (!GameState.Instance.planted)
                        {
                            ClockBG.sprite = Red;
                            ClockProgress.sprite = Green;
                        }
                        else
                        {
                            ClockBG.sprite = Red;
                            ClockProgress.sprite = Green;
                            float mortifierProgress = (float)1034 - ((float)1034 / (float)10) * ((float)10 - (((float)TimeManager.Instance.getAwayTime.ElapsedMilliseconds / (float)1000) / (float)60));


                            ClockMask.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)mortifierProgress, 0);
                        }


                        break;
                    case "Phantom":
                        float phantomProgress = 0;
                        if (!GameState.Instance.targetTime)
                        {
                            ClockBG.sprite = Green;
                            ClockProgress.sprite = Red;
                            phantomProgress = (float)1034 - ((float)1034 / (float)20) * ((float)20 - (((float)GameState.Instance.elapsedSeconds / (float)60) % (float)25));

                        }
                        else
                        {
                            ClockBG.sprite = Red;
                            ClockProgress.sprite = Green;
                            phantomProgress = (float)1034 - ((float)1034 / (float)5) * ((float)5 - ((((float)GameState.Instance.elapsedSeconds / (float)60) % (float)25) - (float)20));

                        }
                        ClockMask.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)phantomProgress, 0);

                        break;
                    case "Fasculto":
                        float fascultoProgress = 0;
                        if (!GameState.Instance.targetTime)
                        {
                            ClockBG.sprite = Green;
                            ClockProgress.sprite = Red;
                            fascultoProgress = (float)1034 - ((float)1034 / (float)40) * ((float)40 - ((float)GameState.Instance.elapsedSeconds / (float)60));

                        }
                        else
                        {
                            ClockBG.sprite = Red;
                            ClockProgress.sprite = Green;
                            fascultoProgress = (float)1034 - ((float)1034 / (float)0) * ((float)20 - (((float)GameState.Instance.elapsedSeconds / (float)60) - (float)40));

                        }
                        ClockMask.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2((float)fascultoProgress, 0);
                        break;
                }
            }
        }
    }
    
    void btnOpenHide()
    {
        btnHide.onClick.RemoveAllListeners();
        btnHide.onClick.AddListener(btnCloseHide);
        canvasHide.gameObject.SetActive(true);
    }
    void btnCloseHide()
    {
        btnHide.onClick.RemoveAllListeners();
        btnHide.onClick.AddListener(btnOpenHide);
        canvasHide.gameObject.SetActive(false);
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
                s = "Einkaufszentrum";

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

    string getName(string role)
    {
        string name = "";
        switch (role)
        {
            case "Doctor":
                name += "Dr.Moe McKay";
                break;
            case "Police":
                name += "Felicity Fields";
                break;
            case "Detective":
                name += "Collin Cooper";
                break;
            case "Psychic":
                name += "Olivia Osswald";
                break;
            case "Psychologist":
                name += "Laura Larsen";
                break;
            case "Reporter":
                name += "Eric Edmond";
                break;
        }
        return name;
    }

    Sprite GetSprite()
    {
        Sprite s = street;
        switch(GameState.Instance.board[GameState.Instance.currentPlace[GameState.Instance.localPlayer.GetComponent<Player>().id][0], GameState.Instance.currentPlace[GameState.Instance.localPlayer.GetComponent<Player>().id][1]])
        {
            case 1:
                s = mainsquare;
                break;
            case 2:
                s = park;
                break;
            case 3:
                s = hospital;
                break;
            case 4:
                s = bank;
                break;
            case 5:
                s = parliament;
                break;
            case 6:
                s = cementary;
                break;
            case 7:
                s = prison;
                break;
            case 8:
                s = casino;
                break;
            case 9:
                s = internetcafe;
                break;
            case 10:
                s = trainstation;
                break;
            case 11:
                s = armyshop;
                break;
            case 12:
                s = shoppingcenter;
                break;
            case 13:
                s = junkyard;
                break;
            case 14:
                s = library;
                break;
            case 15:
                s = laboratory;
                break;
            case 16:
                s = italienrestaurant;
                break;
            case 17:
                s = harbor;
                break;
            case 18:
                s = bar;
                break;
        }
        return s;
    }
}
