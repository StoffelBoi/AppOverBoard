﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Place : MonoBehaviour
{
    
    public Text placeName;
    public Image image;
    public Text actionsTextField;

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

    public Button btnOne;
    public Button btnTwo;
    public Button btnThree;
    public Button btnFour;
    public Button btnFive;
    public Button btnSix;
    public Button btnSeven;
    public Button btnEight;

    public Button btnBack;
    public Button btnInfo;

    public Text btnOneText;
    public Text btnTwoText;
    public Text btnThreeText;
    public Text btnFourText;
    public Text btnFiveText;
    public Text btnSixText;
    public Text btnSevenText;
    public Text btnEightText;

    private int currentBet;
    private int currentPlace;
    private int delayedTurns;

    private bool firstMovementManipulation;
    private int manipulatedPlayer;

    public Text dialogueText;
    public Image dialoguePanel;
    public string leftOverDialogue;
    public string currentDialogue;

    public static Place Instance;

    public bool guessing;

    void Awake()
    {
        guessing = false;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void OnEnable()
    {
        currentBet = 0;
        delayedTurns = 1;
        currentDialogue = "";
        leftOverDialogue = "";
        dialogueText.text = currentDialogue;
        dialogueText.gameObject.SetActive(false);
        dialoguePanel.gameObject.SetActive(false);

        btnBack.gameObject.SetActive(false);
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(btnGoBack);
        btnInfo.onClick.RemoveAllListeners();
        btnInfo.onClick.AddListener(btnToInfo);
        currentPlace = GameState.board[GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        actionsTextField.gameObject.SetActive(false);

        if (GameState.playerState[GameState.currentTurn]!= "Guessing") { 
        placeName.text = translatePlace(currentPlace);
        setPlaceImage(currentPlace);
        //menu if its a street
        if (currentPlace == 0)
        {
            twoButtons();
            btnOneText.text = "Umschauen";
            btnOne.onClick.AddListener(btnLookAroundClick);
            btnTwoText.text = "Item benutzen";
            btnTwo.onClick.AddListener(btnUseItemClick);
        }
        //menu if its not a street
        else
        {
            //menu if its a criminal
            if (GameState.criminal == GameState.roles[GameState.currentTurn])
            {

                eightButtons();
                btnOneText.text = "Ortsoption";
                btnTwoText.text = "Hinweis finden";
                btnThreeText.text = "Item benutzen";
                btnFourText.text = "falscher Hinweis";
                btnFiveText.text = "kleine Falle";
                btnSixText.text = "große Falle";
                btnSevenText.text = "Manipulation";
                btnEightText.text = "Questort aktivieren";

                btnOne.onClick.AddListener(btnPlaceOptionClick);
                btnTwo.onClick.AddListener(btnFindHintClick);
                btnThree.onClick.AddListener(btnUseItemClick);
                btnFour.onClick.AddListener(btnFalseHintClick);
                btnFive.onClick.AddListener(btnSmallTrapClick);
                btnSix.onClick.AddListener(btnBigTrapClick);
                btnSeven.onClick.AddListener(btnManipulationClick);
                btnEight.onClick.AddListener(btnActivateQuestPlaceClick);

                btnSix.interactable = false;
                btnSeven.interactable = false;
                btnEight.interactable = false;
                //checking if big Trap can be used
                if (!GameState.bigTrapUsed)
                {
                    btnSix.interactable = true;
                }

                //checking if manipulation can be used
                if (GameState.money[GameState.currentTurn] >= 10)
                {
                    btnSeven.interactable = true;
                }

                //checking if a questplace can be activated
                if (GameState.money[GameState.currentTurn] >= 6)
                {
                    if (GameState.activatedQuestPlaces < 3)
                    {
                        if (GameState.questPlaces.Contains(currentPlace))
                        {
                            btnEight.interactable = true;
                            {
                            }

                        }
                    }
                }
                if (GameState.activatedQuestPlaces >= 3)
                {
                    if (GameState.targetPlace == currentPlace)
                    {
                        btnEight.interactable = true;
                        btnEightText.text = "Verbrechen ausführen";
                    }
                }
                    
                //checking if theres already a trap on the current place
                if (GameState.activeTraps[currentPlace] != "Safe")
                {
                    btnFive.interactable = false;
                }
            }
            //menu if its a good guy
            else
            {

                threeButtons();
                btnOneText.text = "Ortsoption";
                btnTwoText.text = "Hinweis finden";
                btnThreeText.text = "Item benutzen";
                btnOne.onClick.AddListener(btnPlaceOptionClick);
                btnTwo.onClick.AddListener(btnFindHintClick);
                btnThree.onClick.AddListener(btnUseItemClick);

            }
            //checking if a skillplace can be used
            if (currentPlace == 2)
            {
                btnOne.interactable = false;
                if (GameState.roles[GameState.currentTurn] == "Detective" && !GameState.skillUsed[GameState.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 3)
            {
                btnOne.interactable = false;
                if (GameState.roles[GameState.currentTurn] == "Doctor" && !GameState.skillUsed[GameState.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 4)
            {
                btnOne.interactable = false;
                if (GameState.roles[GameState.currentTurn] == "Police" && !GameState.skillUsed[GameState.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 5)
            {
                btnOne.interactable = false;
                if (GameState.roles[GameState.currentTurn] == "Reporter" && !GameState.skillUsed[GameState.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 6)
            {
                btnOne.interactable = false;
                if (GameState.roles[GameState.currentTurn] == "Psychic" && !GameState.skillUsed[GameState.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 7)
            {
                btnOne.interactable = false;
                if (GameState.roles[GameState.currentTurn] == "Psychologist" && !GameState.skillUsed[GameState.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
        }
        //checking if player triggers a trap;
            Invoke("checkForTraps", 0.01f);
        }
        else
        {
            playerButtons();
            btnOne.onClick.AddListener(btnCheckPlayerOne);
            btnTwo.onClick.AddListener(btnCheckPlayerTwo);
            btnThree.onClick.AddListener(btnCheckPlayerThree);
            btnFour.onClick.AddListener(btnCheckPlayerFour);
            btnFive.onClick.AddListener(btnCheckPlayerFive);
            btnSix.onClick.AddListener(btnCheckPlayerSix);
        }
    }

#region Guessing
    void btnCheckPlayerOne()
    {
        CheckPlayerFact(0);
    }
    void btnCheckPlayerTwo()
    {
        CheckPlayerFact(1);
    }
    void btnCheckPlayerThree()
    {
        CheckPlayerFact(2);
    }
    void btnCheckPlayerFour()
    {
        CheckPlayerFact(3);
    }
    void btnCheckPlayerFive()
    {
        CheckPlayerFact(4);
    }
    void btnCheckPlayerSix()
    {
        CheckPlayerFact(5);
    }
    void CheckPlayerFact(int player)
    {
        if (GameState.roles[player] == GameState.criminal)
        {
            fourButtons();
            btnOneText.text = "Inferno";
            btnTwoText.text = "Dr. Mortifier";
            btnThreeText.text = "Phantom";
            btnFourText.text = "Fasculto";
            btnOne.onClick.AddListener(btnCheckRoleOne);
            btnTwo.onClick.AddListener(btnCheckRoleTwo);
            btnThree.onClick.AddListener(btnCheckRoleThree);
            btnFour.onClick.AddListener(btnCheckRoleFour);
        }
        else
        {
            GameState.playerLost[GameState.currentTurn] = true;
            endTurn();
        }
    }

    void btnCheckRoleOne()
    {
        CheckRoleFact(0);
    }
    void btnCheckRoleTwo()
    {
        CheckRoleFact(1);
    }
    void btnCheckRoleThree()
    {
        CheckRoleFact(2);
    }
    void btnCheckRoleFour()
    {
        CheckRoleFact(3);
    }
    void CheckRoleFact(int role)
    {
        switch (role)
        {
            case 0:
                if (GameState.criminalRole == "Inferno")
                {
                    CheckPlaceLayout();
                }
                else
                {
                    GameState.playerLost[GameState.currentTurn] = true;
                    endTurn();
                }
                break;
            case 1:
                if(GameState.criminalRole == "Dr.Mortifier")
                {
                    CheckPlaceLayout();
                }
                else
                {
                    GameState.playerLost[GameState.currentTurn] = true;
                    endTurn();
                }
                break;
            case 2:
                if (GameState.criminalRole == "Phantom")
                {
                    CheckPlaceLayout();
                }
                else
                {
                    GameState.playerLost[GameState.currentTurn] = true;
                    endTurn();
                }
                break;
            case 3:
                if (GameState.criminalRole == "Fasculto")
                {
                    CheckPlaceLayout();
                }
                else
                {
                    GameState.playerLost[GameState.currentTurn] = true;
                    endTurn();
                }
                break;
        }
    }
    void CheckPlaceLayout()
    {
        threeButtons();
        switch (GameState.criminalRole)
        {
            case "Inferno":
                btnOneText.text = "Parlament";
                btnTwoText.text = "Gefängnis";
                btnThreeText.text = "Kasino";
                break;
            case "Dr.Mortifier":
                btnOneText.text = "Stadtplatz";
                btnTwoText.text = "Shopping Center";
                btnThreeText.text = "Hafen";
                break;
            case "Phantom":
                btnOneText.text = "Bank";
                btnTwoText.text = "Kasino";
                btnThreeText.text = "Shopping Center";
                break;
            case "Fasculto":
                btnOneText.text = "Parlament";
                btnTwoText.text = "Friedhof";
                btnThreeText.text = "Gefängis";
                break;
        }
        btnOne.onClick.AddListener(btnCheckPlaceOne);
        btnTwo.onClick.AddListener(btnCheckPlaceTwo);
        btnThree.onClick.AddListener(btnCheckPlaceThree);
    }
    void btnCheckPlaceOne()
    {
        CheckPlaceFact(0);
    }
    void btnCheckPlaceTwo()
    {
        CheckPlaceFact(1);
    }
    void btnCheckPlaceThree()
    {
        CheckPlaceFact(2);
    }
    void CheckPlaceFact(int place)
    {
        switch (GameState.criminalRole)
        {
            case "Inferno":
                switch (place)
                {
                    case 0:
                        if (GameState.targetPlace ==5)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 1:
                        if (GameState.targetPlace ==7)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 2:
                        if (GameState.targetPlace ==8)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                }
                break;
            case "Dr.Mortifier":
                switch (place)
                {
                    case 0:
                        if (GameState.targetPlace ==1)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 1:
                        if (GameState.targetPlace ==12)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 2:
                        if (GameState.targetPlace ==17)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                }
                break;
            case "Phantom":
                switch (place)
                {
                    case 0:
                        if (GameState.targetPlace ==4)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 1:
                        if (GameState.targetPlace ==8)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 2:
                        if (GameState.targetPlace ==12)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                }
                break;
            case "Fasculto":
                switch (place)
                {
                    case 0:
                        if (GameState.targetPlace ==5)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 1:
                        if (GameState.targetPlace ==6)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                    case 2:
                        if (GameState.targetPlace ==7)
                        {
                            GameState.playerWin[GameState.currentTurn] = true;
                        }
                        else
                        {
                            GameState.playerLost[GameState.currentTurn] = true;
                            endTurn();
                        }
                        break;
                }
                break;
        }
    }

#endregion

    void btnToInfo()
    {
        UIManager.Instance.PrivatePlayer();
    }

    void checkForTraps()
    {
        if (GameState.roles[GameState.currentTurn] == GameState.criminal)
        {
            for (int i = 0; i < 19; i++)
            {
                if (GameState.infernoTraps[i] > 0)
                {
                    if (GameState.infernoTraps[i] == 1)
                    {
                        GameState.activeTraps[i] = "Bomb";
                    }
                    GameState.infernoTraps[i]--;
                }
                if (GameState.drMortifierTraps[i] > 0)
                {
                    if (GameState.drMortifierTraps[i] == 1)
                    {
                        GameState.activeTraps[i] = "PetriDish";
                    }
                    GameState.drMortifierTraps[i]--;
                }
                if (GameState.phantomTraps[i] > 0)
                {
                    if (GameState.phantomTraps[i] == 1)
                    {
                        GameState.activeTraps[i] = "StolenGoods";
                    }
                    GameState.phantomTraps[i]--;
                }
                if (GameState.fascultoTraps[i] > 0)
                {
                    if (GameState.fascultoTraps[i] == 1)
                    {
                        GameState.activeTraps[i] = "CursedArtifact";
                    }
                    GameState.fascultoTraps[i]--;
                }
            }
        }

        if (GameState.activeTraps[currentPlace] != "Safe")
        {
            switch (GameState.activeTraps[currentPlace])
            {
                case "Bomb":
                    if (!GameState.items[GameState.currentTurn].Contains("FireProofCoat"))
                    {
                        if (!GameState.items[GameState.currentTurn].Contains("ProtectiveVest"))
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.activeTraps[currentPlace]);
                            activatedTrap(GameState.currentTurn, findTargetPosition("Inferno"));
                            GameState.isDisabled[GameState.currentTurn] = 1;
                        }
                        else
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a protective vest");
                            GameState.items[GameState.currentTurn].Remove("ProtectiveVest");
                        }
                    }
                    else
                    {
                        Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a fire proof coat");
                    }
                    break;
                case "PetriDish":
                    if (!GameState.items[GameState.currentTurn].Contains("Gasmask"))
                    {
                        if (!GameState.items[GameState.currentTurn].Contains("ProtectiveVest"))
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.activeTraps[currentPlace]);
                            activatedTrap(GameState.currentTurn, findTargetPosition("Dr.Mortifier"));
                            GameState.isDisabled[GameState.currentTurn] = 1;
                        }
                        else
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a protective vest");
                            GameState.items[GameState.currentTurn].Remove("ProtectiveVest");
                        }
                    }
                    else
                    {
                        Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a Gasmask");
                    }
                    break;
                case "StolenGoods":
                    if (!GameState.items[GameState.currentTurn].Contains("Bodycam"))
                    {
                        if (!GameState.items[GameState.currentTurn].Contains("ProtectiveVest"))
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.activeTraps[currentPlace]);
                            activatedTrap(GameState.currentTurn, findTargetPosition("Phantom"));
                            GameState.isDisabled[GameState.currentTurn] = 1;
                        }
                        else
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a protective vest");
                            GameState.items[GameState.currentTurn].Remove("ProtectiveVest");
                        }
                    }
                    else
                    {
                        Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a Bodycam");
                    }
                    break;
                case "CursedArtifact":
                    if (!GameState.items[GameState.currentTurn].Contains("Talisman"))
                    {
                        if (!GameState.items[GameState.currentTurn].Contains("ProtectiveVest"))
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.activeTraps[currentPlace]);
                            activatedTrap(GameState.currentTurn, findTargetPosition("Fasculto"));
                            GameState.isDisabled[GameState.currentTurn] = 1;
                        }
                        else
                        {
                            Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a protective vest");
                            GameState.items[GameState.currentTurn].Remove("ProtectiveVest");
                        }
                    }
                    else
                    {
                        Debug.Log(GameState.roles[GameState.currentTurn] + " was protected by a Talisman");
                    }
                    break;
            }
            GameState.activeTraps[currentPlace] = "Safe";
            endTurn();

        }
    }

    //@TODO Messages for big trap and manipulation, and small trap
    void endTurn()
    {
        if (!GameState.usedEnergyDrink.Contains(true))
        {
            System.Random rn = new System.Random();
            int randomHint = rn.Next(1, 10);
            if (randomHint == 1)
            {
                if (GameState.roles[GameState.currentTurn] == GameState.criminal)
                {
                    addTrueHint();
                }
                else
                {
                    addFalseHint();
                }
            }
            GameState.playerState[GameState.currentTurn] = "Waiting";
            if (GameState.currentTurn == GameState.playerCount - 1)
            {
                GameState.currentTurn = 0;

            }
            else
            {
                GameState.currentTurn++;
            }
            GameState.playerState[GameState.currentTurn] = "Movement";
            //counting down quarantine time
            if (GameState.roles[GameState.currentTurn] == "Doctor")
            {
                for (int i = 0; i < 19; i++)
                {
                    if (GameState.quarantined[i] > 0)
                    {
                        GameState.quarantined[i]--;
                    }
                }
            }
            if (GameState.isDisabled[GameState.currentTurn] > 0)
            {
                Debug.Log(GameState.roles[GameState.currentTurn] + " is still disabled");
                GameState.isDisabled[GameState.currentTurn]--;
                endTurn();
            }
            if (GameState.playerLost[GameState.currentTurn])
            {
                Debug.Log(GameState.roles[GameState.currentTurn] + " has already lost");
                endTurn();
            }
            if (GameState.isManipulated[GameState.currentTurn])
            {
                Debug.Log(GameState.roles[GameState.currentTurn] + " was forced to move here");
                GameState.isManipulated[GameState.currentTurn] = false;
                OnEnable();
            }
            else
            {
                UIManager.Instance.PrivatePlayer();
            }
        }
        else
        {
            GameState.usedEnergyDrink.Remove(true);
            OnEnable();
        }
    }

    #region Dialogue
    void setDialogue(string newDialogue)
    {
        btnInfo.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);
        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(stopTypeWriter);

        currentDialogue = "";
        dialoguePanel.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = currentDialogue;
        dialogueText.fontSize = 60;

        if (newDialogue.Length <= 130)
        {
            currentDialogue = newDialogue;
            leftOverDialogue = "";
        }
        else
        {
            string currentString = "";
            string currentWord = "";
            bool firstLine = true;
            foreach (var c in newDialogue)
            {
                if (firstLine)
                {
                    if (char.IsWhiteSpace(c))
                    {
                        if (currentString.Length + currentWord.Length > 120)
                        {
                            currentDialogue = currentString;
                            firstLine = false;
                            currentString = "";
                            leftOverDialogue = "";
                            leftOverDialogue += currentWord;
                            leftOverDialogue += c;
                            currentWord = "";
                        }
                        currentString += currentWord + c;
                        currentWord = string.Empty;
                    }
                    currentWord += c;
                }
                else
                {
                    leftOverDialogue += c;
                }
            }
        }
        StartCoroutine("TypeWriter");
    }

    IEnumerator TypeWriter()
    {
        foreach (char c in currentDialogue)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
        btnOne.onClick.RemoveAllListeners();
        if (leftOverDialogue == "")
        {
            btnOne.onClick.AddListener(endTurn);
        }
        else
        {
            btnOne.onClick.AddListener(btnLeftOverDialogue);
        }
    }

    void stopTypeWriter()
    {
        StopCoroutine("TypeWriter");
        dialogueText.text = currentDialogue;
        btnOne.onClick.RemoveAllListeners();
        if (leftOverDialogue == "")
        {
            btnOne.onClick.AddListener(endTurn);
        }
        else
        {
            btnOne.onClick.AddListener(btnLeftOverDialogue);
        }
    }

    void btnLeftOverDialogue()
    {
        setDialogue(leftOverDialogue);
    }
    #endregion

    void btnGoBack()
    {
        OnEnable();
    }

    //@TODO: add Random Events
    void btnLookAroundClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Umschauen";
        setDialogue("Du schaust dich um aber du bemerkst nichts außergewöhnliches.");
    }

    #region Use Item
    void btnUseItemClick()
    {
        btnBack.gameObject.SetActive(true);
        int trainersCount = 0;
        int FingerprintKitCount = 0;
        int EnergyDrinkCount = 0;
        int WhiskeyCount = 0;

        for (int i = 0; i < GameState.items[GameState.currentTurn].Count; i++)
        {
            switch (GameState.items[GameState.currentTurn][i])
            {
                case "Trainers":
                    trainersCount++;
                    break;
                case "FingerprintKit":
                    FingerprintKitCount++;
                    break;
                case "EnergyDrink":
                    EnergyDrinkCount++;
                    break;
                case "Whiskey":
                    WhiskeyCount++;
                    break;
            }
        }

        simpleDialogue("Welches Item willst du benutzen?", 60);

        fourButtons();
        btnOneText.text = "Turnschuhe x" + trainersCount;
        btnTwoText.text = "Fingerabdruckset x" + FingerprintKitCount;
        btnThreeText.text = "Energy Drink x" + EnergyDrinkCount;
        btnFourText.text = "Whiskey x" + WhiskeyCount;
        btnOne.onClick.AddListener(btnTrainersOnClick);
        btnTwo.onClick.AddListener(btnFingerprintKitOnClick);
        btnThree.onClick.AddListener(btnEnergyDrinkOnClick);
        btnFour.onClick.AddListener(btnWhiskeyOnClick);

        if (trainersCount == 0)
        {
            btnOne.interactable = false;
        }
        if (FingerprintKitCount == 0)
        {
            btnTwo.interactable = false;
        }
        if (EnergyDrinkCount == 0)
        {
            btnThree.interactable = false;
        }
        if (WhiskeyCount == 0)
        {
            btnFour.interactable = false;
        }
        if (currentPlace != 17)
        {
            btnFour.interactable = false;
        }

    }
    void btnTrainersOnClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
        GameState.items[GameState.currentTurn].Remove("Trainers");
        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(btnTrainersContinue);
        simpleDialogue("Du ziehst deine Turnschuhe an und beginnst zu laufen.", 60);
    }
    void btnTrainersContinue()
    {
        UIManager.Instance.Movement();

    }
    void btnFingerprintKitOnClick()
    {
        int tempFoundHints= GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]; ;
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
        GameState.solvedHints[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        Debug.Log(GameState.roles[GameState.currentTurn] + " has found " + (GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]) + " hints");
        GameState.trueSolveds[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        GameState.items[GameState.currentTurn].Remove("FingerprintKit");
        if (checkForFact())
        {
            if (tempFoundHints == 1)
            {
                simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du einen Hinweis und hast dadurch eine wichtige Information herausfinden können.", 60);
            }
            else
            {
                simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du " + tempFoundHints + " Hinweise und hast dadurch eine wichtige Information herausfinden können.", 60);
            }
            
        }
        else
        {
            if (tempFoundHints > 0)
            {
                if (tempFoundHints == 1)
                {
                    simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du einen Hinweis.", 60);
                }
                else
                {
                    simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du " + tempFoundHints + " Hinweise", 60);
                }

            }
            else
            {
                simpleDialogue("Selbst mit dem Fingerabdruckset lässt sich hier kein Hinweis finden.",60);
            }
        }

        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(btnFingerprintkitContinue);
        
    }
    void btnFingerprintkitContinue()
    {
        OnEnable();
    }
    void btnEnergyDrinkOnClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
        GameState.usedEnergyDrink.Add(true);
        GameState.items[GameState.currentTurn].Remove("EnergyDrink");
        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(btnEnergyDrinkContinue);
        simpleDialogue("Du trinkst einen Energy Drink und fühlst dich voller Energie", 60);
    }
    void btnEnergyDrinkContinue()
    {
        OnEnable();
    }
    void btnWhiskeyOnClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
        GameState.trueSolveds[GameState.currentTurn]++;
        GameState.solvedHints[GameState.currentTurn]++;
        GameState.items[GameState.currentTurn].Remove("Whiskey");
        checkForFact();
        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(btnWhiskeyContinue);
        simpleDialogue("Du tauscht deinen Whiskey gegen einen sicher richtigen Hinweis.",60);
    }
    void btnWhiskeyContinue()
    {
        OnEnable();
    }
    #endregion

    #region Small Trap
    void btnSmallTrapClick()
    {
        btnBack.gameObject.SetActive(true);
        int bombCount = 0;
        int petriDishCount = 0;
        int stoleGoodsCount = 0;
        int cursedArtifactCount = 0;

        for (int i = 0; i < GameState.items[GameState.currentTurn].Count; i++)
        {
            switch (GameState.items[GameState.currentTurn][i])
            {
                case "Bomb":
                    bombCount++;
                    break;
                case "PetriDish":
                    petriDishCount++;
                    break;
                case "StolenGoods":
                    stoleGoodsCount++;
                    break;
                case "CursedArtifact":
                    cursedArtifactCount++;
                    break;
            }
        }


        simpleDialogue("Welche Falle willst du legen?", 60);
        fourButtons();
        btnOneText.text = "Bombe x" + bombCount;
        btnTwoText.text = "Petrischale x" + petriDishCount;
        btnThreeText.text = "Diebesgut x" + stoleGoodsCount;
        btnFourText.text = "Verfluchtes Artifakt x" + cursedArtifactCount;
        btnOne.onClick.AddListener(calibrateInfernoTrap);
        btnTwo.onClick.AddListener(calibrateDrMortifierTrap);
        btnThree.onClick.AddListener(calibratePhantomTrap);
        btnFour.onClick.AddListener(calibrateFascultoTrap);
        if (bombCount == 0)
        {
            if (GameState.criminalRole == "Inferno")
            {
                btnOneText.text = "Bombe 2$";
                btnOne.onClick.RemoveAllListeners();
                btnOne.onClick.AddListener(buyOwnTrap);
                if (GameState.money[GameState.currentTurn] < 2)
                {
                    btnOne.interactable = false;
                }
            }
            else
            {
                btnOne.interactable = false;
            }
        }
        if (petriDishCount == 0)
        {
            if (GameState.criminalRole == "Dr.Mortifier")
            {
                btnTwoText.text = "Petrischale 2$";
                btnTwo.onClick.RemoveAllListeners();
                btnTwo.onClick.AddListener(buyOwnTrap);
                if (GameState.money[GameState.currentTurn] < 2)
                {
                    btnTwo.interactable = false;
                }
            }
            else
            {
                btnTwo.interactable = false;
            }
        }
        if (stoleGoodsCount == 0)
        {
            if (GameState.criminalRole == "Phantom")
            {
                btnThreeText.text = "Diebesgut 2$";
                btnThree.onClick.RemoveAllListeners();
                btnThree.onClick.AddListener(buyOwnTrap);
                if (GameState.money[GameState.currentTurn] < 2)
                {
                    btnThree.interactable = false;
                }
            }
            else
            {
                btnThree.interactable = false;
            }
        }
        if (cursedArtifactCount == 0)
        {
            if (GameState.criminalRole == "Fasculto")
            {
                btnFourText.text = "Verfluchtes Artifakt 2$";
                btnFour.onClick.RemoveAllListeners();
                btnFour.onClick.AddListener(buyOwnTrap);
                if (GameState.money[GameState.currentTurn] < 2)
                {
                    btnFour.interactable = false;
                }
            }
            else
            {
                btnFour.interactable = false;
            }
        }

    }
    void buyOwnTrap()
    {
        switch (GameState.criminalRole)
        {
            case ("Inferno"):
                calibrateInfernoTrap();
                break;
            case ("Dr.Mortifier"):
                calibrateDrMortifierTrap();
                break;
            case ("Phantom"):
                calibratePhantomTrap();
                break;
            case ("Fasculto"):
                calibrateFascultoTrap();
                break;
        }
        btnBack.gameObject.SetActive(false);
    }
    void delayTrapMenu()
    {
        simpleDialogue("Nach wievielen Runden ist die Falle scharf?", 60);
        threeButtons();
        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 300);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(+150, -400);
        actionsTextField.gameObject.SetActive(true);
        actionsTextField.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        actionsTextField.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, -400);
        actionsTextField.fontSize = 130;
        actionsTextField.text = "" + delayedTurns;
        btnOneText.text = "+";
        btnTwoText.text = "Falle legen";
        btnThreeText.text = "-";
        btnOne.onClick.AddListener(btnDelayedTurnUp);
        btnThree.onClick.AddListener(btnDelayedTurnDown);
        if (delayedTurns == 1)
        {
            btnThree.interactable = false;
        }
    }
    void btnDelayedTurnUp()
    {
        delayedTurns++;
        actionsTextField.text = "" + delayedTurns;
        if (delayedTurns > 1)
        {
            btnThree.interactable = true;
        }
    }
    void btnDelayedTurnDown()
    {
        delayedTurns--;
        if (delayedTurns == 1)
        {
            btnThree.interactable = false;
        }
        actionsTextField.text = "" + delayedTurns;
    }
    void calibrateInfernoTrap()
    {
        delayTrapMenu();
        btnTwo.onClick.AddListener(setInfernoTrap);
    }
    void setInfernoTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        if (GameState.items[GameState.currentTurn].Contains("Bomb"))
        {
            GameState.items[GameState.currentTurn].Remove("Bomb");
        }
        else
        {
            GameState.money[GameState.currentTurn] -= 2;
        }

        GameState.infernoTraps[currentPlace] = delayedTurns;
        addTrueHint();
        setDialogue("Du lässte eine Bombe zurück.");
    }

    void calibrateDrMortifierTrap()
    {
        delayTrapMenu();
        btnTwo.onClick.AddListener(setDrMortifierTrap);
    }
    void setDrMortifierTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        if (GameState.items[GameState.currentTurn].Contains("PetriDish"))
        {
            GameState.items[GameState.currentTurn].Remove("PetriDish");
        }
        else
        {
            GameState.money[GameState.currentTurn] -= 2;
        }
        GameState.items[GameState.currentTurn].Remove("PetriDish");
        GameState.drMortifierTraps[currentPlace] = delayedTurns;
        addTrueHint();
        setDialogue("Du infizierst den Ort mit einer Art von Grippe.");

    }
    void calibratePhantomTrap()
    {
        delayTrapMenu();
        btnTwo.onClick.AddListener(setPhantomTrap);
    }
    void setPhantomTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        if (GameState.items[GameState.currentTurn].Contains("StolenGoods"))
        {
            GameState.items[GameState.currentTurn].Remove("StolenGoods");
        }
        else
        {
            GameState.money[GameState.currentTurn] -= 2;
        }
        GameState.items[GameState.currentTurn].Remove("StolenGoods");
        GameState.phantomTraps[currentPlace] = delayedTurns;
        addTrueHint();
        setDialogue("Du platzierst strategisch Diebesgut und sagst deinen Komplizen zu welchem Zeitpunkt sie dies Melden sollen.");
    }
    void calibrateFascultoTrap()
    {
        delayTrapMenu();
        btnTwo.onClick.AddListener(setFascultoTrap);
    }
    void setFascultoTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        if (GameState.items[GameState.currentTurn].Contains("CursedArtifact"))
        {
            GameState.items[GameState.currentTurn].Remove("CursedArtifact");
        }
        else
        {
            GameState.money[GameState.currentTurn] -= 2;
        }
        GameState.items[GameState.currentTurn].Remove("CursedArtifact");
        GameState.fascultoTraps[currentPlace] = delayedTurns;
        addTrueHint();
        setDialogue("Du hinterlässt ein verfluchtes Artifakt");
    }
    #endregion

    void btnActivateQuestPlaceClick()
    {
        addTrueHint();
        if (GameState.activatedQuestPlaces < 3)
        {
            GameState.lastAction[GameState.currentTurn] = "Questort aktivieren";
            GameState.money[GameState.currentTurn] -= 6;
            GameState.questPlaces.Remove(currentPlace);
            GameState.activatedQuestPlaces++;
            string s = "";

            switch (GameState.criminalRole)
            {
                case "Inferno":
                    switch (currentPlace)
                    {
                        //Armyshop
                        case 11:
                            s = "Du kennst den Besitzer des Army Shops und er führt dich in ein für das normale Publikum nicht zugängliches Zimmer. Dort kannst du dir einige deiner benötigten Materialien besorgen.";
                            break;
                        //ShoppingCenter
                        case 12:
                            s = "Man glaubt gar nicht an was für gefährliches Zeug man als normaler Bürger in einem Baumarkt kommt.";
                            break;
                        //Junk Yard
                        case 13:
                            s = "Für die richtig seltenen Komponenten deiner Bombe durchforstest du einen ganzen Tag lang den Schrottplatz.";
                            break;
                    }
                    break;
                case "Dr.Mortifier":
                    switch (currentPlace)
                    {
                        //ShoppingCenter
                        case 12:
                            s = "Du schleichst dich nach den Öffnungszeiten in eine Apotheke und entwendest das nötige Equipment.";
                            break;
                        //Library
                        case 14:
                            s = "Um sicher zugehen das du deine Bakterienstämme auch wirklich richtig miteinander kreuzt, studierst du einen Tag lang in der Bibliothek medizinische Bücher.";
                            //Laboratory
                            break;
                        case 15:
                            s = "Du brichst in ein das Labor ein, dass gerade für eine Studie eine Lieferung seltenere Bakterienstämme bekommen hat. Du bist nun im Besitze der nötigen Bakterienstämme.";
                            break;

                    }
                    break;
                case "Phantom":
                    switch (currentPlace)
                    {
                        //Internet Cafe
                        case 9:
                            s = "Um nicht zurückverfolgt werden zu können, hackst du dich vom Internet Cafe aus in das Sicherheitsystem deines Zielortes";
                            break;
                        //Army Shop
                        case 11:
                            s = "Für einen gelungenen Einbruch, braucht man gutes Equipment. Im Hinterzimmer des Armee Ladens findest du alles was du brauchst.";
                            break;
                        //Bar
                        case 18:
                            s = "Du triffst dich in der Bar mit deinen Komplizen und ihr besprecht jedes noch so kleine Detail eures Plans.";
                            break;
                    }
                    break;
                case "Fasculto":
                    switch (currentPlace)
                    {
                        //Library
                        case 14:
                            s = "Es ist nicht vielen Bekannt das es in der Bibliothek eine geheime okkulte Abteilung gibt. Du und deine Anhänger wissen natürlich wie man zu dieser gelangt und du schmuggelst heimlich eine Kopie des berüchtigten Nekronomikons hinaus.";
                            break;
                        //Harbor
                        case 17:
                            s = "Um dein Ritual vorzubereiten, betest du am Hafen zu den dunklen Göttern der See.";
                            break;
                        //Bar
                        case 18:
                            s = "Für dein Ritual ist ein Opfer notwendig. Es fällt dir leicht in der Bar eine betrunkene Person in den Unterschlupf deines Kultes zu locken.";
                            break;
                    }
                    break;
            }


            setDialogue(s);
        }
        else
        {
            GameState.lastAction[GameState.currentTurn] = "Verbrechen ausführen";
            if (GameState.criminalRole == "Inferno" || GameState.criminalRole == "Phantom" || GameState.criminalRole == "Fasculto")
            {
                GameState.criminalWin = true;
            }
            else if (GameState.criminalRole == "Dr.Mortifier") 
            {
                GameState.planted = true;
            }
        }
        
    }

    void btnFindHintClick()
    {
        int tempfoundHints= GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]; ;
        GameState.lastAction[GameState.currentTurn] = "Hinweis finden";
        GameState.unsolvedHints[GameState.currentTurn] += GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        GameState.trueUnsolveds[GameState.currentTurn] += GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        if (tempfoundHints > 0)
        {
            setDialogue("Du schaust dich genauer um, und findes " + tempfoundHints + " Hinweise, die zum Verbrecher führen könnten.");     
        }
        else
        {
            setDialogue("Du schaust dich genauer um, findest aber nicht was auf den Verbrecher hinweisen könnte.");
        }
    }

    void btnFalseHintClick()
    {
        GameState.lastAction[GameState.currentTurn] = "falscher Hinweis";
        addFalseHint();
        setDialogue("Du platzierst einen falschen Hinweis.");
    }

    //@TODO add description for all places
    #region placeactions
    void btnPlaceOptionClick()
    {
        btnBack.gameObject.SetActive(true);
        switch (currentPlace)
        {
            case 1:
                mainsquareAction();
                break;
            case 2:
                parkAction();
                break;
            case 3:
                hospitalAction();
                break;
            case 4:
                bankAction();
                break;
            case 5:
                parliamentAction();
                break;
            case 6:
                cemetaryAction();
                break;
            case 7:
                prisonAction();
                break;
            case 8:
                casinoAction();
                break;
            case 9:
                internetcafeAction();
                break;
            case 10:
                trainstationAction();
                break;
            case 11:
                armyshopAction();
                break;
            case 12:
                shoppingcenterAction();
                break;
            case 13:
                junkyardAction();
                break;
            case 14:
                libraryAction();
                break;
            case 15:
                laboratoryAction();
                break;
            case 16:
                italienrestaurantAction();
                break;
            case 17:
                harborAction();
                break;
            case 18:
                barAction();
                break;
        }
    }
    void libraryAction()
    {
        oneButton();
        btnOneText.text = "Hinweis entschlüsseln";
        btnOne.onClick.AddListener(solveHint);
    }
    void laboratoryAction()
    {
        libraryAction();
    }
    void solveHint()
    {
        int tempUnsolvedHints= GameState.unsolvedHints[GameState.currentTurn];
        GameState.trueSolveds[GameState.currentTurn] += GameState.trueUnsolveds[GameState.currentTurn];
        GameState.solvedHints[GameState.currentTurn] += GameState.unsolvedHints[GameState.currentTurn];
        GameState.trueUnsolveds[GameState.currentTurn] = 0;
        GameState.unsolvedHints[GameState.currentTurn] = 0;
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";

        if (checkForFact())
        {
            if (tempUnsolvedHints == 1)
            {
                setDialogue("Du hast einen Hinweis entschlüsselt und hast dadurch eine wichtige Information herausfinden können.");
            }
            else
            {
                setDialogue("Du hast " + tempUnsolvedHints + " Hinweise entschlüsselt und hast dadurch eine wichtige Information herausfinden können.");
            }
            
        }
        else
        {
            if (tempUnsolvedHints == 1)
            {
                setDialogue("Du hast einen Hinweis entschlüsselt.");
            }
            else
            {
                setDialogue("Du hast " + tempUnsolvedHints + " Hinweise entschlüsselt.");
            }
            
        }
    }

    void mainsquareAction()
    {
        oneButton();
        btnOneText.text = "Geld verdienen";
        btnOne.onClick.AddListener(earnMoney);

    }
    void earnMoney()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        if (GameState.items[GameState.currentTurn].Contains("Calculator"))
        {
            GameState.money[GameState.currentTurn] += 8;
            setDialogue("Dank deines Taschenrechners konntest du 8$ verdienen.");
        }
        else
        {
            GameState.money[GameState.currentTurn] += 6;
            setDialogue("Du hast 6$ verdient.");
        }
        
    }
    void parkAction()
    {
        oneButton();
        btnOneText.text = "Obdachlose befragen";
        btnOne.onClick.AddListener(btnAskHomeless);

    }
    void btnAskHomeless()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue("Dein Obdachlosennetzwerk berichtet dir, dass der Verbrecher schon" + GameState.activatedQuestPlaces + "/3 seiner Zwischenziele erreicht hat.");
    }
    void hospitalAction()
    {
        threeButtons();
        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(250, -400);
        actionsTextField.gameObject.SetActive(true);
        actionsTextField.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
        actionsTextField.GetComponent<RectTransform>().anchoredPosition = new Vector2(-250, -400);
        actionsTextField.fontSize = 100;
        actionsTextField.text = "Stadtplatz";
        btnOneText.text = "+";
        btnTwoText.text = "Quarantäne";
        btnThreeText.text = "-";
        btnOne.onClick.AddListener(btnPlaceUp);
        btnTwo.onClick.AddListener(btnQuarantine);
        btnThree.onClick.AddListener(btnPlaceDown);
        simpleDialogue("Welcher Ort soll unter Quarantäne gestellt werden?", 60);
    }
    void btnQuarantine()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähgikeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        string place = "";
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                GameState.quarantined[1] = 3;
                place = "den Stadtplatz";
                break;
            case "Park":
                GameState.quarantined[2] = 3;
                place = "den Park";
                break;
            case "Krankenhaus":
                GameState.quarantined[3] = 3;
                place = "das Krankenhaus";
                break;
            case "Bank":
                GameState.quarantined[4] = 3;
                place = "die Bank";
                break;
            case "Parlament":
                GameState.quarantined[5] = 3;
                place = "das Parlament";
                break;
            case "Friedhof":
                GameState.quarantined[6] = 3;
                place = "den Friedhof";
                break;
            case "Gefängnis":
                GameState.quarantined[7] = 3;
                place = "das Gefängnis";
                break;
            case "Kasino":
                GameState.quarantined[8] = 3;
                place = "das Kasino";
                break;
            case "Internet Cafe":
                GameState.quarantined[9] = 3;
                place = "das Internet Cafe";
                break;
            case "Bahnhof":
                GameState.quarantined[10] = 3;
                place = "den Bahnhof";
                break;
            case "Armee Laden":
                GameState.quarantined[11] = 3;
                place = "den Armee Laden";
                break;
            case "Shopping Center":
                GameState.quarantined[12] = 3;
                place = "das Shopping Center";
                break;
            case "Schrottplatz":
                GameState.quarantined[13] = 3;
                place = "den Schrottplatz";
                break;
            case "Bibliothek":
                GameState.quarantined[14] = 3;
                place = "die Bibliothek";
                break;
            case "Labor":
                GameState.quarantined[15] = 3;
                place = "das Labor";
                break;
            case "Italiener":
                GameState.quarantined[16] = 3;
                place = "den Italiener";
                break;
            case "Hafen":
                GameState.quarantined[17] = 3;
                place = "den Hafen";
                break;
            case "Bar":
                GameState.quarantined[18] = 3;
                place = "die Bar";
                break;
        }
        setDialogue("Du hast " + place + " unter Quarantäne gestellt");
    }
    void bankAction()
    {
        playerButtons();
        btnOne.onClick.AddListener(btnPlayerOneTransaction);
        btnTwo.onClick.AddListener(btnPlayerTwoTransaction);
        btnThree.onClick.AddListener(btnPlayerThreeTransaction);
        btnFour.onClick.AddListener(btnPlayerFourTransaction);
        btnFive.onClick.AddListener(btnPlayerFiveTransaction);
        btnSix.onClick.AddListener(btnPlayerSixTransaction);
        simpleDialogue("Wählen einen Spieler", 70);
    }
    void btnPlayerOneTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(0) + "s letzte Transaktion war: " + GameState.lastTransaction[0]);
    }
    void btnPlayerTwoTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(1) + "s letzte Transaktion war: " + GameState.lastTransaction[1]);
    }
    void btnPlayerThreeTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(2) + "s letzte Transaktion war: " + GameState.lastTransaction[2]);
    }
    void btnPlayerFourTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(3) + "s letzte Transaktion war: " + GameState.lastTransaction[3]);
    }
    void btnPlayerFiveTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(4) + "s letzte Transaktion war: " + GameState.lastTransaction[4]);
    }
    void btnPlayerSixTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(5) + "s letzte Transaktion war: " + GameState.lastTransaction[5]);
    }

    void parliamentAction()
    {
        playerButtons();
        btnOne.onClick.AddListener(btnPlayerOneAction);
        btnTwo.onClick.AddListener(btnPlayerTwoAction);
        btnThree.onClick.AddListener(btnPlayerThreeAction);
        btnFour.onClick.AddListener(btnPlayerFourAction);
        btnFive.onClick.AddListener(btnPlayerFiveAction);
        btnSix.onClick.AddListener(btnPlayerSixAction);
        simpleDialogue("Wählen einen Spieler", 70);
    }
    void btnPlayerOneAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(0) + "s letzte Aktion war: " + GameState.lastAction[0]);
    }
    void btnPlayerTwoAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(1) + "s letzte Aktion war: " + GameState.lastAction[1]);
    }
    void btnPlayerThreeAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(2) + "s letzte Aktion war: " + GameState.lastAction[2]);
    }
    void btnPlayerFourAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(3) + "s letzte Aktion war: " + GameState.lastAction[3]);
    }
    void btnPlayerFiveAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(4) + "s letzte Aktion war: " + GameState.lastAction[4]);
    }
    void btnPlayerSixAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(translateName(5) + "s letzte Aktion war: " + GameState.lastAction[5]);
    }

    void cemetaryAction()
    {
        oneButton();
        btnOneText.text = "Seance";
        btnOne.onClick.AddListener(btnSeance);

    }
    void btnSeance()
    {
        string s = "Die Geister teilen dir mit,dass sich sich scharfe Fallen an den Orten:";
        bool noTraps = true;
        for (int i = 0; i < 18; i++)
        {
            if (GameState.activeTraps[i] != "Safe")
            {
                s += (" " + translatePlace(i));
                noTraps = false;
            }
        }
        if (noTraps)
        {
            s = "Die Geister teilen dir mit,dass sich keine scharfe Fallen in der Stadt befinden.";
        }
        else
        {
            s += " befinden.";
        }
        
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        setDialogue(s);
    }

    void prisonAction()
    {
        oneButton();
        btnOneText.text = "Kriminalstudie";
        btnOne.onClick.AddListener(btnCriminalStudy);

    }
    void btnCriminalStudy()
    {
        GameState.skillUsed[GameState.currentTurn] = true;
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                GameState.notFoundFalse[GameState.currentTurn][i, j] = 0;
            }
        }
        setDialogue("Deine Studie ermöglicht es dir bereits vorhandene falsche Hinweise als solche zu durchschauen.");
    }

    void casinoAction()
    {
        threeButtons();
        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(700, 300);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(+150, -400);
        actionsTextField.gameObject.SetActive(true);
        actionsTextField.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        actionsTextField.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, -400);
        actionsTextField.fontSize = 130;
        actionsTextField.text = "" + currentBet;
        btnOneText.text = "+";
        btnTwoText.text = "Einsatz";
        btnThreeText.text = "-";
        btnOne.onClick.AddListener(btnCasinoBetUp);
        btnTwo.onClick.AddListener(btnCasinoBet);
        btnThree.onClick.AddListener(btnCasinoBetDown);
        if (currentBet == 0)
        {
            btnThree.interactable = false;
        }
        if (currentBet == GameState.money[GameState.currentTurn])
        {
            btnOne.interactable = false;
        }
        simpleDialogue("Wieviel setzt du?", 70);
    }
    void btnCasinoBetUp()
    {
        currentBet++;
        if (currentBet == 0)
        {
            btnThree.interactable = false;
        }
        if (currentBet == GameState.money[GameState.currentTurn])
        {
            btnOne.interactable = false;
        }
        actionsTextField.text = "" + currentBet;
       
    }
    void btnCasinoBetDown()
    {
        currentBet--;
        if (currentBet == 0)
        {
            btnThree.interactable = false;
        }
        if (currentBet == GameState.money[GameState.currentTurn])
        {
            btnOne.interactable = false;
        }
        actionsTextField.text = "" + currentBet;
    }
    void btnCasinoBet()
    {
        System.Random rn = new System.Random();
        int rand = rn.Next(0, 100);
        GameState.lastTransaction[GameState.currentTurn] = "Kasino Wette";
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        if (rand < 50)
        {
            GameState.money[GameState.currentTurn] += currentBet;
            setDialogue("Du hast" + currentBet + "$ gewonnen!");
        }
        else
        { 
            GameState.money[GameState.currentTurn] -= currentBet;
            setDialogue("Du hast" + currentBet + "$ verloren!");
        }
    }

    void internetcafeAction()
    {
        twoButtons();
        btnOneText.text = "Geld verdienen";
        btnTwoText.text = "fremde Falle kaufen";
        btnTwo.interactable = false;
        btnOne.onClick.AddListener(earnMoney);
        btnTwo.onClick.AddListener(btnBuyTrap);
        if (GameState.criminal == GameState.roles[GameState.currentTurn])
        {
            if (GameState.money[GameState.currentTurn] >= 2)
            {
                btnTwo.interactable = true;
            }
        }
    }
    void btnBuyTrap()
    {
        fourButtons();
        btnOneText.text = "Bombe";
        btnTwoText.text = "Petrischale";
        btnThreeText.text = "Diebesgut";
        btnFourText.text = "Verfluchtes Artifakt";
        btnOne.onClick.AddListener(btnBuyingInfernoTrap);
        btnOne.onClick.AddListener(btnBuyingDrMortifierTrap);
        btnOne.onClick.AddListener(btnBuyingPhantomTrap);
        btnOne.onClick.AddListener(btnBuyingFascultoTrap);
        simpleDialogue("Welche Falle willst du kaufen?",60);
    }
    void btnBuyingInfernoTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("Bomb");
        addTrueHint();
        setDialogue("Du hast dir eine Bombe gekauft.");
    }
    void btnBuyingDrMortifierTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("PetriDish");
        addTrueHint();
        endTurn();
        setDialogue("Du hast dir eine Petrischale gekauft.");
    }
    void btnBuyingPhantomTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("StolenGoods");
        addTrueHint();
        setDialogue("Du hast dir Diebesgut gekauft.");
    }
    void btnBuyingFascultoTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("CursedArtifact");
        addTrueHint();
        setDialogue("Du hast dir ein verfluchtes Artifakt gekauft.");
    }


    void trainstationAction()
    {
        threeButtons();
        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(250, -400);
        actionsTextField.gameObject.SetActive(true);
        actionsTextField.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 300);
        actionsTextField.GetComponent<RectTransform>().anchoredPosition = new Vector2(-250, -400);
        actionsTextField.fontSize = 100;
        actionsTextField.text = "Stadtplatz";
        btnOneText.text = "+";
        btnTwoText.text = "Abfahrt";
        btnThreeText.text = "-";
        btnOne.onClick.AddListener(btnPlaceUp);
        btnTwo.onClick.AddListener(btnTrainstationTravel);
        btnThree.onClick.AddListener(btnPlaceDown);
        if (GameState.money[GameState.currentTurn] < 2)
        {
            btnTwo.interactable = false;
        }
        simpleDialogue("Wo fährst du hin?",70);
    }
    void btnPlaceDown()
    {
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                actionsTextField.text = "Park";
                break;
            case "Park":
                actionsTextField.text = "Krankenhaus";
                break;
            case "Krankenhaus":
                actionsTextField.text = "Bank";
                break;
            case "Bank":
                actionsTextField.text = "Parlament";
                break;
            case "Parlament":
                actionsTextField.text = "Friedhof";
                break;
            case "Friedhof":
                actionsTextField.text = "Gefängnis";
                break;
            case "Gefängnis":
                actionsTextField.text = "Kasino";
                break;
            case "Kasino":
                actionsTextField.text = "Internet Cafe";
                break;
            case "Internet Cafe":
                actionsTextField.text = "Bahnhof";
                break;
            case "Bahnhof":
                actionsTextField.text = "Armee Laden";
                break;
            case "Armee Laden":
                actionsTextField.text = "Shopping Center";
                break;
            case "Shopping Center":
                actionsTextField.text = "Schrottplatz";
                break;
            case "Schrottplatz":
                actionsTextField.text = "Bibliothek";
                break;
            case "Bibliothek":
                actionsTextField.text = "Labor";
                break;
            case "Labor":
                actionsTextField.text = "Italiener";
                break;
            case "Italiener":
                actionsTextField.text = "Hafen";
                break;
            case "Hafen":
                actionsTextField.text = "Bar";
                break;
            case "Bar":
                actionsTextField.text = "Stadtplatz";
                break;
        }
    }
    void btnPlaceUp()
    {
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                actionsTextField.text = "Bar";
                break;
            case "Park":
                actionsTextField.text = "Stadtplatz";
                break;
            case "Krankenhaus":
                actionsTextField.text = "Park";
                break;
            case "Bank":
                actionsTextField.text = "Krankenhaus";
                break;
            case "Parlament":
                actionsTextField.text = "Bank";
                break;
            case "Friedhof":
                actionsTextField.text = "Parlament";
                break;
            case "Gefängnis":
                actionsTextField.text = "Friedhof";
                break;
            case "Kasino":
                actionsTextField.text = "Gefängnis";
                break;
            case "Internet Cafe":
                actionsTextField.text = "Kasino";
                break;
            case "Bahnhof":
                actionsTextField.text = "Internet Cafe";
                break;
            case "Armee Laden":
                actionsTextField.text = "Bahnhof";
                break;
            case "Shopping Center":
                actionsTextField.text = "Armee Laden";
                break;
            case "Schrottplatz":
                actionsTextField.text = "Shopping Center";
                break;
            case "Bibliothek":
                actionsTextField.text = "Schrottplatz";
                break;
            case "Labor":
                actionsTextField.text = "Bibliothek";
                break;
            case "Italiener":
                actionsTextField.text = "Labor";
                break;
            case "Hafen":
                actionsTextField.text = "Italiener";
                break;
            case "Bar":
                actionsTextField.text = "Hafen";
                break;
        }
    }
    void btnTrainstationTravel()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Zugticket";
        GameState.money[GameState.currentTurn] -= 2;
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                GameState.currentPlace[GameState.currentTurn] = findPosition(1);
                setDialogue("Du hast einen Zug zum Stadtplatz genommen");
                break;
            case "Park":
                GameState.currentPlace[GameState.currentTurn] = findPosition(2);
                setDialogue("Du hast einen Zug zum Park genommen");
                break;
            case "Krankenhaus":
                GameState.currentPlace[GameState.currentTurn] = findPosition(3);
                setDialogue("Du hast einen Zug zum Krankenhaus genommen");
                break;
            case "Bank":
                GameState.currentPlace[GameState.currentTurn] = findPosition(4);
                setDialogue("Du hast einen Zug zur Bank genommen");
                break;
            case "Parlament":
                GameState.currentPlace[GameState.currentTurn] = findPosition(5);
                setDialogue("Du hast einen Zug zum Parlament genommen");
                break;
            case "Friedhof":
                GameState.currentPlace[GameState.currentTurn] = findPosition(6);
                setDialogue("Du hast einen Zug zum Friedhof genommen");
                break;
            case "Gefängnis":
                GameState.currentPlace[GameState.currentTurn] = findPosition(7);
                setDialogue("Du hast einen Zug zum Gefängnis genommen");
                break;
            case "Kasino":
                GameState.currentPlace[GameState.currentTurn] = findPosition(8);
                setDialogue("Du hast einen Zug zum Kasino genommen");
                break;
            case "Internet Cafe":
                GameState.currentPlace[GameState.currentTurn] = findPosition(9);
                setDialogue("Du hast einen Zug zum Internet Cafe genommen");
                break;
            case "Bahnhof":
                GameState.currentPlace[GameState.currentTurn] = findPosition(10);
                setDialogue("Du hast einen Zug zum Bahnhof genommen");
                break;
            case "Armee Laden":
                GameState.currentPlace[GameState.currentTurn] = findPosition(11);
                setDialogue("Du hast einen Zug zum Armee Laden genommen");
                break;
            case "Shopping Center":
                GameState.currentPlace[GameState.currentTurn] = findPosition(12);
                setDialogue("Du hast einen Zug zum Shopping Center genommen");
                break;
            case "Schrottplatz":
                GameState.currentPlace[GameState.currentTurn] = findPosition(13);
                setDialogue("Du hast einen Zug zum Schrottplatz genommen");
                break;
            case "Bibliothek":
                GameState.currentPlace[GameState.currentTurn] = findPosition(14);
                setDialogue("Du hast einen Zug zur Bibliothek genommen");
                break;
            case "Labor":
                GameState.currentPlace[GameState.currentTurn] = findPosition(15);
                setDialogue("Du hast einen Zug zum Labor genommen");
                break;
            case "Italiener":
                GameState.currentPlace[GameState.currentTurn] = findPosition(16);
                setDialogue("Du hast einen Zug zum Italiener genommen");
                break;
            case "Hafen":
                GameState.currentPlace[GameState.currentTurn] = findPosition(17);
                setDialogue("Du hast einen Zug zum Hafen genommen");
                break;
            case "Bar":
                GameState.currentPlace[GameState.currentTurn] = findPosition(18);
                setDialogue("Du hast einen Zug zur Bar genommen");
                break;
        }
        endTurn();
    }

    void armyshopAction()
    {
        twoButtons();
        btnOneText.text = "Schutzweste";
        btnTwoText.text = "Permanenter Schutz";
        btnOne.onClick.AddListener(btnBuyProtectiveVest);
        btnTwo.onClick.AddListener(btnBuyPermanentProtection);
        if (GameState.money[GameState.currentTurn] < 6)
        {
            btnOne.interactable = false;
        }
        if (GameState.money[GameState.currentTurn] < 15)
        {
            btnTwo.interactable = false;
        }
        simpleDialogue("Welche Art von Schutz?", 60);
    }
    void btnBuyProtectiveVest()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Schutzweste";
        GameState.money[GameState.currentTurn] -= 6;
        GameState.items[GameState.currentTurn].Add("ProtectiveVest");
        setDialogue("Du hast dir eine Schutzweste gekauft.");
    }
    void btnBuyPermanentProtection()
    {
        fourButtons();
        btnOneText.text = "feuerfester Mantel";
        btnTwoText.text = "Gasmaske";
        btnThreeText.text = "Bodycam";
        btnFourText.text = "Talisman";
        btnOne.onClick.AddListener(btnBuyBodycam);
        btnTwo.onClick.AddListener(btnBuyGasmask);
        btnThree.onClick.AddListener(btnBuyBodycam);
        btnFour.onClick.AddListener(btnBuyTalisman);
        simpleDialogue("Welche Art von permanenten Schutz?", 60);
    }
    void btnBuyFireProofCoat()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Feuerfester Mantel";
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("FireProofCoat");
        setDialogue("Du hast dir einen feuerfesten Mantel gekauft.");
    }
    void btnBuyGasmask()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Gasmaske";
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Gasmask");
        setDialogue("Du hast dir einen Mantel gekauft.");
    }
    void btnBuyBodycam()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Bodycam";
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Bodycam");
        setDialogue("Du hast dir eine Bodycam gekauft.");
    }
    void btnBuyTalisman()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Talisman";
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Talisman");
        setDialogue("Du hast dir einen Talisman gekauft.");
    }

    void shoppingcenterAction()
    {
        sixButtons();
        btnOneText.text = "Turnschuhe";
        btnTwoText.text = "Fingerabdruckset";
        btnThreeText.text = "Energy Drink";
        btnFourText.text = "Taschenrechner";
        btnFiveText.text = "Whiskey";
        btnSixText.text = "Zufallsfalle";

        btnOne.onClick.AddListener(btnBuyTrainers);
        btnTwo.onClick.AddListener(btnBuyFingerprintKit);
        btnThree.onClick.AddListener(btnBuyEnergyDrink);
        btnFour.onClick.AddListener(btnBuyCalculator);
        btnFive.onClick.AddListener(btnBuyWhiskey);
        btnSix.onClick.AddListener(btnBuyRandomTrap);


        if (!(GameState.criminal == GameState.roles[GameState.currentTurn]))
        {
            btnSix.interactable = false;
        }
        if (GameState.money[GameState.currentTurn] < 8)
        {
            btnFour.interactable = false;
            btnFive.interactable = false;
        }
        if (GameState.money[GameState.currentTurn] < 4)
        {
            btnTwo.interactable = false;
        }
        if (GameState.money[GameState.currentTurn] < 3)
        {
            btnThree.interactable = false;
        }
        if (GameState.money[GameState.currentTurn] < 2)
        {
            btnSix.interactable = false;
            btnOne.interactable = false;
        }
        simpleDialogue("Was willst du kaufen?",60);
    }
    void btnBuyTrainers()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Turnschuhe";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("Trainers");
        setDialogue("Du hast dir Turnschuhe gekauft.");
    }
    void btnBuyFingerprintKit()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Fingerabdruckset";
        GameState.money[GameState.currentTurn] -= 4;
        GameState.items[GameState.currentTurn].Add("FingerprintKit");
        setDialogue("Du hast dir ein Fingerabdruckset gekauft.");
    }
    void btnBuyEnergyDrink()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Energy Drink";
        GameState.money[GameState.currentTurn] -= 3;
        GameState.items[GameState.currentTurn].Add("EnergyDrink");
        setDialogue("Du hast dir einen Energy Drink gekauft.");
    }
    void btnBuyCalculator()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Taschenrechner";
        GameState.money[GameState.currentTurn] -= 8;
        GameState.items[GameState.currentTurn].Add("Calculator");
        setDialogue("Du hast dir einen Taschenrechner gekauft.");
    }
    void btnBuyWhiskey()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Whiskey";
        GameState.money[GameState.currentTurn] -= 8;
        GameState.items[GameState.currentTurn].Add("Whiskey");
        setDialogue("Du hast dir eine Flasche Whiskey gekauft.");
    }
    void btnBuyRandomTrap()
    {
        System.Random rn = new System.Random();
        int rand = rn.Next(0, 3);
        switch (rand)
        {
            case 0:
                btnBuyingInfernoTrap();
                break;
            case 1:
                btnBuyingDrMortifierTrap();
                break;
            case 2:
                btnBuyingPhantomTrap();
                break;
            case 3:
                btnBuyingFascultoTrap();
                break;
        }
    }

    void junkyardAction()
    {
        oneButton();
        btnOneText.text = "Items suchen";
        btnOne.onClick.AddListener(btnJunkyardLookForStuff);
    }
    void btnJunkyardLookForStuff()
    {
        System.Random rn = new System.Random();
        int rand = 0;
        if (GameState.criminal == GameState.roles[GameState.currentTurn])
        {
            rand = rn.Next(0, 17);
        }
        else
        {
            rand = rn.Next(0, 13);
        }
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";

        switch (rand)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                setDialogue("Nichts gefunden");
                break;
            case 5:
                GameState.items[GameState.currentTurn].Add("FireProofCoat");
                setDialogue("Du hast feuerfesten Manel gefunden.");
                break;
            case 6:
                GameState.items[GameState.currentTurn].Add("ProtectiveVest");
                setDialogue("Du hast eine Schutzweste gefunden.");
                break;
            case 7:
                GameState.items[GameState.currentTurn].Add("Gasmask");
                setDialogue("Du hast eine Gasmaske gefunden.");
                break;
            case 8:
                GameState.items[GameState.currentTurn].Add("Talisman");
                setDialogue("Du hast einen Talisman gefunden.");
                break;
            case 9:
                GameState.items[GameState.currentTurn].Add("Trainers");
                setDialogue("Du hast Turnschuhe gefunden.");
                break;
            case 10:
                GameState.items[GameState.currentTurn].Add("FingerprintKit");
                setDialogue("Du hast ein Fingerabdruckset gefunden.");
                break;
            case 11:
                GameState.items[GameState.currentTurn].Add("EnergyDrink");
                setDialogue("Du hast einen Energy Drink gefunden.");
                break;
            case 12:
                GameState.items[GameState.currentTurn].Add("Calculator");
                setDialogue("Du hast einen Taschenrechner gefunden.");
                break;
            case 13:
                GameState.items[GameState.currentTurn].Add("Whiskey");
                setDialogue("Du hast eine Flasche Whiskey gefunden.");
                break;
            case 14:
                GameState.items[GameState.currentTurn].Add("Bomb");
                setDialogue("Du hast eine Bombe gefunden.");
                break;
            case 15:
                GameState.items[GameState.currentTurn].Add("PetriDish");
                setDialogue("Du hast eine Petrischale gefunden.");
                break;
            case 16:
                GameState.items[GameState.currentTurn].Add("StolenGoods");
                setDialogue("Du hast Diebesgut gefunden.");
                break;
            case 17:
                GameState.items[GameState.currentTurn].Add("CursedArtifact");
                setDialogue("Du hast ein verfluchtes Artifakt gefunden.");
                break;
        }
    }
    void italienrestaurantAction()
    {
        fourButtons();
        btnOneText.text = "1 Geld";
        btnTwoText.text = "2 Geld";
        btnThreeText.text = "3 Geld";
        btnFourText.text = "4 Geld";
        btnOne.onClick.AddListener(btnItalienTwentyPercentChance);
        btnTwo.onClick.AddListener(btnItalienThirtyPercentChance);
        btnThree.onClick.AddListener(btnItalienFiftyPercentChance);
        btnFour.onClick.AddListener(btnItalienSixtyPercentChance);
        switch (GameState.money[GameState.currentTurn])
        {
            case 1:
                btnTwo.interactable = false;
                btnThree.interactable = false;
                btnFour.interactable = false;
                break;
            case 2:
                btnThree.interactable = false;
                btnFour.interactable = false;
                break;
            case 3:
                btnFour.interactable = false;
                break;
        }
        simpleDialogue("Wieviel zahlst du für deine Spaghetti?", 60);
    }
    void btnItalienTwentyPercentChance()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
        GameState.money[GameState.currentTurn]--;
        chanceToGetTrueHint(2);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void btnItalienThirtyPercentChance()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
        GameState.money[GameState.currentTurn] -= 2;
        chanceToGetTrueHint(3);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void btnItalienFiftyPercentChance()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
        GameState.money[GameState.currentTurn] -= 3;
        chanceToGetTrueHint(5);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void btnItalienSixtyPercentChance()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
        GameState.money[GameState.currentTurn] -= 4;
        chanceToGetTrueHint(6);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void harborAction()
    {
        twoButtons();
        btnOneText.text = "Hinweis - 5 Geld";
        btnTwoText.text = "fremde Falle kaufen";
        btnOne.onClick.AddListener(btnHarborHint);
        btnTwo.onClick.AddListener(btnBuyTrap);
        if (GameState.money[GameState.currentTurn] < 5)
        {
            btnOne.interactable = false;
        }
        if (GameState.criminalRole != GameState.roles[GameState.currentTurn])
        {
            btnTwo.interactable = false;
        }
        else
        {
            simpleDialogue("Was willst du machen?", 60);
        }
    }
    void btnHarborHint()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Hafenequipment\"";
        GameState.money[GameState.currentTurn] -= 5;
        chanceToGetTrueHint(5);
        setDialogue("Du hast den Hafenarbeitern etwas Equipment abgekauft und dabei einige interessanten Dinge erfahren. Du bist dir aber nicht sicher ob sie dir nicht vielleicht nur Seemannsgarn erzählt haben.");
    }
    void barAction()
    {
        oneButton();
        btnOneText.text = "Ein Bier trinken";
        btnOne.onClick.AddListener(btnBarHint);
    }
    void btnBarHint()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Billiger Vodka";
        GameState.money[GameState.currentTurn] -= 2;
        chanceToGetTrueHint(4);

        System.Random rn = new System.Random();
        int randOne = rn.Next(0, 6);
        int randTwo = rn.Next(0, 7);
        while (GameState.board[randOne, randTwo] == 0)
        {
            randOne = rn.Next(0, 6);
            randTwo = rn.Next(0, 7);
        }
        GameState.currentPlace[GameState.currentTurn][0] = randOne;
        GameState.currentPlace[GameState.currentTurn][1] = randTwo;
        string place = "";
        switch (translatePlace(GameState.board[GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]))
        {
            case "Stadtplatz":
                place = "am Stadtplatz";
                break;
            case "Park":
                place = "im Park";
                break;
            case "Krankenhaus":
                place = "im Krankenhaus";
                break;
            case "Bank":
                place = "in der Bank";
                break;
            case "Parlament":
                place = "im Parlament";
                break;
            case "Friedhof":
                place = "im Friedhof";
                break;
            case "Gefängnis":
                place = "im Gefängnis";
                break;
            case "Kasino":
                place = "im Kasino";
                break;
            case "Internet Cafe":
                place = "im Internet Cafe";
                break;
            case "Bahnhof":
                place = "am Bahnhof";
                break;
            case "Armee Laden":
                place = "im Armee Laden";
                break;
            case "Shopping Center":
                place = "im Shopping Center";
                break;
            case "Schrottplatz":
                place = "im Schrottplatz";
                break;
            case "Bibliothek":
                place = "in der Bibliothek";
                break;
            case "Labor":
                place = "im Labor";
                break;
            case "Italiener":
                place = "beim Italiener";
                break;
            case "Hafen":
                place = "am Hafen";
                break;
            case "Bar":
                place = "in der Bar";
                break;
        }
        setDialogue("Du bist auf ein Bier in die Bar gegangen. Am nächsten Morgen bis du " + place + " aufgewacht. Die anderen Barbesucher haben dir eine wichtigen Hinweis gegeben aber du kannst dich nicht mehr genau daran erinnern.");
    }

    #endregion

    #region manipulation
    void btnManipulationClick()
    {
        btnBack.gameObject.SetActive(true);
        Debug.Log(GameState.roles[GameState.currentTurn] + " is manipulating");
        addTrueHint();
        twoButtons();
        btnOneText.text = "Bewegung";
        btnTwoText.text = "Hinweis";
        btnOne.onClick.AddListener(btnManipulationMovementClick);
        btnTwo.onClick.AddListener(btnManipulationHintClick);
        simpleDialogue("Welche Art von Manipulation?",60);
    }
    void btnManipulationMovementClick()
    {
        simpleDialogue("Wähle einen Spieler aus.", 80);
        playerButtons();
        firstMovementManipulation = true;
        btnOne.onClick.AddListener(btnPlayerOneClickManipulationMovement);
        btnTwo.onClick.AddListener(btnPlayerTwoClickManipulationMovement);
        btnThree.onClick.AddListener(btnPlayerThreeClickManipulationMovement);
        btnFour.onClick.AddListener(btnPlayerFourClickManipulationMovement);
        btnFive.onClick.AddListener(btnPlayerFiveClickManipulationMovement);
        btnSix.onClick.AddListener(btnPlayerSixClickManipulationMovement);

    }


    void btnPlayerOneClickManipulationMovement()
    {
        MovementManipulation(0);
    }
    void btnPlayerTwoClickManipulationMovement()
    {
        MovementManipulation(1);
    }
    void btnPlayerThreeClickManipulationMovement()
    {
        MovementManipulation(2);
    }
    void btnPlayerFourClickManipulationMovement()
    {
        MovementManipulation(3);
    }
    void btnPlayerFiveClickManipulationMovement()
    {
        MovementManipulation(4);
    }
    void btnPlayerSixClickManipulationMovement()
    {
        MovementManipulation(5);
    }

    void MovementManipulation(int player)
    {
        simpleDialogue("Wohin muss "+translateName(player)+" gehen?", 70);
        manipulatedPlayer = player;
        fiveButtons();
        int[] currentPlayerPlace = GameState.currentPlace[player];
        if (currentPlayerPlace[0] > 0)
        {
            if (GameState.quarantined[GameState.board[currentPlayerPlace[0] - 1, currentPlayerPlace[1]]] > 0)
            {
                btnOne.interactable = false;
                btnOneText.fontSize = 50;
                btnOneText.text = "Quarantäne";
            }
            else
            {
                btnOne.interactable = true;
                btnOneText.text = translatePlace(GameState.board[currentPlayerPlace[0] - 1, currentPlayerPlace[1]]);
            }

        }
        else
        {

            btnOne.interactable = false;
            btnOneText.text = "Stadtrand";
        }
        if (currentPlayerPlace[1] < 6)
        {
            if (GameState.quarantined[GameState.board[currentPlayerPlace[0], currentPlayerPlace[1] + 1]] > 0)
            {
                btnTwo.interactable = false;
                btnTwoText.fontSize = 50;
                btnTwoText.text = "Quarantäne";
            }
            else
            {
                btnTwo.interactable = true;
                btnTwoText.text = translatePlace(GameState.board[currentPlayerPlace[0], currentPlayerPlace[1] + 1]);
            }
        }
        else
        {
            btnTwo.interactable = false;
            btnTwoText.text = "Stadtrand";
        }

        if (currentPlayerPlace[0] < 5)
        {
            if (GameState.quarantined[GameState.board[currentPlayerPlace[0] + 1, currentPlayerPlace[1]]] > 0)
            {
                btnThree.interactable = false;
                btnThreeText.fontSize = 50;
                btnThreeText.text = "Quarantäne";
            }
            else
            {
                btnThree.interactable = true;
                btnThreeText.text = translatePlace(GameState.board[currentPlayerPlace[0] + 1, currentPlayerPlace[1]]);
            }
        }
        else
        {
            btnThree.interactable = false;
            btnThreeText.text = "Stadtrand";
        }
        if (currentPlayerPlace[1] > 0)
        {
            if (GameState.quarantined[GameState.board[currentPlayerPlace[0], currentPlayerPlace[1] - 1]] > 0)
            {
                btnFour.interactable = false;
                btnFourText.fontSize = 50;
                btnFourText.text = "Quarantäne";
            }
            else
            {
                btnFour.interactable = true;
                btnFourText.text = translatePlace(GameState.board[currentPlayerPlace[0], currentPlayerPlace[1] - 1]);
            }
        }
        else
        {
            btnFour.interactable = false;
            btnFourText.text = "Stadtrand";
        }

        if (GameState.quarantined[GameState.board[currentPlayerPlace[0], currentPlayerPlace[1]]] > 0)
        {
            btnFive.interactable = false;
            btnFiveText.fontSize = 50;
            btnFiveText.text = "Quarantäne";
        }
        else
        {
            btnFive.interactable = true;
            btnFiveText.text = translatePlace(GameState.board[currentPlayerPlace[0], currentPlayerPlace[1]]);
        }

        btnOne.onClick.AddListener(btnManipulationUp);
        btnTwo.onClick.AddListener(btnManipulationRight);
        btnThree.onClick.AddListener(btnManipulationDown);
        btnFour.onClick.AddListener(btnManipulationLeft);
        btnFive.onClick.AddListener(btnManipulationStay);

    }

    void btnManipulationUp()
    {
        btnBack.gameObject.SetActive(false);
        GameState.currentPlace[manipulatedPlayer][0] -= 1;
        if (firstMovementManipulation && GameState.board[GameState.currentPlace[manipulatedPlayer][0], GameState.currentPlace[manipulatedPlayer][1]] == 0)
        {
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            GameState.lastAction[GameState.currentTurn] = "Manipulation";
            GameState.money[GameState.currentTurn] -= 10;
            firstMovementManipulation = false;
            GameState.isManipulated[manipulatedPlayer] = true;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationRight()
    {
        btnBack.gameObject.SetActive(false);
        GameState.currentPlace[manipulatedPlayer][1] += 1;
        if (firstMovementManipulation && GameState.board[GameState.currentPlace[manipulatedPlayer][0], GameState.currentPlace[manipulatedPlayer][1]] == 0)
        {
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            GameState.lastAction[GameState.currentTurn] = "Manipulation";
            GameState.money[GameState.currentTurn] -= 10;
            firstMovementManipulation = false;
            GameState.isManipulated[manipulatedPlayer] = true;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationDown()
    {
        btnBack.gameObject.SetActive(false);
        GameState.currentPlace[manipulatedPlayer][0] += 1;
        if (firstMovementManipulation && GameState.board[GameState.currentPlace[manipulatedPlayer][0], GameState.currentPlace[manipulatedPlayer][1]] == 0)
        {
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            GameState.lastAction[GameState.currentTurn] = "Manipulation";
            GameState.money[GameState.currentTurn] -= 10;
            firstMovementManipulation = false;
            GameState.isManipulated[manipulatedPlayer] = true;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationLeft()
    {
        btnBack.gameObject.SetActive(false);
        GameState.currentPlace[manipulatedPlayer][1] -= 1;
        if (firstMovementManipulation && GameState.board[GameState.currentPlace[manipulatedPlayer][0], GameState.currentPlace[manipulatedPlayer][1]] == 0)
        {
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            GameState.lastAction[GameState.currentTurn] = "Manipulation";
            GameState.money[GameState.currentTurn] -= 10;
            firstMovementManipulation = false;
            GameState.isManipulated[manipulatedPlayer] = true;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationStay()
    {
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        btnBack.gameObject.SetActive(false);
        GameState.isManipulated[manipulatedPlayer] = true;
        firstMovementManipulation = false;
        GameState.money[GameState.currentTurn] -= 10;
        MovementManipulationDialogue();
    }

    void MovementManipulationDialogue()
    {
        string name = translateName(manipulatedPlayer);
        string place = "";
        int currentPlace = GameState.board[GameState.currentPlace[manipulatedPlayer][0], GameState.currentPlace[manipulatedPlayer][1]];
        if(currentPlace==0|| currentPlace == 14 || currentPlace == 18 || currentPlace == 4)
        {
            place = "zur " + translatePlace(currentPlace);
        }
        else{
            place = "zum " + translatePlace(currentPlace);
        }
        switch (GameState.criminalRole)
        {
            case "Inferno":
                setDialogue("Mit einer ferngesteuerten Bombe hast du " + name + " dazu gezwungen " + place + " zu gehen.");
                break;
            case "Dr.Mortifier":
                setDialogue("Mit einem spezielen Virus hast du " + name + " dazu gezwunden " + place + "zu gehen.");
                break;
            case "Phantom":
                setDialogue("Indem du dich als verlässliche Quelle ausgegeben hast, hast du " + name + " dazu gebracht " + place + " zu gehen");
                break;
            case "Fasculto":
                setDialogue("Mit einer Voodoo Puppe hast du " + name + " dazu gebracht " + place + " zu gehen.");
                break;
        }
    }

    void btnManipulationHintClick()
    {
        simpleDialogue("Wähle einen Spieler aus.", 80);
        playerButtons();
        btnOne.onClick.AddListener(btnPlayerOneClickManipulationHint);
        btnTwo.onClick.AddListener(btnPlayerTwoClickManipulationHint);
        btnThree.onClick.AddListener(btnPlayerThreeClickManipulationHint);
        btnFour.onClick.AddListener(btnPlayerFourClickManipulationHint);
        btnFive.onClick.AddListener(btnPlayerFiveClickManipulationHint);
        btnSix.onClick.AddListener(btnPlayerSixClickManipulationHint);
    }

    void btnPlayerOneClickManipulationHint()
    {
        if (GameState.trueUnsolveds[0] > 0)
        {
            GameState.money[GameState.currentTurn] -= 10;
            GameState.trueUnsolveds[0]--;
            GameState.unsolvedHints[0]--;
        }
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        HintManipulationDialogue(0);
    }
    void btnPlayerTwoClickManipulationHint()
    {
        GameState.money[GameState.currentTurn] -= 10;
        if (GameState.trueUnsolveds[1] > 0)
        {
            GameState.trueUnsolveds[1]--;
            GameState.unsolvedHints[1]--;
        }
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        HintManipulationDialogue(1);
    }
    void btnPlayerThreeClickManipulationHint()
    {
        GameState.money[GameState.currentTurn] -= 10;
        if (GameState.trueUnsolveds[2] > 0)
        {
            GameState.trueUnsolveds[2]--;
            GameState.unsolvedHints[2]--;
        }
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        HintManipulationDialogue(2);
    }
    void btnPlayerFourClickManipulationHint()
    {
        GameState.money[GameState.currentTurn] -= 10;
        if (GameState.trueUnsolveds[3] > 0)
        {
            GameState.trueUnsolveds[3]--;
            GameState.unsolvedHints[3]--;
        }
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        HintManipulationDialogue(3);
    }
    void btnPlayerFiveClickManipulationHint()
    {
        GameState.money[GameState.currentTurn] -= 10;
        if (GameState.trueUnsolveds[4] > 0)
        {
            GameState.trueUnsolveds[4]--;
            GameState.unsolvedHints[4]--;
        }
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        HintManipulationDialogue(4);
    }
    void btnPlayerSixClickManipulationHint()
    {
        GameState.money[GameState.currentTurn] -= 10;
        if (GameState.trueUnsolveds[5] > 0)
        {
            GameState.trueUnsolveds[5]--;
            GameState.unsolvedHints[5]--;
        }
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        HintManipulationDialogue(5);
    }

    void HintManipulationDialogue(int player) {
        string name = translateName(player);

        switch (GameState.criminalRole)
        {
            case "Inferno":
                setDialogue("Mit einer ferngesteuerten Bombe hast du " + name + " dazu gezwungen Beweismaterial zu zerstören.");
                break;
            case "Dr.Mortifier":
                setDialogue("Mit einem spezielen Virus hast du " + name + " dazu gezwunden Beweismaterial zu zerstören.");
                break;
            case "Phantom":
                setDialogue("Indem du dich als verlässliche Quelle ausgegeben hast, hast du " + name + " dazu gebracht Beweismaterial als falsch abzustempeln.");
                break;
            case "Fasculto":
                setDialogue("Mit einer Voodoo Puppe hast du " + name + " dazu gebracht Beweismaterial zu zerstören.");
                break;
        }
    }

    #endregion

    #region Big Trap
    void btnBigTrapClick()
    {
        btnBack.gameObject.SetActive(true);
        
        playerButtons();
        btnOne.onClick.AddListener(btnPlayerOneClickBigTrap);
        btnTwo.onClick.AddListener(btnPlayerTwoClickBigTrap);
        btnThree.onClick.AddListener(btnPlayerThreeClickBigTrap);
        btnFour.onClick.AddListener(btnPlayerFourClickBigTrap);
        btnFive.onClick.AddListener(btnPlayerFiveClickBigTrap);
        btnSix.onClick.AddListener(btnPlayerSixClickBigTrap);

        simpleDialogue("Wähle einen Spieler aus.",80);

        Debug.Log(GameState.roles[GameState.currentTurn] + " used a big Trap");
    }
    void btnPlayerOneClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(0, findTargetPosition(GameState.criminalRole));
        GameState.bigTrapUsed = true;
        addTrueHint();
        bigTrapDialogue(0);
    }
    void btnPlayerTwoClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(1, findTargetPosition(GameState.criminalRole));
        GameState.bigTrapUsed = true;
        addTrueHint();
        bigTrapDialogue(1);
    }
    void btnPlayerThreeClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(2, findTargetPosition(GameState.criminalRole));
        GameState.bigTrapUsed = true;
        addTrueHint();
        bigTrapDialogue(2);
    }
    void btnPlayerFourClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(3, findTargetPosition(GameState.criminalRole));
        GameState.bigTrapUsed = true;
        addTrueHint();
        bigTrapDialogue(3);
    }
    void btnPlayerFiveClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(4, findTargetPosition(GameState.criminalRole));
        GameState.bigTrapUsed = true;
        addTrueHint();
        bigTrapDialogue(4);
    }
    void btnPlayerSixClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(5, findTargetPosition(GameState.criminalRole));
        GameState.bigTrapUsed = true;
        addTrueHint();
        bigTrapDialogue(5);
    }

    void bigTrapDialogue(int player)
    {
        string s = "";
        string name = translateName(player);
        switch (GameState.criminalRole)
        {
            case "Inferno":
                s = "Du hast "+name+" mit einer kleinen Rakete getroffen.";
                break;
            case "Dr.Mortifier":
                s = "Du hast " + name + " mit einer starken Grippe infiziert.";
                break;
            case "Phantom":
                s = "Du hast Diebesgut in der Wohnung von " + name + " platziert.";
                break;
            case "Fasculto":
                s = "Du hast " + name + " mit einem Unglücksfluch belegt und dadurch eine schweren Unfall ausgelöst.";
                break;
        }
        

        setDialogue(s);
    }
    #endregion

    

    //@TODO: Layout for 7 buttons
    #region LayoutFunctions

    void oneButton()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 1000);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -400);

        btnOneText.fontSize = 180;
        btnOne.interactable = true;
    }
    void twoButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 475);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -138);

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 475);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -663);

        btnOneText.fontSize = 150;
        btnTwoText.fontSize = 150;


        btnOne.interactable = true;
        btnTwo.interactable = true;
    }
    void threeButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 300);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50);

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 300);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -400);

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 300);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -750);

        btnOneText.fontSize = 130;
        btnTwoText.fontSize = 130;
        btnThreeText.fontSize = 130;


        btnOne.interactable = true;
        btnTwo.interactable = true;
        btnThree.interactable = true;
    }
    void fourButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);
        btnFour.gameObject.SetActive(true);

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 213);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -6);

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 213);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -269);

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 213);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -531);

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 213);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -793);

        btnOneText.fontSize = 100;
        btnTwoText.fontSize = 100;
        btnThreeText.fontSize = 100;
        btnFourText.fontSize = 100;


        btnOne.interactable = true;
        btnTwo.interactable = true;
        btnThree.interactable = true;
        btnFour.interactable = true;
    }
    void fiveButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);
        btnFour.gameObject.SetActive(true);
        btnFive.gameObject.SetActive(true);

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -50);

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(350, -400);

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0, -750);

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(-350, -400);

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0, -400);

        btnOneText.fontSize = 60;
        btnTwoText.fontSize = 60;
        btnThreeText.fontSize = 60;
        btnFourText.fontSize = 60;
        btnFiveText.fontSize = 60;


        btnOne.interactable = true;
        btnTwo.interactable = true;
        btnThree.interactable = true;
        btnFour.interactable = true;
        btnFive.interactable = true;

    }
    void sixButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);
        btnFour.gameObject.SetActive(true);
        btnFive.gameObject.SetActive(true);
        btnSix.gameObject.SetActive(true);

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 300);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-263, -50);

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 300);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(263, -50);

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 300);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-263, -400);

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 300);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(263, -400);

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 300);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(-263, -750);

        btnSix.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 300);
        btnSix.GetComponent<RectTransform>().anchoredPosition = new Vector2(263, -750);

        btnOneText.fontSize = 75;
        btnTwoText.fontSize = 75;
        btnThreeText.fontSize = 75;
        btnFourText.fontSize = 75;
        btnFiveText.fontSize = 75;
        btnSixText.fontSize = 75;


        btnOne.interactable = true;
        btnTwo.interactable = true;
        btnThree.interactable = true;
        btnFour.interactable = true;
        btnFive.interactable = true;
        btnSix.interactable = true;
    }
    void sevenButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);
        btnFour.gameObject.SetActive(true);
        btnFive.gameObject.SetActive(true);
        btnSix.gameObject.SetActive(true);
        btnSeven.gameObject.SetActive(true);

        btnOne.interactable = true;
        btnTwo.interactable = true;
        btnThree.interactable = true;
        btnFour.interactable = true;
        btnFive.interactable = true;
        btnSix.interactable = true;
        btnSeven.interactable = true;
    }
    void eightButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);
        btnFour.gameObject.SetActive(true);
        btnFive.gameObject.SetActive(true);
        btnSix.gameObject.SetActive(true);
        btnSeven.gameObject.SetActive(true);
        btnEight.gameObject.SetActive(true);

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-263, -6);

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(263, -6);

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-263, -269);

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(263, -269);

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(-263, -531);

        btnSix.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnSix.GetComponent<RectTransform>().anchoredPosition = new Vector2(263, -531);

        btnSeven.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnSeven.GetComponent<RectTransform>().anchoredPosition = new Vector2(-263, -794);

        btnEight.GetComponent<RectTransform>().sizeDelta = new Vector2(475, 213);
        btnEight.GetComponent<RectTransform>().anchoredPosition = new Vector2(263, -794);

        btnOneText.fontSize = 65;
        btnTwoText.fontSize = 65;
        btnThreeText.fontSize = 65;
        btnFourText.fontSize = 65;
        btnFiveText.fontSize = 65;
        btnSixText.fontSize = 65;
        btnSevenText.fontSize = 65;
        btnEightText.fontSize = 65;

        btnOne.interactable = true;
        btnTwo.interactable = true;
        btnThree.interactable = true;
        btnFour.interactable = true;
        btnFive.interactable = true;
        btnSix.interactable = true;
        btnSeven.interactable = true;
        btnEight.interactable = true;
    }
    void disableButtons()
    {


        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);
        btnFour.gameObject.SetActive(true);
        btnFive.gameObject.SetActive(true);
        btnSix.gameObject.SetActive(true);
        btnSeven.gameObject.SetActive(true);
        btnEight.gameObject.SetActive(true);

        btnOne.onClick.RemoveAllListeners();
        btnTwo.onClick.RemoveAllListeners();
        btnThree.onClick.RemoveAllListeners();
        btnFour.onClick.RemoveAllListeners();
        btnFive.onClick.RemoveAllListeners();
        btnSix.onClick.RemoveAllListeners();
        btnSeven.onClick.RemoveAllListeners();
        btnEight.onClick.RemoveAllListeners();

        btnOne.interactable = true;
        btnTwo.interactable = true;
        btnThree.interactable = true;
        btnFour.interactable = true;
        btnFive.interactable = true;
        btnSix.interactable = true;
        btnSeven.interactable = true;
        btnEight.interactable = true;

        btnOne.gameObject.SetActive(false);
        btnTwo.gameObject.SetActive(false);
        btnThree.gameObject.SetActive(false);
        btnFour.gameObject.SetActive(false);
        btnFive.gameObject.SetActive(false);
        btnSix.gameObject.SetActive(false);
        btnSeven.gameObject.SetActive(false);
        btnEight.gameObject.SetActive(false);

        actionsTextField.gameObject.SetActive(false);
    }
    void playerButtons()
    {
        sixButtons();

        btnFour.interactable = false;
        btnFive.interactable = false;
        btnSix.interactable = false;

        btnOneText.text = translateName(0);
        btnTwoText.text = translateName(1);
        btnThreeText.text = translateName(2);
        btnFourText.text = "nicht verfügbar";
        btnFiveText.text = "nicht verfügbar";
        btnSixText.text = "nicht verfügbar";


        switch (GameState.playerCount)
        {
            case 4:
                btnFour.interactable = true;

                btnFourText.text = translateName(3);

                break;
            case 5:
                btnFour.interactable = true;
                btnFive.interactable = true;


                btnFourText.text = translateName(3);
                btnFiveText.text = translateName(4);

                break;
            case 6:
                btnFour.interactable = true;
                btnFive.interactable = true;
                btnSix.interactable = true;

                btnFourText.text = translateName(3);
                btnFiveText.text = translateName(4);
                btnSixText.text = translateName(5);
                break;
        }



    }
    #endregion

    #region Useful functions

    public bool calculateGetAway()
    {
        int distance = 0;
        int[] start = findPosition(GameState.targetPlace);
        int criminalID=-1;
        for (int i = 0; i < GameState.playerCount; i++)
        {
            if (GameState.roles[i] == GameState.criminal)
            {
                criminalID = i;
            }
        }
        int[] end = GameState.currentPlace[criminalID];
        distance += Math.Abs(start[0] - end[0]);
        distance += Math.Abs(start[1] - end[1]);
        return (distance >= 5);
    }

    string translateName(int player)
    {
        string name = "";
        switch (GameState.roles[player])
        {
            case "Doctor":
                name = "Moe McKay";
                break;

            case "Police":
                name = "Felicity Fields";
                break;

            case "Detective":
                name = "Collin Cooper";
                break;

            case "Psychic":
                name = "Olivia Osswald";
                break;

            case "Psychologist":
                name = "Laura Larsen";
                break;

            case "Reporter":
                name = "Eric Edmond";
                break;
        }
        return name;
    }


    void simpleDialogue(string simpleMessage, int fontsize)
    {
        StopCoroutine("SimpleTypeWriter");


        dialoguePanel.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        currentDialogue = simpleMessage;
        dialogueText.fontSize = fontsize;
        dialogueText.text = "";
        StartCoroutine("SimpleTypeWriter");
    }

    IEnumerator SimpleTypeWriter()
    {
        foreach (char c in currentDialogue)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }


    int[] findTargetPosition(string criminalRole)
    {
        int[] targetPosition = new int[2];
        if (criminalRole == "Phantom")
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (GameState.board[i, j] == 7)
                    {
                        targetPosition[0] = i;
                        targetPosition[1] = j;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (GameState.board[i, j] == 3)
                    {
                        targetPosition[0] = i;
                        targetPosition[1] = j;
                    }
                }
            }
        }
        return targetPosition;
    }

    void activatedTrap(int player, int[] targetPosition)
    {
        GameState.money[player] = 0;
        GameState.currentPlace[player] = targetPosition;
        GameState.isDisabled[player] = 2;
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
    void setPlaceImage(int place)
    {
        Sprite pic = street;
        switch (place)
        {
            case 1:
           
                pic = mainsquare;
                break;
            case 2:

                pic = park;
                break;
            case 3:
         
                pic = hospital;
                break;
            case 4:
        
                pic = bank;
                break;
            case 5:

                pic = parliament;
                break;
            case 6:
        
                pic = cementary;
                break;
            case 7:

                pic = prison;
                break;
            case 8:
        
                pic = casino;
                break;
            case 9:
    
                pic = internetcafe;
                break;
            case 10:
   
                pic = trainstation;
                break;
            case 11:
            
                pic = armyshop;
                break;
            case 12:
            
                pic = shoppingcenter;
                break;
            case 13:
       
                pic = junkyard;
                break;
            case 14:
     ;
                pic = library;
                break;
            case 15:
     
                pic = laboratory;
                break;
            case 16:
       
                pic = italienrestaurant;
                break;
            case 17:
     
                pic = harbor;
                break;
            case 18:

                pic = bar;
                break;
        }
        image.sprite = pic;
    }

    void addTrueHint()
    {
        for (int i = 0; i < GameState.playerCount; i++)
        {
            GameState.notFoundTrue[i][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]++;
        }
    }

    void addFalseHint()
    {
        for (int i = 0; i < GameState.playerCount; i++)
        {
            GameState.notFoundFalse[i][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]++;
        }
    }

    void chanceToGetTrueHint(int chance)
    {
        GameState.solvedHints[GameState.currentTurn]++;
        System.Random rn = new System.Random();
        int randomHint = rn.Next(1, 10);
        if (randomHint < chance)
        {
            GameState.trueSolveds[GameState.currentTurn]++;
            checkForFact();
        }
    }

    int[] findPosition(int place)
    {
        int[] position = new int[2];
        for (int i = 0; i<6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (GameState.board[i, j] == place)
                {
                    position[0] = i;
                    position[1] = j;
                }
            }
        }
        return position;
    }

    bool checkForFact()
    {
        
        if (GameState.solvedFacts[GameState.currentTurn] < 3)
        {
            if ((GameState.trueSolveds[GameState.currentTurn] - (GameState.solvedFacts[GameState.currentTurn] * 3)) >= 3)
            {
                System.Random rn = new System.Random();
                int randomFact = rn.Next(0, 3);
                switch (randomFact)
                {
                    case 0:
                        if (GameState.playerFact[GameState.currentTurn] == "")
                        {
                            GameState.playerFact[GameState.currentTurn] = GameState.criminal;
                            GameState.solvedFacts[GameState.currentTurn]++;
                            return true;
                        }
                        else
                        {
                            return checkForFact();
                        }
                    case 1:
                        if (GameState.placeFact[GameState.currentTurn] == "")
                        {
                            GameState.placeFact[GameState.currentTurn] = translatePlace(GameState.targetPlace);
                            GameState.solvedFacts[GameState.currentTurn]++;
                            return true;
                        }
                        else
                        {
                            return checkForFact();
                        }
                    case 2:
                        if (GameState.roleFact[GameState.currentTurn] == "")
                        {
                            GameState.roleFact[GameState.currentTurn] = GameState.criminalRole;
                            GameState.solvedFacts[GameState.currentTurn]++;
                            return true;
                        }
                        else
                        {
                            return checkForFact();
                        }
                }
                return checkForFact();
            }
        }
        return false;
    }

    #endregion
}