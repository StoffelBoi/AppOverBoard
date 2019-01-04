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
    public RawImage tile1_7;
    public RawImage tile2_1;
    public RawImage tile2_2;
    public RawImage tile2_3;
    public RawImage tile2_4;
    public RawImage tile2_5;
    public RawImage tile2_6;
    public RawImage tile2_7;
    public RawImage tile3_1;
    public RawImage tile3_2;
    public RawImage tile3_3;
    public RawImage tile3_4;
    public RawImage tile3_5;
    public RawImage tile3_6;
    public RawImage tile3_7;
    public RawImage tile4_1;
    public RawImage tile4_2;
    public RawImage tile4_3;
    public RawImage tile4_4;
    public RawImage tile4_5;
    public RawImage tile4_6;
    public RawImage tile4_7;
    public RawImage tile5_1;
    public RawImage tile5_2;
    public RawImage tile5_3;
    public RawImage tile5_4;
    public RawImage tile5_5;
    public RawImage tile5_6;
    public RawImage tile5_7;
    public RawImage tile6_1;
    public RawImage tile6_2;
    public RawImage tile6_3;
    public RawImage tile6_4;
    public RawImage tile6_5;
    public RawImage tile6_6;
    public RawImage tile6_7;

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
    // Use this for initialization
    
    void OnEnable () {
        
        player = GameState.Instance.localPlayer.GetComponent<Player>();
        board = new int[6, 7]
            {
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, 0, 0, 0, 0, 0, 0 }
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


            board = new int[6, 7]
            {
            {0, place1, place2, 0, place3, place4, 0 },
            {0, 0, 0, 0, 0, 0, 0 },
            {place5, 0, skillplace1, mainsquare, skillplace2, 0, place6 },
            {place7, 0, skillplace3, skillplace4, skillplace5, 0, place8 },
            {0, 0, 0, 0, 0, 0, 0 },
            {0, place9, place10, 0, place11, place12, 0 }
            };
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
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
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                
                board[i, j] = GameState.Instance.board[i, j];
                Debug.Log("place: " + board[i, j]);
            }
        }
        StartCoroutine("FillBoard");
    }
    IEnumerator FillBoard()
    {
        Debug.Log("FillBoard");
        setImage(tile1_1, 0, 0);
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_2, 0, 1);
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_3, 0, 2);
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_4, 0, 3);
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_5, 0, 4);
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_6, 0, 5);
        yield return new WaitForSeconds(0.001f);
        setImage(tile1_7, 0, 6);
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_1, 1, 0);
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_2, 1, 1);
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_3, 1, 2);
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_4, 1, 3);
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_5, 1, 4);
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_6, 1, 5);
        yield return new WaitForSeconds(0.001f);
        setImage(tile2_7, 1, 6);
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_1, 2, 0);
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_2, 2, 1);
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_3, 2, 2);
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_4, 2, 3);
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_5, 2, 4);
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_6, 2, 5);
        yield return new WaitForSeconds(0.001f);
        setImage(tile3_7, 2, 6);
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_1, 3, 0);
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_2, 3, 1);
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_3, 3, 2);
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_4, 3, 3);
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_5, 3, 4);
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_6, 3, 5);
        yield return new WaitForSeconds(0.001f);
        setImage(tile4_7, 3, 6);
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_1, 4, 0);
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_2, 4, 1);
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_3, 4, 2);
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_4, 4, 3);
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_5, 4, 4);
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_6, 4, 5);
        yield return new WaitForSeconds(0.001f);
        setImage(tile5_7, 4, 6);
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_1, 5, 0);
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_2, 5, 1);
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_3, 5, 2);
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_4, 5, 3);
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_5, 5, 4);
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_6, 5, 5);
        yield return new WaitForSeconds(0.001f);
        setImage(tile6_7, 5, 6);
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
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeManager.Instance.startTimer();
            UIManager.Instance.PrivatePlayer();
        }
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                TimeManager.Instance.startTimer();
                UIManager.Instance.PrivatePlayer();
            }
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
