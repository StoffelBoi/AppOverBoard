using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BoardAssembly : MonoBehaviour {

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

    public LinkedList<int> places = new LinkedList<int>();
    public Canvas canvas;

    public RawImage tile1_1;
    public RawImage tile1_2;
    public RawImage tile1_3;
    public RawImage tile1_4;
    public RawImage tile1_5;
    public RawImage tile1_6;
  
    public RawImage tile2_1;
    public RawImage tile2_2;
    public RawImage tile2_3;
    public RawImage tile2_4;
    public RawImage tile2_5;
    public RawImage tile2_6;
  
    public RawImage tile3_1;
    public RawImage tile3_2;
    public RawImage tile3_3;
    public RawImage tile3_4;
    public RawImage tile3_5;
    public RawImage tile3_6;
   
    public RawImage tile4_1;
    public RawImage tile4_2;
    public RawImage tile4_3;
    public RawImage tile4_4;
    public RawImage tile4_5;
    public RawImage tile4_6;

    public RawImage tile5_1;
    public RawImage tile5_2;
    public RawImage tile5_3;
    public RawImage tile5_4;
    public RawImage tile5_5;
    public RawImage tile5_6;

    public RawImage tile6_1;
    public RawImage tile6_2;
    public RawImage tile6_3;
    public RawImage tile6_4;
    public RawImage tile6_5;
    public RawImage tile6_6;
 
    public RawImage tile7_1;
    public RawImage tile7_2;
    public RawImage tile7_3;
    public RawImage tile7_4;
    public RawImage tile7_5;
    public RawImage tile7_6;


    public Texture armyshop;
    public Texture bank;
    public Texture bar;
    public Texture casino;
    public Texture cemetary;
    public Texture harbor;
    public Texture hospital;
    public Texture internetCafe;
    public Texture italienRest;
    public Texture junkyard;
    public Texture laboratory;
    public Texture library;
    public Texture mainsquareTexture;
    public Texture park;
    public Texture parliament;
    public Texture prison;
    public Texture shoppingcenter;
    public Texture street;
    public Texture trainstation;


    public int[,] board;

    private int place1;
    private int place2;
    private int place3;
    private int place4;
    private int place5;
    private int skillplace1;
    private int mainsquare = 1;
    private int skillplace2;
    private int place6;
    private int place7;
    private int skillplace3;
    private int skillplace4;
    private int skillplace5;
    private int place8;
    private int place9;
    private int place10;
    private int place11;
    private int place12;
    private Player player;
    public Button btnOk;
    public Button btnBack;
    public Button btnMenu;
    // Use this for initialization
    
    void OnEnable () {
        btnBack.interactable = false;
        btnOk.onClick.RemoveAllListeners();
        btnOk.onClick.AddListener(btnReadyToPlay);
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(btnNotReady);
        player = GameState.Instance.localPlayer.GetComponent<Player>();
        board = new int[7, 6]
            {
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0}
            };
        if (player.isServer)
        {


            System.Random rn = new System.Random();

            skillplace1 = newNumber(rn, 2, 7);
            skillplace2 = newNumber(rn, 2, 7);
            skillplace3 = newNumber(rn, 2, 7);
            skillplace4 = newNumber(rn, 2, 7);
            skillplace5 = newNumber(rn, 2, 7);

            place1 = newNumber(rn, 7, 19);
            place2 = newNumber(rn, 7, 19);
            place3 = newNumber(rn, 7, 19);
            place4 = newNumber(rn, 7, 19);
            place5 = newNumber(rn, 7, 19);
            place6 = newNumber(rn, 7, 19);
            place7 = newNumber(rn, 7, 19);
            place8 = newNumber(rn, 7, 19);
            place9 = newNumber(rn, 7, 19);
            place10 = newNumber(rn, 7, 19);
            place11 = newNumber(rn, 7, 19);
            place12 = newNumber(rn, 7, 19);


            board = new int[7, 6]
            {
            {0,0,place1,place2,0,0 },
            {place3,0,0,0,0,place4 },
            {place5,0,skillplace1,skillplace2,0,place6 },
            {0,0,mainsquare,skillplace3,0,0 },
            {place7,0,skillplace4,skillplace5,0,place8 },
            {place9,0,0,0,0,place10 },
            {0,0,place11,place12,0,0 }
            };
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    player.SetBoard(i, j, board[i, j]);
                }
            }
            StartCoroutine("FillBoard");
        }
        else
        {
            StartCoroutine("GetBoard");
        }

    }
    IEnumerator GetBoard()
    {
        Debug.Log("GetBoard Start");
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j <6; j++)
            {
                
                board[i, j] = GameState.Instance.board[i, j];
            }
        }
        StartCoroutine("FillBoard");
    }
    IEnumerator FillBoard()
    {
        

        setImage(tile1_1, 0, 0);
        tile1_1.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_2, 0, 1);
        tile1_2.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_3, 0, 2);
        tile1_3.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_4, 0, 3);
        tile1_4.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_5, 0, 4);
        tile1_5.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_6, 0, 5);
        tile1_6.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_1, 1, 0);
        tile2_1.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_2, 1, 1);
        tile2_2.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_3, 1, 2);
        tile2_3.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_4, 1, 3);
        tile2_4.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_5, 1, 4);
        tile2_5.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_6, 1, 5);
        tile2_6.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_1, 2, 0);
        tile3_1.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_2, 2, 1);
        tile3_2.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_3, 2, 2);
        tile3_3.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_4, 2, 3);
        tile3_4.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_5, 2, 4);
        tile3_5.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_6, 2, 5);
        tile3_6.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_1, 3, 0);
        tile4_1.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_2, 3, 1);
        tile4_2.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_3, 3, 2);
        tile4_3.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_4, 3, 3);
        tile4_4.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_5, 3, 4);
        tile4_5.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_6, 3, 5);
        tile4_6.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_1, 4, 0);
        tile5_1.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_2, 4, 1);
        tile5_2.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_3, 4, 2);
        tile5_3.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_4, 4, 3);
        tile5_4.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_5, 4, 4);
        tile5_5.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_6, 4, 5);
        tile5_6.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_1, 5, 0);
        tile6_1.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_2, 5, 1);
        tile6_2.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_3, 5, 2);
        tile6_3.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_4, 5, 3);
        tile6_4.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_5, 5, 4);
        tile6_5.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_6, 5, 5);
        tile6_6.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile7_1, 6, 0);
        tile7_1.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile7_2, 6, 1);
        tile7_2.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile7_3, 6, 2);
        tile7_3.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile7_4, 6, 3);
        tile7_4.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile7_5, 6, 4);
        tile7_5.gameObject.GetComponent<Animator>().SetTrigger("Turning");
        yield return new WaitForSeconds(0.001f);
        setImage(tile7_6, 6, 5);
        tile7_6.gameObject.GetComponent<Animator>().SetTrigger("Turning");
    }
        private void setImage(RawImage tile, int row, int col)
    {

        switch (board[row, col])
        {
            case 0:
                tile.texture = street;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 1:
                tile.texture = mainsquareTexture;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 2:
                tile.texture = park;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 3:
                tile.texture = hospital;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 4:
                tile.texture = bank;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 5:
                tile.texture = parliament;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 6:
                tile.texture = cemetary;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 7:
                tile.texture = prison;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 8:
                tile.texture = casino;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 9:
                tile.texture = internetCafe;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 10:
                tile.texture = trainstation;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 11:
                tile.texture = armyshop;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 12:
                tile.texture = shoppingcenter;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 13:
                tile.texture = junkyard;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 14:
                tile.texture = library;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 15:
                tile.texture = laboratory;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 16:
                tile.texture = italienRest;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 17:
                tile.texture = harbor;
                tile.color = new Color(255, 255, 255, 255);
                break;
            case 18:
                tile.texture = bar;
                tile.color = new Color(255, 255, 255, 255);
                break;
        }
    }
	
    void btnReadyToPlay()
    {
        GameState.Instance.localPlayer.GetComponent<Player>().SetReadyToPlay(GameState.Instance.localPlayer.GetComponent<Player>().id, true);
        btnBack.interactable = true;
        btnOk.interactable = false;
    }
    void btnNotReady()
    {
        btnOk.interactable = true;
        GameState.Instance.localPlayer.GetComponent<Player>().SetReadyToPlay(GameState.Instance.localPlayer.GetComponent<Player>().id, false);
        btnBack.interactable = false;
    }
    void Update()
    {
        int readyCount = 0;
            for(int i = 0; i<GameState.Instance.playerCount; i++)
            {
                if (GameState.Instance.readyToPlay[i])
                {
                readyCount++;
                }
            }
        if (readyCount == GameState.Instance.playerCount)
        {
            TimeManager.Instance.gameObject.SetActive(true);
            TimeManager.Instance.startTimer();
            UIManager.Instance.Draw();
        }
        
    }
    int newNumber(System.Random rn, int under, int upper)
    {
        int number = 0;

        number = rn.Next(under, upper);

        while(places.Contains(number))
        {
            number = rn.Next(under, upper);

        }

        places.AddLast(number);

        return number;
    }
}
