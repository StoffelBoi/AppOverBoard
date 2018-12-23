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
    public Text txt_board;
    

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

    // Use this for initialization
    
    void Start () {
      
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
        GameState.board = board;
        for(int rows = 0; rows < board.GetLength(0); rows++)
        {
            for(int cols = 0; cols < board.GetLength(1); cols++)
            {
                //txt_board.text += " " + board[rows, cols] + " ";
                txt_board.text += " ";

                switch(board[rows, cols])
                {
                    case 0:
                        txt_board.text += "Straße";
                        break;
                    case 1:
                        txt_board.text += "Stadtplatz";
                        break;
                    case 2:
                        txt_board.text += "Park";
                        break;
                    case 3:
                        txt_board.text += "Krankenhaus";
                        break;
                    case 4:
                        txt_board.text += "Bank";
                        break;
                    case 5:
                        txt_board.text += "Parlament";
                        break;
                    case 6:
                        txt_board.text += "Friedhof";
                        break;
                    case 7:
                        txt_board.text += "Gefängnis";
                        break;
                    case 8:
                        txt_board.text += "Kasino";
                        break;
                    case 9:
                        txt_board.text += "Internet Cafe";
                        break;
                    case 10:
                        txt_board.text += "Bahnhof";
                        break;
                    case 11:
                        txt_board.text += "Armee Laden";
                        break;
                    case 12:
                        txt_board.text += "Shopping Center";
                        break;
                    case 13:
                        txt_board.text += "Schrottplatz";
                        break;
                    case 14:
                        txt_board.text += "Bibliothek";
                        break;
                    case 15:
                        txt_board.text += "Labor";
                        break;
                    case 16:
                        txt_board.text += "Italiener";
                        break;
                    case 17:
                        txt_board.text += "Hafen";
                        break;
                    case 18:
                        txt_board.text += "Bar";
                        break;
                }
                txt_board.text += " ";
            }
            txt_board.text += "\n";
        }

        
       

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UIManager.Instance.Movement();
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
