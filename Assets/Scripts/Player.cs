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
    #region SetSelectedRoles
    public void SetSelectedRoles(int selectedRoles)
    {
        if (isServer)
        {
            GameState.Instance.selectedRoles = selectedRoles;
        }
        else
        {
            CmdSetSelectedRoles(selectedRoles);
        }
    }
    [Command]
    public void CmdSetSelectedRoles(int selectedRoles)
    {
        SetSelectedRoles(selectedRoles);
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
    #region AddQuestPlace
    public void AddQuestPlace(int place)
    {
        if (isServer)
        {
            GameState.Instance.questPlaces.Add(place);
        }
        else
        {
            CmdAddQuestPlace(place);
        }
    }
    [Command]
    public void CmdAddQuestPlace(int place)
    {
        AddQuestPlace(place);
    }
    #endregion
    #region SetTargetPlace
    public void SetTargetPlace(int place)
    {
        if (isServer)
        {
            GameState.Instance.targetPlace = place;
        }
        else
        {
            CmdSetTargetPlace(place);
        }
    }
    [Command]
    public void CmdSetTargetPlace(int place)
    {
        SetTargetPlace(place);
    }
    #endregion
    #region SetPlayerState
    public void SetPlayerState(int index, string state)
    {
        if (isServer)
        {
            GameState.Instance.playerState[index] = state;
        }
        else
        {
            CmdSetPlayerState(index, state);
        }
    }
    [Command]
    public void CmdSetPlayerState(int index, string state)
    {
        SetPlayerState(index, state);
    }
    #endregion
    #region SetRole
    public void SetRole(int index, string role)
    {
        if (isServer)
        {
            GameState.Instance.roles[index] = role;
        }
        else
        {
            CmdSetRole(index, role);
        }
    }
    [Command]
    public void CmdSetRole(int index, string role)
    {
        SetRole(index, role);
    }
    #endregion
    #region SetMoney
    public void SetMoney(int index, int money)
    {
        Debug.Log("index: " + index + " money: " + money);
        if (isServer)
        {
            Debug.Log("SETMONEY");
            GameState.Instance.money[index] = money;
        }
        else
        {
            CmdSetMoney(index, money);
        }
    }
    [Command]
    public void CmdSetMoney(int index, int money)
    {
        Debug.Log("CMDSETMONEY");
        SetMoney(index, money);
    }
    #endregion
    #region SetSolvedHints
    public void SetSolvedHints(int index, int solvedHints)
    {
        if (isServer)
        {
            GameState.Instance.solvedHints[index] = solvedHints;
        }
        else
        {
            CmdSetSolvedHints(index, solvedHints);
        }
    }
    [Command]
    public void CmdSetSolvedHints(int index, int solvedHints)
    {
        SetSolvedHints(index, solvedHints);
    }
    #endregion
    #region SetUnsolvedHints
    public void SetUnsolvedHints(int index, int unsolvedHints)
    {
        if (isServer)
        {
            GameState.Instance.unsolvedHints[index] = unsolvedHints;
        }
        else
        {
            CmdSetUnsolvedHints(index, unsolvedHints);
        }
    }
    [Command]
    public void CmdSetUnsolvedHints(int index, int unsolvedHints)
    {
        SetUnsolvedHints(index, unsolvedHints);
    }
    #endregion
    #region SetTrueSolveds
    public void SetTrueSolveds(int index, int trueSolveds)
    {
        if (isServer)
        {
            GameState.Instance.trueSolveds[index] = trueSolveds;
        }
        else
        {
            CmdSetTrueSolveds(index, trueSolveds);
        }
    }
    [Command]
    public void CmdSetTrueSolveds(int index, int trueSolveds)
    {
        SetTrueSolveds(index, trueSolveds);
    }
    #endregion
    #region SetTrueUnsolveds
    public void SetTrueUnsolveds(int index, int trueUnsolveds)
    {
        if (isServer)
        {
            GameState.Instance.trueUnsolveds[index] = trueUnsolveds;
        }
        else
        {
            CmdSetTrueUnsolveds(index, trueUnsolveds);
        }
    }
    [Command]
    public void CmdSetTrueUnsolveds(int index, int trueUnsolveds)
    {
        SetTrueUnsolveds(index, trueUnsolveds);
    }
    #endregion
    #region SetIsDisabled
    public void SetIsDisabled(int index, int isDisabled)
    {
        if (isServer)
        {
            GameState.Instance.isDisabled[index] = isDisabled;
        }
        else
        {
            CmdSetIsDisabled(index, isDisabled);
        }
    }
    [Command]
    public void CmdSetIsDisabled(int index, int isDisabled)
    {
        SetIsDisabled(index, isDisabled);
    }
    #endregion
    #region SetIsManipulated
    public void SetIsManipulated(int index, bool isManipulated)
    {
        if (isServer)
        {
            GameState.Instance.isManipulated[index] = isManipulated;
        }
        else
        {
            CmdSetIsManipulated(index, isManipulated);
        }
    }
    [Command]
    public void CmdSetIsManipulated(int index, bool isManipulated)
    {
        SetIsManipulated(index, isManipulated);
    }
    #endregion
    #region SetSkillUsed
    public void SetSkillUsed(int index, bool skillUsed)
    {
        if (isServer)
        {
            GameState.Instance.skillUsed[index] = skillUsed;
        }
        else
        {
            CmdSetSkillUsed(index, skillUsed);
        }
    }
    [Command]
    public void CmdSetSkillUsed(int index, bool skillUsed)
    {
        SetSkillUsed(index, skillUsed);
    }
    #endregion
    #region  SetLastTransaction
    public void SetLastTransaction(int index, string lastTransaction)
    {
        if (isServer)
        {
            GameState.Instance.lastTransaction[index] = lastTransaction;
        }
        else
        {
            CmdSetLastTransaction(index, lastTransaction);
        }
    }
    [Command]
    public void CmdSetLastTransaction(int index, string lastTransaction)
    {
        SetLastTransaction(index, lastTransaction);
    }
    #endregion
    #region  SetLastAction
    public void SetLastAction(int index, string lastAction)
    {
        if (isServer)
        {
            GameState.Instance.lastAction[index] = lastAction;
        }
        else
        {
            CmdSetLastAction(index, lastAction);
        }
    }
    [Command]
    public void CmdSetLastAction(int index, string lastAction)
    {
        SetLastAction(index, lastAction);
    }
    #endregion
    #region  SetSolvedFacts
    public void SetSolvedFacts(int index, int solvedFacts)
    {
        if (isServer)
        {
            GameState.Instance.solvedFacts[index] = solvedFacts;
        }
        else
        {
            CmdSetSolvedFacts(index, solvedFacts);
        }
    }
    [Command]
    public void CmdSetSolvedFacts(int index, int solvedFacts)
    {
        SetSolvedFacts(index, solvedFacts);
    }
    #endregion
    #region  SetPlaceFact
    public void SetPlaceFact(int index, string placeFact)
    {
        if (isServer)
        {
            GameState.Instance.placeFact[index] = placeFact;
        }
        else
        {
            CmdSetPlaceFact(index, placeFact);
        }
    }
    [Command]
    public void CmdSetPlaceFact(int index, string placeFact)
    {
        SetPlaceFact(index, placeFact);
    }
    #endregion
    #region  SetRoleFact
    public void SetRoleFact(int index, string roleFact)
    {
        if (isServer)
        {
            GameState.Instance.roleFact[index] = roleFact;
        }
        else
        {
            CmdSetRoleFact(index, roleFact);
        }
    }
    [Command]
    public void CmdSetRoleFact(int index, string roleFact)
    {
        SetRoleFact(index, roleFact);
    }
    #endregion
    #region  SetPlayerFact
    public void SetPlayerFact(int index, string playerFact)
    {
        if (isServer)
        {
            GameState.Instance.playerFact[index] = playerFact;
        }
        else
        {
            CmdSetPlayerFact(index, playerFact);
        }
    }
    [Command]
    public void CmdSetPlayerFact(int index, string playerFact)
    {
        SetPlayerFact(index, playerFact);
    }
    #endregion
    #region  SetPlayerWin
    public void SetPlayerWin(int index, bool playerWin)
    {
        if (isServer)
        {
            GameState.Instance.playerWin[index] = playerWin;
        }
        else
        {
            CmdSetPlayerWin(index, playerWin);
        }
    }
    [Command]
    public void CmdSetPlayerWin(int index, bool playerWin)
    {
        SetPlayerWin(index, playerWin);
    }
    #endregion
    #region  SetPlayerLost
    public void SetPlayerLost(int index, bool playerLost)
    {
        if (isServer)
        {
            GameState.Instance.playerWin[index] = playerLost;
        }
        else
        {
            CmdSetPlayerLost(index, playerLost);
        }
    }
    [Command]
    public void CmdSetPlayerLost(int index, bool playerLost)
    {
        SetPlayerWin(index, playerLost);
    }
    #endregion


    #region SetCurrentPlace
    public void SetCurrentPlace(int index, int[] currentPlace)
    {
        if (isServer)
        {
            GameState.Instance.currentPlace[index] = currentPlace;
            RpcSetCurrentPlace(index, currentPlace);
        }
        else
        {
            CmdSetCurrentPlace(index, currentPlace);
        }
    }
    [Command]
    public void CmdSetCurrentPlace(int index, int[] currentPlace)
    {
        SetCurrentPlace(index, currentPlace);
    }
    [ClientRpc]
    public void RpcSetCurrentPlace(int index, int[] currentPlace)
    {
        GameState.Instance.currentPlace[index] = currentPlace;
    }
    #endregion


    #region SetNotFoundTrue
    public void SetNotFoundTrue(int indexX, int indexY, int indexZ, int notFoundTrue)
    {
        if (isServer)
        {
            GameState.Instance.notFoundTrue[indexX][indexY, indexZ] = notFoundTrue;
            RpcSetNotFoundTrue(indexX, indexY, indexZ, notFoundTrue);
        }
        else{
            CmdSetNotFoundTrue(indexX, indexY, indexZ, notFoundTrue);
        }
    }
    [Command] 
    public void CmdSetNotFoundTrue(int indexX, int indexY, int indexZ, int notFoundTrue)
    {
        SetNotFoundTrue(indexX, indexY, indexZ, notFoundTrue);
    }
    [ClientRpc]
    public void RpcSetNotFoundTrue(int indexX, int indexY, int indexZ, int notFoundTrue)
    {
        GameState.Instance.notFoundTrue[indexX][indexY, indexZ] = notFoundTrue;
    }
    #endregion
    #region SetNotFoundFalse
    public void SetNotFoundFalse(int indexX, int indexY, int indexZ, int notFoundFalse)
    {
        if (isServer)
        {
            GameState.Instance.notFoundFalse[indexX][indexY, indexZ] = notFoundFalse;
            RpcSetNotFoundFalse(indexX, indexY, indexZ, notFoundFalse);
        }
        else
        {
            CmdSetNotFoundFalse(indexX, indexY, indexZ, notFoundFalse);
        }
    }
    [Command]
    public void CmdSetNotFoundFalse(int indexX, int indexY, int indexZ, int notFoundFalse)
    {
        SetNotFoundFalse(indexX, indexY, indexZ, notFoundFalse);
    }
    [ClientRpc]
    public void RpcSetNotFoundFalse(int indexX, int indexY, int indexZ, int notFoundFalse)
    {
        GameState.Instance.notFoundFalse[indexX][indexY, indexZ] = notFoundFalse;
    }
    #endregion
    #region SetBoard
    public void SetBoard(int indexX, int indexY, int place)
    {
        if (isServer)
        {
            GameState.Instance.board[indexX, indexY] = place;
            RpcSetBoard(indexX, indexY, place);
        }
    }
    [Command]
    public void CmdSetBoard(int indexX, int indexY, int place)
    {
        SetBoard(indexX, indexY, place);
    }
    [ClientRpc]
    public void RpcSetBoard(int indexX, int indexY, int place)
    {
        GameState.Instance.board[indexX, indexY] = place;
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
