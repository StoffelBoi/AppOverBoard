using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public Button btnBack;
    public Button btnMenu;

    public Image imgGeneralItemsOne;
    public Image imgGeneralItemsTwo;
    public Image imgGeneralItemsThree;
    public Image imgGeneralItemsFour;
    public Image imgGeneralItemsFive;

    public Text txtGeneralItemsOne;
    public Text txtGeneralItemsTwo;
    public Text txtGeneralItemsThree;
    public Text txtGeneralItemsFour;
    public Text txtGeneralItemsFive;

    public Image imgProtectiveItemsOne;
    public Image imgProtectiveItemsTwo;
    public Image imgProtectiveItemsThree;
    public Image imgProtectiveItemsFour;
    public Image imgProtectiveItemsFive;

    public Text txtProtectiveItemsOne;
    public Text txtProtectiveItemsTwo;
    public Text txtProtectiveItemsThree;
    public Text txtProtectiveItemsFour;
    public Text txtProtectiveItemsFive;

    public Image imgTrapsOne;
    public Image imgTrapsTwo;
    public Image imgTrapsThree;
    public Image imgTrapsFour;

    public Text txtTrapsOne;
    public Text txtTrapsTwo;
    public Text txtTrapsThree;
    public Text txtTrapsFour;

    public Sprite sprFireProofCoat;
    public Sprite sprGasmask;
    public Sprite sprBodycam;
    public Sprite sprTalisman;
    public Sprite sprProtectiveVest;
    public Sprite sprTrainers;
    public Sprite sprFingerprintKit;
    public Sprite sprEnergyDrink;
    public Sprite sprCalculator;
    public Sprite sprWhiskey;
    public Sprite sprBomb;
    public Sprite sprPetridish;
    public Sprite sprStolenGoods;
    public Sprite sprCursedArtifact;


    // Use this for initialization
    void Start()
    {
        btnMenu.onClick.AddListener(UIManager.Instance.OpenMenu);
        btnBack.onClick.AddListener(UIManager.Instance.CloseItems);
    }
    void OnEnable()
    {
       
        txtGeneralItemsOne.text = "";
        txtGeneralItemsTwo.text = "";
        txtGeneralItemsThree.text = "";
        txtGeneralItemsFour.text = "";
        txtGeneralItemsFive.text = "";

        txtProtectiveItemsOne.text = "";
        txtProtectiveItemsTwo.text = "";
        txtProtectiveItemsThree.text = "";
        txtProtectiveItemsFour.text = "";
        txtProtectiveItemsFive.text = "";

        txtTrapsOne.text = "";
        txtTrapsTwo.text = "";
        txtTrapsThree.text = "";
        txtTrapsFour.text = "";

        imgGeneralItemsOne.sprite = null;
        imgGeneralItemsTwo.sprite = null;
        imgGeneralItemsThree.sprite = null;
        imgGeneralItemsFour.sprite = null;
        imgGeneralItemsFive.sprite = null;

        imgProtectiveItemsOne.sprite = null;
        imgProtectiveItemsTwo.sprite = null;
        imgProtectiveItemsThree.sprite = null;
        imgProtectiveItemsFour.sprite = null;
        imgProtectiveItemsFive.sprite = null;

        imgTrapsOne.sprite = null;
        imgTrapsTwo.sprite = null;
        imgTrapsThree.sprite = null;
        imgTrapsFour.sprite = null;

        List<string> items = GameState.Instance.items[GameState.Instance.localPlayer.GetComponent<Player>().id];
        int fireproofCoatCount = 0;
        int gasmaskCount = 0;
        int bodycamCount = 0;
        int talismanCount = 0;
        int protectiveVestCount = 0;
        int trainersCount = 0;
        int fingerprintKitCount = 0;
        int energyDrinkCount = 0;
        int calculatorCount = 0;
        int whiskeyCount = 0;
        int bombCount = 0;
        int petridishCount = 0;
        int stolenGoodsCount = 0;
        int cursedArtifactCount = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == "FireProofCoat")
            {
                fireproofCoatCount++;
            }
            if (items[i] == "Gasmask")
            {
                gasmaskCount++;
            }
            if (items[i] == "Bodycam")
            {
                bodycamCount++;
            }
            if (items[i] == "Talisman")
            {
                talismanCount++;
            }
            if (items[i] == "ProtectiveVest")
            {
                protectiveVestCount++;
            }
            if (items[i] == "Trainers")
            {
                trainersCount++;
            }
            if (items[i] == "FingerprintKit")
            {
                fingerprintKitCount++;
            }
            if (items[i] == "EnergyDrink")
            {
                energyDrinkCount++;
            }
            if (items[i] == "Whiskey")
            {
                whiskeyCount++;
            }
            if (items[i] == "Calculator")
            {
                calculatorCount++;
            }
            if (items[i] == "Bomb")
            {
                bombCount++;
            }
            if (items[i] == "PetriDish")
            {
                petridishCount++;
            }
            if (items[i] == "StolenGoods")
            {
                stolenGoodsCount++;
            }
            if (items[i] == "CursedArtifact")
            {
                cursedArtifactCount++;
            }
        }
        
        if (trainersCount + fingerprintKitCount + energyDrinkCount + whiskeyCount + calculatorCount == 0)
        {
            txtGeneralItemsOne.text = "Du besitzt keine Items.";
        }
        else
        {
            if (trainersCount > 0)
            {
                imgGeneralItemsOne.sprite = sprTrainers;
                txtGeneralItemsOne.text = trainersCount + "x Turnschuhe";
            }
            if (fingerprintKitCount > 0)
            {
                if (txtGeneralItemsOne.text == "")
                {
                    imgGeneralItemsOne.sprite = sprFingerprintKit;
                    txtGeneralItemsOne.text = fingerprintKitCount + "x Fingerabdruck Set";
                }
                else
                {
                    imgGeneralItemsTwo.sprite = sprFingerprintKit;
                    txtGeneralItemsTwo.text = fingerprintKitCount + "x Fingerabdruck Set";
                }
            }
            if (energyDrinkCount > 0)
            {
                if (txtGeneralItemsOne.text == "")
                {
                    imgGeneralItemsOne.sprite = sprEnergyDrink;
                    txtGeneralItemsOne.text = energyDrinkCount + "x Energy Drink";
                }
                else if (txtGeneralItemsTwo.text == "")
                {
                    imgGeneralItemsTwo.sprite = sprEnergyDrink;
                    txtGeneralItemsTwo.text = energyDrinkCount + "x Energy Drink";
                }
                else
                {
                    imgGeneralItemsThree.sprite = sprEnergyDrink;
                    txtGeneralItemsThree.text = energyDrinkCount + "x Energy Drink";
                }
            }
            if(calculatorCount > 0)
            {
                if (txtGeneralItemsOne.text == "")
                {
                    imgGeneralItemsOne.sprite = sprCalculator;
                    txtGeneralItemsOne.text = calculatorCount + "x Taschenrechner";
                }
                else if (txtGeneralItemsTwo.text == "")
                {
                    imgGeneralItemsTwo.sprite = sprCalculator;
                    txtGeneralItemsTwo.text = calculatorCount + "x Taschenrechner";
                }
                else if(txtGeneralItemsThree.text =="")
                {
                    imgGeneralItemsThree.sprite = sprCalculator;
                    txtGeneralItemsThree.text = calculatorCount + "x Taschenrechner";
                }
                else
                {
                    imgGeneralItemsFour.sprite = sprCalculator;
                    txtGeneralItemsFour.text = calculatorCount + "x Taschenrechner";
                }
            }
            if (whiskeyCount > 0)
            {
                if (txtGeneralItemsOne.text == "")
                {
                    imgGeneralItemsOne.sprite = sprWhiskey;
                    txtGeneralItemsOne.text = whiskeyCount + "x Whiskey";
                }
                else if (txtGeneralItemsTwo.text == "")
                {
                    imgGeneralItemsTwo.sprite = sprWhiskey;
                    txtGeneralItemsTwo.text = whiskeyCount + "x Whiskey";
                }
                else if (txtGeneralItemsThree.text == "")
                {
                    imgGeneralItemsThree.sprite = sprWhiskey;
                    txtGeneralItemsThree.text = whiskeyCount + "x Whiskey";
                }
                else if(txtGeneralItemsFour.text == "")
                {
                    imgGeneralItemsFour.sprite = sprWhiskey;
                    txtGeneralItemsFour.text = whiskeyCount + "x Whiskey";
                }
                else
                {
                    imgGeneralItemsFive.sprite = sprWhiskey;
                    txtGeneralItemsFive.text = whiskeyCount + "x Whiskey";
                }
            }
        }
        
        if (fireproofCoatCount + gasmaskCount + bodycamCount + talismanCount + protectiveVestCount == 0)
        {
            txtProtectiveItemsOne.text = "Du besitzt keinen Schutz.";
        }
        else
        {
            if (protectiveVestCount > 0)
            {
                imgProtectiveItemsOne.sprite = sprProtectiveVest;
                txtProtectiveItemsOne.text = protectiveVestCount + "x Schutzwesten";
            }
            if (fireproofCoatCount > 0)
            {
                if (txtProtectiveItemsOne.text == "")
                {
                    imgProtectiveItemsOne.sprite = sprFireProofCoat;
                    txtProtectiveItemsOne.text = fireproofCoatCount + "x Feuerfester Mantel";
                }
                else
                {
                    imgProtectiveItemsTwo.sprite = sprFireProofCoat;
                    txtProtectiveItemsTwo.text = fireproofCoatCount + "x Feuerfester Mantel";
                }
            }
            if (gasmaskCount > 0)
            {
                if (txtProtectiveItemsOne.text == "")
                {
                    imgProtectiveItemsOne.sprite = sprGasmask;
                    txtProtectiveItemsOne.text = gasmaskCount + "x Gasmaske";
                }
                else if (txtProtectiveItemsTwo.text == "")
                {
                    imgProtectiveItemsTwo.sprite = sprGasmask;
                    txtProtectiveItemsTwo.text = gasmaskCount + "x Gasmaske";
                }
                else
                {
                    imgProtectiveItemsThree.sprite = sprGasmask;
                    txtProtectiveItemsThree.text = gasmaskCount + "x Gasmaske";
                }
            }
            if (bodycamCount > 0)
            {
                if (txtProtectiveItemsOne.text == "")
                {
                    imgProtectiveItemsOne.sprite = sprBodycam;
                    txtProtectiveItemsOne.text = bodycamCount + "x Bodycam";
                }
                else if (txtProtectiveItemsTwo.text == "")
                {
                    imgProtectiveItemsTwo.sprite = sprBodycam;
                    txtProtectiveItemsTwo.text = bodycamCount + "x Bodycam";
                }
                else if (txtProtectiveItemsThree.text == "")
                {
                    imgProtectiveItemsThree.sprite = sprBodycam;
                    txtProtectiveItemsThree.text = bodycamCount + "x Bodycam";
                }
                else
                {
                    imgProtectiveItemsFour.sprite = sprBodycam;
                    txtProtectiveItemsFour.text = bodycamCount + "x Bodycam";
                }
            }
            if (talismanCount > 0)
            {
                if (txtProtectiveItemsOne.text == "")
                {
                    imgProtectiveItemsOne.sprite = sprTalisman;
                    txtProtectiveItemsOne.text = talismanCount + "x Talisman";
                }
                else if (txtProtectiveItemsTwo.text == "")
                {
                    imgProtectiveItemsTwo.sprite = sprTalisman;
                    txtProtectiveItemsTwo.text = talismanCount + "x Talisman";
                }
                else if (txtProtectiveItemsThree.text == "")
                {
                    imgProtectiveItemsThree.sprite = sprTalisman;
                    txtProtectiveItemsThree.text = talismanCount + "x Talisman";
                }
                else if (txtProtectiveItemsFour.text == "")
                {
                    imgProtectiveItemsFour.sprite = sprTalisman;
                    txtProtectiveItemsFour.text = talismanCount + "x Talisman";
                }
                else
                {
                    imgProtectiveItemsFive.sprite = sprTalisman;
                    txtProtectiveItemsFive.text = talismanCount + "x Talisman";
                }
            }
        }

        if (bombCount + petridishCount + stolenGoodsCount + cursedArtifactCount == 0)
        {
            txtTrapsOne.text = "Du besitzt keine Fallen.";
        }
        else
        {
            if (bombCount > 0)
            {
                imgTrapsOne.sprite = sprBomb;
                txtTrapsOne.text = bombCount + "x Bombe";
            }
            if (petridishCount > 0)
            {
                if (txtTrapsOne.text == "")
                {
                    imgTrapsOne.sprite = sprPetridish;
                    txtTrapsOne.text = petridishCount + "x Petrischale";
                }
                else
                {
                    imgTrapsTwo.sprite = sprPetridish;
                    txtTrapsTwo.text = petridishCount + "x Petrischale";
                }
            }
            if (stolenGoodsCount > 0)
            {
                if (txtTrapsOne.text == "")
                {
                    imgTrapsOne.sprite = sprStolenGoods;
                    txtTrapsOne.text = stolenGoodsCount + "x Diebesgut";
                }
                else if (txtTrapsTwo.text == "")
                {
                    imgTrapsTwo.sprite = sprStolenGoods;
                    txtTrapsTwo.text = stolenGoodsCount + "x Diebesgut";
                }
                else
                {
                    imgTrapsThree.sprite = sprStolenGoods;
                    txtTrapsThree.text = stolenGoodsCount + "x Diebesgut";
                }
            }
            if (cursedArtifactCount > 0)
            {
                if (txtTrapsOne.text == "")
                {
                    imgTrapsOne.sprite = sprCursedArtifact;
                    txtTrapsOne.text = cursedArtifactCount + "x Verfluchtes Artifakt";
                }
                else if (txtTrapsTwo.text == "")
                {
                    imgTrapsTwo.sprite = sprCursedArtifact;
                    txtTrapsTwo.text = cursedArtifactCount + "x Verfluchtes Artifakt";
                }
                else if (txtTrapsThree.text == "")
                {
                    imgTrapsThree.sprite = sprCursedArtifact;
                    txtTrapsThree.text = cursedArtifactCount + "x Verfluchtes Artifakt";
                }
                else
                {
                    imgTrapsFour.sprite = sprCursedArtifact;
                    txtTrapsFour.text = cursedArtifactCount + "x Verfluchtes Artifakt";
                }
            }
        }
       
    }
}