using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Place : MonoBehaviour
{

    public Text placeName;
    public Image image;
    public Text actionsTextField;
    public Image actionsTextFieldPanel;

    public Sprite imgStreet_Symbol;
    public Sprite imgMainsquare_Symbol;
    public Sprite imgPark_Symbol;
    public Sprite imgHospital_Symbol;
    public Sprite imgBank_Symbol;
    public Sprite imgParliament_Symbol;
    public Sprite imgCemetary_Symbol;
    public Sprite imgPrison_Symbol;
    public Sprite imgCasino_Symbol;
    public Sprite imgInternetcafe_Symbol;
    public Sprite imgTrainstation_Symbol;
    public Sprite imgArmyshop_Symbol;
    public Sprite imgShoppingcenter_Symbol;
    public Sprite imgJunkyard_Symbol;
    public Sprite imgLibrary_Symbol;
    public Sprite imgLaboratory_Symbol;
    public Sprite imgItalienrestaurant_Symbol;
    public Sprite imgHarbor_Symbol;
    public Sprite imgBar_Symbol;
    public Sprite imgQuarantine_Symbol;
    public Sprite imgEdge_Symbol;


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

    public Sprite mckay;
    public Sprite fields;
    public Sprite cooper;
    public Sprite osswald;
    public Sprite edmond;
    public Sprite larson;

    public Sprite twoByTwo;
    public Sprite twoByThree;
    public Sprite twoByFour;
    public Sprite twoByFive;
    public Sprite twoBySeven;
    public Sprite twoByNine;
    public Sprite threeByThree;
    public Sprite threeByFour;
    public Sprite threeByFive;
    public Sprite threeBySeven;
    public Sprite fourByThree;
    public Sprite fourByThree_Border;
    public Sprite fourByFive;
    public Sprite fourBySeven;

    public Image up;
    public Image down;
    public Image ActionsTextFieldImage;

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
    public Button btnMenu;

    public Text btnOneText;
    public Text btnTwoText;
    public Text btnThreeText;
    public Text btnFourText;
    public Text btnFiveText;
    public Text btnSixText;
    public Text btnSevenText;
    public Text btnEightText;

    public Image btnOneMask;
    public Image btnOneImage;
    public Image btnOneBorder;
    public Image btnTwoMask;
    public Image btnTwoImage;
    public Image btnTwoBorder;
    public Image btnThreeMask;
    public Image btnThreeImage;
    public Image btnThreeBorder;
    public Image btnFourMask;
    public Image btnFourImage;
    public Image btnFourBorder;
    public Image btnFiveMask;
    public Image btnFiveImage;
    public Image btnFiveBorder;
    public Image btnSixMask;
    public Image btnSixImage;
    public Image btnSixBorder;
    public Image btnSevenMask;
    public Image btnSevenImage;
    public Image btnSevenBorder;
    public Image btnEightMask;
    public Image btnEightImage;
    public Image btnEightBorder;


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

    private bool guessedCorrectly;
    private string guessedPlayer;
    private string guessedCriminal;
    private string guessedPlace;
    private Player localPlayer;


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void OnEnable()
    {
        btnMenu.onClick.RemoveAllListeners();
        btnMenu.onClick.AddListener(UIManager.Instance.OpenMenu);
        guessedCorrectly = true;
        localPlayer = GameState.Instance.localPlayer.GetComponent<Player>();
        currentBet = 0;
        delayedTurns = 1;
        currentDialogue = "";
        leftOverDialogue = "";
        dialogueText.text = currentDialogue;
        dialogueText.gameObject.SetActive(false);
        dialoguePanel.gameObject.SetActive(false);

        btnBack.interactable = false;
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(btnGoBack);
        btnInfo.gameObject.SetActive(true);
        btnInfo.interactable = true;
        btnInfo.onClick.RemoveAllListeners();
        btnInfo.onClick.AddListener(btnToInfo);
        currentPlace = GameState.Instance.board[GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]];
        actionsTextField.gameObject.SetActive(false);
        placeName.text = translatePlace(currentPlace);
        setPlaceImage(currentPlace);
        setDescription(currentPlace);
        if (GameState.Instance.isDisabled[GameState.Instance.currentTurn] > 0)
        {
            if (GameState.Instance.isDisabled[GameState.Instance.currentTurn] == 2)
            {
                localPlayer.SetIsDisabled(GameState.Instance.currentTurn, (GameState.Instance.isDisabled[GameState.Instance.currentTurn] - 1));
                switch (GameState.Instance.criminalRole)
                {
                    case "Inferno":
                        setDialogue("Du hast bist aus heiterem Himmel von einer kleinen Rakete getroffen worden und befindest dich nun im Krankenhaus.");
                        break;
                    case "Dr.Mortifier":
                        setDialogue("Du hast dich auf einmal mit einer starken Grippe infiziert und befindest dich nun im Krankenhaus.");
                        break;
                    case "Phantom":
                        setDialogue("Aus irgeneinem Grund wurde Diebesgut in deiner Wohnung gefunden. Du befindest dich num im Gefängnis.");
                        break;
                    case "Fasculto":
                        setDialogue("Plötzlich hattest du eine unglaubliche Pechsträhne und nach mehreren kleinen Unfällen befindest du dich nun im Krankenhaus.");
                        break;
                }

            }
            else
            {
                localPlayer.SetIsDisabled(GameState.Instance.currentTurn, (GameState.Instance.isDisabled[GameState.Instance.currentTurn] - 1));
                setDialogue("Du bist immer noch im " + translatePlace(currentPlace));
            }
            return;
        }
        if (!GameState.Instance.isGuessing[GameState.Instance.currentTurn])
        {
            if (GameState.Instance.isMovementManipulated[GameState.Instance.currentTurn])
            {
                simpleDialogue("Du wurdest gezwungen dich hier her zu bewegen.", 60);
                localPlayer.SetIsMovementManipulated(GameState.Instance.currentTurn, false);
            }
            if (GameState.Instance.isHintManipulated[GameState.Instance.currentTurn])
            {
                simpleDialogue("Jemand hat dich gezwungen Beweismaterial zu vernichten.", 60);
                localPlayer.SetIsHintManipulated(GameState.Instance.currentTurn, false);
            }

            //menu if its a criminal
            if (GameState.Instance.criminal == GameState.Instance.roles[GameState.Instance.currentTurn])
            {
                if (currentPlace == 0)
                {
                    fourButtons();
                    btnOneText.text = "Umschauen";
                    btnOne.onClick.AddListener(btnLookAroundClick);
                    btnTwoText.text = "Item";
                    btnTwo.onClick.AddListener(btnUseItemClick);
                    btnThreeText.text = "große Falle";
                    btnThree.onClick.AddListener(btnBigTrapClick);
                    btnFourText.text = "Manipulation";
                    btnFour.onClick.AddListener(btnManipulationClick);
                    btnThree.interactable = false;
                    btnFour.interactable = false;

                    //checking if big Trap can be used
                    if (!GameState.Instance.bigTrapUsed)
                    {
                        btnThree.interactable = true;
                    }

                    //checking if manipulation can be used
                    if (GameState.Instance.money[GameState.Instance.currentTurn] >= 10)
                    {
                        btnFour.interactable = true;
                    }
                }
                else
                {
                    eightButtons();
                    btnOneText.text = "Ortsoption";
                    btnTwoText.text = "Hinweis suchen";
                    btnThreeText.text = "Item";
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
                    if (!GameState.Instance.bigTrapUsed)
                    {
                        btnSix.interactable = true;
                    }

                    //checking if manipulation can be used
                    if (GameState.Instance.money[GameState.Instance.currentTurn] >= 10)
                    {
                        btnSeven.interactable = true;
                    }

                    //checking if a questplace can be activated
                    if (GameState.Instance.money[GameState.Instance.currentTurn] >= 6)
                    {
                        if (GameState.Instance.activatedQuestPlaces < 3)
                        {
                            if (GameState.Instance.questPlaces.Contains(currentPlace))
                            {
                                btnEight.interactable = true;
                            }
                        }
                    }
                    if (GameState.Instance.activatedQuestPlaces >= 3)
                    {
                        btnEightText.text = "Verbrechen ausführen";
                        if (GameState.Instance.targetPlace == currentPlace)
                        {
                            if (GameState.Instance.targetTime)
                            {
                                btnEight.interactable = true;
                            }
                        }
                    }

                }
            }
            //menu if its a good guy
            else
            {
                if (currentPlace == 0)
                {
                    twoButtons();
                    btnOneText.text = "Umschauen";
                    btnOne.onClick.AddListener(btnLookAroundClick);
                    btnTwoText.text = "Item";
                    btnTwo.onClick.AddListener(btnUseItemClick);
                }
                else
                {

                    threeButtons();
                    btnOneText.text = "Ortsoption";
                    btnTwoText.text = "Hinweis suchen";
                    btnThreeText.text = "Item";
                    btnOne.onClick.AddListener(btnPlaceOptionClick);
                    btnTwo.onClick.AddListener(btnFindHintClick);
                    btnThree.onClick.AddListener(btnUseItemClick);

                }
            }
            //checking if a skillplace can be used
            if (currentPlace == 2)
            {
                btnOne.interactable = false;
                if (GameState.Instance.roles[GameState.Instance.currentTurn] == "Detective" && !GameState.Instance.skillUsed[GameState.Instance.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 3)
            {
                btnOne.interactable = false;
                if (GameState.Instance.roles[GameState.Instance.currentTurn] == "Doctor" && !GameState.Instance.skillUsed[GameState.Instance.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 4)
            {
                btnOne.interactable = false;
                if (GameState.Instance.roles[GameState.Instance.currentTurn] == "Police" && !GameState.Instance.skillUsed[GameState.Instance.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 5)
            {
                btnOne.interactable = false;
                if (GameState.Instance.roles[GameState.Instance.currentTurn] == "Reporter" && !GameState.Instance.skillUsed[GameState.Instance.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 6)
            {
                btnOne.interactable = false;
                if (GameState.Instance.roles[GameState.Instance.currentTurn] == "Psychic" && !GameState.Instance.skillUsed[GameState.Instance.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }
            if (currentPlace == 7)
            {
                btnOne.interactable = false;
                if (GameState.Instance.roles[GameState.Instance.currentTurn] == "Psychologist" && !GameState.Instance.skillUsed[GameState.Instance.currentTurn])
                {
                    btnOneText.text = "Fähigkeit nutzen";
                    btnOne.interactable = true;
                }
            }

            //checking if player triggers a trap;
            Invoke("checkForTraps", 0.01f);
        }
        else
        {
            localPlayer.SetIsGuessing(GameState.Instance.currentTurn, false);
            playerButtons();
            simpleDialogue("Wer ist der Verbrecher?", 70);
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
        if (GameState.Instance.roles[player] != GameState.Instance.criminal)
        {

            guessedCorrectly = false;
        }
        guessedPlayer = translateName(player);
        simpleDialogue("Um welchen Verbrecher handelt es sich?", 70);
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
                guessedCriminal = "Inferno";
                if (GameState.Instance.criminalRole != "Inferno")
                {
                    guessedCorrectly = false;
                }
                break;
            case 1:
                guessedCriminal = "Dr.Mortifier";
                if (GameState.Instance.criminalRole != "Dr.Mortifier")
                {
                    guessedCorrectly = false;
                }
                break;
            case 2:
                guessedCriminal = "Phantom";
                if (GameState.Instance.criminalRole != "Phantom")
                {
                    guessedCorrectly = false;
                }
                break;
            case 3:
                guessedCriminal = "Fasculto";
                if (GameState.Instance.criminalRole != "Fasculto")
                {
                    guessedCorrectly = false;
                }
                break;
        }
        simpleDialogue("Wo wird das Verbrechen stattfinden?", 70);
        CheckPlaceLayout();

    }
    void CheckPlaceLayout()
    {
        threeButtons();
        switch (GameState.Instance.criminalRole)
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
        switch (GameState.Instance.criminalRole)
        {
            case "Inferno":
                switch (place)
                {
                    case 0:
                        guessedPlace = translatePlace(5);
                        if (GameState.Instance.targetPlace != 5)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 1:
                        guessedPlace = translatePlace(7);
                        if (GameState.Instance.targetPlace != 7)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 2:
                        guessedPlace = translatePlace(8);
                        if (GameState.Instance.targetPlace != 8)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                }
                break;
            case "Dr.Mortifier":
                switch (place)
                {
                    case 0:
                        guessedPlace = translatePlace(1);
                        if (GameState.Instance.targetPlace != 1)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 1:
                        guessedPlace = translatePlace(12);
                        if (GameState.Instance.targetPlace != 12)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 2:
                        guessedPlace = translatePlace(17);
                        if (GameState.Instance.targetPlace != 17)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                }
                break;
            case "Phantom":
                switch (place)
                {
                    case 0:
                        guessedPlace = translatePlace(4);
                        if (GameState.Instance.targetPlace != 4)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 1:
                        guessedPlace = translatePlace(8);
                        if (GameState.Instance.targetPlace != 8)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 2:
                        guessedPlace = translatePlace(12);
                        if (GameState.Instance.targetPlace != 12)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                }
                break;
            case "Fasculto":
                switch (place)
                {
                    case 0:
                        guessedPlace = translatePlace(5);
                        if (GameState.Instance.targetPlace != 5)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 1:
                        guessedPlace = translatePlace(6);
                        if (GameState.Instance.targetPlace != 6)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                    case 2:
                        guessedPlace = translatePlace(7);
                        if (GameState.Instance.targetPlace != 7)
                        {
                            guessedCorrectly = false;
                        }
                        break;
                }
                break;
        }

        checkGuess();
    }
    void checkGuess()
    {
        oneButton();
        btnOneText.text = "OK";
        btnOne.onClick.AddListener(checkGuessClick);
        simpleDialogue("Spieler: " + guessedPlayer + "\nVerbrecher: " + guessedCriminal + "\nZielort: " + guessedPlace + "\nKorrekt?", 60);
    }
    void checkGuessClick()
    {
        if (guessedCorrectly)
        {
            localPlayer.SetPlayerWin(localPlayer.id, true);
        }
        else
        {
            localPlayer.SetPlayerLost(localPlayer.id, true);
            endTurn();
        }
    }
    #endregion

    void btnToInfo()
    {
        UIManager.Instance.PrivatePlayer();
    }

    void checkForTraps()
    {
        if (GameState.Instance.roles[GameState.Instance.currentTurn] == GameState.Instance.criminal)
        {
            for (int i = 0; i < 19; i++)
            {
                if (GameState.Instance.infernoTraps[i] > 0)
                {
                    if (GameState.Instance.infernoTraps[i] == 1)
                    {
                        localPlayer.SetActiveTraps(i, "Bomb");
                    }
                    localPlayer.SetInfernoTraps(i, (GameState.Instance.infernoTraps[i] - 1));
                }
                if (GameState.Instance.drMortifierTraps[i] > 0)
                {
                    if (GameState.Instance.drMortifierTraps[i] == 1)
                    {
                        localPlayer.SetActiveTraps(i, "PetriDish");
                    }
                    localPlayer.SetDrMortifierTraps(i, (GameState.Instance.drMortifierTraps[i] - 1));

                }
                if (GameState.Instance.phantomTraps[i] > 0)
                {
                    if (GameState.Instance.phantomTraps[i] == 1)
                    {
                        localPlayer.SetActiveTraps(i, "StolenGoods");
                    }
                    localPlayer.SetPhantomTraps(i, (GameState.Instance.phantomTraps[i] - 1));
                }
                if (GameState.Instance.fascultoTraps[i] > 0)
                {
                    if (GameState.Instance.fascultoTraps[i] == 1)
                    {
                        localPlayer.SetActiveTraps(i, "CursedArtifact");
                    }
                    localPlayer.SetFascultoTraps(i, (GameState.Instance.fascultoTraps[i] - 1));
                }
            }
        }

        if (GameState.Instance.activeTraps[currentPlace] != "Safe")
        {
            switch (GameState.Instance.activeTraps[currentPlace])
            {
                case "Bomb":
                    if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("FireProofCoat"))
                    {
                        if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("ProtectiveVest"))
                        {

                            activatedTrap(GameState.Instance.currentTurn, findTargetPosition("Inferno"));
                            localPlayer.SetIsDisabled(GameState.Instance.currentTurn, 1);
                            setDialogue("Du hast eine Bombe ausgelöst und musst die nächsten zwei Züge im Krankenhaus verbringen.");
                        }
                        else
                        {
                            simpleDialogue("Du hast eine Bombe ausgelöst aber deine Schutzweste hat dich beschützt.", 60);
                            localPlayer.RemoveItem(GameState.Instance.currentTurn, "ProtectiveVest");
                        }
                    }
                    else
                    {
                        simpleDialogue("Du hast eine Bombe ausgelöst aber dein feuerfester Mantel hat dich beschützt.", 60);
                    }
                    break;
                case "PetriDish":
                    if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("Gasmask"))
                    {
                        if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("ProtectiveVest"))
                        {

                            activatedTrap(GameState.Instance.currentTurn, findTargetPosition("Dr.Mortifier"));
                            localPlayer.SetIsDisabled(GameState.Instance.currentTurn, 1);
                            setDialogue("Du hast dich aus mysteriösen Gründen mit der Grippe angesteckt, und musst die nächsten 2 Züge im Krankenhaus verbringen,");
                        }
                        else
                        {
                            simpleDialogue("Du hättest dich fast mit der Grippe angesteckt aber deine Schutzweste hat dich beschützt.", 60);
                            localPlayer.RemoveItem(GameState.Instance.currentTurn, "ProtectiveVest");
                        }
                    }
                    else
                    {
                        simpleDialogue("Du hättest dich fast mit der Grippe angesteckt aber deine Gasmaske hat dich beschützt.", 60);
                    }
                    break;
                case "StolenGoods":
                    if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("Bodycam"))
                    {
                        if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("ProtectiveVest"))
                        {

                            activatedTrap(GameState.Instance.currentTurn, findTargetPosition("Phantom"));
                            localPlayer.SetIsDisabled(GameState.Instance.currentTurn, 1);
                            setDialogue("Dir wurde leider ein Verbrechen angehängt das du nicht begangen hast. Deshalb verbringst du die nächsten zwei Züge im Gefängnis.");
                        }
                        else
                        {
                            simpleDialogue("Dir wurde fast ein Verbrechen angehängt aber deine Schutzweste hat dich beschützt.", 60);
                            localPlayer.RemoveItem(GameState.Instance.currentTurn, "ProtectiveVest");
                        }
                    }
                    else
                    {
                        simpleDialogue("Dir wurde fast ein Verbrechen angehängt aber deine Bodycam hat dich beschützt.", 60);
                    }
                    break;
                case "CursedArtifact":
                    if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("Talisman"))
                    {
                        if (!GameState.Instance.items[GameState.Instance.currentTurn].Contains("ProtectiveVest"))
                        {

                            activatedTrap(GameState.Instance.currentTurn, findTargetPosition("Fasculto"));
                            localPlayer.SetIsDisabled(GameState.Instance.currentTurn, 1);
                            setDialogue("Du hast einen komischen Gegenstand angegriffen und hast dich nach einer langen Pechsträhne schwer verletzt. Du muss die nächsten 2 Züge im Krankenhaus verbringen.");
                        }
                        else
                        {
                            simpleDialogue("Du wärst beinahe verflucht worden, doch deine Schutzweste hat dich beschützt.", 60);
                            localPlayer.RemoveItem(GameState.Instance.currentTurn, "ProtectiveVest");
                        }
                    }
                    else
                    {
                        simpleDialogue("Du wärst beinahe verflucht worden, doch dein Talisman hat dich beschützt.", 60);
                    }
                    break;
            }
            localPlayer.SetActiveTraps(currentPlace, "Safe");
            return;
        }
    }

    void endTurn()
    {
        if (!GameState.Instance.usedEnergyDrink.Contains(true))
        {
            System.Random rn = new System.Random();
            int randomHint = rn.Next(1, 10);
            if (randomHint == 1)
            {
                if (GameState.Instance.roles[GameState.Instance.currentTurn] == GameState.Instance.criminal)
                {
                    addTrueHint();
                }
                else
                {
                    addFalseHint();
                }
            }
            localPlayer.SetPlayerState(GameState.Instance.currentTurn, "Waiting");
            localPlayer.SetCurrentTurn(((GameState.Instance.currentTurn + 1) % GameState.Instance.playerCount));
            localPlayer.SetPlayerState(GameState.Instance.currentTurn, "Movement");
            //counting down quarantine time
            if (GameState.Instance.roles[GameState.Instance.currentTurn] == "Doctor")
            {
                for (int i = 0; i < 19; i++)
                {
                    if (GameState.Instance.quarantined[i] > 0)
                    {
                        localPlayer.SetQuarantine(i, (GameState.Instance.quarantined[i] - 1));
                    }
                }
            }
            if (GameState.Instance.playerLost[GameState.Instance.currentTurn])
            {
                Debug.Log(GameState.Instance.roles[GameState.Instance.currentTurn] + " has already lost");
                endTurn();
            }
            else
            {
                UIManager.Instance.PrivatePlayer();
            }
        }
        else
        {
            localPlayer.RemoveUsedEnergyDrink(true);
            OnEnable();
        }
    }


    #region Dialogue
    void setDialogue(string newDialogue)
    {
        btnInfo.interactable = false;
        btnBack.interactable = false;
        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(stopTypeWriter);

        currentDialogue = "";
        dialoguePanel.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        dialogueText.text = currentDialogue;
        dialogueText.fontSize = 49;

        if (newDialogue.Length <= 120)
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
        StopCoroutine("SimpleTypeWriter");
        StopCoroutine("TypeWriter");
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
        StopCoroutine("SimpleTypeWriter");
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

    void btnLookAroundClick()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Umschauen");
        System.Random rn = new System.Random();
        int r = rn.Next(1, 40);
        switch (r)
        {
            case 1:
                localPlayer.SetMoney(GameState.Instance.currentTurn, GameState.Instance.money[GameState.Instance.currentTurn] + 1);
                setDialogue("Du schaust dich um und findest einen Dollar am Boden. Muss wohl dein Glückstag sein.");
                break;
            case 2:
                localPlayer.SetMoney(GameState.Instance.currentTurn, GameState.Instance.money[GameState.Instance.currentTurn] + 1);
                setDialogue("Du schaust dich um und findest einen Dollar am Boden. Muss wohl dein Glückstag sein.");
                break;
            case 3:
                if (GameState.Instance.money[GameState.Instance.currentTurn] > 0)
                {
                    localPlayer.SetMoney(GameState.Instance.currentTurn, GameState.Instance.money[GameState.Instance.currentTurn] - 3);
                }
                setDialogue("Du schaust dich genau um und findest aber nichts interessantes. Später findest du heraus das dich jemand bestohlen hat währen du abgelenkt warst.");
                break;
            case 4:
                localPlayer.SetUnsolvedHints(GameState.Instance.currentTurn, GameState.Instance.unsolvedHints[GameState.Instance.currentTurn] + 1);
                setDialogue("Du schaust dich um, als plötzlich ein Fremder auf dich zu kommt. Er gibt dir einen interessanten Tipp und du denkst, dass du einen neuen Hinweis hast musst ihn jedoch noch genauer analysieren.");
                break;
            case 5:
                localPlayer.SetUnsolvedHints(GameState.Instance.currentTurn, GameState.Instance.unsolvedHints[GameState.Instance.currentTurn] + 1);
                localPlayer.SetTrueUnsolveds(GameState.Instance.currentTurn, GameState.Instance.trueUnsolveds[GameState.Instance.currentTurn] + 1);
                setDialogue("Du schaust dich um und als plötzlich ein Fremder auf dich zu kommt. Er gibt dir einen interessanten Tipp und du denkst, dass du einen neuen Hinweis hast musst ihn jedoch noch genauer analysieren.");
                break;
            case 6:
                localPlayer.SetIsDisabled(GameState.Instance.currentTurn, 1);
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(3)[0], findPosition(3)[1]);
                setDialogue("Du schaust dich so genau um, dass du eine Straßenlaterne übersiehst und dir eine leichte Gehirnerschütterung ergatterst. Du bist für die nächste Runde im Krankenhaus.");
                break;
            case 7:
                int xPlace = rn.Next(0, 5);
                int yPlace = rn.Next(0, 6);
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, xPlace, yPlace);
                setDialogue("Du schaust dich um und triffst einen alten Freund. Ihr verbringt den restlichen Tag in einer Bar und der Alkohol fließt in Strömen. Am nächsten Tag wachst du an einem unbekannten Platz auf.");
                break;
            case 8:
                if (GameState.Instance.criminal == GameState.Instance.roles[GameState.Instance.currentTurn])
                {
                    int criminalrole = rn.Next(0, 3);
                    switch (criminalrole)
                    {
                        case 0:
                            setDialogue("Du schaust dich um und plötzlich hast du eine göttliche Eingebung. Du bist dir sicher das der Verbrecher Inferno ist.");
                            break;
                        case 1:
                            setDialogue("Du schaust dich um und plötzlich hast du eine göttliche Eingebung. Du bist dir sicher das der Verbrecher Dr. Mortifier ist.");
                            break;
                        case 2:
                            setDialogue("Du schaust dich um und plötzlich hast du eine göttliche Eingebung. Du bist dir sicher das der Verbrecher Phantom ist.");
                            break;
                        case 3:
                            setDialogue("Du schaust dich um und plötzlich hast du eine göttliche Eingebung. Du bist dir sicher das der Verbrecher Fasculto ist.");
                            break;
                        default:
                            setDialogue("Du schaust dich um und plötzlich hast du eine göttliche Eingebung. Du bist dir sicher das der Verbrecher Inferno ist.");
                            break;
                    }
                    
                }
                else
                {
                    setDialogue("Du schaust dich um und plötzlich bist du dir sicher das dir eine Person auf der Schliche ist. Paranoid versuchst du dich in den Schatten zu halten.");
                }
                break;
            case 9:
                localPlayer.AddItem(GameState.Instance.currentTurn, "EnergyDrink");
                setDialogue("Du schaust dich um und findest eine halbvolle Energy Drink Dose und steckst sie ein. Optimistisch aber ekelhaft!");
                break;
            case 10:
                localPlayer.AddItem(GameState.Instance.currentTurn, "ProtectiveVest");
                setDialogue("Du schaust dich um und findest ein Holzbrett. Du denkst dir das es dir als Schutzweste dienen kann. Du schaust aus wie ein Vollidiot aber du fühlst dich sicher.");
                break;
            case 11:
                if (GameState.Instance.money[GameState.Instance.currentTurn] > 0)
                {
                    localPlayer.SetMoney(GameState.Instance.currentTurn, GameState.Instance.money[GameState.Instance.currentTurn] - 1);
                    setDialogue("Du schaust dich um und siehst einen Obdachlosen. Du gibst ihm einen Dollar. Du bekommst einen Karmapunkt :P.");
                }
                else
                {
                    localPlayer.SetMoney(GameState.Instance.currentTurn, GameState.Instance.money[GameState.Instance.currentTurn] +1);
                    setDialogue("Du schaust dich um und siehst einen Obdachlosen. Er sieht dir an, dass du ärmer bist als er und gibt dir einen Dollar.");
                }
                
                break;
            case 12:
                int pair = rn.Next(0, 9);
                switch(pair){
                    case 0:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"MM+CC\"");
                        break;
                    case 1:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"Felicity rulez\"");
                        break;
                    case 2:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"Westfield sucks\"");
                        break;
                    case 3:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"AA ist cool\"");
                        break;
                    case 4:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"Nugs not Drugs\"");
                        break;
                    case 5:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"GoT wird überschätzt\"");
                        break;
                    case 6:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"<- ist dämlich\"");
                        break;
                    case 7:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"Erik <3 ~L\"");
                        break;
                    case 8:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"F this Tree!\"");
                        break;
                    case 9:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"Osswald ist eine Betrügerin\"");
                        break;
                    default:
                        setDialogue("Du schaust dich um und siehst eine in einen Baum geritze Nachricht: \"!Westfields Papergirls!\"");
                        break;
                }
                
                break;
            case 13:
                localPlayer.AddItem(GameState.Instance.currentTurn, "Trainers");
                setDialogue("Du schaust dich um und findest ein paar alte Turnschuhe und steckst sie ein. Du hoffst das dich niemand dabei beobachtet hat.");
                break;
            case 14:
                int escape = rn.Next(0, 10);
                if (escape == 0)
                {
                    localPlayer.SetMoney(GameState.Instance.currentTurn, 0);
                    setDialogue("Du schaust dich um als plötzlich jemand auf dich zustürmt und dich mit einen Messer bedroht. Du gibst ihm dein ganzes Geld, dafür kommst du unverletzt davon.");
                }
                else
                {
                    setDialogue("Du schaust dich um als plötzlich jemand auf dich zustürmt und dich mit einen Messer bedroht. Du bist jedoch flink genug um zu entkommen.");
                }
                break;
            case 15:
                if (GameState.Instance.skillUsed[GameState.Instance.currentTurn])
                {
                    setDialogue("Du schaust dich um als dich plötzlich eine junge Frau anspricht. Wie sich herausstellt haben sich deine Ermittlungen herumgesprochen und die Frau ist ein großer Fan. Du fühlst dich bestätigt und kannst deine Fähigkeit erneut benutzen.");
                }
                else
                {
                    setDialogue("Du schaust dich um als dich plötzlich ein junger Mann anspricht. Wie sich herausstellt haben sich deine Ermittlungen herumgesprochen und der Mann ist ein großer Fan. Das ganze ist dir ein wenig unangenehm.");
                }
        break;
            case 16:
                if (GameState.Instance.solvedHints[GameState.Instance.currentTurn] > 0)
                {
                    if (GameState.Instance.trueSolveds[GameState.Instance.currentTurn] > 0)
                    {
                        localPlayer.SetTrueSolveds(GameState.Instance.currentTurn, GameState.Instance.trueSolveds[GameState.Instance.currentTurn] - 1);
                    }
                   
                    localPlayer.SetSolvedHints(GameState.Instance.currentTurn, GameState.Instance.solvedHints[GameState.Instance.currentTurn] - 1);
                }
                
                setDialogue("Du schaust dich um übersiehst aber trotzdem einen kleinen Stein und stolperst. Dabei verlierst du einen deiner Hinweise.");
                break;
            case 17:
                setDialogue("Du schaust dich um entdeckst einen kaputten Taschenrechner und steckst ihn ein. Warum genau du das tust weißt du jedoch auch nicht, schließlich ist er ja kaputt.");
                break;
            case 18:
                setDialogue("Du schaust dich um findest einen Mantel. Du testest ob er feuerfest ist und er geht in Flammen auf. Was hast du erwartet?!");
                break;
            case 19:
                setDialogue("Du schaust dich um und findest eine Petrischale. Du entscheidest dich dagegen sie einzustecken, wer weiß was du dir dabei einfangen könntest.");
                break;
            case 20:
                localPlayer.SetIsDisabled(GameState.Instance.currentTurn, 1);
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(3)[0], findPosition(3)[1]);
                setDialogue("Du schaust dich um und findest eine Petrischale und steckst sie ein. Ein paar Stunden später fühlst du dich elendst und begibst dich ins Krankenhaus, wo du für eine Runde bleiben musst.");
                break;
            default:
                setDialogue("Du schaust dich um aber du bemerkst nichts außergewöhnliches.");
                break;
        }
        
    }

    #region Use Item
    void btnUseItemClick()
    {
        btnBack.interactable = true;
        int trainersCount = 0;
        int FingerprintKitCount = 0;
        int EnergyDrinkCount = 0;
        int WhiskeyCount = 0;

        for (int i = 0; i < GameState.Instance.items[GameState.Instance.currentTurn].Count; i++)
        {
            switch (GameState.Instance.items[GameState.Instance.currentTurn][i])
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
        if (FingerprintKitCount == 0 || currentPlace == 0)
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Item benutzen");
        localPlayer.RemoveItem(GameState.Instance.currentTurn, "Trainers");
        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(btnTrainersContinue);
        simpleDialogue("Du ziehst deine Turnschuhe an und beginnst zu laufen.", 60);
    }
    void btnTrainersContinue()
    {
        localPlayer.SetPlayerState(GameState.Instance.currentTurn, "Movement");
        UIManager.Instance.Movement();

    }
    void btnFingerprintKitOnClick()
    {
        int tempFoundHints = GameState.Instance.notFoundTrue[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] + GameState.Instance.notFoundFalse[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]]; ;
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Item benutzen");
        localPlayer.SetSolvedHints(GameState.Instance.currentTurn, (GameState.Instance.solvedHints[GameState.Instance.currentTurn] + GameState.Instance.notFoundTrue[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] + GameState.Instance.notFoundFalse[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]]));
        localPlayer.SetTrueSolveds(GameState.Instance.currentTurn, (GameState.Instance.trueSolveds[GameState.Instance.currentTurn] + GameState.Instance.notFoundTrue[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]]));
        localPlayer.SetNotFoundTrue(GameState.Instance.currentTurn, GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1], 0);
        localPlayer.SetNotFoundFalse(GameState.Instance.currentTurn, GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1], 0);
        localPlayer.RemoveItem(GameState.Instance.currentTurn, "FingerprintKit");
        if (checkForFact())
        {
            if (tempFoundHints == 1)
            {
                simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du 1 Hinweis und hast dadurch wichtige Informationen herausfinden können.", 60);
            }
            else
            {
                simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du " + tempFoundHints + " Hinweise und hast dadurch wichtige Informationen herausfinden können.", 60);
            }

        }
        else
        {
            if (tempFoundHints > 0)
            {
                if (tempFoundHints == 1)
                {
                    simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du 1 Hinweis.", 60);
                }
                else
                {
                    simpleDialogue("Mit dem Fingerprintset findest und entschlüsselst du " + tempFoundHints + " Hinweise", 60);
                }

            }
            else
            {
                simpleDialogue("Selbst mit dem Fingerabdruckset lässt sich hier kein Hinweis finden.", 60);
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Item benutzen");
        localPlayer.AddUsedEnergyDrink(true);
        localPlayer.RemoveItem(GameState.Instance.currentTurn, "EnergyDrink");
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Item benutzten");
        localPlayer.SetTrueSolveds(GameState.Instance.currentTurn, (GameState.Instance.trueSolveds[GameState.Instance.currentTurn] + 1));
        localPlayer.SetSolvedHints(GameState.Instance.currentTurn, (GameState.Instance.solvedHints[GameState.Instance.currentTurn] + 1));
        localPlayer.RemoveItem(GameState.Instance.currentTurn, "Whiskey");
        checkForFact();
        oneButton();
        btnOneText.text = "Weiter";
        btnOne.onClick.AddListener(btnWhiskeyContinue);
        simpleDialogue("Du tauscht deinen Whiskey gegen einen sicher richtigen Hinweis.", 60);
    }
    void btnWhiskeyContinue()
    {
        OnEnable();
    }
    #endregion

    #region Small Trap
    void btnSmallTrapClick()
    {
        btnBack.interactable = true;
        int bombCount = 0;
        int petriDishCount = 0;
        int stoleGoodsCount = 0;
        int cursedArtifactCount = 0;

        for (int i = 0; i < GameState.Instance.items[GameState.Instance.currentTurn].Count; i++)
        {
            switch (GameState.Instance.items[GameState.Instance.currentTurn][i])
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
            if (GameState.Instance.criminalRole == "Inferno")
            {
                btnOneText.text = "Bombe 2$";
                btnOne.onClick.RemoveAllListeners();
                btnOne.onClick.AddListener(buyOwnTrap);
                if (GameState.Instance.money[GameState.Instance.currentTurn] < 2)
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
            if (GameState.Instance.criminalRole == "Dr.Mortifier")
            {
                btnTwoText.text = "Petrischale 2$";
                btnTwo.onClick.RemoveAllListeners();
                btnTwo.onClick.AddListener(buyOwnTrap);
                if (GameState.Instance.money[GameState.Instance.currentTurn] < 2)
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
            if (GameState.Instance.criminalRole == "Phantom")
            {
                btnThreeText.text = "Diebesgut 2$";
                btnThree.onClick.RemoveAllListeners();
                btnThree.onClick.AddListener(buyOwnTrap);
                if (GameState.Instance.money[GameState.Instance.currentTurn] < 2)
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
            if (GameState.Instance.criminalRole == "Fasculto")
            {
                btnFourText.text = "Verfluchtes Artifakt 2$";
                btnFour.onClick.RemoveAllListeners();
                btnFour.onClick.AddListener(buyOwnTrap);
                if (GameState.Instance.money[GameState.Instance.currentTurn] < 2)
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
        switch (GameState.Instance.criminalRole)
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
        btnBack.interactable = true;
    }
    void delayTrapMenu()
    {
        simpleDialogue("Nach wievielen Runden ist die Falle scharf?", 60);
        actionTextFieldNumber();
        actionsTextField.fontSize = 130;
        actionsTextField.text = "" + delayedTurns;
        btnTwoText.text = "Falle legen";
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "kleine Falle");
        if (GameState.Instance.items[GameState.Instance.currentTurn].Contains("Bomb"))
        {
            localPlayer.RemoveItem(GameState.Instance.currentTurn, "Bomb");
        }
        else
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        }
        localPlayer.SetInfernoTraps(currentPlace, delayedTurns);
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "kleine Falle");
        if (GameState.Instance.items[GameState.Instance.currentTurn].Contains("PetriDish"))
        {
            localPlayer.RemoveItem(GameState.Instance.currentTurn, "PetriDish");
        }
        else
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        }
        localPlayer.SetDrMortifierTraps(currentPlace, delayedTurns);
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "kleine Falle");
        if (GameState.Instance.items[GameState.Instance.currentTurn].Contains("StolenGoods"))
        {
            localPlayer.RemoveItem(GameState.Instance.currentTurn, "StolenGoods");
        }
        else
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        }
        localPlayer.SetPhantomTraps(currentPlace, delayedTurns);
        addTrueHint();
        setDialogue("Du platzierst strategisch Diebesgut und sagst deinen Komplizen zu welchem Zeitpunkt sie dies melden sollen.");
    }
    void calibrateFascultoTrap()
    {
        delayTrapMenu();
        btnTwo.onClick.AddListener(setFascultoTrap);
    }
    void setFascultoTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "kleine Falle");
        if (GameState.Instance.items[GameState.Instance.currentTurn].Contains("CursedArtifact"))
        {
            localPlayer.RemoveItem(GameState.Instance.currentTurn, "CursedArtifact");
        }
        else
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));

        }
        localPlayer.SetFascultoTraps(currentPlace, delayedTurns);
        addTrueHint();
        setDialogue("Du hinterlässt ein verfluchtes Artifakt");
    }
    #endregion

    void btnActivateQuestPlaceClick()
    {
        addTrueHint();
        if (GameState.Instance.activatedQuestPlaces < 3)
        {
            localPlayer.SetLastAction(GameState.Instance.currentTurn, "Questort aktivieren");
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 6));
            localPlayer.RemoveQuestPlace(currentPlace);
            localPlayer.SetActivatedQuestPlaces(GameState.Instance.activatedQuestPlaces + 1);
            string s = "";

            switch (GameState.Instance.criminalRole)
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
            localPlayer.SetLastAction(GameState.Instance.currentTurn, "Verbrechen ausführen");
            if (GameState.Instance.criminalRole == "Inferno" || GameState.Instance.criminalRole == "Phantom" || GameState.Instance.criminalRole == "Fasculto")
            {
                localPlayer.SetCriminalWin(true);
            }
            else if (GameState.Instance.criminalRole == "Dr.Mortifier")
            {
                localPlayer.SetPlanted(true);
                setDialogue("Du hast deine Biowaffe platziert. Begib dich schnell in Sicherheit.");
            }
        }

    }

    void btnFindHintClick()
    {
        int tempfoundHints = GameState.Instance.notFoundTrue[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] + GameState.Instance.notFoundFalse[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]]; ;
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Hinweis finden");
        localPlayer.SetUnsolvedHints((GameState.Instance.currentTurn), (GameState.Instance.unsolvedHints[GameState.Instance.currentTurn] + GameState.Instance.notFoundTrue[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] + GameState.Instance.notFoundFalse[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]]));
        localPlayer.SetTrueUnsolveds(GameState.Instance.currentTurn, (GameState.Instance.trueUnsolveds[GameState.Instance.currentTurn] + GameState.Instance.notFoundTrue[GameState.Instance.currentTurn][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]]));
        localPlayer.SetNotFoundTrue(GameState.Instance.currentTurn, GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1], 0);
        localPlayer.SetNotFoundFalse(GameState.Instance.currentTurn, GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1], 0);
        if (tempfoundHints > 0)
        {
            if (tempfoundHints == 1)
            {
                setDialogue("Du schaust dich genauer um, und findest " + tempfoundHints + " Hinweis, der zum Verbrecher führen könnten.");
            }
            else
            {
                setDialogue("Du schaust dich genauer um, und findest " + tempfoundHints + " Hinweise, die zum Verbrecher führen könnten.");
            }

        }
        else
        {
            setDialogue("Du schaust dich genauer um, findest aber nichts was auf den Verbrecher hinweisen könnte.");
        }
    }

    void btnFalseHintClick()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "falscher Hinweis");
        addFalseHint();
        setDialogue("Du platzierst einen falschen Hinweis.");
    }

    #region placeactions

    void btnPlaceOptionClick()
    {
        btnBack.interactable = true;
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
        int tempUnsolvedHints = GameState.Instance.unsolvedHints[GameState.Instance.currentTurn];
        localPlayer.SetTrueSolveds(GameState.Instance.currentTurn, (GameState.Instance.trueSolveds[GameState.Instance.currentTurn] + GameState.Instance.trueUnsolveds[GameState.Instance.currentTurn]));
        localPlayer.SetSolvedHints(GameState.Instance.currentTurn, (GameState.Instance.solvedHints[GameState.Instance.currentTurn] + GameState.Instance.unsolvedHints[GameState.Instance.currentTurn]));
        localPlayer.SetTrueUnsolveds(GameState.Instance.currentTurn, 0);
        localPlayer.SetUnsolvedHints(GameState.Instance.currentTurn, 0);
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");

        if (checkForFact())
        {
            if (tempUnsolvedHints == 1)
            {
                setDialogue("Du hast einen Hinweis entschlüsselt und hast dadurch wichtige Informationen herausfinden können.");
            }
            else
            {
                setDialogue("Du hast " + tempUnsolvedHints + " Hinweise entschlüsselt und hast dadurch wichtige Informationen herausfinden können.");
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        if (GameState.Instance.items[GameState.Instance.currentTurn].Contains("Calculator"))
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] + 8));
            setDialogue("Dank deines Taschenrechners konntest du 8$ verdienen.");
        }
        else
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] + 6));
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue("Dein Obdachlosennetzwerk berichtet dir, dass der Verbrecher schon" + GameState.Instance.activatedQuestPlaces + "/3 seiner Zwischenziele erreicht hat.");
    }
    void hospitalAction()
    {
        actionTextFieldString();
        ActionsTextFieldImage.sprite = imgMainsquare_Symbol;
        actionsTextField.text = "Stadtplatz";
        btnTwoText.text = "Quarantäne";
        btnOne.onClick.AddListener(btnPlaceUp);
        btnTwo.onClick.AddListener(btnQuarantine);
        btnThree.onClick.AddListener(btnPlaceDown);
        simpleDialogue("Welcher Ort soll unter Quarantäne gestellt werden?", 60);
    }
    void btnQuarantine()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        string place = "";
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                localPlayer.SetQuarantine(1, 3);
                place = "den Stadtplatz";
                break;
            case "Park":
                localPlayer.SetQuarantine(2, 3);
                place = "den Park";
                break;
            case "Krankenhaus":
                localPlayer.SetQuarantine(3, 3);
                place = "das Krankenhaus";
                break;
            case "Bank":
                localPlayer.SetQuarantine(4, 3);
                place = "die Bank";
                break;
            case "Parlament":
                localPlayer.SetQuarantine(5, 3);
                place = "das Parlament";
                break;
            case "Friedhof":
                localPlayer.SetQuarantine(6, 3);
                place = "den Friedhof";
                break;
            case "Gefängnis":
                localPlayer.SetQuarantine(7, 3);
                place = "das Gefängnis";
                break;
            case "Kasino":
                localPlayer.SetQuarantine(8, 3);
                place = "das Kasino";
                break;
            case "Internet Cafe":
                localPlayer.SetQuarantine(9, 3);
                place = "das Internet Cafe";
                break;
            case "Bahnhof":
                localPlayer.SetQuarantine(10, 3);
                place = "den Bahnhof";
                break;
            case "Armee Laden":
                localPlayer.SetQuarantine(11, 3);
                place = "den Armee Laden";
                break;
            case "Shopping Center":
                localPlayer.SetQuarantine(12, 3);
                place = "das Shopping Center";
                break;
            case "Schrottplatz":
                localPlayer.SetQuarantine(13, 3);
                place = "den Schrottplatz";
                break;
            case "Bibliothek":
                localPlayer.SetQuarantine(14, 3);
                place = "die Bibliothek";
                break;
            case "Labor":
                localPlayer.SetQuarantine(15, 3);
                place = "das Labor";
                break;
            case "Italiener":
                localPlayer.SetQuarantine(16, 3);
                place = "den Italiener";
                break;
            case "Hafen":
                localPlayer.SetQuarantine(17, 3);
                place = "den Hafen";
                break;
            case "Bar":
                localPlayer.SetQuarantine(18, 3);
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(0) + "s letzte Transaktion war: " + GameState.Instance.lastTransaction[0]);
    }
    void btnPlayerTwoTransaction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(1) + "s letzte Transaktion war: " + GameState.Instance.lastTransaction[1]);
    }
    void btnPlayerThreeTransaction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(2) + "s letzte Transaktion war: " + GameState.Instance.lastTransaction[2]);
    }
    void btnPlayerFourTransaction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(3) + "s letzte Transaktion war: " + GameState.Instance.lastTransaction[3]);
    }
    void btnPlayerFiveTransaction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(4) + "s letzte Transaktion war: " + GameState.Instance.lastTransaction[4]);
    }
    void btnPlayerSixTransaction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(5) + "s letzte Transaktion war: " + GameState.Instance.lastTransaction[5]);
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(0) + "s letzte Aktion war: " + GameState.Instance.lastAction[0]);
    }
    void btnPlayerTwoAction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(1) + "s letzte Aktion war: " + GameState.Instance.lastAction[1]);
    }
    void btnPlayerThreeAction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(2) + "s letzte Aktion war: " + GameState.Instance.lastAction[2]);
    }
    void btnPlayerFourAction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(3) + "s letzte Aktion war: " + GameState.Instance.lastAction[3]);
    }
    void btnPlayerFiveAction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(4) + "s letzte Aktion war: " + GameState.Instance.lastAction[4]);
    }
    void btnPlayerSixAction()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        setDialogue(translateName(5) + "s letzte Aktion war: " + GameState.Instance.lastAction[5]);
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
            if (GameState.Instance.activeTraps[i] != "Safe")
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

        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Fähigkeit");
        localPlayer.SetSkillUsed(GameState.Instance.currentTurn, true);
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                localPlayer.SetNotFoundFalse(GameState.Instance.currentTurn, i, j, 0);
            }
        }
        setDialogue("Deine Studie ermöglicht es dir bereits vorhandene falsche Hinweise als solche zu durchschauen.");
    }

    void casinoAction()
    {
        actionTextFieldNumber();
        actionsTextField.fontSize = 130;
        actionsTextField.text = "" + currentBet;
        btnTwoText.text = "Einsatz";
        btnOne.onClick.AddListener(btnCasinoBetUp);
        btnTwo.onClick.AddListener(btnCasinoBet);
        btnThree.onClick.AddListener(btnCasinoBetDown);
        if (currentBet == 0)
        {
            btnThree.interactable = false;
        }
        if (currentBet == GameState.Instance.money[GameState.Instance.currentTurn])
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
        else
        {
            btnThree.interactable = true;
        }
        if (currentBet == GameState.Instance.money[GameState.Instance.currentTurn])
        {
            btnOne.interactable = false;
        }
        else
        {
            btnOne.interactable = true;
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
        else
        {
            btnThree.interactable = true;
        }
        if (currentBet == GameState.Instance.money[GameState.Instance.currentTurn])
        {
            btnOne.interactable = false;
        }
        else
        {
            btnOne.interactable = true;
        }
        actionsTextField.text = "" + currentBet;
    }
    void btnCasinoBet()
    {
        System.Random rn = new System.Random();
        int rand = rn.Next(0, 100);
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Kasino Wette");
        if (rand < 50)
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] + currentBet));
            setDialogue("Du hast" + currentBet + "$ gewonnen!");
        }
        else
        {
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - currentBet));
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
        if (GameState.Instance.criminal == GameState.Instance.roles[GameState.Instance.currentTurn])
        {
            if (GameState.Instance.money[GameState.Instance.currentTurn] >= 2)
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
        simpleDialogue("Welche Falle willst du kaufen?", 60);
    }
    void btnBuyingInfernoTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "kleine Falle");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        localPlayer.AddItem(GameState.Instance.currentTurn, "Bomb");
        addTrueHint();
        setDialogue("Du hast dir eine Bombe gekauft.");
    }
    void btnBuyingDrMortifierTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "kleine Falle");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        localPlayer.AddItem(GameState.Instance.currentTurn, "PetriDish");
        addTrueHint();
        endTurn();
        setDialogue("Du hast dir eine Petrischale gekauft.");
    }
    void btnBuyingPhantomTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "kleine Falle");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        localPlayer.AddItem(GameState.Instance.currentTurn, "StolenGoods");
        addTrueHint();
        setDialogue("Du hast dir Diebesgut gekauft.");
    }
    void btnBuyingFascultoTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "kleine Falle");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        localPlayer.AddItem(GameState.Instance.currentTurn, "CursedArtifact");
        addTrueHint();
        setDialogue("Du hast dir ein verfluchtes Artifakt gekauft.");
    }


    void trainstationAction()
    {
        actionTextFieldString();
        ActionsTextFieldImage.sprite = imgMainsquare_Symbol;
        actionsTextField.text = "Stadtplatz";
        btnTwoText.text = "Abfahrt";
        btnOne.onClick.AddListener(btnPlaceUp);
        btnTwo.onClick.AddListener(btnTrainstationTravel);
        btnThree.onClick.AddListener(btnPlaceDown);
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 2)
        {
            btnTwo.interactable = false;
        }
        simpleDialogue("Wo fährst du hin?", 70);
    }
    void btnPlaceDown()
    {
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                actionsTextField.text = "Park";
                ActionsTextFieldImage.sprite = imgPark_Symbol;
                break;
            case "Park":
                actionsTextField.text = "Krankenhaus";
                ActionsTextFieldImage.sprite = imgHospital_Symbol;
                break;
            case "Krankenhaus":
                actionsTextField.text = "Bank";
                ActionsTextFieldImage.sprite = imgBank_Symbol;
                break;
            case "Bank":
                actionsTextField.text = "Parlament";
                ActionsTextFieldImage.sprite = imgParliament_Symbol;
                break;
            case "Parlament":
                actionsTextField.text = "Friedhof";
                ActionsTextFieldImage.sprite = imgCemetary_Symbol;
                break;
            case "Friedhof":
                actionsTextField.text = "Gefängnis";
                ActionsTextFieldImage.sprite = imgPrison_Symbol;
                break;
            case "Gefängnis":
                actionsTextField.text = "Kasino";
                ActionsTextFieldImage.sprite = imgCasino_Symbol;
                break;
            case "Kasino":
                actionsTextField.text = "Internet Cafe";
                ActionsTextFieldImage.sprite = imgInternetcafe_Symbol;
                break;
            case "Internet Cafe":
                actionsTextField.text = "Bahnhof";
                ActionsTextFieldImage.sprite = imgTrainstation_Symbol;
                break;
            case "Bahnhof":
                actionsTextField.text = "Armee Laden";
                ActionsTextFieldImage.sprite = imgArmyshop_Symbol;
                break;
            case "Armee Laden":
                actionsTextField.text = "Shopping Center";
                ActionsTextFieldImage.sprite = imgShoppingcenter_Symbol;
                break;
            case "Shopping Center":
                actionsTextField.text = "Schrottplatz";
                ActionsTextFieldImage.sprite = imgJunkyard_Symbol;
                break;
            case "Schrottplatz":
                actionsTextField.text = "Bibliothek";
                ActionsTextFieldImage.sprite = imgLibrary_Symbol;
                break;
            case "Bibliothek":
                actionsTextField.text = "Labor";
                ActionsTextFieldImage.sprite = imgLaboratory_Symbol;
                break;
            case "Labor":
                actionsTextField.text = "Italiener";
                ActionsTextFieldImage.sprite = imgItalienrestaurant_Symbol;
                break;
            case "Italiener":
                actionsTextField.text = "Hafen";
                ActionsTextFieldImage.sprite = imgHarbor_Symbol;
                break;
            case "Hafen":
                actionsTextField.text = "Bar";
                ActionsTextFieldImage.sprite = imgBar_Symbol;
                break;
            case "Bar":
                actionsTextField.text = "Stadtplatz";
                ActionsTextFieldImage.sprite = imgMainsquare_Symbol;
                break;
        }
    }

    void btnPlaceUp()
    {
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                actionsTextField.text = "Bar";
                ActionsTextFieldImage.sprite = imgBar_Symbol;
                break;
            case "Park":
                actionsTextField.text = "Stadtplatz";
                ActionsTextFieldImage.sprite = imgMainsquare_Symbol;
                break;
            case "Krankenhaus":
                actionsTextField.text = "Park";
                ActionsTextFieldImage.sprite = imgPark_Symbol;
                break;
            case "Bank":
                actionsTextField.text = "Krankenhaus";
                ActionsTextFieldImage.sprite = imgHospital_Symbol;
                break;
            case "Parlament":
                actionsTextField.text = "Bank";
                ActionsTextFieldImage.sprite = imgBank_Symbol;
                break;
            case "Friedhof":
                actionsTextField.text = "Parlament";
                ActionsTextFieldImage.sprite = imgParliament_Symbol;
                break;
            case "Gefängnis":
                actionsTextField.text = "Friedhof";
                ActionsTextFieldImage.sprite = imgCemetary_Symbol;
                break;
            case "Kasino":
                actionsTextField.text = "Gefängnis";
                ActionsTextFieldImage.sprite = imgPrison_Symbol;
                break;
            case "Internet Cafe":
                actionsTextField.text = "Kasino";
                ActionsTextFieldImage.sprite = imgCasino_Symbol;
                break;
            case "Bahnhof":
                actionsTextField.text = "Internet Cafe";
                ActionsTextFieldImage.sprite = imgInternetcafe_Symbol;
                break;
            case "Armee Laden":
                actionsTextField.text = "Bahnhof";
                ActionsTextFieldImage.sprite = imgTrainstation_Symbol;
                break;
            case "Shopping Center":
                actionsTextField.text = "Armee Laden";
                ActionsTextFieldImage.sprite = imgArmyshop_Symbol;
                break;
            case "Schrottplatz":
                actionsTextField.text = "Shopping Center";
                ActionsTextFieldImage.sprite = imgShoppingcenter_Symbol;
                break;
            case "Bibliothek":
                actionsTextField.text = "Schrottplatz";
                ActionsTextFieldImage.sprite = imgJunkyard_Symbol;
                break;
            case "Labor":
                actionsTextField.text = "Bibliothek";
                ActionsTextFieldImage.sprite = imgLibrary_Symbol;
                break;
            case "Italiener":
                actionsTextField.text = "Labor";
                ActionsTextFieldImage.sprite = imgLaboratory_Symbol;
                break;
            case "Hafen":
                actionsTextField.text = "Italiener";
                ActionsTextFieldImage.sprite = imgItalienrestaurant_Symbol;
                break;
            case "Bar":
                actionsTextField.text = "Hafen";
                ActionsTextFieldImage.sprite = imgHarbor_Symbol;
                break;
        }
    }
    void btnTrainstationTravel()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Zugticket");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(1)[0], findPosition(1)[1]);
                setDialogue("Du hast einen Zug zum Stadtplatz genommen");
                break;
            case "Park":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(2)[0], findPosition(2)[1]);
                setDialogue("Du hast einen Zug zum Park genommen");
                break;
            case "Krankenhaus":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(3)[0], findPosition(3)[1]);
                setDialogue("Du hast einen Zug zum Krankenhaus genommen");
                break;
            case "Bank":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(4)[0], findPosition(4)[1]);
                setDialogue("Du hast einen Zug zur Bank genommen");
                break;
            case "Parlament":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(5)[0], findPosition(5)[1]);
                setDialogue("Du hast einen Zug zum Parlament genommen");
                break;
            case "Friedhof":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(6)[0], findPosition(6)[1]);
                setDialogue("Du hast einen Zug zum Friedhof genommen");
                break;
            case "Gefängnis":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(7)[0], findPosition(7)[1]);
                setDialogue("Du hast einen Zug zum Gefängnis genommen");
                break;
            case "Kasino":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(8)[0], findPosition(8)[1]);
                setDialogue("Du hast einen Zug zum Kasino genommen");
                break;
            case "Internet Cafe":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(9)[0], findPosition(9)[1]);
                setDialogue("Du hast einen Zug zum Internet Cafe genommen");
                break;
            case "Bahnhof":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(10)[0], findPosition(10)[1]);
                setDialogue("Du hast einen Zug zum Bahnhof genommen");
                break;
            case "Armee Laden":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(11)[0], findPosition(11)[1]);
                setDialogue("Du hast einen Zug zum Armee Laden genommen");
                break;
            case "Shopping Center":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(12)[0], findPosition(12)[1]);
                setDialogue("Du hast einen Zug zum Shopping Center genommen");
                break;
            case "Schrottplatz":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(13)[0], findPosition(13)[1]);
                setDialogue("Du hast einen Zug zum Schrottplatz genommen");
                break;
            case "Bibliothek":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(14)[0], findPosition(14)[1]);
                setDialogue("Du hast einen Zug zur Bibliothek genommen");
                break;
            case "Labor":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(15)[0], findPosition(15)[1]);
                setDialogue("Du hast einen Zug zum Labor genommen");
                break;
            case "Italiener":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(16)[0], findPosition(16)[1]);
                setDialogue("Du hast einen Zug zum Italiener genommen");
                break;
            case "Hafen":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(17)[0], findPosition(17)[1]);
                setDialogue("Du hast einen Zug zum Hafen genommen");
                break;
            case "Bar":
                localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, findPosition(18)[0], findPosition(18)[1]);
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
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 6)
        {
            btnOne.interactable = false;
        }
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 15)
        {
            btnTwo.interactable = false;
        }
        simpleDialogue("Welche Art von Schutz?", 60);
    }
    void btnBuyProtectiveVest()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Schutzweste");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 6));
        localPlayer.AddItem(GameState.Instance.currentTurn, "ProtectiveVest");
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Feuerfester Mantel");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 15));
        localPlayer.AddItem(GameState.Instance.currentTurn, "FireProofCoat");
        setDialogue("Du hast dir einen feuerfesten Mantel gekauft.");
    }
    void btnBuyGasmask()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Gasmaske");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 15));
        localPlayer.AddItem(GameState.Instance.currentTurn, "Gasmask");
        setDialogue("Du hast dir eine Gasmaske gekauft.");
    }
    void btnBuyBodycam()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Bodycam");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 15));
        localPlayer.AddItem(GameState.Instance.currentTurn, "Bodycam");
        setDialogue("Du hast dir eine Bodycam gekauft.");
    }
    void btnBuyTalisman()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Talisman");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 15));
        localPlayer.AddItem(GameState.Instance.currentTurn, "Talisman");
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


        if (!(GameState.Instance.criminal == GameState.Instance.roles[GameState.Instance.currentTurn]))
        {
            btnSix.interactable = false;
        }
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 8)
        {
            btnFour.interactable = false;
            btnFive.interactable = false;
        }
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 4)
        {
            btnTwo.interactable = false;
        }
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 3)
        {
            btnThree.interactable = false;
        }
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 2)
        {
            btnSix.interactable = false;
            btnOne.interactable = false;
        }
        simpleDialogue("Was willst du kaufen?", 60);
    }
    void btnBuyTrainers()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Turnschuhe");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        localPlayer.AddItem(GameState.Instance.currentTurn, "Trainers");
        setDialogue("Du hast dir Turnschuhe gekauft.");
    }
    void btnBuyFingerprintKit()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Fingerabdruckset");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 4));
        localPlayer.AddItem(GameState.Instance.currentTurn, "FingerprintKit");
        setDialogue("Du hast dir ein Fingerabdruckset gekauft.");
    }
    void btnBuyEnergyDrink()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Energy Drink");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 3));
        localPlayer.AddItem(GameState.Instance.currentTurn, "EnergyDrink");
        setDialogue("Du hast dir einen Energy Drink gekauft.");
    }
    void btnBuyCalculator()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Taschenrechner");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 8));
        localPlayer.AddItem(GameState.Instance.currentTurn, "Calculator");
        setDialogue("Du hast dir einen Taschenrechner gekauft.");
    }
    void btnBuyWhiskey()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "Whiskey");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 8));
        localPlayer.AddItem(GameState.Instance.currentTurn, "Whiskey");
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
        if (GameState.Instance.criminal == GameState.Instance.roles[GameState.Instance.currentTurn])
        {
            rand = rn.Next(0, 17);
        }
        else
        {
            rand = rn.Next(0, 13);
        }
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");

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
                localPlayer.AddItem(GameState.Instance.currentTurn, "FireProofCoat");
                setDialogue("Du hast feuerfesten Manel gefunden.");
                break;
            case 6:
                localPlayer.AddItem(GameState.Instance.currentTurn, "ProtectiveVest");
                setDialogue("Du hast eine Schutzweste gefunden.");
                break;
            case 7:
                localPlayer.AddItem(GameState.Instance.currentTurn, "Gasmask");
                setDialogue("Du hast eine Gasmaske gefunden.");
                break;
            case 8:
                localPlayer.AddItem(GameState.Instance.currentTurn, "Talisman");
                setDialogue("Du hast einen Talisman gefunden.");
                break;
            case 9:
                localPlayer.AddItem(GameState.Instance.currentTurn, "Trainers");
                setDialogue("Du hast Turnschuhe gefunden.");
                break;
            case 10:
                localPlayer.AddItem(GameState.Instance.currentTurn, "FingerprintKit");
                setDialogue("Du hast ein Fingerabdruckset gefunden.");
                break;
            case 11:
                localPlayer.AddItem(GameState.Instance.currentTurn, "EnergyDrink");
                setDialogue("Du hast einen Energy Drink gefunden.");
                break;
            case 12:
                localPlayer.AddItem(GameState.Instance.currentTurn, "Calculator");
                setDialogue("Du hast einen Taschenrechner gefunden.");
                break;
            case 13:
                localPlayer.AddItem(GameState.Instance.currentTurn, "Whiskey");
                setDialogue("Du hast eine Flasche Whiskey gefunden.");
                break;
            case 14:
                localPlayer.AddItem(GameState.Instance.currentTurn, "Bomb");
                setDialogue("Du hast eine Bombe gefunden.");
                break;
            case 15:
                localPlayer.AddItem(GameState.Instance.currentTurn, "PetriDish");
                setDialogue("Du hast eine Petrischale gefunden.");
                break;
            case 16:
                localPlayer.AddItem(GameState.Instance.currentTurn, "StolenGoods");
                setDialogue("Du hast Diebesgut gefunden.");
                break;
            case 17:
                localPlayer.AddItem(GameState.Instance.currentTurn, "CursedArtifact");
                setDialogue("Du hast ein verfluchtes Artifakt gefunden.");
                break;
        }
    }
    void italienrestaurantAction()
    {
        fourButtons();
        btnOneText.text = "1$";
        btnTwoText.text = "2$";
        btnThreeText.text = "3$";
        btnFourText.text = "4$";
        btnOne.onClick.AddListener(btnItalienTwentyPercentChance);
        btnTwo.onClick.AddListener(btnItalienThirtyPercentChance);
        btnThree.onClick.AddListener(btnItalienFiftyPercentChance);
        btnFour.onClick.AddListener(btnItalienSixtyPercentChance);
        btnOne.interactable = false;
        btnTwo.interactable = false;
        btnThree.interactable = false;
        btnFour.interactable = false;
        switch (GameState.Instance.money[GameState.Instance.currentTurn])
        {
            case 0:
                break;
            case 1:
                btnOne.interactable = true;
                break;
            case 2:
                btnOne.interactable = true;
                btnTwo.interactable = true;
                break;
            case 3:
                btnOne.interactable = true;
                btnTwo.interactable = true;
                btnThree.interactable = true;
                break;
            default:
                btnOne.interactable = true;
                btnTwo.interactable = true;
                btnThree.interactable = true;
                btnFour.interactable = true;
                break;
        }
        simpleDialogue("Wieviel zahlst du für deine Spaghetti?", 60);
    }
    void btnItalienTwentyPercentChance()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "\"Italienisches Essen\"");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 1));
        chanceToGetTrueHint(2);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void btnItalienThirtyPercentChance()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "\"Italienisches Essen\"");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        chanceToGetTrueHint(3);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void btnItalienFiftyPercentChance()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "\"Italienisches Essen\"");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 3));
        chanceToGetTrueHint(5);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void btnItalienSixtyPercentChance()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "\"Italienisches Essen\"");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 4));
        chanceToGetTrueHint(6);
        setDialogue("Du hattest ein interessantes Gespräch mit dem Besitzer. Du weißt jedoch nicht ob er die Wahrheit erzählt hat.");
    }
    void harborAction()
    {
        twoButtons();
        btnOneText.text = "Hinweis - 3$";
        btnTwoText.text = "fremde Falle kaufen";
        btnOne.onClick.AddListener(btnHarborHint);
        btnTwo.onClick.AddListener(btnBuyTrap);
        if (GameState.Instance.money[GameState.Instance.currentTurn] < 3)
        {
            btnOne.interactable = false;
        }
        if (GameState.Instance.criminalRole != GameState.Instance.roles[GameState.Instance.currentTurn])
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "\"Hafenequipment\"");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 3));
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
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Ortsoption");
        localPlayer.SetLastTransaction(GameState.Instance.currentTurn, "\"ein Bier\"");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 2));
        chanceToGetTrueHint(4);

        System.Random rn = new System.Random();
        int randOne = rn.Next(0, 7);
        int randTwo = rn.Next(0, 6);
        while (GameState.Instance.board[randOne, randTwo] == 0)
        {
            randOne = rn.Next(0, 7);
            randTwo = rn.Next(0, 6);
        }
        localPlayer.SetCurrentPlace(GameState.Instance.currentTurn, randOne, randTwo);
        string place = "";
        switch (translatePlace(GameState.Instance.board[GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]]))
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
        setDialogue("Du bist auf \"ein Bier\" in die Bar gegangen. Am nächsten Morgen bis du aus irgeneinem Grun " + place + " aufgewacht. Die anderen Barbesucher haben dir eine wichtigen Hinweis gegeben aber du kannst dich nicht mehr genau daran erinnern.");
    }

    #endregion

    #region manipulation
    void btnManipulationClick()
    {
        btnBack.interactable = true;
        addTrueHint();
        twoButtons();
        btnOneText.text = "Bewegung";
        btnTwoText.text = "Hinweis";
        btnOne.onClick.AddListener(btnManipulationMovementClick);
        btnTwo.onClick.AddListener(btnManipulationHintClick);
        simpleDialogue("Welche Art von Manipulation?", 60);
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
        simpleDialogue("Wohin muss " + translateName(player) + " gehen?", 70);
        manipulatedPlayer = player;
        fiveButtons();

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(332, 333);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1, 58.5f);
        btnOne.GetComponent<Image>().sprite = threeByThree;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(349, -233.5f);
        btnTwo.GetComponent<Image>().sprite = fourByThree;

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(332, 333);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1, -526.5f);
        btnThree.GetComponent<Image>().sprite = threeByThree;

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(332, 447);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(-352, -233.5f);
        btnFour.GetComponent<Image>().sprite = fourByThree;

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(332, 215);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1, -233.5f);
        btnFive.GetComponent<Image>().sprite = twoByThree;

        btnOneBorder.gameObject.SetActive(true);
        btnOneBorder.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 170);
        btnTwoBorder.gameObject.SetActive(true);
        btnTwoBorder.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 170);
        btnThreeBorder.gameObject.SetActive(true);
        btnThreeBorder.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 170);
        btnFourBorder.gameObject.SetActive(true);
        btnFourBorder.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 170);
        btnFiveBorder.gameObject.SetActive(true);
        btnFiveBorder.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(170, 170);

        btnOneText.gameObject.SetActive(false);
        btnTwoText.gameObject.SetActive(false);
        btnThreeText.gameObject.SetActive(false);
        btnFourText.gameObject.SetActive(false);
        btnFiveText.gameObject.SetActive(false);

        int[] currentPlayerPlace = GameState.Instance.currentPlace[player];
        if (currentPlayerPlace[0] > 0)
        {
            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlayerPlace[0] - 1, currentPlayerPlace[1]]] > 0)
            {
                btnOne.interactable = false;
                btnOneText.fontSize = 50;
                btnOneText.text = "Quarantäne";
                btnOneBorder.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnOne.interactable = true;
                btnOneText.text = translatePlace(GameState.Instance.board[currentPlayerPlace[0] - 1, currentPlayerPlace[1]]);
                btnOneBorder.sprite=getPlaceSymbol(GameState.Instance.board[currentPlayerPlace[0] - 1, currentPlayerPlace[1]]);
            }

        }
        else
        {

            btnOne.interactable = false;
            btnOneText.text = "Stadtrand";
            btnOneBorder.sprite = imgEdge_Symbol;
        }
        if (currentPlayerPlace[1] < 5)
        {
            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1] + 1]] > 0)
            {
                btnTwo.interactable = false;
                btnTwoText.fontSize = 50;
                btnTwoText.text = "Quarantäne";
                btnTwoBorder.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnTwo.interactable = true;
                btnTwoText.text = translatePlace(GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1] + 1]);
                btnTwoBorder.sprite = getPlaceSymbol(GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1] + 1]);
            }
        }
        else
        {
            btnTwo.interactable = false;
            btnTwoText.text = "Stadtrand";
            btnTwoBorder.sprite = imgEdge_Symbol;
        }

        if (currentPlayerPlace[0] < 6)
        {
            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlayerPlace[0] + 1, currentPlayerPlace[1]]] > 0)
            {
                btnThree.interactable = false;
                btnThreeText.fontSize = 50;
                btnThreeText.text = "Quarantäne";
                btnThreeBorder.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnThree.interactable = true;
                btnThreeText.text = translatePlace(GameState.Instance.board[currentPlayerPlace[0] + 1, currentPlayerPlace[1]]);
                btnThreeBorder.sprite = getPlaceSymbol(GameState.Instance.board[currentPlayerPlace[0] + 1, currentPlayerPlace[1]]);
            }
        }
        else
        {
            btnThree.interactable = false;
            btnThreeText.text = "Stadtrand";
            btnThreeBorder.sprite = imgEdge_Symbol;
        }
        if (currentPlayerPlace[1] > 0)
        {
            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1] - 1]] > 0)
            {
                btnFour.interactable = false;
                btnFourText.fontSize = 50;
                btnFourText.text = "Quarantäne";
                btnFourBorder.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnFour.interactable = true;
                btnFourText.text = translatePlace(GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1] - 1]);
                btnFourBorder.sprite = getPlaceSymbol(GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1] - 1]);
            }
        }
        else
        {
            btnFour.interactable = false;
            btnFourText.text = "Stadtrand";
            btnFourBorder.sprite = imgEdge_Symbol;
        }

        if (GameState.Instance.quarantined[GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1]]] > 0)
        {
            btnFive.interactable = false;
            btnFiveText.fontSize = 50;
            btnFiveText.text = "Quarantäne";
            btnFiveBorder.sprite = imgQuarantine_Symbol;
        }
        else
        {
            btnFive.interactable = true;
            btnFiveText.text = translatePlace(GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1]]);
            btnFiveBorder.sprite = getPlaceSymbol(GameState.Instance.board[currentPlayerPlace[0], currentPlayerPlace[1]]);
        }

        btnOne.onClick.AddListener(btnManipulationUp);
        btnTwo.onClick.AddListener(btnManipulationRight);
        btnThree.onClick.AddListener(btnManipulationDown);
        btnFour.onClick.AddListener(btnManipulationLeft);
        btnFive.onClick.AddListener(btnManipulationStay);

    }

    void btnManipulationUp()
    {
        btnBack.interactable = false;
        localPlayer.SetCurrentPlace(manipulatedPlayer, GameState.Instance.currentPlace[manipulatedPlayer][0] - 1, GameState.Instance.currentPlace[manipulatedPlayer][1]);
        if (firstMovementManipulation && GameState.Instance.board[GameState.Instance.currentPlace[manipulatedPlayer][0], GameState.Instance.currentPlace[manipulatedPlayer][1]] == 0)
        {
            btnBack.interactable = false;
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
            localPlayer.SetIsMovementManipulated(manipulatedPlayer, true);
            firstMovementManipulation = false;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationRight()
    {
        btnBack.interactable = false;
        localPlayer.SetCurrentPlace(manipulatedPlayer, GameState.Instance.currentPlace[manipulatedPlayer][0], GameState.Instance.currentPlace[manipulatedPlayer][1] + 1);
        if (firstMovementManipulation && GameState.Instance.board[GameState.Instance.currentPlace[manipulatedPlayer][0], GameState.Instance.currentPlace[manipulatedPlayer][1]] == 0)
        {
            btnBack.interactable = false;
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
            localPlayer.SetIsMovementManipulated(manipulatedPlayer, true);
            firstMovementManipulation = false;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationDown()
    {
        btnBack.interactable = false;
        localPlayer.SetCurrentPlace(manipulatedPlayer, GameState.Instance.currentPlace[manipulatedPlayer][0] + 1, GameState.Instance.currentPlace[manipulatedPlayer][1]);
        if (firstMovementManipulation && GameState.Instance.board[GameState.Instance.currentPlace[manipulatedPlayer][0], GameState.Instance.currentPlace[manipulatedPlayer][1]] == 0)
        {
            btnBack.interactable = false;
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
            localPlayer.SetIsMovementManipulated(manipulatedPlayer, true);
            firstMovementManipulation = false;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationLeft()
    {
        btnBack.interactable = false;
        localPlayer.SetCurrentPlace(manipulatedPlayer, GameState.Instance.currentPlace[manipulatedPlayer][0], GameState.Instance.currentPlace[manipulatedPlayer][1] - 1);
        if (firstMovementManipulation && GameState.Instance.board[GameState.Instance.currentPlace[manipulatedPlayer][0], GameState.Instance.currentPlace[manipulatedPlayer][1]] == 0)
        {
            btnBack.interactable = false;
            firstMovementManipulation = false;
            MovementManipulation(manipulatedPlayer);
        }
        else
        {
            localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
            localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
            localPlayer.SetIsMovementManipulated(manipulatedPlayer, true);
            firstMovementManipulation = false;
            MovementManipulationDialogue();
        }
    }
    void btnManipulationStay()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
        localPlayer.SetIsMovementManipulated(manipulatedPlayer, true);
        btnBack.interactable = false;
        firstMovementManipulation = false;
        MovementManipulationDialogue();
    }

    void MovementManipulationDialogue()
    {
        string name = translateName(manipulatedPlayer);
        string place = "";
        int currentManipulatedPlace = GameState.Instance.board[GameState.Instance.currentPlace[manipulatedPlayer][0], GameState.Instance.currentPlace[manipulatedPlayer][1]];
        if (currentManipulatedPlace == 0 || currentManipulatedPlace == 14 || currentManipulatedPlace == 18 || currentManipulatedPlace == 4)
        {
            place = "zur " + translatePlace(currentManipulatedPlace);
        }
        else
        {
            place = "zum " + translatePlace(currentManipulatedPlace);
        }
        switch (GameState.Instance.criminalRole)
        {
            case "Inferno":
                setDialogue("Mit einer ferngesteuerten Bombe hast du " + name + " dazu gezwungen " + place + " zu gehen.");
                break;
            case "Dr.Mortifier":
                setDialogue("Mit einem spezielen Virus hast du " + name + " dazu gezwunden " + place + " zu gehen.");
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
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
        if (GameState.Instance.trueUnsolveds[0] > 0)
        {
            localPlayer.SetTrueUnsolveds(0, (GameState.Instance.trueSolveds[0] - 1));
            localPlayer.SetUnsolvedHints(0, (GameState.Instance.unsolvedHints[0] - 1));
        }
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
        HintManipulationDialogue(0);
    }
    void btnPlayerTwoClickManipulationHint()
    {
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
        if (GameState.Instance.trueUnsolveds[1] > 0)
        {
            localPlayer.SetTrueUnsolveds(1, (GameState.Instance.trueSolveds[1] - 1));
            localPlayer.SetUnsolvedHints(1, (GameState.Instance.unsolvedHints[1] - 1));
        }
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
        HintManipulationDialogue(1);
    }
    void btnPlayerThreeClickManipulationHint()
    {
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
        if (GameState.Instance.trueUnsolveds[2] > 0)
        {
            localPlayer.SetTrueUnsolveds(2, (GameState.Instance.trueSolveds[2] - 1));
            localPlayer.SetUnsolvedHints(2, (GameState.Instance.unsolvedHints[2] - 1));
        }
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
        HintManipulationDialogue(2);
    }
    void btnPlayerFourClickManipulationHint()
    {
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
        if (GameState.Instance.trueUnsolveds[3] > 0)
        {
            localPlayer.SetTrueUnsolveds(3, (GameState.Instance.trueSolveds[3] - 1));
            localPlayer.SetUnsolvedHints(3, (GameState.Instance.unsolvedHints[3] - 1));
        }
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
        HintManipulationDialogue(3);
    }
    void btnPlayerFiveClickManipulationHint()
    {
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
        if (GameState.Instance.trueUnsolveds[4] > 0)
        {
            localPlayer.SetTrueUnsolveds(4, (GameState.Instance.trueSolveds[4] - 1));
            localPlayer.SetUnsolvedHints(4, (GameState.Instance.unsolvedHints[4] - 1));
        }
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
        HintManipulationDialogue(4);
    }
    void btnPlayerSixClickManipulationHint()
    {
        localPlayer.SetMoney(GameState.Instance.currentTurn, (GameState.Instance.money[GameState.Instance.currentTurn] - 10));
        if (GameState.Instance.trueUnsolveds[5] > 0)
        {
            localPlayer.SetTrueUnsolveds(5, (GameState.Instance.trueSolveds[5] - 1));
            localPlayer.SetUnsolvedHints(5, (GameState.Instance.unsolvedHints[5] - 1));
        }
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Manipulation");
        HintManipulationDialogue(5);
    }

    void HintManipulationDialogue(int player)
    {
        string name = translateName(player);
        localPlayer.SetIsHintManipulated(player, true);
        switch (GameState.Instance.criminalRole)
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
        btnBack.interactable = true;

        playerButtons();
        btnOne.onClick.AddListener(btnPlayerOneClickBigTrap);
        btnTwo.onClick.AddListener(btnPlayerTwoClickBigTrap);
        btnThree.onClick.AddListener(btnPlayerThreeClickBigTrap);
        btnFour.onClick.AddListener(btnPlayerFourClickBigTrap);
        btnFive.onClick.AddListener(btnPlayerFiveClickBigTrap);
        btnSix.onClick.AddListener(btnPlayerSixClickBigTrap);

        simpleDialogue("Wähle einen Spieler aus.", 80);
    }
    void btnPlayerOneClickBigTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Große Falle");
        activatedTrap(0, findTargetPosition(GameState.Instance.criminalRole));
        localPlayer.SetBigTrapUsed(true);
        addTrueHint();
        bigTrapDialogue(0);
    }
    void btnPlayerTwoClickBigTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Große Falle");
        activatedTrap(1, findTargetPosition(GameState.Instance.criminalRole));
        localPlayer.SetBigTrapUsed(true);
        addTrueHint();
        bigTrapDialogue(1);
    }
    void btnPlayerThreeClickBigTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Große Falle");
        activatedTrap(2, findTargetPosition(GameState.Instance.criminalRole));
        localPlayer.SetBigTrapUsed(true);
        addTrueHint();
        bigTrapDialogue(2);
    }
    void btnPlayerFourClickBigTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Große Falle");
        activatedTrap(3, findTargetPosition(GameState.Instance.criminalRole));
        localPlayer.SetBigTrapUsed(true);
        addTrueHint();
        bigTrapDialogue(3);
    }
    void btnPlayerFiveClickBigTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Große Falle");
        activatedTrap(4, findTargetPosition(GameState.Instance.criminalRole));
        localPlayer.SetBigTrapUsed(true);
        addTrueHint();
        bigTrapDialogue(4);
    }
    void btnPlayerSixClickBigTrap()
    {
        localPlayer.SetLastAction(GameState.Instance.currentTurn, "Große Falle");
        activatedTrap(5, findTargetPosition(GameState.Instance.criminalRole));
        localPlayer.SetBigTrapUsed(true);
        addTrueHint();
        bigTrapDialogue(5);
    }

    void bigTrapDialogue(int player)
    {
        string s = "";
        string name = translateName(player);
        switch (GameState.Instance.criminalRole)
        {
            case "Inferno":
                s = "Du hast " + name + " mit einer kleinen Rakete getroffen.";
                break;
            case "Dr.Mortifier":
                s = "Du hast " + name + " mit einer starken Grippe infiziert.";
                break;
            case "Phantom":
                s = "Du hast Diebesgut in der Wohnung von " + name + " platziert.";
                break;
            case "Fasculto":
                s = "Du hast " + name + " mit einem Unglücksfluch belegt und dadurch eine einige kleine Unfälle ausgelöst.";
                break;
        }


        setDialogue(s);
    }
    #endregion

    #region LayoutFunctions

    void oneButton()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(565, 450);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1.5f, -233f);
        btnOne.GetComponent<Image>().sprite = fourByFive;
        btnOneText.fontSize = 180;
        btnOne.interactable = true;
    }
    void twoButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(799, 450);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-118.5f, 0);
        btnOne.GetComponent<Image>().sprite = fourBySeven;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(799, 450);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(116.5f, -468);
        btnOne.GetComponent<Image>().sprite = fourBySeven;

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

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 333);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-118, 58.5f);
        btnOne.GetComponent<Image>().sprite = threeBySeven;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(1034, 214);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1, -233);
        btnTwo.GetComponent<Image>().sprite = twoByNine;

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 333);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(115, -526.5f);
        btnThree.GetComponent<Image>().sprite = threeBySeven;

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

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 215);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-118, 118.5f);
        btnOne.GetComponent<Image>().sprite = twoBySeven;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 215);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(117, -115.5f);
        btnTwo.GetComponent<Image>().sprite = twoBySeven;

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 215);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-118, -351.5f);
        btnThree.GetComponent<Image>().sprite = twoBySeven;

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 215);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(117, -584.5f);
        btnFour.GetComponent<Image>().sprite = twoBySeven;

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

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 333);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-235, 58.5f);
        btnOne.GetComponent<Image>().sprite = threeByFive;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(449, 333);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(290.5f, 58.5f);
        btnTwo.GetComponent<Image>().sprite = threeByFour;

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(1034, 214);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1, -233);
        btnThree.GetComponent<Image>().sprite = twoByNine;

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(449, 333);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(-293.5f, -525.5f);
        btnFour.GetComponent<Image>().sprite = threeByFour;

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 333);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(233, -525.5f);
        btnFive.GetComponent<Image>().sprite = threeByFive;

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

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 333);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-235, 58.5f);
        btnOne.GetComponent<Image>().sprite = threeByFive;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(449, 333);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(290.5f, 58.5f);
        btnTwo.GetComponent<Image>().sprite = threeByFour;

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(449, 215);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-293.5f, -233);
        btnThree.GetComponent<Image>().sprite = twoByFour;

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 215);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(233, -233);
        btnFour.GetComponent<Image>().sprite = twoByFive;

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 333);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(-235, -525.5f);
        btnFive.GetComponent<Image>().sprite = threeByFive;

        btnSix.GetComponent<RectTransform>().sizeDelta = new Vector2(449, 333);
        btnSix.GetComponent<RectTransform>().anchoredPosition = new Vector2(290.5f, -525.5f);
        btnSix.GetComponent<Image>().sprite = threeByFour;

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

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 217);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-235, 116.5f);
        btnOne.GetComponent<Image>().sprite = twoByFive;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(448, 217);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(290.5f, 116.5f);
        btnTwo.GetComponent<Image>().sprite = twoByFour;

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(448, 217);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(-294, -117.5f);
        btnThree.GetComponent<Image>().sprite = twoByFour;

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 217);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(233, -117.5f);
        btnFour.GetComponent<Image>().sprite = twoByFive;

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 217);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(-235, -351.5f);
        btnFive.GetComponent<Image>().sprite = twoByFive;

        btnSix.GetComponent<RectTransform>().sizeDelta = new Vector2(448, 217);
        btnSix.GetComponent<RectTransform>().anchoredPosition = new Vector2(290.5f, -351.5f);
        btnSix.GetComponent<Image>().sprite = twoByFour;

        btnSeven.GetComponent<RectTransform>().sizeDelta = new Vector2(448, 217);
        btnSeven.GetComponent<RectTransform>().anchoredPosition = new Vector2(-294, -585.5f);
        btnSeven.GetComponent<Image>().sprite = twoByFour;

        btnEight.GetComponent<RectTransform>().sizeDelta = new Vector2(566, 217);
        btnEight.GetComponent<RectTransform>().anchoredPosition = new Vector2(233, -585.5f);
        btnEight.GetComponent<Image>().sprite = twoByFive;

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

        btnOneText.gameObject.SetActive(true);
        btnTwoText.gameObject.SetActive(true);
        btnThreeText.gameObject.SetActive(true);
        btnFourText.gameObject.SetActive(true);
        btnFiveText.gameObject.SetActive(true);
        btnSixText.gameObject.SetActive(true);
        btnSevenText.gameObject.SetActive(true);
        btnEightText.gameObject.SetActive(true);


        btnOneImage.color = new Color(255, 255, 255, 255);
        btnTwoImage.color = new Color(255, 255, 255, 255);
        btnThreeImage.color = new Color(255, 255, 255, 255);
        btnFourImage.color = new Color(255, 255, 255, 255);
        btnFiveImage.color = new Color(255, 255, 255, 255);
        btnSixImage.color = new Color(255, 255, 255, 255);

        btnOneMask.gameObject.SetActive(false);
        btnOneImage.gameObject.SetActive(false);
        btnOneBorder.gameObject.SetActive(false);
        btnTwoMask.gameObject.SetActive(false);
        btnTwoImage.gameObject.SetActive(false);
        btnTwoBorder.gameObject.SetActive(false);
        btnThreeMask.gameObject.SetActive(false);
        btnThreeImage.gameObject.SetActive(false);
        btnThreeBorder.gameObject.SetActive(false);
        btnFourMask.gameObject.SetActive(false);
        btnFourImage.gameObject.SetActive(false);
        btnFourBorder.gameObject.SetActive(false);
        btnFiveMask.gameObject.SetActive(false);
        btnFiveImage.gameObject.SetActive(false);
        btnFiveBorder.gameObject.SetActive(false);
        btnSixMask.gameObject.SetActive(false);
        btnSixImage.gameObject.SetActive(false);
        btnSixBorder.gameObject.SetActive(false);
        btnSevenMask.gameObject.SetActive(false);
        btnSevenImage.gameObject.SetActive(false);
        btnSevenBorder.gameObject.SetActive(false);
        btnEightMask.gameObject.SetActive(false);
        btnEightImage.gameObject.SetActive(false);
        btnEightBorder.gameObject.SetActive(false);

        btnOne.targetGraphic = btnOne.GetComponent<Image>();
        btnTwo.targetGraphic = btnTwo.GetComponent<Image>();
        btnThree.targetGraphic = btnThree.GetComponent<Image>();
        btnFour.targetGraphic = btnFour.GetComponent<Image>();
        btnFive.targetGraphic = btnFive.GetComponent<Image>();
        btnSix.targetGraphic = btnSix.GetComponent<Image>();

        up.gameObject.SetActive(false);
        down.gameObject.SetActive(false);

        actionsTextField.gameObject.SetActive(false);

        actionsTextFieldPanel.gameObject.SetActive(false);
        actionsTextFieldPanel.color = new Color(255, 255, 255, 255);
    }
    void playerButtons()
    {
        sixButtons();

        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(-351.5f, 1.5f);
        btnOne.GetComponent<Image>().sprite = fourByThree;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0.5f, 1.5f);
        btnTwo.GetComponent<Image>().sprite = fourByThree;

        btnThree.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnThree.GetComponent<RectTransform>().anchoredPosition = new Vector2(349.5f, 1.5f);
        btnThree.GetComponent<Image>().sprite = fourByThree;

        btnFour.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnFour.GetComponent<RectTransform>().anchoredPosition = new Vector2(-351.5f, -466.5f);
        btnFour.GetComponent<Image>().sprite = fourByThree;

        btnFive.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnFive.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0.5f, -466.5f);
        btnFive.GetComponent<Image>().sprite = fourByThree;

        btnSix.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnSix.GetComponent<RectTransform>().anchoredPosition = new Vector2(349.5f, -466.5f);
        btnSix.GetComponent<Image>().sprite = fourByThree;

        btnOne.targetGraphic = btnOneImage;
        btnTwo.targetGraphic = btnTwoImage;
        btnThree.targetGraphic = btnThreeImage;
        btnFour.targetGraphic = btnFourImage;
        btnFive.targetGraphic = btnFiveImage;
        btnSix.targetGraphic = btnSixImage;

        btnFour.interactable = false;
        btnFive.interactable = false;
        btnSix.interactable = false;
        btnFourImage.color = new Color(0, 0, 0, 255);
        btnFiveImage.color = new Color(0, 0, 0, 255);
        btnSixImage.color = new Color(0, 0, 0, 255);


        btnOneText.text = "";
        btnTwoText.text = "";
        btnThreeText.text = "";
        btnFourText.text = "";
        btnFiveText.text = "";
        btnSixText.text = "";

        btnOneMask.gameObject.SetActive(true);
        btnOneImage.gameObject.SetActive(true);
        btnOneBorder.gameObject.SetActive(true);
        btnTwoMask.gameObject.SetActive(true);
        btnTwoImage.gameObject.SetActive(true);
        btnTwoBorder.gameObject.SetActive(true);
        btnThreeMask.gameObject.SetActive(true);
        btnThreeImage.gameObject.SetActive(true);
        btnThreeBorder.gameObject.SetActive(true);
        btnFourMask.gameObject.SetActive(true);
        btnFourImage.gameObject.SetActive(true);
        btnFourBorder.gameObject.SetActive(true);
        btnFiveMask.gameObject.SetActive(true);
        btnFiveImage.gameObject.SetActive(true);
        btnFiveBorder.gameObject.SetActive(true);
        btnSixMask.gameObject.SetActive(true);
        btnSixImage.gameObject.SetActive(true);
        btnSixBorder.gameObject.SetActive(true);

        btnOneMask.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnOneMask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnOneMask.sprite = fourByThree;

        btnTwoMask.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnTwoMask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnTwoMask.sprite = fourByThree;

        btnThreeMask.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnThreeMask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnThreeMask.sprite = fourByThree;

        btnFourMask.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnFourMask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnFourMask.sprite = fourByThree;

        btnFiveMask.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnFiveMask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnFiveMask.sprite = fourByThree;

        btnSixMask.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnSixMask.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnSixMask.sprite = fourByThree;

        btnOneBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnOneBorder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnOneBorder.sprite = fourByThree_Border;

        btnTwoBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnTwoBorder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnTwoBorder.sprite = fourByThree_Border;

        btnThreeBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnThreeBorder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnThreeBorder.sprite = fourByThree_Border;

        btnFourBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnFourBorder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnFourBorder.sprite = fourByThree_Border;

        btnFiveBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnFiveBorder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnFiveBorder.sprite = fourByThree_Border;

        btnSixBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(333, 447);
        btnSixBorder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        btnSixBorder.sprite = fourByThree_Border;
        btnOneImage.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
        btnOneImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -40);
        btnOneImage.GetComponent<Image>().sprite = getPlayerPic(0);

        btnTwoImage.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
        btnTwoImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -40);
        btnTwoImage.GetComponent<Image>().sprite = getPlayerPic(1);

        btnThreeImage.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
        btnThreeImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -40);
        btnThreeImage.GetComponent<Image>().sprite = getPlayerPic(2);

        btnFourImage.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
        btnFourImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -40);
        btnFourImage.GetComponent<Image>().sprite = getPlayerPic(3);

        btnFiveImage.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
        btnFiveImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -40);
        btnFiveImage.GetComponent<Image>().sprite = getPlayerPic(4);

        btnSixImage.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
        btnSixImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -40);
        btnSixImage.GetComponent<Image>().sprite = getPlayerPic(5);


        switch (GameState.Instance.playerCount)
        {
            case 4:
                btnFour.interactable = true;
                btnFourImage.color = new Color(255, 255, 255, 255);
                break;
            case 5:
                btnFour.interactable = true;
                btnFive.interactable = true;
                btnFourImage.color = new Color(255, 255, 255, 255);
                btnFiveImage.color = new Color(255, 255, 255, 255);
                break;
            case 6:
                btnFour.interactable = true;
                btnFive.interactable = true;
                btnSix.interactable = true;
                btnFourImage.color = new Color(255, 255, 255, 255);
                btnFiveImage.color = new Color(255, 255, 255, 255);
                btnSixImage.color = new Color(255, 255, 255, 255);
                break;
        }
    }
    void actionTextFieldNumber()
    {
        threeButtons();
        actionsTextField.gameObject.SetActive(true);
        actionsTextFieldPanel.gameObject.SetActive(true);

        actionsTextFieldPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(214, 214);
        actionsTextFieldPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-411, -233);
        actionsTextFieldPanel.GetComponent<Image>().sprite = twoByTwo;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 214);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(116, -233);
        btnTwo.GetComponent<Image>().sprite = twoBySeven;

        btnOneText.text = "";
        btnThreeText.text = "";

        up.gameObject.SetActive(true);
        down.gameObject.SetActive(true);

        actionsTextField.gameObject.SetActive(true);
        ActionsTextFieldImage.gameObject.SetActive(false);
    }
    void actionTextFieldString()
    {
        threeButtons();
        actionsTextField.gameObject.SetActive(true);
        actionsTextFieldPanel.gameObject.SetActive(true);

        actionsTextFieldPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(214, 214);
        actionsTextFieldPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-411, -233);
        actionsTextFieldPanel.GetComponent<Image>().sprite = twoByTwo;

        btnTwo.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 214);
        btnTwo.GetComponent<RectTransform>().anchoredPosition = new Vector2(116, -233);
        btnTwo.GetComponent<Image>().sprite = twoBySeven;

        btnOneText.text = "";
        btnThreeText.text = "";

        up.gameObject.SetActive(true);
        down.gameObject.SetActive(true);

        actionsTextField.gameObject.SetActive(false);
        ActionsTextFieldImage.gameObject.SetActive(true);
    }
    #endregion

    #region Useful functions
    Sprite getPlayerPic(int player)
    {
        Sprite s = mckay;
        if (player < GameState.Instance.playerCount)
        {
            switch (GameState.Instance.roles[player])
            {
                case "Doctor":
                    s = mckay;
                    break;
                case "Police":
                    s = fields;
                    break;
                case "Detective":
                    s = cooper;
                    break;
                case "Psychic":
                    s = osswald;
                    break;
                case "Psychologist":
                    s = larson;
                    break;
                case "Reporter":
                    s = edmond;
                    break;
            }
        }
        else
        {
            List<string> leftOverPlayers = new List<string>();
            if (!GameState.Instance.roles.Contains("Doctor"))
            {
                leftOverPlayers.Add("Doctor");
            }
            if (!GameState.Instance.roles.Contains("Police"))
            {
                leftOverPlayers.Add("Police");
            }
            if (!GameState.Instance.roles.Contains("Detective"))
            {
                leftOverPlayers.Add("Detective");
            }
            if (!GameState.Instance.roles.Contains("Psychic"))
            {
                leftOverPlayers.Add("Psychic");
            }
            if (!GameState.Instance.roles.Contains("Psychologist"))
            {
                leftOverPlayers.Add("Psychologist");
            }
            if (!GameState.Instance.roles.Contains("Reporter"))
            {
                leftOverPlayers.Add("Reporter");
            }
            switch (leftOverPlayers[player - GameState.Instance.playerCount])
            {
                case "Doctor":
                    s = mckay;
                    break;
                case "Police":
                    s = fields;
                    break;
                case "Detective":
                    s = cooper;
                    break;
                case "Psychic":
                    s = osswald;
                    break;
                case "Psychologist":
                    s = larson;
                    break;
                case "Reporter":
                    s = edmond;
                    break;
            }
        }
        return s;
    }


    string translateName(int player)
    {
        string name = "";
        switch (GameState.Instance.roles[player])
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
        StopCoroutine("TypeWriter");
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
            yield return new WaitForSeconds(0.01f);
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }


    int[] findTargetPosition(string criminalRole)
    {
        int[] targetPosition = new int[2];
        if (criminalRole == "Phantom")
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (GameState.Instance.board[i, j] == 7)
                    {
                        targetPosition[0] = i;
                        targetPosition[1] = j;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (GameState.Instance.board[i, j] == 3)
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
        localPlayer.SetMoney(player, 0);
        localPlayer.SetCurrentPlace(player, targetPosition[0], targetPosition[1]);
        localPlayer.SetIsDisabled(player, 2);
    }
    Sprite getPlaceSymbol(int place)
    {
        Sprite s = imgStreet_Symbol;
        switch (place)
        {
            case 1:
                s = imgMainsquare_Symbol;

                break;
            case 2:
                s = imgPark_Symbol;

                break;
            case 3:
                s = imgHospital_Symbol;

                break;
            case 4:
                s = imgBank_Symbol;

                break;
            case 5:
                s = imgParliament_Symbol;

                break;
            case 6:
                s = imgCemetary_Symbol;

                break;
            case 7:
                s = imgPrison_Symbol;

                break;
            case 8:
                s = imgCasino_Symbol;

                break;
            case 9:
                s = imgInternetcafe_Symbol;

                break;
            case 10:
                s = imgTrainstation_Symbol;

                break;
            case 11:
                s = imgArmyshop_Symbol;

                break;
            case 12:
                s = imgShoppingcenter_Symbol;

                break;
            case 13:
                s = imgJunkyard_Symbol;

                break;
            case 14:
                s = imgLibrary_Symbol;

                break;
            case 15:
                s = imgLaboratory_Symbol;

                break;
            case 16:
                s = imgItalienrestaurant_Symbol;

                break;
            case 17:
                s = imgHarbor_Symbol;

                break;
            case 18:
                s = imgBar_Symbol;

                break;
        }
        return s;
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
    void setDescription(int place)
    {
        switch (place)
        {
            case 0:
                simpleDialogue("Du befindest dich auf einer der vielen Straßen Westfields, auf dem ersten Blick wirkt alles normal aber vielleicht gibt es was zum entdecken.", 45);
                break;
            case 1:
                simpleDialogue("Du befindest dich am Stadtplatz. Wie an den meisten Tagen herrscht reges Geschehen doch jeder scheint sich nur auf sich selbst zu konzentrieren.", 45);
                break;
            case 2:
                simpleDialogue("Du befindest dich im Park. Als du dich umsiehst siehst du nur ein altes Ehepaar welches die Enten füttert und ein paar Obdachlose die im Kreis um eine Mülltonne stehen.", 50);
                break;
            case 3:
                simpleDialogue("Du befindest dich im Krankenhaus. Es sieht alles sehr steril aus und um dich herum siehst du Ärzte und Krankenpfleger welche hektisch von Raum zu Raum gehen.", 50);
                break;
            case 4:
                simpleDialogue("Du befindest dich in der Bank. Um dich herum ist nur ein Angestellter welcher am Schalter steht und zwei Kunden welche gerade etwas Geld am Automaten abheben.", 50);
                break;
            case 5:
                simpleDialogue("Du befindest dich im Parlamentsgebäude. Um dich herum siehst du einige Politiker und Politikerinnen die sich rege miteinander unterhalten.", 50);
                break;
            case 6:
                simpleDialogue("Du befindest dich auf dem Friedhof. Obwohl dich die Atmosphere an diesem Ort etwas verunsichert weist du, dass du nicht ohne Grund hier bist.", 50);
                break;
            case 7:
                simpleDialogue("Du befindest dich im Gefängnis. Durch ein Fenster siehst du ein Paar Häftlinge in orangenen Overalls und geglegentlich eine Wache.", 50);
                break;
            case 8:
                simpleDialogue("Du befindest dich im Kasino. Als du dich umsiehst siehst du einige Leute in Abendgardrobe, außerdem hörst du das klingen und klirren von Spielchips und Sektflöten", 50);
                break;
            case 9:
                simpleDialogue("Du befindest dich im Internetcafe. Um dich herum nimmst du das klacken von Tastaturen und den Geruch ungewaschener Körper wahr.", 50);
                break;
            case 10:
                simpleDialogue("Du befindest dich auf dem Bahnhof. Du siehst dich um und siehst eine Menge an hektischer Menschen und leuchtenden Anzeigetafeln.", 50);
                break;
            case 11:
                simpleDialogue("Du befindest dich im Armeeladen. Als du den Laden betrittst siehst du verschiedenste Waffen an der Wand hängen und der Verkäufer nickt dir grimmig zu.", 50);
                break;
            case 12:
                simpleDialogue("Du befindest dich im Einkauszentrum. Um dich herum sind Leute die hektisch mit ihren Einkaufstaschen von Laden zu Laden hetzen als wollten sie so schnell wie möglich hier raus.", 50);
                break;
            case 13:
                simpleDialogue("Du befindest dich auf dem Schrottplatz. Um dich herum siehst du alte verschrottete Autos und diverse andere altes Zeug welches augenscheinlich schon seit Jahren hier liegt.", 50);
                break;
            case 14:
                simpleDialogue("Du befindest dich in der Bibliothek. Du siehst nur ein Paar junge Studenten die in ihre Bücher vertieft sind. Gelegentlich hört man ein verärgertes \"Psst\".", 50);
                break;
            case 15:
                simpleDialogue("Du befindest dich im Labor. Du versuchst dich an den chemischen Geruch zu gewöhnen während du den Forscher beim arbeiten zuschaust.", 50);
                break;
            case 16:
                simpleDialogue("Du befindest dich im italienischen Restaurant. Der Geruch von Tomatensoße liegt in der Luft und der Besitzer ruft dir ein freundliches \"buongiorno\" zu.", 50);
                break;
            case 17:
                simpleDialogue("Du befindest dich am Hafen. Du riechst den Geruch des Meeres und siehst eine Gruppe von Hafenarbeitern bei den Docks stehen.", 50);
                break;
            case 18:
                simpleDialogue("Du befindest dich in der Bar. Du siehst die gewöhnlichen Stammkunden und wiederstehst dem Verlangen augenblicklich ein Bier zu bestellen.", 50);
                break;
        }
    }
    void addTrueHint()
    {
        for (int i = 0; i < GameState.Instance.playerCount; i++)
        {
            localPlayer.SetNotFoundTrue(i, GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1], (GameState.Instance.notFoundTrue[i][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] + 1));

        }
    }

    void addFalseHint()
    {
        for (int i = 0; i < GameState.Instance.playerCount; i++)
        {
            localPlayer.SetNotFoundFalse(i, GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1], (GameState.Instance.notFoundFalse[i][GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] + 1));
        }
    }

    void chanceToGetTrueHint(int chance)
    {
        localPlayer.SetSolvedHints(GameState.Instance.currentTurn, (GameState.Instance.solvedHints[GameState.Instance.currentTurn] + 1));
        System.Random rn = new System.Random();
        int randomHint = rn.Next(1, 10);
        if (randomHint < chance)
        {
            localPlayer.SetTrueSolveds(GameState.Instance.currentTurn, (GameState.Instance.trueSolveds[GameState.Instance.currentTurn] + 1));
            checkForFact();
        }
    }

    int[] findPosition(int place)
    {
        int[] position = new int[2];
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (GameState.Instance.board[i, j] == place)
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

        if (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] < 3)
        {
            if ((GameState.Instance.trueSolveds[GameState.Instance.currentTurn] - (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] * 3)) >= 3)
            {
                System.Random rn = new System.Random();
                int randomFact = rn.Next(0, 3);
                switch (randomFact)
                {
                    case 0:
                        if (GameState.Instance.playerFact[GameState.Instance.currentTurn] == "")
                        {
                            string playerFact = "";
                            for (int i = 0; i < GameState.Instance.playerCount; i++)
                            {
                                if (GameState.Instance.roles[i] == GameState.Instance.criminal)
                                {
                                    playerFact = translateName(i);
                                }
                            }
                            localPlayer.SetPlayerFact(GameState.Instance.currentTurn, playerFact);
                            localPlayer.SetSolvedFacts(GameState.Instance.currentTurn, (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] + 1));
                            if ((GameState.Instance.trueSolveds[GameState.Instance.currentTurn] - (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] * 3)) >= 3)
                            {
                                return checkForFact();
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return checkForFact();
                        }
                    case 1:
                        if (GameState.Instance.placeFact[GameState.Instance.currentTurn] == "")
                        {
                            localPlayer.SetPlaceFact(GameState.Instance.currentTurn, translatePlace(GameState.Instance.targetPlace));
                            localPlayer.SetSolvedFacts(GameState.Instance.currentTurn, (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] + 1));
                            if ((GameState.Instance.trueSolveds[GameState.Instance.currentTurn] - (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] * 3)) >= 3)
                            {
                                return checkForFact();
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return checkForFact();
                        }
                    case 2:
                        if (GameState.Instance.roleFact[GameState.Instance.currentTurn] == "")
                        {
                            localPlayer.SetRoleFact(GameState.Instance.currentTurn, GameState.Instance.criminalRole);
                            localPlayer.SetSolvedFacts(GameState.Instance.currentTurn, (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] + 1));
                            if ((GameState.Instance.trueSolveds[GameState.Instance.currentTurn] - (GameState.Instance.solvedFacts[GameState.Instance.currentTurn] * 3)) >= 3)
                            {
                                return checkForFact();
                            }
                            else
                            {
                                return true;
                            }
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
