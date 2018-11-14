using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    private int[] currentPlace;
    public Button btnStay;
    public Button btnRight;
    public Button btnDown;
    public Button btnLeft;
    public Button btnUp;
    public Text txtStay;
    public Text txtRight;
    public Text txtDown;
    public Text txtLeft;
    public Text txtUp;
    // Use this for initialization
    void Start () {
        currentPlace = GameState.currentPlace[GameState.currentTurn];
        setButtons(currentPlace);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void setButtons(int[] currentPlace)
    {
        txtStay.text = translatePlace(GameState.board[currentPlace[0],currentPlace[1]]);
        if (currentPlace[0] > 0)
        {
        txtStay.text = translatePlace(GameState.board[currentPlace[0]+1, currentPlace[1]]);
        }
        if (currentPlace[0] < 5)
        {
            txtStay.text = translatePlace(GameState.board[currentPlace[0] - 1, currentPlace[1]]);
        }
        if (currentPlace[1] > 0)
        {
            txtStay.text = translatePlace(GameState.board[currentPlace[0], currentPlace[1]+1]);
        }
        if (currentPlace[1] < 6)
        {
            txtStay.text = translatePlace(GameState.board[currentPlace[0] + 1, currentPlace[1]-1]);
        }

    }
    string translatePlace(int place)
    {
        /*
   * 0 ... Street
   * 1 ... Citysquare
   * 2 ... Park
   * 3 ... Hospital
   * 4 ... Bank
   * 5 ... Parliament
   * 6 ... Cemetary
   * 7 ... Prison
   * 8 ... Casino
   * 9 ... Internet Cafe
   * 10 .. Trainstation
   * 11 .. Armyshop
   * 12 .. Shoppingcenter
   * 13 .. Junk Yard
   * 14 .. Library
   * 15 .. Laboratory
   * 16 .. Italien Restaurant
   * 17 .. Harbor
   * 18 .. Bar
   */
        string s = "Straße";
        switch (place)
        {
            case 1:
                s= "Stadtplatz";
                break;
            case 2:
                s= "Park";
                break;
            case 3:
                s= "Krankenhaus";
                break;
            case 4:
                s= "Bank";
                break;
            case 5:
                s= "Parlament";
                break;
            case 6:
                s= "Friedhof";
                break;
            case 7:
                s= "Gefängnis";
                break;
            case 8:
                s= "Kasino";
                break;
            case 9:
                s= "Internet Cafe";
                break;
            case 10:
                s= "Bahnhof";
                break;
            case 11:
                s= "Armee Laden";
                break;
            case 12:
                s= "Shopping Center";
                break;
            case 13:
                s= "Schrottplatz";
                break;
            case 14:
                s= "Bibliothek";
                break;
            case 15:
                s= "Labor";
                break;
            case 16:
                s= "Italiener";
                break;
            case 17:
                s= "Hafen";
                break;
            case 18:
                s= "Bar";
                break;
        }
        return s;
    }

}
