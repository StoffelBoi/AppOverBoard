﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rules : MonoBehaviour
{
    public Canvas cvsRulesStart;
    public Canvas cvsPlaces;
    public Canvas cvsCharacter;
    public Canvas cvsCriminals;
    public Canvas cvsItems;
    public Canvas cvsGeneral;

    public Text txtTitel;

    public Button btnGeneral;
    public Button btnPlaces;
    public Button btnCharacter;
    public Button btnCriminals;
    public Button btnItems;

    public Button btnPageBack;
    public Button btnPageForward;
    public Button btnBack;

    public Text txtGeneral;

    public Text txtPlaceOne;
    public Text txtPlaceTwo;
    public Text txtPlaceThree;
    public Text txtPlaceFour;

    public Image imgPlaceOne;
    public Image imgPlaceTwo;
    public Image imgPlaceThree;
    public Image imgPlaceFour;

    public Image imgPlaceOneSymbol;
    public Image imgPlaceTwoSymbol;
    public Image imgPlaceThreeSymbol;
    public Image imgPlaceFourSymbol;

    public Text txtCharacterOne;
    public Text txtCharacterTwo;
    public Text txtCharacterThree;

    public Image imgCharacterOne;
    public Image imgCharacterTwo;
    public Image imgCharacterThree;

    public Image imgCharacterOneBG;
    public Image imgCharacterTwoBG;
    public Image imgCharacterThreeBG;

    public Image CriminalGeneralPanel;
    public Text txtCriminalGeneral;

    public Image imgCriminalOne;
    public Image imgCriminalTwo;

    public Text txtCriminalOne;
    public Text txtCriminalTwo;

    public Image imgItemsOne;
    public Image imgItemsTwo;
    public Image imgItemsThree;

    public Text txtItemsOne;
    public Text txtItemsTwo;
    public Text txtItemsThree;

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

    public Sprite mcay;
    public Sprite fields;
    public Sprite cooper;
    public Sprite osswald;
    public Sprite larsen;
    public Sprite edmond;

    public Sprite trainers;
    public Sprite fingerprintKit;
    public Sprite energyDrink;
    public Sprite calculator;
    public Sprite whiskey;
    public Sprite protectiveItems;

    public Sprite inferno;
    public Sprite drMortifier;
    public Sprite phantom;
    public Sprite fasculto;

    private int page = 1;
    private string chapter="start";

    void OnEnable()
    {
        DisableEverything();
        cvsRulesStart.gameObject.SetActive(true);

        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(UIManager.Instance.CloseRules);

        btnPageBack.onClick.RemoveAllListeners();
        btnPageBack.onClick.AddListener(PageBack);

        btnPageForward.onClick.RemoveAllListeners();
        btnPageForward.onClick.AddListener(PageForward);

        btnPageBack.interactable = false;
        btnPageForward.interactable = false;

        txtTitel.text = "Regeln";

        page = 1;
        chapter = "start";

        btnGeneral.onClick.RemoveAllListeners();
        btnGeneral.onClick.AddListener(General);
        btnPlaces.onClick.RemoveAllListeners();
        btnPlaces.onClick.AddListener(Places);
        btnCharacter.onClick.RemoveAllListeners();
        btnCharacter.onClick.AddListener(Character);
        btnCriminals.onClick.RemoveAllListeners();
        btnCriminals.onClick.AddListener(Criminals);
        btnItems.onClick.RemoveAllListeners();
        btnItems.onClick.AddListener(Items);

    }

    void DisableEverything()
    {
        cvsRulesStart.gameObject.SetActive(false);
        cvsGeneral.gameObject.SetActive(false);
        cvsPlaces.gameObject.SetActive(false);
        cvsCharacter.gameObject.SetActive(false);
        cvsCriminals.gameObject.SetActive(false);
        cvsItems.gameObject.SetActive(false);
    }

    void PageBack()
    {
        page--;

        switch (chapter)
        {
            case "start":
                OnEnable();
                break;
            case "general":
                General();
                break;
            case "places":
                Places();
                break;
            case "character":
                Character();
                break;
            case "criminals":
                Criminals();
                break;
            case "items":
                Items();
                break;
        }
    }

    void PageForward()
    {
        page++;

        switch (chapter)
        {
            case "start":
                OnEnable();
                break;
            case "general":
                General();
                break;
            case "places":
                Places();
                break;
            case "character":
                Character();
                break;
            case "criminals":
                Criminals();
                break;
            case "items":
                Items();
                break;
        }
    }

    void General()
    {
        DisableEverything();
        cvsGeneral.gameObject.SetActive(true);
        txtTitel.text = "Allgemeines";
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(OnEnable);
        chapter = "general";

        switch (page)
        {
            case 1:
                btnPageForward.interactable = true;
                btnPageBack.interactable = false;

                txtGeneral.text = "Allgemeine Regeln Seite 1";
                break;
            case 2:
                btnPageForward.interactable = false;
                btnPageBack.interactable = true;

                txtGeneral.text = "Allgemeine Regeln Seite 2";
                break;
        }
    }

    void Places()
    {
        DisableEverything();
        cvsPlaces.gameObject.SetActive(true);
        txtTitel.text = "Orte";
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(OnEnable);
        chapter = "places";

        switch (page)
        {
            case 1:
                btnPageForward.interactable = true;
                btnPageBack.interactable = false;

                imgPlaceOne.sprite = mainsquare;
                imgPlaceOneSymbol.sprite = imgMainsquare_Symbol;
                imgPlaceTwo.sprite = internetcafe;
                imgPlaceTwoSymbol.sprite = imgInternetcafe_Symbol;
                imgPlaceThree.sprite = casino;
                imgPlaceThreeSymbol.sprite = imgCasino_Symbol;
                imgPlaceFour.sprite = junkyard;
                imgPlaceFourSymbol.sprite = imgJunkyard_Symbol;

                txtPlaceOne.text = "Stadtplatz\n\n-Startpunkt für alle Spieler\n\n-Geld verdienen: 6$";
                txtPlaceTwo.text = "Internet Cafe\n\n-Geld verdienen: 6$\n\n-Verbrecher kann sich hier Fallen kaufen.";
                txtPlaceTwo.fontSize = 39;
                txtPlaceThree.text = "Kasino\n\n-Glückspiel: 50% Chance sein gesetztes Geld zu verdoppeln bzw. verlieren.";
                txtPlaceFour.text = "Schrottplatz\n\n-Schrott durchsuchen und zufällige Items finden.";

                break;
            case 2:
                btnPageForward.interactable = true;
                btnPageBack.interactable = true;

                imgPlaceOne.sprite = armyshop;
                imgPlaceOneSymbol.sprite = imgArmyshop_Symbol;
                imgPlaceTwo.sprite = shoppingcenter;
                imgPlaceTwoSymbol.sprite = imgShoppingcenter_Symbol;
                imgPlaceThree.sprite = trainstation;
                imgPlaceThreeSymbol.sprite = imgTrainstation_Symbol;
                imgPlaceFour.sprite = library;
                imgPlaceFourSymbol.sprite = imgLibrary_Symbol;

                txtPlaceOne.text = "Armee Laden\n\n-Schutzitems kaufen:\n\t-6$ Schutzweste\n\t-15$ F.fester Mantel\n\t-15$ Gasmaske\n\t-15$ Bodycam\n\t-15$ Talisman";
                txtPlaceTwo.text = "Shopping Center\n\n-Items kaufen: \n\t-4$ Turnschuhe\n\t-4$ Fingerabdruck Set\n\t-3$ Energy Drink\n\t-8$ Taschenrechner\n\t-8$ Whiskey\n-2$ Verbrecher kann sich hier zufällig eine Falle kaufen.";
                txtPlaceTwo.fontSize = 34;
                txtPlaceThree.text = "Bahnhof\n\n-Reise zu jeden Ort für 2$.";
                txtPlaceFour.text = "Bibliothek\n\n-Hinweise entschlüsseln.";
                break;
            case 3:
                btnPageForward.interactable = true;
                btnPageBack.interactable = true;

                imgPlaceOne.sprite = laboratory;
                imgPlaceOneSymbol.sprite = imgLaboratory_Symbol;
                imgPlaceTwo.sprite = italienrestaurant;
                imgPlaceTwoSymbol.sprite = imgItalienrestaurant_Symbol;
                imgPlaceThree.sprite = harbor;
                imgPlaceThreeSymbol.sprite = imgHarbor_Symbol;
                imgPlaceFour.sprite = bar;
                imgPlaceFourSymbol.sprite = imgBar_Symbol;

                txtPlaceOne.text = "Labor\n\n-Hinweise entschlüsseln";
                txtPlaceTwo.text = "Italiener\n\n-1-4$ für einen ev. richtigen Hinweis, je mehr man zahlt desto besser sind die Chancen.";
                txtPlaceTwo.fontSize = 39;
                txtPlaceThree.text = "Hafen\n\n-3$ für einen ev. richtigen Hinweis\n\n-Verbrecher kann sich hier Fallen kaufen.";
                txtPlaceFour.text = "Bar\n\n-2$ für einen ev. richtigen Hinweis, in der nächsten Runde wacht man an einen zufälligen Platz auf.";
                break;
            case 4:
                btnPageForward.interactable = true;
                btnPageBack.interactable = true;

                imgPlaceOne.sprite = hospital;
                imgPlaceOneSymbol.sprite = imgHospital_Symbol;
                imgPlaceTwo.sprite = bank;
                imgPlaceTwoSymbol.sprite = imgBank_Symbol;
                imgPlaceThree.sprite = park;
                imgPlaceThreeSymbol.sprite = imgPark_Symbol;
                imgPlaceFour.sprite = cementary;
                imgPlaceFourSymbol.sprite = imgCemetary_Symbol;

                txtPlaceOne.text = "Krankenhaus\n\n-Ort für die Fähigkeit von Dr. Moe McKay.";
                txtPlaceTwo.text = "Bank\n\n-Ort für die Fähigkeit von Felicity Fields.";
                txtPlaceTwo.fontSize = 39;
                txtPlaceThree.text = "Park\n\n-Ort für die Fähigkeit von Colin Cooper.";
                txtPlaceFour.text = "Friedhof\n\n-Ort für die Fähigkeit von Olivia Osswald.";
                break;
            case 5:
                btnPageForward.interactable = false;
                btnPageBack.interactable = true;

                imgPlaceOne.sprite = prison;
                imgPlaceOneSymbol.sprite = imgPrison_Symbol;
                imgPlaceTwo.sprite = parliament;
                imgPlaceTwoSymbol.sprite = imgParliament_Symbol;
                imgPlaceThree.sprite = street;
                imgPlaceThreeSymbol.sprite = imgStreet_Symbol;
                imgPlaceFour.sprite = null;
                imgPlaceFourSymbol.sprite = null;

                txtPlaceOne.text = "Gefängnis\n\n-Ort für die Fähigkeit von Laura Larsen.";
                txtPlaceTwo.text = "Parlament\n\n-Ort für die Fähigkeit von Erik Edmond.";
                txtPlaceTwo.fontSize = 39;
                txtPlaceThree.text = "Straße\n\n-zufällige Event.s";
                txtPlaceFour.text = " ";
                break;
        }

    }

    void Character()
    {
        DisableEverything();
        cvsCharacter.gameObject.SetActive(true);
        txtTitel.text = "Charaktere";
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(OnEnable);
        chapter = "character";

        switch (page)
        {
            case 1:
                btnPageForward.interactable = true;
                btnPageBack.interactable = false;

                imgCharacterOne.sprite = mcay;
                imgCharacterTwo.sprite = fields;
                imgCharacterThree.sprite = cooper;

                imgCharacterOneBG.sprite = hospital;
                imgCharacterTwoBG.sprite = bank;
                imgCharacterThreeBG.sprite = park;

                txtCharacterOne.text = "Dr. Moe McKay\n\n-kann im Krankenhaus einen Ort für 2 Runden unter Quarantäne stellen und in so für alle Charaktere sperren.";
                txtCharacterTwo.text = "Felicity Field\n\n-kann in der Bank die letzte Transaktion eines Spielers einsehen.";
                txtCharacterThree.text = "Colin Cooper\n\n-kann im Park sein Obdachlosennetzwerk fragen wieviele Questorte der Verbrecher schon erledigt hat.";

                break;
            case 2:
                btnPageForward.interactable = false;
                btnPageBack.interactable = true;

                imgCharacterOne.sprite = osswald;
                imgCharacterTwo.sprite = larsen;
                imgCharacterThree.sprite = edmond;

                imgCharacterOneBG.sprite = cementary;
                imgCharacterTwoBG.sprite = prison;
                imgCharacterThreeBG.sprite = parliament;

                txtCharacterOne.text = "Olivia Osswald\n\n-kann im Friedhof eine Seance abhalten um herauszufinden wo sich in der Stadt scharfe Fallen befinden.";
                txtCharacterTwo.text = "Laura Larsen\n\n-kann im Gefängnis eine Studie durch- führen um alle falschen Hinweise in der Stadt verschwinden zu lassen.";
                txtCharacterThree.text = "Eric Edmond\n\n-kann im Parlament einen Politiker erpressen um heraus- zufinden welche Aktion ein Spieler im letzten Zug durchgeführt hat.";
                break;

        }
    }

    void Criminals()
    {
        DisableEverything();
        cvsCriminals.gameObject.SetActive(true);
        txtTitel.text = "Verbrecher";
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(OnEnable);
        chapter = "criminals";

        switch (page)
        {
            case 1:
                btnPageForward.interactable = true;
                btnPageBack.interactable = false;
                CriminalGeneralPanel.gameObject.SetActive(true);
                txtCriminalGeneral.text = "Allgemeine Verbrecher Regeln Seite 1";
                break;
            case 2:
                btnPageForward.interactable = true;
                btnPageBack.interactable = true;
                CriminalGeneralPanel.gameObject.SetActive(true);
                txtCriminalGeneral.text = "Allgemeine Verbrecher Regeln Seite 2";
                break;
            case 3:
                btnPageForward.interactable = true;
                btnPageBack.interactable = true;
                CriminalGeneralPanel.gameObject.SetActive(false);

                imgCriminalOne.sprite = inferno;
                imgCriminalTwo.sprite = drMortifier;

                txtCriminalOne.text = "Inferno\n\n-muss seine Bombe innerhalb von 50 Minuten platzieren.\n\nQuestorte:\nArmee Laden\nShopping Center\nSchrottplatz\n\nMögliche Zielorte:\nParlament\nGefängnis\nKasino";
                txtCriminalTwo.text = "Dr.Mortifier\n\n-muss nach dem Platzieren der Krankheitserreger innerhalb von 10 Minuten 5+ Felder vom Seuchenherd entfernt sein.\n\nQuestorte:\nShopping Center\nBibliothek\nLabor\n\nMögliche Zielorte:\nStadtplatz\nShopping Center\nHafen";

                break;
            case 4:
                btnPageForward.interactable = false;
                btnPageBack.interactable = true;
                CriminalGeneralPanel.gameObject.SetActive(false);

                imgCriminalOne.sprite = phantom;
                imgCriminalTwo.sprite = fasculto;

                txtCriminalOne.text = "Phantom\n\n-hat alle 20 Minuten ein 5 Minuten Zeitfenster für seinen Einbruch.\n\nQuestorte:\nInternet Cafe\nArmee Laden\nBar\n\nMögliche Zielorte:\nBank\nKasino\nShoppingCenter";
                txtCriminalTwo.text = "Fasculto\n\n-hat nach 40 Minuten für 20 Minuten Zeit sein Ritual durchzuführen.\n\nQuestorte:\nBibliothek\nHafen\nBar\n\nMögliche Zielorte:\nParlament\nFriedhof\nGefängnis";

                break;
        }
    }

    void Items()
    {
        DisableEverything();
        cvsItems.gameObject.SetActive(true);
        txtTitel.text = "Items";
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(OnEnable);
        chapter = "items";

        switch (page)
        {
            case 1:
                btnPageBack.interactable = false;
                btnPageForward.interactable = true;
                imgItemsOne.sprite = trainers;
                imgItemsTwo.sprite = fingerprintKit;
                imgItemsThree.sprite = energyDrink;

                    txtItemsOne.text = "Turnschuhe\n\n-ermöglichen es sich ein weiteres Mal zu bewegen.";
                txtItemsTwo.text = "Fingerabdruck Set\n\n-ermöglicht es alle Hinweise am derzeitigen Platz zu finden und diese sofort zu entschlüsseln.";
                txtItemsThree.fontSize = 50;
                txtItemsThree.text = "Energy Drink\n\n-ermöglicht es im aktuellen Zug eine weitere Aktion durchzuführen.";
                break;
            case 2:
                btnPageBack.interactable = true;
                btnPageForward.interactable = false;
                imgItemsOne.sprite = calculator;
                imgItemsTwo.sprite = whiskey;
                imgItemsThree.sprite = protectiveItems;

                   txtItemsOne.text = "Taschenrechner\n\n-ermöglicht es am Stadtplatz und im Internet Cafe 2$ mehr zu verdienen.";
                txtItemsTwo.text = "Whiskey\n\n-ermöglicht es diesen am Hafen gegen eine wahren entschlüsselten Hinweis auszutauschen.";
                txtItemsThree.fontSize = 30;
                txtItemsThree.text = "Schutz Items\n\n-schützen dich gegen Fallen.\n\nSchutzweste: einmal alle Fallen.\n\nF.fester Mantel: permanent Bomben.\n\nGasmaske: permanent Petrischalen.\n\nBodycam: permanent Diebesgut.\n\nTalisman: permanent v. Artifakte.";
                break;

        }
    }






























    /* public Button btn_places;
     public Button btn_evil;
     public Button btn_good;
     public Button btn_winCon;
     public Button btn_hints;
     public Button btn_movement;
     public Button btn_player;
     public Button btn_backPlace;
     public Button btn_backEvil;
     public Button btn_backGood;
     public Button btn_backWinCon;
     public Button btn_backHints;
     public Button btn_backMovement;

     public Canvas places1;
     public Canvas places2;
     public Canvas places3;
     public Canvas places4;
     public Canvas evil1;
     public Canvas evil2;
     public Canvas evil3;
     public Canvas evil4;
     public Canvas good1;
     public Canvas good2;
     public Canvas winCon;
     public Canvas hints;
     public Canvas movement;
     private Touch lastTouch;
     public Text testText;
     void btnToPrivatePlayer()
     {
         UIManager.Instance.PrivatePlayer();
     }

     void btnToRulesPlace1()
     {
         UIManager.Instance.RulesPlace1();
     }

     void btnToRulesPlace2()
     {
         UIManager.Instance.RulesPlace2();
     }

     void btnToRulesPlace3()
     {
         UIManager.Instance.RulesPlace3();
     }

     void btnToRulesPlace4()
     {
         UIManager.Instance.RulesPlace4();
     }

     void btnToRulesEvil1()
     {
         UIManager.Instance.RulesEvil1();
     }

     void btnToRulesEvil2()
     {
         UIManager.Instance.RulesEvil2();
     }

     void btnToRulesEvil3()
     {
         UIManager.Instance.RulesEvil3();
     }

     void btnToRulesEvil4()
     {
         UIManager.Instance.RulesEvil4();
     }

     void btnToRulesGood1()
     {
         UIManager.Instance.RulesGood1();
     }

     void btnToRulesGood2()
     {
         UIManager.Instance.RulesGood2();
     }

     void btnToRulesWinCon()
     {
         UIManager.Instance.RulesWinCon();
     }

     void btnToRulesHints()
     {
         UIManager.Instance.RulesHints();
     }

     void btnToRulesMovement()
     {
         UIManager.Instance.RulesMovement();
     }

     void btnToContents()
     {
         UIManager.Instance.Rules();
     }
     void Start()
     {
         btn_places.onClick.AddListener(btnToRulesPlace1);
         btn_evil.onClick.AddListener(btnToRulesEvil1);
         btn_good.onClick.AddListener(btnToRulesGood1);
         btn_winCon.onClick.AddListener(btnToRulesWinCon);
         btn_hints.onClick.AddListener(btnToRulesHints);
         btn_movement.onClick.AddListener(btnToRulesMovement);
         btn_player.onClick.AddListener(btnToPrivatePlayer);
         btn_backPlace.onClick.AddListener(btnToContents);
         btn_backGood.onClick.AddListener(btnToContents);
         btn_backEvil.onClick.AddListener(btnToContents);
         btn_backHints.onClick.AddListener(btnToContents);
         btn_backMovement.onClick.AddListener(btnToContents);
         btn_backWinCon.onClick.AddListener(btnToContents);
     }
     void OnEnable()
     {
         lastTouch = Input.GetTouch(0);

     }

     private void Update()
     {
         bool inputGiven = true;
         Touch touch = Input.GetTouch(0);

         if (Input.GetTouch(0).phase == TouchPhase.Ended)
         {

             if (places1.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace2();
                 }


                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace2();
                 }
             }

             if (places2.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace1();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace3();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace3();
                 }
             }

             if (places3.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace2();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace4();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace4();
                 }
             }

             if (places4.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesPlace3();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
             }
             if (evil1.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil2();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil2();
                 }
             }

             if (evil2.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil1();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil3();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil3();
                 }
             }

             if (evil3.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil2();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil4();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil4();
                 }
             }

             if (evil4.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesEvil3();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
             }

             if (good1.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesGood2();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesGood2();
                 }
             }

             if (good2.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.RulesGood1();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
             }

             if (winCon.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
             }

             if (hints.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
             }

             if (movement.enabled && inputGiven && touch.position.x != lastTouch.position.x)
             {
                 if (touch.position.x <= 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
                 else if (touch.position.x > 540)
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }

                 if (Input.GetKeyDown(KeyCode.Space))
                 {
                     inputGiven = false;
                     UIManager.Instance.Rules();
                 }
             }
         }
         lastTouch = touch;

     }
     */
}
