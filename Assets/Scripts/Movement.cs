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
    public Button btnMenu;
    public Button btnInfo;

    public Image imgChar;
    public Image imgPlace;
    public Image imgUp;
    public Image imgRight;
    public Image imgDown;
    public Image imgLeft;
    public Image imgStay;

    public Sprite mckay;
    public Sprite cooper;
    public Sprite fields;
    public Sprite osswald;
    public Sprite edmond;
    public Sprite larson;

    public Sprite imgStreet;
    public Sprite imgMainsquare;
    public Sprite imgPark;
    public Sprite imgHospital;
    public Sprite imgBank;
    public Sprite imgParliament;
    public Sprite imgCemetary;
    public Sprite imgPrison;
    public Sprite imgCasino;
    public Sprite imgInternetcafe;
    public Sprite imgTrainstation;
    public Sprite imgArmyshop;
    public Sprite imgShoppingcenter;
    public Sprite imgJunkyard;
    public Sprite imgLibrary;
    public Sprite imgLaboratory;
    public Sprite imgItalienrestaurant;
    public Sprite imgHarbor;
    public Sprite imgBar;

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

    public Text txtMoney;
    public Text txtSolveds;
    public Text txtUnsolveds;
    private bool firstMove;
    // Use this for initialization
    private Player player;
    
    void Start()
    {
        btnMenu.onClick.AddListener(UIManager.Instance.OpenMenu);
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
        player = GameState.Instance.localPlayer.GetComponent<Player>();
        if (GameState.Instance.isMovementManipulated[GameState.Instance.currentTurn] || GameState.Instance.isDisabled[GameState.Instance.currentTurn] > 0)
        {
            firstMove = false;
            endClick();
        }
        else
        {
            newTurn();
        }

    }

    void newTurn()
    {
        switch (GameState.Instance.roles[GameState.Instance.currentTurn])
        {
            case "Detective":
                imgChar.GetComponent<Image>().sprite = cooper;
                break;
            case "Doctor":
                imgChar.GetComponent<Image>().sprite = mckay;
                break;
            case "Police":
                imgChar.GetComponent<Image>().sprite = fields;
                break;
            case "Psychic":
                imgChar.GetComponent<Image>().sprite = osswald;
                break;
            case "Reporter":
                imgChar.GetComponent<Image>().sprite = edmond;
                break;
            case "Psychologist":
                imgChar.GetComponent<Image>().sprite = larson;
                break;
        }
        currentPlace = GameState.Instance.currentPlace[GameState.Instance.currentTurn];
        imgPlace.sprite = Place(GameState.Instance.board[currentPlace[0], currentPlace[1]]);

        setButtons(currentPlace);

        txtMoney.text = "";
        txtSolveds.text = "";
        txtUnsolveds.text = "";

        if (GameState.Instance.money[player.id] < 10)
        {
            txtMoney.text += "0";
        }
        if (GameState.Instance.solvedHints[player.id] < 10)
        {
            txtSolveds.text += "0";
        }
        if (GameState.Instance.unsolvedHints[player.id] < 10)
        {
            txtUnsolveds.text += "0";
        }
        txtMoney.text += ""+GameState.Instance.money[player.id];
        txtSolveds.text += "" + GameState.Instance.solvedHints[player.id];
        txtUnsolveds.text += "" + GameState.Instance.unsolvedHints[player.id];
    }

    void setButtons(int[] currentPlace)
    {
        if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0], currentPlace[1]]] > 0)
        {
            btnStay.interactable = false;
            imgStay.sprite = imgQuarantine_Symbol;
        }
        else
        {
            imgStay.sprite = Symbol(GameState.Instance.board[currentPlace[0], currentPlace[1]]);
        }
        if (currentPlace[0] > 0)
        {
            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0] - 1, currentPlace[1]]] > 0)
            {
                btnUp.interactable = false;
                imgUp.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnUp.interactable = true;
                imgUp.sprite=Symbol(GameState.Instance.board[currentPlace[0] - 1, currentPlace[1]]);
            }

        }
        else
        {
            btnUp.interactable = false;
            imgUp.sprite = imgEdge_Symbol;
        }
        if (currentPlace[0] < 6)
        {
            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0] + 1, currentPlace[1]]] > 0)
            {
                btnDown.interactable = false;
                imgDown.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnDown.interactable = true;
                imgDown.sprite = Symbol(GameState.Instance.board[currentPlace[0] + 1, currentPlace[1]]);
            }

        }
        else
        {
            btnDown.interactable = false;
            imgDown.sprite = imgEdge_Symbol;
        }
        if (currentPlace[1] > 0)
        {

            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0], currentPlace[1] - 1]] > 0)
            {
                btnLeft.interactable = false;
                imgLeft.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnLeft.interactable = true;
                imgLeft.sprite = Symbol(GameState.Instance.board[currentPlace[0], currentPlace[1] - 1]);
            }
        }
        else
        {
            btnLeft.interactable = false;
            imgLeft.sprite = imgEdge_Symbol;
        }
        if (currentPlace[1] < 5)
        {

            if (GameState.Instance.quarantined[GameState.Instance.board[currentPlace[0], currentPlace[1] + 1]] > 0)
            {
                btnRight.interactable = false;
                imgRight.sprite = imgQuarantine_Symbol;
            }
            else
            {
                btnRight.interactable = true;
                imgRight.sprite = Symbol(GameState.Instance.board[currentPlace[0], currentPlace[1] + 1]);
            }
        }
        else
        {
            btnRight.interactable = false;
            imgRight.sprite = imgEdge_Symbol;
        }

    }

    void endClick()
    {


        if (firstMove && GameState.Instance.board[GameState.Instance.currentPlace[GameState.Instance.currentTurn][0], GameState.Instance.currentPlace[GameState.Instance.currentTurn][1]] == 0)
        {
            firstMove = false;
            currentPlace = GameState.Instance.currentPlace[GameState.Instance.currentTurn];
            setButtons(currentPlace);
            imgPlace.sprite = Place(GameState.Instance.board[currentPlace[0], currentPlace[1]]);
        }
        else
        {
            firstMove = true;
            player.SetPlayerState(GameState.Instance.currentTurn, "Action");
            UIManager.Instance.Place();
        }
    }
    void rightClick()
    {
        currentPlace[1] += 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace[0], currentPlace[1]);
        endClick();
    }
    void leftClick()
    {
        currentPlace[1] -= 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace[0], currentPlace[1]);
        endClick();
    }
    void downClick()
    {
        currentPlace[0] += 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace[0], currentPlace[1]);
        endClick();
    }
    void upClick()
    {
        currentPlace[0] -= 1;
        player.SetCurrentPlace(GameState.Instance.currentTurn, currentPlace[0], currentPlace[1]);
        endClick();
    }
    void stayClick()
    {
        firstMove = false;
        endClick();
    }

    Sprite Symbol(int place)
    {
        Sprite s = imgStreet_Symbol;
        switch (place)
        {
            case 0:
                s = imgStreet_Symbol;
                break;
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
    Sprite Place(int place)
    {
        Sprite s = imgStreet;
        switch (place)
        {
            case 0:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -2.33f, 0);
                s = imgStreet;
                break;
            case 1:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -2.33f, 0);
                s = imgMainsquare;
                break;
            case 2:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -2.33f, 0);
                s = imgPark;
                break;
            case 3:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -2.33f, 0);
                s = imgHospital;
                break;
            case 4:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 17.33f, 0);
                s = imgBank;
                break;
            case 5:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -2.33f, 0);
                s = imgParliament;
                break;
            case 6:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,58.6f, 0);
                s = imgCemetary;
                break;
            case 7:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -58.94f, 0);
                s = imgPrison;
                break;
            case 8:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -59.02f, 0);
                s = imgCasino;
                break;
            case 9:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -27.89f, 0);
                s = imgInternetcafe;
                break;
            case 10:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50.4f, 0);
                s = imgTrainstation;
                break;
            case 11:
                s = imgArmyshop;
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -2.33f, 0);
                break;
            case 12:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 6.58f, 0);
                s = imgShoppingcenter;
                break;
            case 13:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 15.8f, 0);
                s = imgJunkyard;
                break;
            case 14:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 54.12f, 0);
                s = imgLibrary;
                break;
            case 15:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50.37f, 0);
                s = imgLaboratory;
                break;
            case 16:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 38.18f, 0);
                s = imgItalienrestaurant;
                break;
            case 17:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -51.58f, 0);
                s = imgHarbor;
                break;
            case 18:
                imgPlace.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 24.65f, 0);
                s = imgBar;
                break;
        }
        return s;
    }

}
