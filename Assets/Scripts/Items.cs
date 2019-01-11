using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public Text txtItemsList;
    public Button btnBack;
    public Button btnMenu;
    // Use this for initialization
    void Start()
    {
        btnBack.onClick.AddListener(UIManager.Instance.CloseItems);
    }
    void OnEnable()
    {
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
        string itemsText = "";
        if (trainersCount + fingerprintKitCount + energyDrinkCount + whiskeyCount + calculatorCount > 0)
        {
            itemsText += "Allgemeine Items:\n";
            if (trainersCount > 0)
            {
                itemsText += ("\n" + trainersCount + "x Turnschuhe");
            }
            if (fingerprintKitCount > 0)
            {
                itemsText += ("\n" + fingerprintKitCount + "x Fingerabdruckset");
            }
            if (energyDrinkCount > 0)
            {
                itemsText += ("\n" + energyDrinkCount + "x Energy Drink");
            }
            if (whiskeyCount > 0)
            {
                itemsText += ("\n" + whiskeyCount + "x Whiskey");
            }
            if (calculatorCount > 0)
            {
                itemsText += ("\n" + calculatorCount + "x Taschenrechner");
            }
        }
        if (fireproofCoatCount + gasmaskCount + bodycamCount + talismanCount + protectiveVestCount > 0)
        {
            if (trainersCount + fingerprintKitCount + energyDrinkCount + whiskeyCount + calculatorCount > 0)
            {
                itemsText += "\n";
            }
                itemsText += "\nSchutz Items:\n";
            if (protectiveVestCount > 0)
            {
                itemsText += ("\n" + protectiveVestCount + "x Schutzweste");
            }
            if (fireproofCoatCount > 0)
            {
                itemsText += ("\n" + fireproofCoatCount + "x feuerfester Mantel");
            }
            if (gasmaskCount > 0)
            {
                itemsText += ("\n" + gasmaskCount + "x Gasmaske");
            }
            if (bodycamCount > 0)
            {
                itemsText += ("\n" + bodycamCount + "x Bodycam");
            }
            if (talismanCount > 0)
            {
                itemsText += ("\n" + talismanCount + "x Talisman");
            }
        }
        if (bombCount + petridishCount + stolenGoodsCount + cursedArtifactCount > 0)
        {
            if (trainersCount + fingerprintKitCount + energyDrinkCount + whiskeyCount + calculatorCount+ fireproofCoatCount + gasmaskCount + bodycamCount + talismanCount + protectiveVestCount > 0)
            {
                itemsText += "\n";
             }
            itemsText += "\nFallen:\n";
            if (bombCount > 0)
            {
                itemsText += ("\n" + bombCount + "x Bombe");
            }
            if (petridishCount > 0)
            {
                itemsText += ("\n" + petridishCount + "x  Petrischale");
            }
            if (stolenGoodsCount > 0)
            {
                itemsText += ("\n" + stolenGoodsCount + "x Diebesgut");
            }
            if (cursedArtifactCount > 0)
            {
                itemsText += ("\n" + cursedArtifactCount + "x verfluchtes Artifakt");
            }
        }
        if (itemsText == "")
        {
            itemsText = "Du besitzt keine Items";
        }
        txtItemsList.text = itemsText;
    }
}