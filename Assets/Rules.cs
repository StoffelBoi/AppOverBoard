using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour {
    public Canvas rulesPlacesOne;
    public Canvas rulesPlacesTwo;
    public Canvas rulesPlacesThree;
    public Canvas rulesPlacesFour;
    public Rules scriptRules;
    void Awake()
    {
        scriptRules=GetComponent<Rules>();
        rulesPlacesOne.enabled = false;
        rulesPlacesTwo.enabled = false;
        rulesPlacesThree.enabled = false;
        rulesPlacesFour.enabled = false;
        scriptRules.enabled = false;
    }
}
