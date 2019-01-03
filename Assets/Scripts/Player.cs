using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    public int id;
    // Use this for initialization
    void Start() {
        id = GameState.Instance.connectedPlayer;
        if (isLocalPlayer)
        {
            gameObject.name = "local";
            GameState.Instance.localPlayer = gameObject;
            ConnectedPlayerUp();
            UIManager.Instance.Waiting();
        }
    }

    // Update is called once per frame
    void Update() {

    }

    #region ConnectedPlayerUp
    void ConnectedPlayerUp()
    {
        if (isServer)
        {
            GameState.Instance.connectedPlayer++;
        }
        else
        {
            CmdConnectedPlayerUp();
        }
    }
    [Command]
    public void CmdConnectedPlayerUp()
    {
        ConnectedPlayerUp();
    }
    #endregion
    #region SelectedRolesUp
    public void SelectedRolesUp()
    {
        if (isServer)
        {
            GameState.Instance.selectedRoles++;
        }
        else
        {
            CmdSelectedRolesUp();
        }
    }
    [Command]
    public void CmdSelectedRolesUp()
    {
        SelectedRolesUp();
    }
    #endregion
    #region SetTargetTime
    public void SetTargetTime(bool active)
    {
        if (isServer)
        {
            GameState.Instance.targetTime = active;
        }
        else
        {
            CmdSetTargetTime(active);
        }
    }
    [Command]
    public void CmdSetTargetTime(bool active)
    {
        SetTargetTime(active);
    }
    #endregion
    #region SetElapsedSeconds
    public void SetElapsedSeconds(int elapsedSeconds)
    {
        if (isServer)
        {
            GameState.Instance.elapsedSeconds = elapsedSeconds;
        }
        else
        {
            CmdSetElapsedSeconds(elapsedSeconds);
        }
    }
    [Command]
    public void CmdSetElapsedSeconds(int elapsedSeconds)
    {
        SetElapsedSeconds(elapsedSeconds);
    }
    #endregion
    #region SetElapsedTime
    public void SetElapsedTime(string elapsedTime)
    {
        if (isServer)
        {
            GameState.Instance.elapsedTime = elapsedTime;
        }
        else
        {
            CmdSetElapsedTime(elapsedTime);
        }
    }
    [Command]
    public void CmdSetElapsedTime(string elapsedTime)
    {
        SetElapsedTime(elapsedTime);
    }
    #endregion
    #region SetDraw
    public void SetDraw(bool draw)
    {
        if (isServer)
        {
            GameState.Instance.draw = draw;
        }
        else
        {
            CmdSetDraw(draw);
        }
    }
    [Command]
    public void CmdSetDraw(bool draw)
    {
        SetDraw(draw);
    }

    #endregion
    #region SetCriminalWin
    public void SetCriminalWin(bool win)
    {
        if (isServer)
        {
            GameState.Instance.criminalWin = win;
        }
        else
        {
            CmdSetCriminalWin(win);
        }
    }
    [Command]
    public void CmdSetCriminalWin(bool win)
    {
        SetCriminalWin(win);
    }

    #endregion
    #region SetCriminal
    public void SetCriminal(string role)
    {
        if (isServer)
        {
            GameState.Instance.criminal = role;
        }
        else
        {
            CmdSetCriminal(role);
        }
    }
    [Command]
    public void CmdSetCriminal(string role)
    {
        SetCriminal(role);
    }
    #endregion
    #region SetCriminalRole
    public void SetCriminalRole(string role)
    {
        if (isServer)
        {
            GameState.Instance.criminalRole = role;
        }
        else
        {
            CmdSetCriminalRole(role);
        }
    }
    [Command]
    public void CmdSetCriminalRole(string role)
    {
        SetCriminalRole(role);
    }
    #endregion
    /*
     
    CommandSchematic for copying:

     #region FunctionName
    public void FunctionName()
    {
        if (isServer)
        {
            GameState.Instance.variable = value;
        }
        else
        {
            CmdFunctionName();
        }
    }
    [Command]
    public void CmdFunctionName()
    {
        FunctionName;
    }
    #endregion
     */


}
