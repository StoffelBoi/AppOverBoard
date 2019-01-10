using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

public class MyNetManager : NetworkManager
{
    public static MyNetManager Instance;
    public NetworkDiscovery MyNetDiscovery;
    public bool isServer;
    public bool isClient;
    public bool waiting;
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
        MyNetDiscovery.Initialize();
        waiting = true;
        StartCoroutine("animateLookingForGame");
        yield return new WaitForSeconds(.5f);
        MyNetDiscovery.StartAsClient();
        yield return new WaitForSeconds(4.5f);
        waiting = false;
        yield return new WaitForSeconds(1f);
        if (IsClientConnected())
        {
            MyNetDiscovery.StopBroadcast();
            isClient = true;
            Connection.Instance.txtInfo.text = "Verbunden!";
            yield return new WaitForSeconds(1.2f);
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
    IEnumerator animateLookingForGame()
    {

        while (waiting)
        {
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel    ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel .  ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel .. ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Suche nach \nSpiel ...";
            yield return new WaitForSeconds(0.3f);
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
            waiting = true;
            StartCoroutine("animateManualConnection");
            networkAddress = Connection.Instance.IPInputField.text;
            StartClient();
            yield return new WaitForSeconds(3f);
            waiting = false;
            yield return new WaitForSeconds(1.2f);
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
    IEnumerator animateManualConnection()
    {
        while (waiting)
        {
            Connection.Instance.txtInfo.text = "Manuelles verbinden    ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Manuelles verbinden .  ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Manuelles verbinden .. ";
            yield return new WaitForSeconds(0.3f);
            Connection.Instance.txtInfo.text = "Manuelles verbinden ...";
            yield return new WaitForSeconds(0.3f);

        }
    }

    public void StopHosting()
    {
        if (isServer)
        {
            StopHost();
            NetworkServer.ClearLocalObjects();
            NetworkServer.ClearSpawners();
            //MyNetDiscovery.StopBroadcast();
        }
        if (isClient)
        {
            StopHost();
            StopClient();
            //MyNetDiscovery.StopBroadcast();
            
        }
        StopAllCoroutines();
        NetworkServer.Reset();
        NetworkTransport.Init();
        NetworkTransport.Shutdown();
        isServer = false;
        isClient = false;
        TimeManager.Instance.gameObject.SetActive(false);
        UIManager.Instance.Connection();
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        
    }

    public string LocalIPAddress()
    {
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            {
                Console.WriteLine(ni.Name);
                foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.Address.ToString();
                    }
                }
            }
        }
        return "Unknown";
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
