using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetDiscovery : NetworkDiscovery
{

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {

        var items = fromAddress.Split(':');
        MyNetManager.Instance.networkAddress = items[3];
        Debug.Log(items[3]);
        MyNetManager.Instance.StartClient();
        StopBroadcast();
    }
}
