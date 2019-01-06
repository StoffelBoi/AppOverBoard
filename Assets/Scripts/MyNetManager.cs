using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.Sockets;

public class MyNetManager : NetworkManager
{
    public static MyNetManager Instance;
    public NetworkDiscovery MyNetDiscovery;
    public bool isServer;
    public bool isClient;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }


    void Start()
    {
        NetworkTransport.Init();
    }

    public void StartGame()
    {
        isServer = true;
        StartHost();
        MyNetDiscovery.Initialize();
        MyNetDiscovery.StartAsServer();
    }

    public void SearchGame()
    {
        StartCoroutine(CheckConnection());
    }

    IEnumerator CheckConnection()
    {
        Debug.Log("CheckConnection");
        MyNetDiscovery.Initialize();
        Connection.Instance.txtInfo.text = "Suche nach Spiel ...";
        yield return new WaitForSeconds(.5f);
        MyNetDiscovery.StartAsClient();
        yield return new WaitForSeconds(4.5f);
        if (IsClientConnected())
        {
            MyNetDiscovery.StopBroadcast();
            isClient = true;
            Connection.Instance.txtInfo.text = "Verbunden!";
            yield return new WaitForSeconds(1f);
        }
        else
        {
            Connection.Instance.txtInfo.text = "Nichts gefunden. Versuche es manuell.";
            StopClient();
            MyNetDiscovery.StopBroadcast();
            yield return new WaitForSeconds(.1f);
            Connection.Instance.ManualConnectLayout();

        }
    }
    public void ManualConnect()
    {
        
        StartCoroutine(ManualConnectEnter());
    }

    IEnumerator ManualConnectEnter()
    {
        
        if (Connection.Instance.IPInputField.text != "")
        {
            Connection.Instance.txtInfo.text = "Manuelles verbinden ...";
            networkAddress = Connection.Instance.IPInputField.text;
            StartClient();
            yield return new WaitForSeconds(3f);
            if (IsClientConnected())
            {
                isClient = true;
                Connection.Instance.txtInfo.text = "Verbunden!";
            }
            else
            {
                Connection.Instance.txtInfo.text = "Nichts gefunden, probiers nochmal.";
                StopClient();
            }
        }
        else
        {
            Connection.Instance.txtInfo.text = "Gib eine Ip-Adresse ein.";
        }
    }


    public void StopHosting()
    {
        if (isServer)
        {
            StopHost();
            NetworkServer.ClearLocalObjects();
            NetworkServer.ClearSpawners();
            MyNetDiscovery.StopBroadcast();
            
        }
        if (isClient)
        {
            StopHost();
            StopClient();
            MyNetDiscovery.StopBroadcast();
        }
        StopAllCoroutines();
        NetworkServer.Reset();
        isServer = false;
        isClient = false;
        UIManager.Instance.Connection();
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        
    }
    
    public string LocalIPAddress()

    {
        IPHostEntry host;
        string localIP = "0.0.0.0";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {

                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }


    public override void OnStopServer()
    {
        base.OnStopServer();
        isServer = false;
        MyNetDiscovery.StopBroadcast();
        UIManager.Instance.Connection();
    }

    // public override void OnServerDisconnect(NetworkConnection conn)
    //{
    //    base.OnServerDisconnect(conn);
    //    EventDispatcher.TriggerEvent(Vars.ServerHandleDisconnect);
    //}

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        if (isClient)
        {
            Connection.Instance.txtInfo.text = "Client IP: " + LocalIPAddress();
        }

    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);
        isClient = false;
        Connection.Instance.txtInfo.text = "Disconnected! Try Again! Code: 2" + conn.lastError;

    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        if (IsClientConnected())
        {
            isClient = false;
            Connection.Instance.txtInfo.text = "Disconnected! Try Again! Code: 1";
        }
    }
}
