using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrivatPlayer : MonoBehaviour {

    public Text txt_char;
    public Text txt_villainPlain;
    public Text txt_villain;
    public Text txt_TargetPlain;
    public Text txt_target;
    public Text txt_TimePlain;
    public Text txt_time;

    // Use this for initialization
    void Start () {
        txt_villainPlain.enabled = false;
        txt_villain.enabled = false;
        txt_TargetPlain.enabled = false;
        txt_target.enabled = false;
        txt_TimePlain.enabled = false;
        txt_time.enabled = false;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
