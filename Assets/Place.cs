using System.Collections;
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

    public Button btnPlaceOption;
    public Button btnFindHint;
    public Button btnUseItem;
    public Button btnPlaceOption_alt;
    public Button btnFindHint_alt;
    public Button btnUseItem_alt;
    public Button btnFalseHint;
    public Button btnSmallTrap;
    public Button btnBigTrap;
    public Button btnManipulation;
    public Button btnActivateQuestPlace;

    public Button btnLookAround;

    public Text btnPlaceOptionText;
    public Text btnPlaceOption_altText;
    public Text btnActivateQuestPlaceText;

    public Button btnPlayerOne;
    public Button btnPlayerTwo;
    public Button btnPlayerThree;
    public Button btnPlayerFour;
    public Button btnPlayerFive;
    public Button btnPlayerSix;

    public Text btnPlayerOneText;
    public Text btnPlayerTwoText;
    public Text btnPlayerThreeText;
    public Text btnPlayerFourText;
    public Text btnPlayerFiveText;
    public Text btnPlayerSixText;

    public Button btnManipulationMovement;
    public Button btnManipulationHint;

    private int currentPlace;

    void Awake()
    {
        scriptPlace = GetComponent<Place>();
        scriptPlace.enabled = false;
        place.enabled = false;
    }
    void Start()
    {
        btnPlaceOption.onClick.AddListener(btnPlaceOptionClick);
        btnFindHint.onClick.AddListener(btnFindHintClick);
        btnUseItem.onClick.AddListener(btnUseItemClick);
        btnPlaceOption_alt.onClick.AddListener(btnPlaceOptionClick);
        btnFindHint_alt.onClick.AddListener(btnFindHintClick);
        btnUseItem_alt.onClick.AddListener(btnUseItemClick);
        btnFalseHint.onClick.AddListener(btnFalseHintClick);
        btnSmallTrap.onClick.AddListener(btnSmallTrapClick);
        btnBigTrap.onClick.AddListener(btnBigTrapClick);
        btnManipulation.onClick.AddListener(btnManipulationClick);
        btnActivateQuestPlace.onClick.AddListener(btnActivateQuestPlaceClick);
        btnManipulationMovement.onClick.AddListener(btnManipulationMovementClick);
        btnManipulationHint.onClick.AddListener(btnManipulationHintClick);
        btnLookAround.onClick.AddListener(btnLookAroundClick);
    }
    void OnEnable()
    {
        scriptMovement = movementController.GetComponent<Movement>();
        scriptPlace = GetComponent<Place>();
        currentPlace = GameState.board[GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        translatePlace(currentPlace);
        //deactivating lookAround Button
        btnLookAround.gameObject.SetActive(false);

        //disabling the player choice menu buttons
        btnPlayerOne.gameObject.SetActive(false);
        btnPlayerTwo.gameObject.SetActive(false);
        btnPlayerThree.gameObject.SetActive(false);
        btnPlayerFour.gameObject.SetActive(false);
        btnPlayerFive.gameObject.SetActive(false);
        btnPlayerSix.gameObject.SetActive(false);

        //disabling and hiding the manipulation menu buttons
        btnManipulationMovement.gameObject.SetActive(false);
        btnManipulationHint.gameObject.SetActive(false);

        //resetting text for place option button
        btnPlaceOptionText.text = "Ortsoption";
        btnPlaceOption_altText.text = "Ortsoption";

        //checking if current place is a street and changing menu accordingly
        if (currentPlace == 0)
        {
            deactivatePlaceButtons();
            btnLookAround.gameObject.SetActive(true);
        }
        else
        {
            //changing menu if the current Player is a criminal
            if (GameState.criminal == GameState.roles[GameState.currentTurn])
            {
                deactivatePlaceButtons();
                btnPlaceOption_alt.gameObject.SetActive(true);
                btnFindHint_alt.gameObject.SetActive(true);
                btnUseItem_alt.gameObject.SetActive(true);
                btnFalseHint.gameObject.SetActive(true);
                btnSmallTrap.gameObject.SetActive(true);
                btnBigTrap.gameObject.SetActive(true);
                btnManipulation.gameObject.SetActive(true);
                btnActivateQuestPlace.gameObject.SetActive(true);
                btnActivateQuestPlace.interactable = false;
                btnManipulation.interactable = false;
                btnBigTrap.interactable = false;

                //checking if a skillplace can be used
                if (currentPlace == 2)
                {
                    btnPlaceOption_alt.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Detective" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOption_altText.text = "Fähigkeit nutzen";
                        btnPlaceOption_alt.interactable = true;
                    }
                }
                if (currentPlace == 3)
                {
                    btnPlaceOption_alt.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Doctor" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOption_altText.text = "Fähigkeit nutzen";
                        btnPlaceOption_alt.interactable = true;
                    }
                }
                if (currentPlace == 4)
                {
                    btnPlaceOption_alt.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Police" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOption_altText.text = "Fähigkeit nutzen";
                        btnPlaceOption_alt.interactable = true;
                    }
                }
                if (currentPlace == 5)
                {
                    btnPlaceOption_alt.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Reporter" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOption_altText.text = "Fähigkeit nutzen";
                        btnPlaceOption_alt.interactable = true;
                    }
                }
                if (currentPlace == 6)
                {
                    btnPlaceOption_alt.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Psychic" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOption_altText.text = "Fähigkeit nutzen";
                        btnPlaceOption_alt.interactable = true;
                    }
                }
                if (currentPlace == 7)
                {
                    btnPlaceOption_alt.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Psychologist" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOption_altText.text = "Fähigkeit nutzen";
                        btnPlaceOption_alt.interactable = true;
                    }
                }


                //checking if big Trap can be used
                if (!GameState.bigTrapUsed)
                {
                    btnBigTrap.interactable = true;
                }

                //checking if manipulation can be used
                if (GameState.money[GameState.currentTurn] >= 10)
                {
                    btnManipulation.interactable = true;
                }

                //checking if a questplace can be activated
                if (GameState.money[GameState.currentTurn] >= 6)
                {
                    if (GameState.activatedQuestPlaces < 3)
                    {
                        if (GameState.questPlaces.Contains(currentPlace))
                        {
                            btnActivateQuestPlace.interactable = true;
                            {
                            }

                        }
                    }
                    else
                    {
                        if (GameState.targetPlace == currentPlace)
                        {
                            btnActivateQuestPlace.interactable = true;
                            btnActivateQuestPlaceText.text = "Verbrechen ausführen";
                        }
                    }
                }
            }
            else
            {
                deactivatePlaceButtons();
                btnPlaceOption.gameObject.SetActive(true);
                btnFindHint.gameObject.SetActive(true);
                btnUseItem.gameObject.SetActive(true);


                //checking if a skillPlace can be used
                if (currentPlace == 2)
                {
                    btnPlaceOption.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Detective" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOptionText.text = "Fähigkeit nutzen";
                        btnPlaceOption.interactable = true;
                    }
                }
                if (currentPlace == 3)
                {
                    btnPlaceOption.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Doctor" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOptionText.text = "Fähigkeit nutzen";
                        btnPlaceOption.interactable = true;
                    }
                }
                if (currentPlace == 4)
                {
                    btnPlaceOption.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Police" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOptionText.text = "Fähigkeit nutzen";
                        btnPlaceOption.interactable = true;
                    }
                }
                if (currentPlace == 5)
                {
                    btnPlaceOption.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Reporter" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOptionText.text = "Fähigkeit nutzen";
                        btnPlaceOption.interactable = true;
                    }
                }
                if (currentPlace == 6)
                {
                    btnPlaceOption.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Psychic" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOptionText.text = "Fähigkeit nutzen";
                        btnPlaceOption.interactable = true;
                    }
                }
                if (currentPlace == 7)
                {
                    btnPlaceOption.interactable = false;
                    if (GameState.roles[GameState.currentTurn] == "Psychologist" && !GameState.skillUsed[GameState.currentTurn])
                    {
                        btnPlaceOptionText.text = "Fähigkeit nutzen";
                        btnPlaceOption.interactable = true;
                    }
                }
            }
        }
       
    }

    void toMovement()
    {
        System.Random rn = new System.Random();
        int randomHint = rn.Next(0, 10);
        if (randomHint == 0)
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

    //TODO: action for commiting the crime
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
        toMovement();
    }
    void btnFindHintClick()
    {
        GameState.unsolvedHints[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        Debug.Log(GameState.roles[GameState.currentTurn]+" has found "+(GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]])+" hints");
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
        activatePlayerButtons();
        btnPlayerOne.onClick.AddListener(btnPlayerOneClickBigTrap);
        btnPlayerTwo.onClick.AddListener(btnPlayerTwoClickBigTrap);
        btnPlayerThree.onClick.AddListener(btnPlayerThreeClickBigTrap);
        btnPlayerFour.onClick.AddListener(btnPlayerFourClickBigTrap);
        btnPlayerFive.onClick.AddListener(btnPlayerFiveClickBigTrap);
        btnPlayerSix.onClick.AddListener(btnPlayerSixClickBigTrap);
        Debug.Log(GameState.roles[GameState.currentTurn] + " used a big Trap");
    }
    void btnManipulationClick()
    {
        Debug.Log(GameState.roles[GameState.currentTurn] + " is manipulating");
        addTrueHint();
        deactivatePlaceButtons();
        btnManipulationMovement.gameObject.SetActive(true);
        btnManipulationHint.gameObject.SetActive(true);
    }



    //place action functions
    void libraryAction()
    {
        GameState.trueSolveds[GameState.currentTurn] += GameState.trueUnsolveds[GameState.currentTurn];
        GameState.solvedHints[GameState.currentTurn] += GameState.unsolvedHints[GameState.currentTurn];
        GameState.trueUnsolveds[GameState.currentTurn] = 0;
        GameState.unsolvedHints[GameState.currentTurn] = 0;
    }
    void laboratoryAction()
    {
        GameState.trueSolveds[GameState.currentTurn] += GameState.trueUnsolveds[GameState.currentTurn];
        GameState.solvedHints[GameState.currentTurn] += GameState.unsolvedHints[GameState.currentTurn];
        GameState.trueUnsolveds[GameState.currentTurn] = 0;
        GameState.unsolvedHints[GameState.currentTurn] = 0;
    }
    //TODO check for money item
    void mainsquareAction()
    {
        if (false)
        {
            GameState.money[GameState.currentTurn] += 8;
        }
        else
        {
            GameState.money[GameState.currentTurn]+=6;
        }
    }

    //TODO add Functionality for the following places
    void parkAction()
    {

    }
    void hospitalAction()
    {

    }
    void bankAction()
    {

    }
    void parliamentAction()
    {

    }
    void cemetaryAction()
    {

    }
    void prisonAction()
    {

    }
    void casinoAction()
    {

    }
    void internetcafeAction()
    {

    }
    void trainstationAction()
    {

    }
    void armyshopAction()
    {

    }
    void shoppingcenterAction()
    {

    }
    void junkyardAction()
    {

    }

    void italienrestaurantAction()
    {

    }
    void harborAction()
    {

    }
    void barAction()
    {

    }

    //eventlistener for manipulation action
    void btnManipulationMovementClick()
    {
        Debug.Log("False");
        btnManipulationMovement.gameObject.SetActive(false);
        btnManipulationHint.gameObject.SetActive(false);
        activatePlayerButtons();
        btnPlayerOne.onClick.AddListener(btnPlayerOneClickManipulationMovement);
        btnPlayerTwo.onClick.AddListener(btnPlayerTwoClickManipulationMovement);
        btnPlayerThree.onClick.AddListener(btnPlayerThreeClickManipulationMovement);
        btnPlayerFour.onClick.AddListener(btnPlayerFourClickManipulationMovement);
        btnPlayerFive.onClick.AddListener(btnPlayerFiveClickManipulationMovement);
        btnPlayerSix.onClick.AddListener(btnPlayerSixClickManipulationMovement);

    }

    //TODO: addMovementManipulation
    void btnPlayerOneClickManipulationMovement()
    {

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
        Debug.Log("Test 1");
        btnManipulationMovement.gameObject.SetActive(false);
        btnManipulationHint.gameObject.SetActive(false);
        activatePlayerButtons();
        btnPlayerOne.onClick.AddListener(btnPlayerOneClickManipulationHint);
        btnPlayerTwo.onClick.AddListener(btnPlayerTwoClickManipulationHint);
        btnPlayerThree.onClick.AddListener(btnPlayerThreeClickManipulationHint);
        btnPlayerFour.onClick.AddListener(btnPlayerFourClickManipulationHint);
        btnPlayerFive.onClick.AddListener(btnPlayerFiveClickManipulationHint);
        btnPlayerSix.onClick.AddListener(btnPlayerSixClickManipulationHint);
    }

    void btnPlayerOneClickManipulationHint()
    {
        if (GameState.trueUnsolveds[0] > 0)
        {
            
            GameState.trueUnsolveds[0]--;
            GameState.unsolvedHints[0]--;
        }
        Debug.Log("Test 2");
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


    //Useful functions
    void deactivatePlaceButtons()
    {
        btnPlaceOption.gameObject.SetActive(false);
        btnFindHint.gameObject.SetActive(false);
        btnUseItem.gameObject.SetActive(false);
        btnPlaceOption_alt.gameObject.SetActive(false);
        btnFindHint_alt.gameObject.SetActive(false);
        btnUseItem_alt.gameObject.SetActive(false);
        btnFalseHint.gameObject.SetActive(false);
        btnSmallTrap.gameObject.SetActive(false);
        btnBigTrap.gameObject.SetActive(false);
        btnManipulation.gameObject.SetActive(false);
        btnActivateQuestPlace.gameObject.SetActive(false);
    }

    void activatePlayerButtons()
    {

        deactivatePlaceButtons();


        btnPlayerOne.gameObject.SetActive(true);
        btnPlayerTwo.gameObject.SetActive(true);
        btnPlayerThree.gameObject.SetActive(true);
        btnPlayerFour.gameObject.SetActive(true);
        btnPlayerFive.gameObject.SetActive(true);
        btnPlayerSix.gameObject.SetActive(true);

        btnPlayerOne.onClick.RemoveAllListeners();
        btnPlayerTwo.onClick.RemoveAllListeners();
        btnPlayerThree.onClick.RemoveAllListeners();
        btnPlayerFour.onClick.RemoveAllListeners();
        btnPlayerFive.onClick.RemoveAllListeners();
        btnPlayerSix.onClick.RemoveAllListeners();

        btnPlayerFour.interactable = false;
        btnPlayerFive.interactable = false;
        btnPlayerSix.interactable = false;

        btnPlayerOneText.text = GameState.roles[0];
        btnPlayerTwoText.text = GameState.roles[1];
        btnPlayerThreeText.text = GameState.roles[2];
        btnPlayerFourText.text = "nicht verfügbar";
        btnPlayerFiveText.text = "nicht verfügbar";
        btnPlayerSixText.text = "nicht verfügbar";


        switch (GameState.playerCount)
        {
            case 4:
                btnPlayerFour.interactable = true;

                btnPlayerFourText.text = GameState.roles[3];

                break;
            case 5:
                btnPlayerFour.interactable = true;
                btnPlayerFive.interactable = true;


                btnPlayerFourText.text = GameState.roles[3];
                btnPlayerFiveText.text = GameState.roles[4];

                break;
            case 6:
                btnPlayerFour.interactable = true;
                btnPlayerFive.interactable = true;
                btnPlayerSix.interactable = true;

                btnPlayerFourText.text = GameState.roles[3];
                btnPlayerFiveText.text = GameState.roles[4];
                btnPlayerSixText.text = GameState.roles[5];
                break;
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

    void activatedTrap(int player,int[]targetPosition)
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
}
