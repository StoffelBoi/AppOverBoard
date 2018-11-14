using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    public bool firstMove;
    // Use this for initialization
    public Canvas movement;
    public Movement scriptMovement;
    private void Awake()
    {

        scriptMovement = this.GetComponent<Movement>();
        scriptMovement.enabled = false;
    }
    void Start () {
        
        btnRight.onClick.AddListener(rightClick);
        btnLeft.onClick.AddListener(leftClick);
        btnUp.onClick.AddListener(upClick);
        btnDown.onClick.AddListener(downClick);
        btnSty.onClick.AddListener(stayClick);
        newTurn();
    }
	void newTurn()
    {
        currentPlace = GameState.currentPlace[GameState.currentTurn];
        setButtons(currentPlace);
        firstMove = true;
    }
	// Update is called once per frame
	void Update () {
		
	}

    void setButtons(int[] currentPlace)
    {
        txtStay.text = translatePlace(GameState.board[currentPlace[0], currentPlace[1]]);
        if (currentPlace[0] > 0)
        {
            txtUp.text = translatePlace(GameState.board[currentPlace[0] - 1, currentPlace[1]]);
        }
        else
        {
            btnUp.interactable = false;
            txtUp.text = "Stadtrand";
        }
        if (currentPlace[0] < 5)
        {
            txtDown.text = translatePlace(GameState.board[currentPlace[0] + 1, currentPlace[1]]);
        }
        else
        {
            btnDown.interactable = false;
            txtDown.text = "Stadtrand";
        }
        if (currentPlace[1] > 0)
        {
            txtLeft.text = translatePlace(GameState.board[currentPlace[0], currentPlace[1] - 1]);
        }
        else
        {
            btnLeft.interactable = false;
            txtLeft.text = "Stadtrand";
        }
        if (currentPlace[1] < 6)
        {
            txtRight.text = translatePlace(GameState.board[currentPlace[0], currentPlace[1] + 1]);
        }
        else
        {
            btnRight.interactable = false;
            txtRight.text = "Stadtrand";
        }

    }
    string translatePlace(int place)
    {
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
    void endClick()
    {
        
        if (firstMove && GameState.board[GameState.currentPlace[GameState.currentTurn][0], GameState.currentPlace[GameState.currentTurn][1]] == 0)
        {
            firstMove = false;
            currentPlace = GameState.currentPlace[GameState.currentTurn];
            setButtons(currentPlace);
        }
        else
        {
            if (GameState.currentTurn == GameState.playerCount -1)
            {
                GameState.currentTurn = 0;
            }
            else
            {
                GameState.currentTurn++;
            }
            newTurn();
        }
    }
    void rightClick()
    {
        GameState.currentPlace[GameState.currentTurn][1] += 1;
        endClick();
    }
    void leftClick()
    {
        GameState.currentPlace[GameState.currentTurn][1]-=1;
        endClick();
    }
    void downClick()
    {
        GameState.currentPlace[GameState.currentTurn][0]+=1;
        endClick();
    }
    void upClick()
    {
        GameState.currentPlace[GameState.currentTurn][0]-=1;
        endClick();
    }
    void stayClick()
    {
        firstMove = false;
    }
}
