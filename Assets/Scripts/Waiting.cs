using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waiting : MonoBehaviour
{

    public Text playerCount;
    public Text txtWaiting;
    public Text ipAdress;

    public Button btnMenu;
    public Button btnBack;
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
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(MyNetManager.Instance.StopHosting);
        btnMenu.onClick.RemoveAllListeners();
        btnMenu.onClick.AddListener(UIManager.Instance.OpenMenu);
        ipAdress.text = "Deine IP-Adresse:\n" + MyNetManager.Instance.LocalIPAddress();
        waiting = true;
        StartCoroutine("AnimateDots");
    }
    // Update is called once per frame
    void Update()
    {
        playerCount.text = "Verbundene Spieler:" + (GameState.Instance.connectedPlayer + "/" + GameState.Instance.playerCount);

        if (GameState.Instance.connectedPlayer == GameState.Instance.playerCount)
        {
            if (MyNetManager.Instance.isServer)
            {
                MyNetManager.Instance.MyNetDiscovery.StopBroadcast();
            }
            waiting = false;
            UIManager.Instance.RoleSelection();
        }
    }
    IEnumerator AnimateDots()
    {
        while (waiting)
        {
            txtWaiting.text = "Waiting for\nPlayers    ";
            yield return new WaitForSeconds(0.3f);
            txtWaiting.text = "Waiting for\nPlayers .  ";
            yield return new WaitForSeconds(0.3f);
            txtWaiting.text = "Waiting for\nPlayers .. ";
            yield return new WaitForSeconds(0.3f);
            txtWaiting.text = "Waiting for\nPlayers ...";
            yield return new WaitForSeconds(0.3f);

        }
    }
}