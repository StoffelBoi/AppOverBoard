using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Image TitelPanel;
    public Button btnBoard;
    public Button btnRules;
    public Button btnRestart;
    public Image RestartPanel;
    public Button btnNo;
    public Button btnYes;
    public Button btnBack;
    public Image BoardTitelPanel;
    public Image BoardPanel;

    public Sprite armyshop;
    public Sprite bank;
    public Sprite bar;
    public Sprite casino;
    public Sprite cemetary;
    public Sprite harbor;
    public Sprite hospital;
    public Sprite internetCafe;
    public Sprite italienRest;
    public Sprite junkyard;
    public Sprite laboratory;
    public Sprite library;
    public Sprite mainsquare;
    public Sprite park;
    public Sprite parliament;
    public Sprite prison;
    public Sprite shoppingcenter;
    public Sprite street;
    public Sprite trainstation;

    public Image symbol_0_0;
    public Image symbol_0_1;
    public Image symbol_0_2;
    public Image symbol_0_3;
    public Image symbol_0_4;
    public Image symbol_0_5;

    public Image symbol_1_0;
    public Image symbol_1_1;
    public Image symbol_1_2;
    public Image symbol_1_3;
    public Image symbol_1_4;
    public Image symbol_1_5;

    public Image symbol_2_0;
    public Image symbol_2_1;
    public Image symbol_2_2;
    public Image symbol_2_3;
    public Image symbol_2_4;
    public Image symbol_2_5;

    public Image symbol_3_0;
    public Image symbol_3_1;
    public Image symbol_3_2;
    public Image symbol_3_3;
    public Image symbol_3_4;
    public Image symbol_3_5;

    public Image symbol_4_0;
    public Image symbol_4_1;
    public Image symbol_4_2;
    public Image symbol_4_3;
    public Image symbol_4_4;
    public Image symbol_4_5;

    public Image symbol_5_0;
    public Image symbol_5_1;
    public Image symbol_5_2;
    public Image symbol_5_3;
    public Image symbol_5_4;
    public Image symbol_5_5;

    public Image symbol_6_0;
    public Image symbol_6_1;
    public Image symbol_6_2;
    public Image symbol_6_3;
    public Image symbol_6_4;
    public Image symbol_6_5;


    // Use this for initialization
    void Start()
    {
        btnBack.onClick.AddListener(UIManager.Instance.CloseMenu);
        btnBoard.onClick.AddListener(btnBoardOnClick);
        btnNo.onClick.AddListener(btnRestartClose);
        btnYes.onClick.AddListener(UIManager.Instance.RestartScene);
        btnRestart.onClick.AddListener(btnRestartClick);

        TitelPanel.gameObject.SetActive(true);
        btnBoard.gameObject.SetActive(true);
        btnRules.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(true);

        RestartPanel.gameObject.SetActive(false);
        btnNo.gameObject.SetActive(false);
        btnYes.gameObject.SetActive(false);
        BoardTitelPanel.gameObject.SetActive(false);
        BoardPanel.gameObject.SetActive(false);
    }
    void OnEnable()
    {
        TitelPanel.gameObject.SetActive(true);
        btnBoard.gameObject.SetActive(true);
        btnRules.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(true);

        RestartPanel.gameObject.SetActive(false);
        btnNo.gameObject.SetActive(false);
        btnYes.gameObject.SetActive(false);
        BoardTitelPanel.gameObject.SetActive(false);
        BoardPanel.gameObject.SetActive(false);

        if (GameState.Instance.boardGenerated)
        {
            btnBoard.interactable = true;
        }
        else
        {
            btnBoard.interactable = false;
        }
    }
    void btnBoardOnClick()
    {
        FillBoard();
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(btnBoardClose);
        BoardTitelPanel.gameObject.SetActive(true);
        BoardPanel.gameObject.SetActive(true);

        TitelPanel.gameObject.SetActive(false);
        btnBoard.gameObject.SetActive(false);
        btnRules.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);

    }

    void btnBoardClose()
    {
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(UIManager.Instance.CloseMenu);
        BoardTitelPanel.gameObject.SetActive(false);
        BoardPanel.gameObject.SetActive(false);

        TitelPanel.gameObject.SetActive(true);
        btnBoard.gameObject.SetActive(true);
        btnRules.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(true);
    }

    void btnRestartClick()
    {
        RestartPanel.gameObject.SetActive(true);
        btnNo.gameObject.SetActive(true);
        btnYes.gameObject.SetActive(true);

        TitelPanel.gameObject.SetActive(false);
        btnBoard.gameObject.SetActive(false);
        btnRules.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);
    }

    void btnRestartClose()
    {
        RestartPanel.gameObject.SetActive(false);
        btnNo.gameObject.SetActive(false);
        btnYes.gameObject.SetActive(false);

        TitelPanel.gameObject.SetActive(true);
        btnBoard.gameObject.SetActive(true);
        btnRules.gameObject.SetActive(true);
        btnRestart.gameObject.SetActive(true);
    }

    void FillBoard()
    {
        symbol_0_0.sprite = GetPlacePic(GameState.Instance.board[0, 0]);
        symbol_0_1.sprite = GetPlacePic(GameState.Instance.board[0, 1]);
        symbol_0_2.sprite = GetPlacePic(GameState.Instance.board[0, 2]);
        symbol_0_3.sprite = GetPlacePic(GameState.Instance.board[0, 3]);
        symbol_0_4.sprite = GetPlacePic(GameState.Instance.board[0, 4]);
        symbol_0_5.sprite = GetPlacePic(GameState.Instance.board[0, 5]);

        symbol_1_0.sprite = GetPlacePic(GameState.Instance.board[1, 0]);
        symbol_1_1.sprite = GetPlacePic(GameState.Instance.board[1, 1]);
        symbol_1_2.sprite = GetPlacePic(GameState.Instance.board[1, 2]);
        symbol_1_3.sprite = GetPlacePic(GameState.Instance.board[1, 3]);
        symbol_1_4.sprite = GetPlacePic(GameState.Instance.board[1, 4]);
        symbol_1_5.sprite = GetPlacePic(GameState.Instance.board[1, 5]);

        symbol_2_0.sprite = GetPlacePic(GameState.Instance.board[2, 0]);
        symbol_2_1.sprite = GetPlacePic(GameState.Instance.board[2, 1]);
        symbol_2_2.sprite = GetPlacePic(GameState.Instance.board[2, 2]);
        symbol_2_3.sprite = GetPlacePic(GameState.Instance.board[2, 3]);
        symbol_2_4.sprite = GetPlacePic(GameState.Instance.board[2, 4]);
        symbol_2_5.sprite = GetPlacePic(GameState.Instance.board[2, 5]);

        symbol_3_0.sprite = GetPlacePic(GameState.Instance.board[3, 0]);
        symbol_3_1.sprite = GetPlacePic(GameState.Instance.board[3, 1]);
        symbol_3_2.sprite = GetPlacePic(GameState.Instance.board[3, 2]);
        symbol_3_3.sprite = GetPlacePic(GameState.Instance.board[3, 3]);
        symbol_3_4.sprite = GetPlacePic(GameState.Instance.board[3, 4]);
        symbol_3_5.sprite = GetPlacePic(GameState.Instance.board[3, 5]);

        symbol_4_0.sprite = GetPlacePic(GameState.Instance.board[4, 0]);
        symbol_4_1.sprite = GetPlacePic(GameState.Instance.board[4, 1]);
        symbol_4_2.sprite = GetPlacePic(GameState.Instance.board[4, 2]);
        symbol_4_3.sprite = GetPlacePic(GameState.Instance.board[4, 3]);
        symbol_4_4.sprite = GetPlacePic(GameState.Instance.board[4, 4]);
        symbol_4_5.sprite = GetPlacePic(GameState.Instance.board[4, 5]);

        symbol_5_0.sprite = GetPlacePic(GameState.Instance.board[5, 0]);
        symbol_5_1.sprite = GetPlacePic(GameState.Instance.board[5, 1]);
        symbol_5_2.sprite = GetPlacePic(GameState.Instance.board[5, 2]);
        symbol_5_3.sprite = GetPlacePic(GameState.Instance.board[5, 3]);
        symbol_5_4.sprite = GetPlacePic(GameState.Instance.board[5, 4]);
        symbol_5_5.sprite = GetPlacePic(GameState.Instance.board[5, 5]);

        symbol_6_0.sprite = GetPlacePic(GameState.Instance.board[6, 0]);
        symbol_6_1.sprite = GetPlacePic(GameState.Instance.board[6, 1]);
        symbol_6_2.sprite = GetPlacePic(GameState.Instance.board[6, 2]);
        symbol_6_3.sprite = GetPlacePic(GameState.Instance.board[6, 3]);
        symbol_6_4.sprite = GetPlacePic(GameState.Instance.board[6, 4]);
        symbol_6_5.sprite = GetPlacePic(GameState.Instance.board[6, 5]);
    }

    Sprite GetPlacePic(int place)
    {
        Sprite s = street;
        switch (place)
        {
            case 0:
                s = street;
                break;
            case 1:
                s = mainsquare;
                break;
            case 2:
                s = park;
                break;
            case 3:
                s = hospital;
                break;
            case 4:
                s = bank;
                break;
            case 5:
                s = parliament;
                break;
            case 6:
                s = cemetary;
                break;
            case 7:
                s = prison;
                break;
            case 8:
                s = casino;
                break;
            case 9:
                s = internetCafe;
                break;
            case 10:
                s = trainstation;
                break;
            case 11:
                s = armyshop;
                break;
            case 12:
                s = shoppingcenter;
                break;
            case 13:
                s = junkyard;
                break;
            case 14:
                s = library;
                break;
            case 15:
                s = laboratory;
                break;
            case 16:
                s = italienRest;
                break;
            case 17:
                s = harbor;
                break;
            case 18:
                s = bar;
                break;
        }
        return s;
    }
}
