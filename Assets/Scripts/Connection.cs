using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Connection : MonoBehaviour {
    public Button btnHost;
    public Button btnJoin;
    public Button btnBack;
    public Button btnUp;
    public Button btnDown;
    public Button btnOK;
    public Text txtInfo;
    public Text txtPlayerCount;
    public Image infoPanel;
    public Image PlayerCountPanel;
    public InputField IPInputField;

    public static Connection Instance;
    public int playerCount;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

    }
    void OnEnable()
    {
        playerCount = 3;
        disableEverything();
        btnHost.gameObject.SetActive(true);
        btnJoin.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(true);
        txtInfo.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(true);
        txtInfo.text = "Hoste oder tritt einem Spiel bei.";
        btnHost.onClick.AddListener(btnSelectPlayerCount);
        btnJoin.onClick.AddListener(btnJoinClick);
        btnBack.onClick.AddListener(btnToStart);
        btnJoin.GetComponent<RectTransform>().anchoredPosition = new Vector3(-118, -409.5f, 0);
    }
    void disableEverything()
    {
        btnJoin.interactable = true;
        btnBack.interactable = true;
        btnHost.interactable = true;
        btnDown.interactable = true;
        btnUp.interactable = true;
        btnOK.interactable = true;
        IPInputField.interactable = true;

        btnJoin.GetComponentInChildren<Text>().text = "Verbinden";
        btnHost.onClick.RemoveAllListeners();
        btnJoin.onClick.RemoveAllListeners();
        btnBack.onClick.RemoveAllListeners();
        btnUp.onClick.RemoveAllListeners();
        btnDown.onClick.RemoveAllListeners();
        btnOK.onClick.RemoveAllListeners();

        btnHost.gameObject.SetActive(false);
        btnJoin.gameObject.SetActive(false);
        btnBack.gameObject.SetActive(false);
        btnUp.gameObject.SetActive(false);
        btnDown.gameObject.SetActive(false);
        btnOK.gameObject.SetActive(false);
        txtInfo.gameObject.SetActive(false);
        txtPlayerCount.gameObject.SetActive(false);
        infoPanel.gameObject.SetActive(false);
        PlayerCountPanel.gameObject.SetActive(false);
        IPInputField.gameObject.SetActive(false);
    }

    void btnToStart()
    {
        UIManager.Instance.StartUp();
    }

    void btnSelectPlayerCount()
    {
        disableEverything();
        btnUp.gameObject.SetActive(true);
        btnDown.gameObject.SetActive(true);
        btnOK.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(true);
        txtInfo.gameObject.SetActive(true);
        txtInfo.text = "Leg die Spieleranzahl fest.";
        txtPlayerCount.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(true);
        PlayerCountPanel.gameObject.SetActive(true);
        txtPlayerCount.text = "" + playerCount;
        btnUp.onClick.AddListener(btnUpClick);
        btnDown.onClick.AddListener(btnDownClick);
        btnOK.onClick.AddListener(btnHostClick);
        btnBack.onClick.AddListener(OnEnable);
        btnUp.interactable = true;
        btnDown.interactable = true;
        if (playerCount <= 1)
        {
            btnDown.interactable = false;
        }
        if(playerCount >= 6)
        {
            btnUp.interactable = false;
        }
    }

    void btnUpClick()
    {
        playerCount++;
        btnSelectPlayerCount();
    }
    void btnDownClick()
    {
        playerCount--;
        btnSelectPlayerCount();
        
    }

    void btnHostClick()
    {
        MyNetManager.Instance.StartGame();
        GameState.Instance.connectedPlayer = 0;
        GameState.Instance.playerCount = playerCount;
    }

    void btnJoinClick()
    {
        disableEverything();
        btnJoin.gameObject.SetActive(true);
        btnJoin.interactable = false;
        btnBack.gameObject.SetActive(true);
        txtInfo.gameObject.SetActive(true);
        infoPanel.gameObject.SetActive(true);
        IPInputField.gameObject.SetActive(true);
        IPInputField.interactable = false;
        btnBack.onClick.RemoveAllListeners();
        btnBack.interactable = false;
        btnBack.onClick.AddListener(btnStopHost);
        btnJoin.GetComponent<RectTransform>().anchoredPosition = new Vector3(116, -59.5f, 0);
        MyNetManager.Instance.SearchGame();


    }

    public void ManualConnectLayout()
    {
        btnBack.interactable = true;
        btnJoin.GetComponentInChildren<Text>().text = "Bestätigen";
        btnJoin.onClick.RemoveAllListeners();
        btnJoin.onClick.AddListener(MyNetManager.Instance.ManualConnect);
        btnJoin.interactable = true;
        IPInputField.interactable = true;
    }

    void btnStopHost()
    {
        MyNetManager.Instance.StopHosting();
    }
}
