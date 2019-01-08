using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waiting : MonoBehaviour {

    public Text playerCount;
    public Text txtWaiting;
    public Text ipAdress;
    public static Waiting Instance;
    private bool waiting;
	void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void OnEnable()
    {
        ipAdress.text = "Deine IP-Adresse:\n" + MyNetManager.Instance.LocalIPAddress();
        waiting = true;
        StartCoroutine("AnimateDots");
    }
	// Update is called once per frame
	void Update () {
        playerCount.text=(GameState.Instance.connectedPlayer+"/" + GameState.Instance.playerCount);

        if (GameState.Instance.connectedPlayer == GameState.Instance.playerCount)
        {
            waiting = false;
            UIManager.Instance.RoleSelection();
        }
    }
    IEnumerator AnimateDots()
    {
        while (waiting)
        {
            txtWaiting.text = "IP Adress: " + MyNetManager.Instance.LocalIPAddress() + "\nWaiting for\nPlayers    ";
            yield return new WaitForSeconds(0.3f);
            txtWaiting.text = "IP Adress: " + MyNetManager.Instance.LocalIPAddress() + "\nWaiting for\nPlayers .  ";
            yield return new WaitForSeconds(0.3f);
            txtWaiting.text = "IP Adress: " + MyNetManager.Instance.LocalIPAddress() + "\nWaiting for\nPlayers .. ";
            yield return new WaitForSeconds(0.3f);
            txtWaiting.text = "IP Adress: " + MyNetManager.Instance.LocalIPAddress() + "\nWaiting for\nPlayers ...";
            yield return new WaitForSeconds(0.3f);

        }
    }
}
