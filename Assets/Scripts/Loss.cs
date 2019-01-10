using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loss : MonoBehaviour {
    public Button btnRestart;
	// Use this for initialization
	void Start () {
        btnRestart.onClick.AddListener(UIManager.Instance.RestartScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
