﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    private Place scriptPlace;
    public Canvas place;
    public GameObject movementController;
    public Canvas movement;
    private Movement scriptMovement;
    public Text placeName;
    public Image image;

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

    public Text btnOneText;
    public Text btnTwoText;
    public Text btnThreeText;
    public Text btnFourText;
    public Text btnFiveText;
    public Text btnSixText;
    public Text btnSevenText;
    public Text btnEightText;

    private int currentPlace;

    void Awake()
    {
        scriptPlace = GetComponent<Place>();
        scriptPlace.enabled = false;
        place.enabled = false;
    }
    void Start()
    {
        
      
    }
    void OnEnable()
    {
        scriptMovement = movementController.GetComponent<Movement>();
        scriptPlace = GetComponent<Place>();
        currentPlace = GameState.board[GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        Debug.Log(currentPlace);
        translatePlace(currentPlace);
        //menu if its a street
        if (currentPlace == 0)
        {
            oneButton();
            btnOneText.text = "Umschauen";
            btnOne.onClick.AddListener(btnLookAroundClick);
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
                    else
                    {
                        if (GameState.targetPlace == currentPlace)
                        {
                            btnEight.interactable = true;
                            btnEightText.text = "Verbrechen ausführen";
                        }
                    }
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

    }

    void toMovement()
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
        if (GameState.roles[GameState.currentTurn] == GameState.criminal) { }
        if (GameState.currentTurn == GameState.playerCount - 1)
        {
            GameState.currentTurn = 0;
        }
        else
        {
            GameState.currentTurn++;
        }
        if (GameState.isDisabled[GameState.currentTurn] > 0)
        {
            Debug.Log(GameState.roles[GameState.currentTurn] + " is still disabled");
            GameState.isDisabled[GameState.currentTurn]--;
            toMovement();
        }
        else
        {
            place.enabled = false;
            movement.enabled = true;
            scriptMovement.enabled = true;
            scriptPlace.enabled = false;
        }

    }

    //TODO: add Random Events
    void btnLookAroundClick()
    {
        Debug.Log("Du schaust dich um und ... bemerkst nichts außergewöhnliches");
        toMovement();
    }

    //TODO: add Functionality;
    void btnUseItemClick()
    {
        toMovement();
    }

    //TODO: add Functionality;
    void btnSmallTrapClick()
    {
        addTrueHint();


        toMovement();
    }

    //TODO: action for commiting the crime with time aspekt
    void btnActivateQuestPlaceClick()
    {
        GameState.money[GameState.currentTurn] -= 6;
        addTrueHint();
        if (GameState.activatedQuestPlaces < 3)
        {
            GameState.questPlaces.Remove(currentPlace);
            GameState.activatedQuestPlaces++;
        }
        else
        {
            //TODO action for planted 
        }

        toMovement();
    }
    void btnPlaceOptionClick()
    {
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
    void btnFindHintClick()
    {
        GameState.unsolvedHints[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        Debug.Log(GameState.roles[GameState.currentTurn] + " has found " + (GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]) + " hints");
        GameState.trueUnsolveds[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        toMovement();
    }
    void btnFalseHintClick()
    {
        addFalseHint();
        toMovement();
    }
    void btnBigTrapClick()
    {
        GameState.bigTrapUsed = true;
        addTrueHint();
        playerButtons();
        btnOne.onClick.AddListener(btnPlayerOneClickBigTrap);
        btnTwo.onClick.AddListener(btnPlayerTwoClickBigTrap);
        btnThree.onClick.AddListener(btnPlayerThreeClickBigTrap);
        btnFour.onClick.AddListener(btnPlayerFourClickBigTrap);
        btnFive.onClick.AddListener(btnPlayerFiveClickBigTrap);
        btnSix.onClick.AddListener(btnPlayerSixClickBigTrap);

        Debug.Log(GameState.roles[GameState.currentTurn] + " used a big Trap");
    }
    void btnManipulationClick()
    {
        Debug.Log(GameState.roles[GameState.currentTurn] + " is manipulating");
        addTrueHint();
        twoButtons();
        btnOneText.text = "Bewwegung";
        btnTwoText.text = "Hinweis";
        btnOne.onClick.AddListener(btnManipulationMovementClick);
        btnTwo.onClick.AddListener(btnManipulationHintClick);
    }



    //place action functions
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
        GameState.trueSolveds[GameState.currentTurn] += GameState.trueUnsolveds[GameState.currentTurn];
        GameState.solvedHints[GameState.currentTurn] += GameState.unsolvedHints[GameState.currentTurn];
        GameState.trueUnsolveds[GameState.currentTurn] = 0;
        GameState.unsolvedHints[GameState.currentTurn] = 0;
        toMovement();
    }
    void mainsquareAction()
    {
        oneButton();
        btnOneText.text = "Geld verdienen";
        btnOne.onClick.AddListener(earnMoney);

    }
    void earnMoney()
    {
        if (GameState.items[GameState.currentTurn].Contains("Calculator"))
        {
            GameState.money[GameState.currentTurn] += 8;
        }
        else
        {
            GameState.money[GameState.currentTurn] += 6;
        }
        toMovement();
    }
    //@TODO add functionality
    void parkAction()
    {

    }
    //@TODO add functionality
    void hospitalAction()
    {

    }
    //@TODO add functionality
    void bankAction()
    {

    }
    //@TODO add functionality
    void parliamentAction()
    {

    }
    //@TODO add functionality
    void cemetaryAction()
    {

    }
    //@TODO add functionality
    void prisonAction()
    {

    }
    //@TODO add functionality
    void casinoAction()
    {

    }
    void btnCasinoBet(int bet)
    {
        System.Random rn = new System.Random();
        int rand = rn.Next(0, 1);
        if(rand == 0)
        {
            GameState.money[GameState.currentTurn] += bet;
        }
        else
        {
            GameState.money[GameState.currentTurn] -= bet;
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
        btnOneText.text = "Infernos Falle";
        btnTwoText.text = "Dr.Mortifiers Falle";
        btnThreeText.text = "Phantoms Falle";
        btnFourText.text = "Fascultos Falle";
        btnOne.onClick.AddListener(btnBuyingInfernoTrap);
        btnOne.onClick.AddListener(btnBuyingDrMortifierTrap);
        btnOne.onClick.AddListener(btnBuyingPhantomTrap);
        btnOne.onClick.AddListener(btnBuyingFascultoTrap);
    }
    void btnBuyingInfernoTrap()
    {
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("Bomb");
        addTrueHint();
        toMovement();
    }
    void btnBuyingDrMortifierTrap()
    {
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("PetriDish");
        addTrueHint();
        toMovement();
    }
    void btnBuyingPhantomTrap()
    {
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("StolenGoods");
        addTrueHint();
        toMovement();
    }
    void btnBuyingFascultoTrap()
    {
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("CursedArtifact");
        addTrueHint();
        toMovement();
    }
    //@TODO add functionality
    void trainstationAction()
    {

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
    }
    void btnBuyProtectiveVest()
    {
        GameState.money[GameState.currentTurn] -= 6;
        GameState.items[GameState.currentTurn].Add("ProtectiveVest");
        toMovement();
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
    }
    void btnBuyFireProofCoat()
    {
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("FireProofCoat");
        toMovement();
    }
    void btnBuyGasmask()
    {
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Gasmask");
        toMovement();
    }
    void btnBuyBodycam()
    {
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Bodycam");
        toMovement();
    }
    void btnBuyTalisman()
    {
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Talisman");
        toMovement();
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
            btnFour.interactable=false;
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
    }
    void btnBuyTrainers()
    {
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("Trainers");
        toMovement();
    }
    void btnBuyFingerprintKit()
    {
        GameState.money[GameState.currentTurn] -= 4;
        GameState.items[GameState.currentTurn].Add("FingerprintKit");
        toMovement();
    }
    void btnBuyEnergyDrink()
    {
        GameState.money[GameState.currentTurn] -= 3;
        GameState.items[GameState.currentTurn].Add("EnergyDrink");
        toMovement();
    }
    void btnBuyCalculator()
    {
        GameState.money[GameState.currentTurn] -= 8;
        GameState.items[GameState.currentTurn].Add("Calculator");
        toMovement();
    }
    void btnBuyWhiskey()
    {
        GameState.money[GameState.currentTurn] -= 8;
        GameState.items[GameState.currentTurn].Add("Whiskey");
        toMovement();
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


        switch (rand)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                Debug.Log("Nichts gefunden");
                break;
            case 5:
                GameState.items[GameState.currentTurn].Add("FireProofCoat");
                break;
            case 6:
                GameState.items[GameState.currentTurn].Add("ProtectiveVest");
                break;
            case 7:
                GameState.items[GameState.currentTurn].Add("Gasmask");
                break;
            case 8:
                GameState.items[GameState.currentTurn].Add("Talisman");
                break;
            case 9:
                GameState.items[GameState.currentTurn].Add("Trainers");
                break;
            case 10:
                GameState.items[GameState.currentTurn].Add("FingerprintKit");
                break;
            case 11:
                GameState.items[GameState.currentTurn].Add("EnergyDrink");
                break;
            case 12:
                GameState.items[GameState.currentTurn].Add("Calculator");
                break;
            case 13:
                GameState.items[GameState.currentTurn].Add("Whiskey");
                break;
            case 14:
                GameState.items[GameState.currentTurn].Add("Bomb");
                break;
            case 15:
                GameState.items[GameState.currentTurn].Add("PetriDish");
                break;
            case 16:
                GameState.items[GameState.currentTurn].Add("StolenGoods");
                break;
            case 17:
                GameState.items[GameState.currentTurn].Add("CursedArtifact");
                break;
        }
        toMovement();
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
    }
    void btnItalienTwentyPercentChance()
    {
        GameState.money[GameState.currentTurn]--;
        chanceToGetTrueHint(2);
        toMovement();
    }
    void btnItalienThirtyPercentChance()
    {
        GameState.money[GameState.currentTurn]-=2;
        chanceToGetTrueHint(3);
        toMovement();
    }
    void btnItalienFiftyPercentChance()
    {
        GameState.money[GameState.currentTurn]-=3;
        chanceToGetTrueHint(5);
        toMovement();
    }
    void btnItalienSixtyPercentChance()
    {
        GameState.money[GameState.currentTurn]-=4;
        chanceToGetTrueHint(6);
        toMovement();
    }
    void harborAction()
    {
        twoButtons();
        btnOneText.text= "Hinweis - 5 Geld";
        btnTwoText.text = "fremde Falle kaufen";
        btnOne.onClick.AddListener(btnHarborHint);
        btnTwo.onClick.AddListener(btnBuyTrap);
        if (GameState.money[GameState.currentTurn] < 5)
        {
            btnOne.interactable = false;
        }
    }
    void btnHarborHint()
    {
        GameState.money[GameState.currentTurn] -= 5;
        chanceToGetTrueHint(5);
        toMovement();
    }
    void barAction()
    {
        Debug.Log("Hello");
        oneButton();
        btnOneText.text = "SAAAAAUUUUFEN";
        btnOne.onClick.AddListener(btnBarHint);
    }
    void btnBarHint()
    {
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
        GameState.currentPlace[GameState.currentTurn][0]=randOne;
        GameState.currentPlace[GameState.currentTurn][1] = randTwo;
        toMovement();
    }

    //eventlistener for manipulation action
    void btnManipulationMovementClick()
    {
        playerButtons();
        btnOne.onClick.AddListener(btnPlayerOneClickManipulationMovement);
        btnTwo.onClick.AddListener(btnPlayerTwoClickManipulationMovement);
        btnThree.onClick.AddListener(btnPlayerThreeClickManipulationMovement);
        btnFour.onClick.AddListener(btnPlayerFourClickManipulationMovement);
        btnFive.onClick.AddListener(btnPlayerFiveClickManipulationMovement);
        btnSix.onClick.AddListener(btnPlayerSixClickManipulationMovement);

    }

    //TODO: addMovementManipulation
    void btnPlayerOneClickManipulationMovement()
    {
        playerButtons();
        btnOne.onClick.AddListener(toMovement);
        btnTwo.onClick.AddListener(toMovement);
        btnThree.onClick.AddListener(toMovement);
        btnFour.onClick.AddListener(toMovement);
        btnFive.onClick.AddListener(toMovement);
        btnSix.onClick.AddListener(toMovement);
    }
    void btnPlayerTwoClickManipulationMovement()
    {

    }
    void btnPlayerThreeClickManipulationMovement()
    {

    }
    void btnPlayerFourClickManipulationMovement()
    {

    }
    void btnPlayerFiveClickManipulationMovement()
    {

    }
    void btnPlayerSixClickManipulationMovement()
    {

    }


    void btnManipulationHintClick()
    {
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

            GameState.trueUnsolveds[0]--;
            GameState.unsolvedHints[0]--;
        }
        toMovement();
    }
    void btnPlayerTwoClickManipulationHint()
    {
        if (GameState.trueUnsolveds[1] > 0)
        {
            GameState.trueUnsolveds[1]--;
            GameState.unsolvedHints[1]--;
        }
        toMovement();
    }
    void btnPlayerThreeClickManipulationHint()
    {
        if (GameState.trueUnsolveds[2] > 0)
        {
            GameState.trueUnsolveds[2]--;
            GameState.unsolvedHints[2]--;
        }
        toMovement();
    }
    void btnPlayerFourClickManipulationHint()
    {
        if (GameState.trueUnsolveds[3] > 0)
        {
            GameState.trueUnsolveds[3]--;
            GameState.unsolvedHints[3]--;
        }
        toMovement();
    }
    void btnPlayerFiveClickManipulationHint()
    {
        if (GameState.trueUnsolveds[4] > 0)
        {
            GameState.trueUnsolveds[4]--;
            GameState.unsolvedHints[4]--;
        }
        toMovement();
    }
    void btnPlayerSixClickManipulationHint()
    {
        if (GameState.trueUnsolveds[5] > 0)
        {
            GameState.trueUnsolveds[5]--;
            GameState.unsolvedHints[5]--;
        }
        toMovement();
    }



    //event listener for big trap action
    void btnPlayerOneClickBigTrap()
    {
        activatedTrap(0, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerTwoClickBigTrap()
    {
        activatedTrap(1, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerThreeClickBigTrap()
    {
        activatedTrap(2, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerFourClickBigTrap()
    {
        activatedTrap(3, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerFiveClickBigTrap()
    {
        activatedTrap(4, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerSixClickBigTrap()
    {
        activatedTrap(5, findTargetPosition(GameState.criminalRole));
        toMovement();
    }

    //LayoutFunctions
    //@TODO: Layout for 5 buttons and 7 buttons
    void oneButton()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnOne.GetComponent<RectTransform>().sizeDelta = new Vector2(1000, 1000);
        btnOne.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -400);

        btnOneText.fontSize = 180;
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
    }
    void fiveButtons()
    {
        disableButtons();
        btnOne.gameObject.SetActive(true);
        btnTwo.gameObject.SetActive(true);
        btnThree.gameObject.SetActive(true);
        btnFour.gameObject.SetActive(true);
        btnFive.gameObject.SetActive(true);



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
    }
    void playerButtons()
    {
        sixButtons();

        btnFour.interactable = false;
        btnFive.interactable = false;
        btnSix.interactable = false;

        btnOneText.text = GameState.roles[0];
        btnTwoText.text = GameState.roles[1];
        btnThreeText.text = GameState.roles[2];
        btnFourText.text = "nicht verfügbar";
        btnFiveText.text = "nicht verfügbar";
        btnSixText.text = "nicht verfügbar";


        switch (GameState.playerCount)
        {
            case 4:
                btnFour.interactable = true;

                btnFourText.text = GameState.roles[3];

                break;
            case 5:
                btnFour.interactable = true;
                btnFive.interactable = true;


                btnFourText.text = GameState.roles[3];
                btnFiveText.text = GameState.roles[4];

                break;
            case 6:
                btnFour.interactable = true;
                btnFive.interactable = true;
                btnSix.interactable = true;

                btnFourText.text = GameState.roles[3];
                btnFiveText.text = GameState.roles[4];
                btnSixText.text = GameState.roles[5];
                break;
        }



    }

    //Useful functions

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

    void translatePlace(int place)
    {
        string s = "Straße";
        Sprite pic = street;
        switch (place)
        {
            case 1:
                s = "Stadtplatz";
                pic = mainsquare;
                break;
            case 2:
                s = "Park";
                pic = park;
                break;
            case 3:
                s = "Krankenhaus";
                pic = hospital;
                break;
            case 4:
                s = "Bank";
                pic = bank;
                break;
            case 5:
                s = "Parlament";
                pic = parliament;
                break;
            case 6:
                s = "Friedhof";
                pic = cementary;
                break;
            case 7:
                s = "Gefängnis";
                pic = prison;
                break;
            case 8:
                s = "Kasino";
                pic = casino;
                break;
            case 9:
                s = "Internet Cafe";
                pic = internetcafe;
                break;
            case 10:
                s = "Bahnhof";
                pic = trainstation;
                break;
            case 11:
                s = "Armee Laden";
                pic = armyshop;
                break;
            case 12:
                s = "Shopping Center";
                pic = shoppingcenter;
                break;
            case 13:
                s = "Schrottplatz";
                pic = junkyard;
                break;
            case 14:
                s = "Bibliothek";
                pic = library;
                break;
            case 15:
                s = "Labor";
                pic = laboratory;
                break;
            case 16:
                s = "Italiener";
                pic = italienrestaurant;
                break;
            case 17:
                s = "Hafen";
                pic = harbor;
                break;
            case 18:
                s = "Bar";
                pic = bar;
                break;
        }
        placeName.text = s;
        image.GetComponent<Image>().sprite = pic;
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
        }
    }
}
