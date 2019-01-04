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
    private bool firstMove;
    public Image img;
    public Sprite Doctor;
    public Sprite Detective;
    public Sprite Police;
    public Sprite Psychic;
    public Sprite Reporter;
    public Sprite Psychologist;

    public Button btnInfo;
    // Use this for initialization
    private Player player;
    
    void Start()
    {
        player = GameState.Instance.localPlayer.GetComponent<Player>();
        btnInfo.onClick.AddListener(btnToInfo);
        btnRight.onClick.AddListener(rightClick);
        btnLeft.onClick.AddListener(leftClick);
        btnUp.onClick.AddListener(upClick);
        btnDown.onClick.AddListener(downClick);
        btnStay.onClick.AddListener(stayClick);
        firstMove = true;
    }

    void btnToInfo()
    {
        UIManager.Instance.PrivatePlayer();
    }

    void OnEnable()
    {
        newTurn();
    }

	void newTurn()
    {
        switch (GameState.Instance.roles[GameState.Instance.currentTurn])
        {
            case "Detective":
                img.GetComponent<Image>().sprite = Detective;
                break;
            case "Doctor":
                img.GetComponent<Image>().sprite = Doctor;
                break;
            case "Police":
                img.GetComponent<Image>().sprite = Police;
                break;
            case "Psychic":
                img.GetComponent<Image>().sprite = Psychic;
                break;
            case "Reporter":
                img.GetComponent<Image>().sprite = Reporter;
                break;
            case "Psychologist":
                img.GetComponent<Image>().sprite = Psychologist;
                break;
        }
        currentPlace = GameState.Instance.currentPlace[GameState.Instance.currentTurn];
        setButtons(currentPlace);
        
    }
	// Update is called once per frame
	void Update () {
		
	}

    void setButtons(int[] currentPlace)
    {
        txtDown.fontSize = 60;
        txtUp.fontSize = 60;
        txtLeft.fontSize = 60;
        txtRight.fontSize = 60;
        txtStay.fontSize = 60;
        if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0], currentPlace[1]]] > 0)
        {
            btnStay.interactable = false;
            txtStay.fontSize = 50;
            txtStay.text = "Quarantäne";
        }
        else
        {
            txtStay.text = translatePlace(GameState.Instance.board[currentPlace[0], currentPlace[1]]);
        }
        if (currentPlace[0] > 0)
        {
            if(GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0] - 1, currentPlace[1]]] > 0){
                btnUp.interactable = false;
                txtUp.fontSize = 50;
                txtUp.text = "Quarantäne";
            }
            else
            {
                btnUp.interactable = true;
                txtUp.text = translatePlace(GameState.Instance.board[currentPlace[0] - 1, currentPlace[1]]);
            }
           
        }
        else
        {
            btnUp.interactable = false;
            txtUp.text = "Stadtrand";
        }
        if (currentPlace[0] < 5)
        {
            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0] + 1, currentPlace[1]]] > 0)
            {
                btnDown.interactable = false;
                txtDown.fontSize = 50;
                txtDown.text = "Quarantäne";
            }
            else
            {
                btnDown.interactable = true;
                txtDown.text = translatePlace(GameState.Instance.board[currentPlace[0] + 1, currentPlace[1]]);
            }
                
        }
        else
        {
            btnDown.interactable = false;
            txtDown.text = "Stadtrand";
        }
        if (currentPlace[1] > 0)
        {

            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0], currentPlace[1] - 1]] > 0)
            {
                btnLeft.interactable = false;
                txtLeft.fontSize = 50;
                txtLeft.text = "Quarantäne";
            }
            else
            {
                btnLeft.interactable = true;
                txtLeft.text = translatePlace(GameState.Instance.board[currentPlace[0], currentPlace[1] - 1]);
            }
        }
        else
        {
            btnLeft.interactable = false;
            txtLeft.text = "Stadtrand";
        }
        if (currentPlace[1] < 6)
        {

            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0], currentPlace[1] + 1]] > 0)
            {
                btnRight.interactable = false;
                txtRight.fontSize = 50;
                txtRight.text = "Quarantäne";
            }
            else
            {
                btnRight.interactable = true;
                txtRight.text = translatePlace(GameState.Instance.board[currentPlace[0], currentPlace[1] + 1]);
            }
        }
        else
        {
            btnRight.interactable = false;
            txtRight.text = "Stadtrand";
        }

    }
    
    void endClick()
    {
        

        if (firstMove && GameState.Instance.board[GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] == 0)
        {
            firstMove = false;
            currentPlace = GameState.Instance.currentPlace[GameState.Instance.currentTurn];
            setButtons(currentPlace);
        }
        else
        {
            firstMove = true;
            player.SetPlayerState(GameState.Instance.currentTurn , "Action");
            UIManager.Instance.Place();
        }
    }
    void rightClick()
    {
        currentPlace[1] += 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace);
        endClick();
    }
    void leftClick()
    {
        currentPlace[1] -= 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace);
        endClick();
    }
    void downClick()
    {
        currentPlace[0] += 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace);
        endClick();
    }
    void upClick()
    {
        currentPlace[0] -= 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace);
        endClick();
    }
    void stayClick()
    {
        firstMove = false;
        endClick();
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
}
