using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool firstMovementManipulation;
    private int manipulatedPlayer;

    void OnEnable()
    {
        Debug.Log("iwashere");
        btnBack.gameObject.SetActive(false);
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(btnGoBack);
        currentPlace = GameState.board[GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        actionsTextField.gameObject.SetActive(false);
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
            if (GameState.currentTurn == GameState.playerCount - 1)
            {
                GameState.currentTurn = 0;
            }
            else
            {
                GameState.currentTurn++;
            }
            //counting down quarantine time
            if(GameState.roles[GameState.currentTurn] == "Doctor")
            {
                for(int i = 0; i<19; i++)
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
                toMovement();
            }
            if (GameState.isManipulated[GameState.currentTurn])
            {
                Debug.Log(GameState.roles[GameState.currentTurn] + " was forced to move here");
                GameState.isManipulated[GameState.currentTurn] = false;
                OnEnable();
            }
            else
            {
                UIManager.Instance.Movement();
            }
        }
        else
        {
            GameState.usedEnergyDrink.Remove(true);
            OnEnable();
        }
    }

    void btnGoBack()
    {
        OnEnable();
    }

    //TODO: add Random Events
    void btnLookAroundClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Umschauen";
        Debug.Log("Du schaust dich um und ... bemerkst nichts außergewöhnliches");
        toMovement();
    }

    #region Use Item
    void btnUseItemClick()
    {
        btnBack.gameObject.SetActive(true);
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
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
        GameState.items[GameState.currentTurn].Remove("Trainers");
        UIManager.Instance.Movement();
    }
    void btnFingerprintKitOnClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
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
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
        GameState.usedEnergyDrink.Add(true);
        GameState.items[GameState.currentTurn].Remove("EnergyDrink");
        OnEnable();
    }
    void btnWhiskeyOnClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Item benutzen";
        GameState.trueSolveds[GameState.currentTurn]++;
        GameState.solvedHints[GameState.currentTurn]++;
        GameState.items[GameState.currentTurn].Remove("Whiskey");
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
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        GameState.items[GameState.currentTurn].Remove("Bomb");
        GameState.traps[currentPlace] = "Bomb";
        addTrueHint();
        toMovement();
    }
    void setDrMortifierTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        GameState.items[GameState.currentTurn].Remove("PetriDish");
        GameState.traps[currentPlace] = "PetriDish";
        addTrueHint();
        toMovement();
    }
    void setPhantomTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        GameState.items[GameState.currentTurn].Remove("StolenGoods");
        GameState.traps[currentPlace] = "StolenGoods";
        addTrueHint();
        toMovement();
    }
    void setFascultoTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "kleine Falle";
        GameState.items[GameState.currentTurn].Remove("CursedArtifact");
        GameState.traps[currentPlace] = "CursedArtifact";
        addTrueHint();
        toMovement();
    }
    #endregion

    //TODO: action for commiting the crime with time aspekt
    void btnActivateQuestPlaceClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Questort aktivieren";
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

    void btnFindHintClick()
    {
        GameState.lastAction[GameState.currentTurn] = "Hinweis finden";
        GameState.unsolvedHints[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        Debug.Log(GameState.roles[GameState.currentTurn] + " has found " + (GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] + GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]]) + " hints");
        GameState.trueUnsolveds[GameState.currentTurn] = GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        GameState.notFoundTrue[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        GameState.notFoundFalse[GameState.currentTurn][GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] = 0;
        toMovement();
    }

    void btnFalseHintClick()
    {
        GameState.lastAction[GameState.currentTurn] = "falscher Hinweis";
        addFalseHint();
        toMovement();
    }

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
        GameState.trueSolveds[GameState.currentTurn] += GameState.trueUnsolveds[GameState.currentTurn];
        GameState.solvedHints[GameState.currentTurn] += GameState.unsolvedHints[GameState.currentTurn];
        GameState.trueUnsolveds[GameState.currentTurn] = 0;
        GameState.unsolvedHints[GameState.currentTurn] = 0;
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        toMovement();
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
        Debug.Log("Der Verbrecher hat " + GameState.activatedQuestPlaces + " Questorte aktiviert.");
        GameState.skillUsed[GameState.currentTurn]=true;
        toMovement();
    }

    //@TODO add functionality
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


        
    }
    void btnQuarantine()
    {
        switch (actionsTextField.text)
        {
            case "Stadtplatz":
                GameState.quarantined[1] = 3;
                break;
            case "Park":
                GameState.quarantined[2] = 3;
                break;
            case "Krankenhaus":
                GameState.quarantined[3] = 3;
                break;
            case "Bank":
                GameState.quarantined[4] = 3;
                break;
            case "Parlament":
                GameState.quarantined[5] = 3;
                break;
            case "Friedhof":
                GameState.quarantined[6] = 3;
                break;
            case "Gefängnis":
                GameState.quarantined[7] = 3;
                break;
            case "Kasino":
                GameState.quarantined[8] = 3;
                break;
            case "Internet Cafe":
                GameState.quarantined[9] = 3;
                break;
            case "Bahnhof":
                GameState.quarantined[10] = 3;
                break;
            case "Armee Laden":
                GameState.quarantined[11] = 3;
                break;
            case "Shopping Center":
                GameState.quarantined[12] = 3;
                break;
            case "Schrottplatz":
                GameState.quarantined[13] = 3;
                break;
            case "Bibliothek":
                GameState.quarantined[14] = 3;
                break;
            case "Labor":
                GameState.quarantined[15] = 3;
                break;
            case "Italiener":
                GameState.quarantined[16] = 3;
                break;
            case "Hafen":
                GameState.quarantined[17] = 3;
                break;
            case "Bar":
                GameState.quarantined[18] = 3;
                break;
        }
        GameState.lastAction[GameState.currentTurn] = "Fähgikeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        toMovement();
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
    }
    void btnPlayerOneTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[5] + "s letzte Transaktion war: " + GameState.lastTransaction[0]);
        toMovement();
    }
    void btnPlayerTwoTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[5] + "s letzte Transaktion war: " + GameState.lastTransaction[1]);
        toMovement();
    }
    void btnPlayerThreeTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[5] + "s letzte Transaktion war: " + GameState.lastTransaction[2]);
        toMovement();
    }
    void btnPlayerFourTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[5] + "s letzte Transaktion war: " + GameState.lastTransaction[3]);
        toMovement();
    }
    void btnPlayerFiveTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[5] + "s letzte Transaktion war: " + GameState.lastTransaction[4]);
        toMovement();
    }
    void btnPlayerSixTransaction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[5] + "s letzte Transaktion war: " + GameState.lastTransaction[5]);
        toMovement();
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
    }
    void btnPlayerOneAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[0] + "s letzte Aktion war: " + GameState.lastAction[0]);
        toMovement();
    }
    void btnPlayerTwoAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[1] + "s letzte Aktion war: " + GameState.lastAction[1]);
        toMovement();
    }
    void btnPlayerThreeAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[2] + "s letzte Aktion war: " + GameState.lastAction[2]);
        toMovement();
    }
    void btnPlayerFourAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[3] + "s letzte Aktion war: " + GameState.lastAction[3]);
        toMovement();
    }
    void btnPlayerFiveAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[4] + "s letzte Aktion war: " + GameState.lastAction[4]);
        toMovement();
    }
    void btnPlayerSixAction()
    {
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        Debug.Log(GameState.roles[5] + "s letzte Aktion war: " + GameState.lastAction[5]);
        toMovement();
    }

    void cemetaryAction()
    {
        oneButton();
        btnOneText.text = "Seance";
        btnOne.onClick.AddListener(btnSeance);
        
    }
    void btnSeance()
    {
        string s = "Es befinden sich scharfe Fallen an den Orten:";
        bool noTraps = true;
        for (int i = 0; i < 18; i++)
        {
            if (GameState.traps[i] != "Safe")
            {
                s += (" " + translatePlace(i));
                noTraps = false;
            }
        }
        if (noTraps)
        {
            s = "Es befinden sich keine scharfen Fallen in der Stadt";
        }
        Debug.Log(s);
        GameState.lastAction[GameState.currentTurn] = "Fähigkeit";
        GameState.skillUsed[GameState.currentTurn] = true;
        toMovement();
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
        Debug.Log("Alle falschen Hinweise verschwinden aus der Stadt");
        toMovement();
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
        GameState.lastTransaction[GameState.currentTurn] = "Kasino Wette";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("Bomb");
        addTrueHint();
        toMovement();
    }
    void btnBuyingDrMortifierTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("PetriDish");
        addTrueHint();
        toMovement();
    }
    void btnBuyingPhantomTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("StolenGoods");
        addTrueHint();
        toMovement();
    }
    void btnBuyingFascultoTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Kleine Falle";
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
        btnOne.onClick.AddListener(btnPlaceUp);
        btnTwo.onClick.AddListener(btnTrainstationTravel);
        btnThree.onClick.AddListener(btnPlaceDown);
        if (GameState.money[GameState.currentTurn] < 2)
        {
            btnTwo.interactable = false;
        }
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Schutzweste";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Feuerfester Mantel";
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("FireProofCoat");
        toMovement();
    }
    void btnBuyGasmask()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Gasmaske";
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Gasmask");
        toMovement();
    }
    void btnBuyBodycam()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Bodycam";
        GameState.money[GameState.currentTurn] -= 15;
        GameState.items[GameState.currentTurn].Add("Bodycam");
        toMovement();
    }
    void btnBuyTalisman()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Talisman";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Turnschuhe";
        GameState.money[GameState.currentTurn] -= 2;
        GameState.items[GameState.currentTurn].Add("Trainers");
        toMovement();
    }
    void btnBuyFingerprintKit()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Fingerabdruckset";
        GameState.money[GameState.currentTurn] -= 4;
        GameState.items[GameState.currentTurn].Add("FingerprintKit");
        toMovement();
    }
    void btnBuyEnergyDrink()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Energy Drink";
        GameState.money[GameState.currentTurn] -= 3;
        GameState.items[GameState.currentTurn].Add("EnergyDrink");
        toMovement();
    }
    void btnBuyCalculator()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Taschenrechner";
        GameState.money[GameState.currentTurn] -= 8;
        GameState.items[GameState.currentTurn].Add("Calculator");
        toMovement();
    }
    void btnBuyWhiskey()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "Whiskey";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
        GameState.money[GameState.currentTurn]--;
        chanceToGetTrueHint(2);
        toMovement();
    }
    void btnItalienThirtyPercentChance()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
        GameState.money[GameState.currentTurn]-=2;
        chanceToGetTrueHint(3);
        toMovement();
    }
    void btnItalienFiftyPercentChance()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
        GameState.money[GameState.currentTurn]-=3;
        chanceToGetTrueHint(5);
        toMovement();
    }
    void btnItalienSixtyPercentChance()
    {
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Italienisches Essen\"";
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
        GameState.lastAction[GameState.currentTurn] = "Ortsoption";
        GameState.lastTransaction[GameState.currentTurn] = "\"Hafenequipment\"";
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
        GameState.currentPlace[GameState.currentTurn][0]=randOne;
        GameState.currentPlace[GameState.currentTurn][1] = randTwo;
        toMovement();
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
    }
    void btnManipulationMovementClick()
    {
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

    void MovementManipulation (int player)
    {
        manipulatedPlayer = player;
        fiveButtons();
        int[] currentPlayerPlace = GameState.currentPlace[player];
        if (currentPlayerPlace[0] > 0)
        {
            if(GameState.quarantined[GameState.board[currentPlayerPlace[0] - 1, currentPlayerPlace[1]]] > 0)
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
            toMovement();
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
            toMovement();
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
            toMovement();
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
            toMovement();
        }
    }
    void btnManipulationStay()
    {
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        btnBack.gameObject.SetActive(false);
        GameState.isManipulated[manipulatedPlayer] = true;
        firstMovementManipulation = false;
        GameState.money[GameState.currentTurn] -= 10;
        toMovement();
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
            GameState.money[GameState.currentTurn] -= 10;
            GameState.trueUnsolveds[0]--;
            GameState.unsolvedHints[0]--;
        }
        GameState.lastAction[GameState.currentTurn] = "Manipulation";
        toMovement();
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
        toMovement();
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
        toMovement();
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
        toMovement();
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
        toMovement();
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
        toMovement();
    }

    #endregion

    #region Big Trap
    void btnBigTrapClick()
    {
        btnBack.gameObject.SetActive(true);
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
    void btnPlayerOneClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(0, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerTwoClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(1, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerThreeClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(2, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerFourClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(3, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerFiveClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(4, findTargetPosition(GameState.criminalRole));
        toMovement();
    }
    void btnPlayerSixClickBigTrap()
    {
        GameState.lastAction[GameState.currentTurn] = "Große Falle";
        activatedTrap(5, findTargetPosition(GameState.criminalRole));
        toMovement();
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
    #endregion

    #region Useful functions
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
    #endregion
}
