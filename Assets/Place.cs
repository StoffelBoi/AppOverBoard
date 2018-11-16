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
    public Text text;
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

    private int currentPlace;


    // Use this for initialization

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
        btnPlaceOption_alt.onClick.AddListener(btnPlaceOption_altClick);
        btnFindHint_alt.onClick.AddListener(btnFindHind_altClick);
        btnUseItem_alt.onClick.AddListener(btnUseItem_altClick);
        btnFalseHint.onClick.AddListener(btnFalseHintClick);
        btnSmallTrap.onClick.AddListener(btnSmallTrapClick);
        btnBigTrap.onClick.AddListener(btnBigTrapClick);
        btnManipulation.onClick.AddListener(btnManipulationClick);
        btnActivateQuestPlace.onClick.AddListener(btnActivateQuestPlaceClick);
    }
    void OnEnable()
    {
        scriptMovement = movementController.GetComponent<Movement>();
        scriptPlace = GetComponent<Place>();
        currentPlace = GameState.board[GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]];
        translatePlace(currentPlace);

        if (GameState.criminal == GameState.roles[GameState.currentTurn])
        {
            btnPlaceOption.gameObject.SetActive(false);
            btnFindHint.gameObject.SetActive(false);
            btnUseItem.gameObject.SetActive(false);
            btnPlaceOption_alt.gameObject.SetActive(true);
            btnFindHint_alt.gameObject.SetActive(true);
            btnUseItem_alt.gameObject.SetActive(true);
            btnFalseHint.gameObject.SetActive(true);
            btnSmallTrap.gameObject.SetActive(true);
            btnBigTrap.gameObject.SetActive(true);
            btnManipulation.gameObject.SetActive(true);
            btnActivateQuestPlace.gameObject.SetActive(true);

            

        }
        else
        {
            btnPlaceOption.gameObject.SetActive(true);
            btnFindHint.gameObject.SetActive(true);
            btnUseItem.gameObject.SetActive(true);
            btnPlaceOption_alt.gameObject.SetActive(false);
            btnFindHint_alt.gameObject.SetActive(false);
            btnUseItem_alt.gameObject.SetActive(false);
            btnFalseHint.gameObject.SetActive(false);
            btnSmallTrap.gameObject.SetActive(false);
            btnBigTrap.gameObject.SetActive(false);
            btnManipulation.gameObject.SetActive(false);
            btnActivateQuestPlace.gameObject.SetActive(false);

        }
    }

    void toMovement()
    {
        if (GameState.currentTurn == GameState.playerCount - 1)
        {
            GameState.currentTurn = 0;
        }
        else
        {
            GameState.currentTurn++;
        }
        place.enabled = false;
        movement.enabled = true;
        scriptMovement.enabled = true;
        scriptPlace.enabled = false;
    }


    void btnPlaceOptionClick()
    {
        toMovement();
    }
    void btnFindHintClick()
    {
        toMovement();
    }
    void btnUseItemClick()
    {
        toMovement();
    }

    void btnPlaceOption_altClick()
    {
        toMovement();
    }
    void btnFindHind_altClick()
    {
        toMovement();
    }
    void btnUseItem_altClick()
    {
        toMovement();
    }

    void btnFalseHintClick()
    {
        toMovement();
    }
    void btnSmallTrapClick()
    {
        toMovement();
    }
    void btnBigTrapClick()
    {
        toMovement();
    }
    void btnManipulationClick()
    {
        toMovement();
    }
    void btnActivateQuestPlaceClick()
    {
        toMovement();
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
        text.text = s;
        image.GetComponent<Image>().sprite = pic;
    }
}
