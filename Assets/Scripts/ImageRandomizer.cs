using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
public class ImageRandomizer : MonoBehaviour
{
    public Sprite imgStreet;
    public Sprite imgCitysquare;
    public Sprite imgPark;
    public Sprite imgHospital;
    public Sprite imgBank;
    public Sprite imgParliament;
    public Sprite imgCemetary;
    public Sprite imgPrison;
    public Sprite imgCasino;
    public Sprite imgInternetCafe;
    public Sprite imgTrainstation;
    public Sprite imgArmyshop;
    public Sprite imgShoppingCenter;
    public Sprite imgJunkYard;
    public Sprite imgLibrary;
    public Sprite imgLaboratory;
    public Sprite imgItalienRestaurant;
    public Sprite imgHarbor;
    public Sprite imgBar;
    public Sprite imgRed;
    public Sprite imgYellow;
    public Sprite imgBlue;
    public Sprite imgGreen;
    public Sprite imgPink;


    private bool changing = false;
    public Animator tileTurn;

    public int aspectX = 6;
    public int aspectY = 4;

    private int xBorder;
    private int yBorder;
    public static System.Random rn = new System.Random();
    // Use this for initialization
    void Start()
    {
        switch (aspectX)
        {
            case 2:
                xBorder = 380;
                break;
            case 3:
                xBorder = 310;
                break;
            case 4:
                xBorder = 240;
                break;
            case 5:
                xBorder = 170;
                break;
            case 6:
                xBorder = 150;
                break;
        }
        switch (aspectY)
        {
            case 2:
                yBorder = 220;
                break;
            case 3:
                yBorder = 180;
                break;
            case 4:
                yBorder = 40;
                break;
        }
    }
    IEnumerator ChangeImage()
    { 
        yield return new WaitForSeconds(0.3f);
        int xPosition = rn.Next(-xBorder, xBorder);
        int yPosition = rn.Next(-yBorder, yBorder);
        this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPosition, yPosition, 0);
        int image = rn.Next(0, 19);
        Sprite imgPlace = imgStreet;
        switch (image)
        {
            case 0:
                imgPlace = imgStreet;
                break;
            case 1:
                imgPlace = imgCitysquare;
                break;
            case 2:
                imgPlace = imgPark;
                break;
            case 3:
                imgPlace = imgHospital;
                break;
            case 4:
                imgPlace = imgBank;
                break;
            case 5:
                imgPlace = imgParliament;
                break;
            case 6:
                imgPlace = imgCemetary;
                break;
            case 7:
                imgPlace = imgPrison;
                break;
            case 8:
                imgPlace = imgCasino;
                break;
            case 9:
                imgPlace = imgInternetCafe;
                break;
            case 10:
                imgPlace = imgTrainstation;
                break;
            case 11:
                imgPlace = imgArmyshop;
                break;
            case 12:
                imgPlace = imgShoppingCenter;
                break;
            case 13:
                imgPlace = imgJunkYard;
                break;
            case 14:
                imgPlace = imgLibrary;
                break;
            case 15:
                imgPlace = imgLaboratory;
                break;
            case 16:
                imgPlace = imgItalienRestaurant;
                break;
            case 17:
                imgPlace = imgHarbor;
                break;
            case 18:
                imgPlace = imgBar;
                break;
        }
        this.gameObject.GetComponent<Image>().sprite = imgPlace;
        yield return new WaitForSeconds(1f);

        changing = false;
    }
    public void ImageChanger()
    {
        if (!changing)
        {
            changing = true;
            if (tileTurn != null)
            {
                tileTurn.SetTrigger("Turning");

            }
            StartCoroutine("ChangeImage");
        }
    }
}
