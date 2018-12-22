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

    private int currentBet;
    private int currentPlace;

    public Text actionsTextField;
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
        actionsTextField.gameObject.SetActive(false);
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
                //checking if theres already a trap on the current place
                if (GameState.traps[currentPlace] != "Safe")
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
        //resetting the current bet
        currentBet = 0;
    }
 
    void checkForTraps()
    {
        if (GameState.traps[currentPlace] != "Safe")
        {
            switch (GameState.traps[currentPlace])
            {
               case "Bomb":
                    if (!GameState.items[GameState.currentTurn].Contains("FireProofCoat"))
                    {
                        if (!GameState.items[GameState.currentTurn].Contains("ProtectiveVest"))
                        {
                                Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.traps[currentPlace]);
                                activatedTrap(GameState.currentTurn, findTargetPosition("Inferno"));
                                GameState.isDisabled[currentPlace] = 1;
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
                                Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.traps[currentPlace]);
                                activatedTrap(GameState.currentTurn, findTargetPosition("Dr.Mortifier"));
                                GameState.isDisabled[currentPlace] = 1;
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
                                Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.traps[currentPlace]);
                                activatedTrap(GameState.currentTurn, findTargetPosition("Phantom"));
                                GameState.isDisabled[currentPlace] = 1;
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
                                Debug.Log(GameState.roles[GameState.currentTurn] + " has triggered a " + GameState.traps[currentPlace]);
                                activatedTrap(GameState.currentTurn, findTargetPosition("Fasculto"));
                                GameState.isDisabled[currentPlace] = 1;
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
            GameState.traps[currentPlace] = "Safe";
            toMovement();

        }
    }
    void toMovement()
    {
        if (!GameState.usedEnergyDrink.Contains(true)) { 
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
        else
        {
            GameState.usedEnergyDrink.Remove(true);
            OnEnable();
        }
    }

    //TODO: add Random Events
    void btnLookAroundClick()
    {
        Debug.Log("Du schaust dich um und ... bemerkst nichts außergewöhnliches");
        toMovement();
    }

    void btnUseItemClick()
    {
        int trainersCount=0;
        int FingerprintKitCount = 0;
        int EnergyDrinkCount = 0;
        int WhiskeyCount = 0;

        for(int i = 0; i<GameState.items[GameState.currentTurn].Count; i++)
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



        fourButtons();
        btnOneText.text = "Turnschuhe x"+trainersCount;
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
        if(EnergyDrinkCount == 0)
        {
            btnThree.interactable = false;
        }
        if(WhiskeyCount == 0)
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
        GameState.items[GameState.currentTurn].Remove("Trainers");
        place.enabled = false;
        movement.enabled = true;
        scriptMovement.enabled = true;
        scriptPlace.enabled = false;
    }
    void btnFingerprintKitOnClick()
    {
        GameState.solvedHints[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        Debug.Log(GameState.roles[GameState.currentTurn] + " has found " + (GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]) + " hints");
        GameState.trueSolveds[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        GameState.items[GameState.currentTurn].Remove("FingerprintKit");
        OnEnable();
    }
    void btnEnergyDrinkOnClick()
    {
        GameState.usedEnergyDrink.Add(true);
        GameState.items[GameState.currentTurn].Remove("EnergyDrink");
        OnEnable();
    }
    void btnWhiskeyOnClick()
    {
        GameState.trueSolveds[GameState.currentTurn]++;
        GameState.solvedHints[GameState.currentTurn]++;
        GameState.items[GameState.currentTurn].Remove("Whiskey");
        OnEnable();
    }


    void btnSmallTrapClick()
    {
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



        fourButtons();
        btnOneText.text = "Bombe x"+bombCount;
        btnTwoText.text = "Petrischale x"+petriDishCount;
        btnThreeText.text = "Diebesgut x"+stoleGoodsCount;
        btnFourText.text = "Verfluchtes Artifakt x"+cursedArtifactCount;
        btnOne.onClick.AddListener(setInfernoTrap);
        btnTwo.onClick.AddListener(setDrMortifierTrap);
        btnThree.onClick.AddListener(setPhantomTrap);
        btnFour.onClick.AddListener(setFascultoTrap);
        if (bombCount == 0)
        {
            if (GameState.criminalRole == "Inferno")
            {
                btnOneText.text = "Bombe 2$";
                btnOne.onClick.RemoveAllListeners();
                btnOne.onClick.AddListener(buyOwnTrap);
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
            }
            else
            {
                btnFour.interactable = false;
            }
        }

    }
    void buyOwnTrap()
    {
        GameState.money[GameState.currentTurn] -= 2;
        switch (GameState.criminalRole)
        {
            case ("Inferno"):
                setInfernoTrap();
                break;
            case ("Dr.Mortifier"):
                setDrMortifierTrap();
                break;
            case ("Phantom"):
                setPhantomTrap();
                break;
            case ("Fasculto"):
                setFascultoTrap();
                break;
        }
    }
    void setInfernoTrap()
    {
        GameState.items[GameState.currentTurn].Remove("Bomb");
        GameState.traps[currentPlace] = "Bomb";
        addTrueHint();
        toMovement();
    }
    void setDrMortifierTrap()
    {
        GameState.items[GameState.currentTurn].Remove("PetriDish");
        GameState.traps[currentPlace] = "PetriDish";
        addTrueHint();
        toMovement();
    }
    void setPhantomTrap()
    {
        GameState.items[GameState.currentTurn].Remove("StolenGoods");
        GameState.traps[currentPlace] = "StolenGoods";
        addTrueHint();
        toMovement();
    }
    void setFascultoTrap()
    {
        GameState.items[GameState.currentTurn].Remove("CursedArtifact");
        GameState.traps[currentPlace] = "CursedArtifact";
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

    }
    void btnCasinoBetUp()
    {
        currentBet++;
        casinoAction();
    }
    void btnCasinoBetDown()
    {
        currentBet--;
        casinoAction();
    }
    void btnCasinoBet()
    {
        System.Random rn = new System.Random();
        int rand = rn.Next(0, 100);
        if(rand < 50)
        {
            Debug.Log(GameState.roles[GameState.currentTurn] + " won " + currentBet + "$");
            GameState.money[GameState.currentTurn] += currentBet;
        }
        else
        {
            Debug.Log(GameState.roles[GameState.currentTurn] + " lost " + currentBet + "$");
            GameState.money[GameState.currentTurn] -= currentBet;
        }
        toMovement();
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
        btnOne.onClick.AddListener(btnTrainstationPlaceUp);
        btnTwo.onClick.AddListener(btnTrainstationTravel);
        btnThree.onClick.AddListener(btnTrainstationPlaceDown);
        if (GameState.money[GameState.currentTurn] < 2)
        {
            btnTwo.interactable = false;
        }
    }
    void btnTrainstationPlaceDown()
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
    void btnTrainstationPlaceUp()
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
        GameState.money[GameState.currentTurn] -= 2;
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                GameState.currentPlace[GameState.currentTurn] = findPosition(1);
                break;
            case "Park":
                GameState.currentPlace[GameState.currentTurn] = findPosition(2);
                break;
            case "Krankenhaus":
                GameState.currentPlace[GameState.currentTurn] = findPosition(3);
                break;
            case "Bank":
                GameState.currentPlace[GameState.currentTurn] = findPosition(4);
                break;
            case "Parlament":
                GameState.currentPlace[GameState.currentTurn] = findPosition(5);
                break;
            case "Friedhof":
                GameState.currentPlace[GameState.currentTurn] = findPosition(6);
                break;
            case "Gefängnis":
                GameState.currentPlace[GameState.currentTurn] = findPosition(7);
                break;
            case "Kasino":
                GameState.currentPlace[GameState.currentTurn] = findPosition(8);
                break;
            case "Internet Cafe":
                GameState.currentPlace[GameState.currentTurn] = findPosition(9);
                break;
            case "Bahnhof":
                GameState.currentPlace[GameState.currentTurn] = findPosition(10);
                break;
            case "Armee Laden":
                GameState.currentPlace[GameState.currentTurn] = findPosition(11);
                break;
            case "Shopping Center":
                GameState.currentPlace[GameState.currentTurn] = findPosition(12);
                break;
            case "Schrottplatz":
                GameState.currentPlace[GameState.currentTurn] = findPosition(13);
                break;
            case "Bibliothek":
                GameState.currentPlace[GameState.currentTurn] = findPosition(14);
                break;
            case "Labor":
                GameState.currentPlace[GameState.currentTurn] = findPosition(15);
                break;
            case "Italiener":
                GameState.currentPlace[GameState.currentTurn] = findPosition(16);
                break;
            case "Hafen":
                GameState.currentPlace[GameState.currentTurn] = findPosition(17);
                break;
            case "Bar":
                GameState.currentPlace[GameState.currentTurn] = findPosition(18);
                break;
        }
        toMovement();
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

    int[] findPosition(int place)
    {
        int[] position = new int[2];
        for (int i = 0; i<6; i++)
        {
            for (int j = 0; j<7; j++)
            {
                if(GameState.board[i,j] == place)
                {
                    position[0] = i;
                    position[1] = j;
                }
            }
        }
        return position;
    }
}
