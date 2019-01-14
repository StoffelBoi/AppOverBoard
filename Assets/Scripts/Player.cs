using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public int id;
    // Use this for initialization
    void Start()
    {
        id = GameState.Instance.connectedPlayer;
        if (isLocalPlayer)
        {
            gameObject.name = "local";
            GameState.Instance.localPlayer = gameObject;
            ConnectedPlayerUp();
            UIManager.Instance.Waiting();
        }
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            if (GameState.Instance.criminalWin == true)
            {
                if (GameState.Instance.criminal == GameState.Instance.roles[GameState.Instance.localPlayer.GetComponent<Player>().id])
                {
                    UIManager.Instance.Win();
                    return;
                }
                else
                {
                    UIManager.Instance.Loss();
                    return;
                }
            }
            if (GameState.Instance.playerWin.Contains(true))
            {
                if (GameState.Instance.playerWin[GameState.Instance.localPlayer.GetComponent<Player>().id])
                {
                    UIManager.Instance.Win();
                    return;
                }
                else
                {
                    UIManager.Instance.Loss();
                    return;
                }
            }
            if (GameState.Instance.criminal == GameState.Instance.roles[GameState.Instance.localPlayer.GetComponent<Player>().id])
            {
                if (GameState.Instance.playerLost.Contains(true))
                {
                    int lostPlayers = 0;
                    for (int i = 0; i < GameState.Instance.playerCount; i++)
                    {
                        if (GameState.Instance.playerLost[i])
                        {
                            lostPlayers++;
                        }
                    }
                    if (lostPlayers == GameState.Instance.playerCount - 1)
                    {
                        GameState.Instance.localPlayer.GetComponent<Player>().SetCriminalWin(true);
                        return;
                    }
                }
            }
            if (GameState.Instance.playerLost[GameState.Instance.localPlayer.GetComponent<Player>().id])
            {
                UIManager.Instance.Loss();
                return;
            }
            if (GameState.Instance.draw)
            {
                UIManager.Instance.Draw();
                return;
            }
        }
    }


    ///////////////////////////////////////////////////////
    //////////////Manually Synchronized Stuff//////////////
    ///////////////////////////////////////////////////////
    #region SetSelectedRoles
    public void SetSelectedRoles(int selectedRoles)
    {
        GameState.Instance.selectedRoles = selectedRoles;
        if (isServer)
        {
            RpcSetSelectedRoles(selectedRoles);
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
    [ClientRpc]
    public void RpcSetSelectedRoles(int selectedRoles)
    {
        if (!isServer)
        {
            GameState.Instance.selectedRoles = selectedRoles;
        }
    }
    #endregion
    #region SetTargetTime
    public void SetTargetTime(bool active)
    {
        if (isServer)
        {
            GameState.Instance.targetTime = active;
            RpcSetTargetTime(active);
        }
        else
        {
            // CmdSetTargetTime(active);
        }
    }
    [Command]
    public void CmdSetTargetTime(bool active)
    {
        SetTargetTime(active);
    }
    [ClientRpc]
    public void RpcSetTargetTime(bool active)
    {
        if (!isServer)
        {
            GameState.Instance.targetTime = active;
        }
    }
    #endregion
    #region SetElapsedSeconds
    public void SetElapsedSeconds(int elapsedSeconds)
    {
        if (isServer)
        {
            GameState.Instance.elapsedSeconds = elapsedSeconds;
            RpcSetElapsedSeconds(elapsedSeconds);
        }
        else
        {
            // CmdSetElapsedSeconds(elapsedSeconds);
        }
    }
    [Command]
    public void CmdSetElapsedSeconds(int elapsedSeconds)
    {
        SetElapsedSeconds(elapsedSeconds);
    }
    [ClientRpc]
    public void RpcSetElapsedSeconds(int elapsedSeconds)
    {
        if (!isServer)
        {
            GameState.Instance.elapsedSeconds = elapsedSeconds;
        }
    }
    #endregion
    #region SetElapsedTime
    public void SetElapsedTime(string elapsedTime)
    {
        if (isServer)
        {
            GameState.Instance.elapsedTime = elapsedTime;
            RpcSetElapsedTime(elapsedTime);
        }
        else
        {
            //CmdSetElapsedTime(elapsedTime);
        }
    }
    [Command]
    public void CmdSetElapsedTime(string elapsedTime)
    {
        SetElapsedTime(elapsedTime);
    }
    [ClientRpc]
    public void RpcSetElapsedTime(string elapsedTime)
    {
        if (!isServer)
        {
            GameState.Instance.elapsedTime = elapsedTime;
        }
    }
    #endregion
    #region SetDraw
    public void SetDraw(bool draw)
    {
        GameState.Instance.draw = draw;
        if (isServer)
        {
            RpcSetDraw(draw);
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
    [ClientRpc]
    public void RpcSetDraw(bool draw)
    {
        if (!isServer)
        {
            GameState.Instance.draw = draw;
        }
    }

    #endregion
    #region SetCriminalWin
    public void SetCriminalWin(bool win)
    {
        GameState.Instance.criminalWin = win;
        if (isServer)
        {
            RpcSetCriminalWin(win);
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
    [ClientRpc]
    public void RpcSetCriminalWin(bool win)
    {
        if (!isServer)
        {
            GameState.Instance.criminalWin = win;
        }
    }
    #endregion
    #region SetCriminal
    public void SetCriminal(string role)
    {
     
        if (isServer)
        {
            GameState.Instance.criminal = role;
            RpcSetCriminal(role);
        }
    }
    [ClientRpc]
    public void RpcSetCriminal(string role)
    {
        if (!isServer)
        {
            GameState.Instance.criminal = role;
        }
    }
    #endregion
    #region SetCriminalRole
    public void SetCriminalRole(string role)
    {
        
        if (isServer)
        {
            GameState.Instance.criminalRole = role;
            RpcSetCriminalRole(role);
        }
    }
    [ClientRpc]
    public void RpcSetCriminalRole(string role)
    {
        if (!isServer)
        {
            GameState.Instance.criminalRole = role;
        }
    }
    #endregion
    #region SetTargetPlace
    public void SetTargetPlace(int place)
    {
        
        if (isServer)
        {
            GameState.Instance.targetPlace = place;
            RpcSetTargetPlace(place);
        }
    }
    [ClientRpc]
    public void RpcSetTargetPlace(int place)
    {
        if (!isServer)
        {
            GameState.Instance.targetPlace = place;
        }
    }
    #endregion
    #region SetCurrentTurn
    public void SetCurrentTurn(int currentTurn)
    {
        GameState.Instance.currentTurn = currentTurn;
        if (isServer)
        {
            RpcSetCurrenTurn(currentTurn);
        }
        else
        {
            CmdSetCurrentTurn(currentTurn);
        }
    }
    [Command]
    public void CmdSetCurrentTurn(int currentTurn)
    {
        SetCurrentTurn(currentTurn);
    }
    [ClientRpc]
    public void RpcSetCurrenTurn(int currentTurn)
    {
        if (!isServer)
        {
            GameState.Instance.currentTurn = currentTurn;
        }
    }
    #endregion
    #region SetActivatedQuestPlaces
    public void SetActivatedQuestPlaces(int activatedPlaces)
    {
        GameState.Instance.activatedQuestPlaces = activatedPlaces;
        if (isServer)
        {
            RpcSetActivatedQuestPlaces(activatedPlaces);
        }
        else
        {
            CmdSetActivatedQuestPlaces(activatedPlaces);
        }
    }
    [Command]
    public void CmdSetActivatedQuestPlaces(int activatedPlaces)
    {
        SetActivatedQuestPlaces(activatedPlaces);
    }
    [ClientRpc]
    public void RpcSetActivatedQuestPlaces(int activatedPlaces)
    {
        if (!isServer)
        {
            GameState.Instance.activatedQuestPlaces = activatedPlaces;
        }
    }
    #endregion
    #region SetPlanted
    public void SetPlanted(bool planted)
    {
        GameState.Instance.planted = planted;
        if (isServer)
        {
            RpcSetPlanted(planted);
        }
        else
        {
            CmdSetPlanted(planted);
        }
    }
    [Command]
    public void CmdSetPlanted(bool planted)
    {
        SetPlanted(planted);
    }
    [ClientRpc]
    public void RpcSetPlanted(bool planted)
    {
        if (!isServer)
        {
            GameState.Instance.planted = planted;
        }
    }
    #endregion
    #region SetBigTrapUsed
    public void SetBigTrapUsed(bool bigTrapUsed)
    {
        GameState.Instance.bigTrapUsed = bigTrapUsed;
        if (isServer)
        {
            RpcSetBigTrapUsed(bigTrapUsed);
        }
        else
        {
            CmdSetBigTrapUsed(bigTrapUsed);
        }
    }
    [Command]
    public void CmdSetBigTrapUsed(bool bigTrapUsed)
    {
        SetBigTrapUsed(bigTrapUsed);
    }
    [ClientRpc]
    public void RpcSetBigTrapUsed(bool bigTrapUsed)
    {
        if (!isServer)
        {
            GameState.Instance.bigTrapUsed = bigTrapUsed;
        }
    }
    #endregion
    #region SetCurrentPlace
    public void SetCurrentPlace(int index, int currentPlaceX, int currentPlaceY)
    {
        GameState.Instance.currentPlace[index] = new int[] { currentPlaceX, currentPlaceY };
        if (isServer)
        {
            RpcSetCurrentPlace(index, currentPlaceX, currentPlaceY);
        }
        else
        {
            CmdSetCurrentPlace(index, currentPlaceX, currentPlaceY);
        }
    }
    [Command]
    public void CmdSetCurrentPlace(int index, int currentPlaceX, int currentPlaceY)
    {
        SetCurrentPlace(index, currentPlaceX, currentPlaceY);
    }
    [ClientRpc]
    public void RpcSetCurrentPlace(int index, int currentPlaceX, int currentPlaceY)
    {
        if (!isServer)
        {
            GameState.Instance.currentPlace[index] = new int[] { currentPlaceX, currentPlaceY };
        }
    }
    #endregion
    #region SetNotFoundTrue
    public void SetNotFoundTrue(int indexX, int indexY, int indexZ, int notFoundTrue)
    {
        GameState.Instance.notFoundTrue[indexX][indexY, indexZ] = notFoundTrue;
        if (isServer)
        {
            RpcSetNotFoundTrue(indexX, indexY, indexZ, notFoundTrue);
        }
        else
        {
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
        if (!isServer)
        {
            GameState.Instance.notFoundTrue[indexX][indexY, indexZ] = notFoundTrue;
        }
    }
    #endregion
    #region SetNotFoundFalse
    public void SetNotFoundFalse(int indexX, int indexY, int indexZ, int notFoundFalse)
    {
        GameState.Instance.notFoundFalse[indexX][indexY, indexZ] = notFoundFalse;
        if (isServer)
        {
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
        if (!isServer)
        {
            GameState.Instance.notFoundFalse[indexX][indexY, indexZ] = notFoundFalse;
        }
    }
    #endregion
    #region SetBoard
    public void SetBoard(int indexX, int indexY, int place)
    {
        GameState.Instance.board[indexX, indexY] = place;
        if (isServer)
        {
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
        if (!isServer)
        {
            GameState.Instance.board[indexX, indexY] = place;
        }
    }
    #endregion
    #region AddQuestPlace
    public void AddQuestPlace(int place)
    {
       
        if (isServer)
        {
            GameState.Instance.questPlaces.Add(place);
            RpcAddQuestPlace(place);
        }
    }
    [ClientRpc]
    public void RpcAddQuestPlace(int place)
    {
        GameState.Instance.questPlaces.Add(place);
    }
    #endregion
    #region RemoveQuestPlace
    public void RemoveQuestPlace(int place)
    {
        GameState.Instance.questPlaces.Remove(place);
        if (isServer)
        {
            RpcRemoveQuestPlace(place);
        }
        else
        {
            CmdRemoveQuestPlace(place);
        }
    }
    [Command]
    public void CmdRemoveQuestPlace(int place)
    {
        RemoveQuestPlace(place);
    }
    [ClientRpc]
    public void RpcRemoveQuestPlace(int place)
    {
        GameState.Instance.questPlaces.Remove(place);
    }
    #endregion
    #region SetPlayerState
    public void SetPlayerState(int index, string state)
    {
        GameState.Instance.playerState[index] = state;
        if (isServer)
        {
            RpcSetPlayerState(index, state);
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
    [ClientRpc]
    public void RpcSetPlayerState(int index, string state)
    {
        GameState.Instance.playerState[index] = state;
    }
    #endregion
    #region SetRole
    public void SetRole(int index, string role)
    {
        GameState.Instance.roles[index] = role;
        if (isServer)
        {
            RpcSetRole(index, role);
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
    [ClientRpc]
    public void RpcSetRole(int index, string role)
    {
        GameState.Instance.roles[index] = role;
    }
    #endregion
    #region SetMoney
    public void SetMoney(int index, int money)
    {

        GameState.Instance.money[index] = money;
        if (isServer)
        {
            RpcSetMoney(index, money);

        }
        else
        {
            CmdSetMoney(index, money);
        }
    }
    [Command]
    public void CmdSetMoney(int index, int money)
    {
        SetMoney(index, money);
    }
    [ClientRpc]
    public void RpcSetMoney(int index, int money)
    {
        GameState.Instance.money[index] = money;
    }
    #endregion
    #region SetSolvedHints
    public void SetSolvedHints(int index, int solvedHints)
    {
        GameState.Instance.solvedHints[index] = solvedHints;
        if (isServer)
        {
            RpcSetSolvedHints(index, solvedHints);
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
    [ClientRpc]
    public void RpcSetSolvedHints(int index, int solvedHints)
    {
        GameState.Instance.solvedHints[index] = solvedHints;
    }
    #endregion
    #region SetUnsolvedHints
    public void SetUnsolvedHints(int index, int unsolvedHints)
    {
        GameState.Instance.unsolvedHints[index] = unsolvedHints;
        if (isServer)
        {
            RpcSetUnsolvedHints(index, unsolvedHints);
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
    [ClientRpc]
    public void RpcSetUnsolvedHints(int index, int unsolvedHints)
    {
        GameState.Instance.unsolvedHints[index] = unsolvedHints;
    }
    #endregion
    #region SetTrueSolveds
    public void SetTrueSolveds(int index, int trueSolveds)
    {
        GameState.Instance.trueSolveds[index] = trueSolveds;
        if (isServer)
        {
            RpcSetTrueSolveds(index, trueSolveds);
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
    [ClientRpc]
    public void RpcSetTrueSolveds(int index, int trueSolveds)
    {
        GameState.Instance.trueSolveds[index] = trueSolveds;
    }
    #endregion
    #region SetTrueUnsolveds
    public void SetTrueUnsolveds(int index, int trueUnsolveds)
    {
        GameState.Instance.trueUnsolveds[index] = trueUnsolveds;
        if (isServer)
        {
            RpcSetTrueUnsolveds(index, trueUnsolveds);
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
    [ClientRpc]
    public void RpcSetTrueUnsolveds(int index, int trueUnsolveds)
    {
        GameState.Instance.trueUnsolveds[index] = trueUnsolveds;
    }
    #endregion
    #region SetIsDisabled
    public void SetIsDisabled(int index, int isDisabled)
    {
        GameState.Instance.isDisabled[index] = isDisabled;
        if (isServer)
        {
            RpcSetIsDisabled(index, isDisabled);
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
    [ClientRpc]
    public void RpcSetIsDisabled(int index, int isDisabled)
    {
        GameState.Instance.isDisabled[index] = isDisabled;
    }
    #endregion
    #region SetIsMovementManipulated
    public void SetIsMovementManipulated(int index, bool isMovementManipulated)
    {
        GameState.Instance.isMovementManipulated[index] = isMovementManipulated;
        if (isServer)
        {
            RpcSetIsMovmentManipulated(index, isMovementManipulated);
        }
        else
        {
            CmdSetIsMovementManipulated(index, isMovementManipulated);
        }
    }
    [Command]
    public void CmdSetIsMovementManipulated(int index, bool isMovementManipulated)
    {
        SetIsMovementManipulated(index, isMovementManipulated);
    }
    [ClientRpc]
    public void RpcSetIsMovmentManipulated(int index, bool isMovementManipulated)
    {
        GameState.Instance.isMovementManipulated[index] = isMovementManipulated;
    }
    #endregion
    #region SetIsHintManipulated
    public void SetIsHintManipulated(int index, bool isHintManipulated)
    {
        GameState.Instance.isHintManipulated[index] = isHintManipulated;
        if (isServer)
        {
            RpcSetIsHintManipulated(index, isHintManipulated);
        }
        else
        {
            CmdSetIsHintManipulated(index, isHintManipulated);
        }
    }
    [Command]
    public void CmdSetIsHintManipulated(int index, bool isHintManipulated)
    {
        SetIsHintManipulated(index, isHintManipulated);
    }
    [ClientRpc]
    public void RpcSetIsHintManipulated(int index, bool isHintManipulated)
    {
        GameState.Instance.isHintManipulated[index] = isHintManipulated;
    }
    #endregion
    #region SetSkillUsed
    public void SetSkillUsed(int index, bool skillUsed)
    {
        GameState.Instance.skillUsed[index] = skillUsed;
        if (isServer)
        {
            RpcSetSkillUsed(index, skillUsed);
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
    [ClientRpc]
    public void RpcSetSkillUsed(int index, bool skillUsed)
    {
        GameState.Instance.skillUsed[index] = skillUsed;
    }
    #endregion
    #region  SetLastTransaction
    public void SetLastTransaction(int index, string lastTransaction)
    {
        GameState.Instance.lastTransaction[index] = lastTransaction;
        if (isServer)
        {
            RpcSetLastTransaction(index, lastTransaction);
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
    [ClientRpc]
    public void RpcSetLastTransaction(int index, string lastTransaction)
    {
        GameState.Instance.lastTransaction[index] = lastTransaction;
    }
    #endregion
    #region  SetLastAction
    public void SetLastAction(int index, string lastAction)
    {
        GameState.Instance.lastAction[index] = lastAction;
        if (isServer)
        {
            RpcSetLastAction(index, lastAction);
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
    [ClientRpc]
    public void RpcSetLastAction(int index, string lastAction)
    {
        GameState.Instance.lastAction[index] = lastAction;
    }
    #endregion
    #region  SetSolvedFacts
    public void SetSolvedFacts(int index, int solvedFacts)
    {
        GameState.Instance.solvedFacts[index] = solvedFacts;
        if (isServer)
        {
            RpcSetSolvedFacts(index, solvedFacts);
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
    [ClientRpc]
    public void RpcSetSolvedFacts(int index, int solvedFacts)
    {
        GameState.Instance.solvedFacts[index] = solvedFacts;
    }
    #endregion
    #region  SetPlaceFact
    public void SetPlaceFact(int index, string placeFact)
    {
        GameState.Instance.placeFact[index] = placeFact;
        if (isServer)
        {
            RpcSetPlaceFact(index, placeFact);
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
    [ClientRpc]
    public void RpcSetPlaceFact(int index, string placeFact)
    {
        GameState.Instance.placeFact[index] = placeFact;
    }
    #endregion
    #region  SetRoleFact
    public void SetRoleFact(int index, string roleFact)
    {
        GameState.Instance.roleFact[index] = roleFact;
        if (isServer)
        {
            RpcSetRoleFact(index, roleFact);
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
    [ClientRpc]
    public void RpcSetRoleFact(int index, string roleFact)
    {
        GameState.Instance.roleFact[index] = roleFact;
    }
    #endregion
    #region  SetPlayerFact
    public void SetPlayerFact(int index, string playerFact)
    {
        GameState.Instance.playerFact[index] = playerFact;
        if (isServer)
        {
            RpcSetPlayerFact(index, playerFact);
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
    [ClientRpc]
    public void RpcSetPlayerFact(int index, string playerFact)
    {
        GameState.Instance.playerFact[index] = playerFact;
    }
    #endregion
    #region  SetPlayerWin
    public void SetPlayerWin(int index, bool playerWin)
    {
        GameState.Instance.playerWin[index] = playerWin;
        if (isServer)
        {
            RpcSetPlayerWin(index, playerWin);
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
    [ClientRpc]
    public void RpcSetPlayerWin(int index, bool playerWin)
    {
        GameState.Instance.playerWin[index] = playerWin;
    }
    #endregion
    #region  SetPlayerLost
    public void SetPlayerLost(int index, bool playerLost)
    {
        GameState.Instance.playerLost[index] = playerLost;
        if (isServer)
        {
            RpcSetPlayerLost(index, playerLost);
        }
        else
        {
            CmdSetPlayerLost(index, playerLost);
        }
    }
    [Command]
    public void CmdSetPlayerLost(int index, bool playerLost)
    {
        SetPlayerLost(index, playerLost);
    }
    [ClientRpc]
    public void RpcSetPlayerLost(int index, bool playerLost)
    {
        GameState.Instance.playerLost[index] = playerLost;
    }
    #endregion
    #region SetActiveTraps
    public void SetActiveTraps(int index, string activeTrap)
    {
        GameState.Instance.activeTraps[index] = activeTrap;
        if (isServer)
        {
            RpcSetActiveTraps(index, activeTrap);
        }
        else
        {
            CmdSetActiveTraps(index, activeTrap);
        }
    }
    [Command]
    public void CmdSetActiveTraps(int index, string activeTrap)
    {
        SetActiveTraps(index, activeTrap);
    }
    [ClientRpc]
    public void RpcSetActiveTraps(int index, string activeTrap)
    {
        GameState.Instance.activeTraps[index] = activeTrap;
    }
    #endregion
    #region SetInfernoTraps
    public void SetInfernoTraps(int index, int turns)
    {
        GameState.Instance.infernoTraps[index] = turns;
        if (isServer)
        {
            RpcSetInfernoTraps(index, turns);
        }
        else
        {
            CmdSetInfernoTraps(index, turns);
        }

    }
    [Command]
    public void CmdSetInfernoTraps(int index, int turns)
    {
        SetInfernoTraps(index, turns);
    }
    [ClientRpc]
    public void RpcSetInfernoTraps(int index, int turns)
    {
        GameState.Instance.infernoTraps[index] = turns;
    }
    #endregion
    #region SetDrMortifierTraps
    public void SetDrMortifierTraps(int index, int turns)
    {
        GameState.Instance.drMortifierTraps[index] = turns;
        if (isServer)
        {
            RpcSetDrMortifierTraps(index, turns);
        }
        else
        {
            CmdSetDrMortifierTraps(index, turns);
        }

    }
    [Command]
    public void CmdSetDrMortifierTraps(int index, int turns)
    {
        SetDrMortifierTraps(index, turns);
    }
    [ClientRpc]
    public void RpcSetDrMortifierTraps(int index, int turns)
    {
        GameState.Instance.drMortifierTraps[index] = turns;
    }
    #endregion
    #region SetPhantomTraps
    public void SetPhantomTraps(int index, int turns)
    {
        GameState.Instance.phantomTraps[index] = turns;
        if (isServer)
        {
            RpcSetPhantomTraps(index, turns);
        }
        else
        {
            CmdSetPhantomTraps(index, turns);
        }

    }
    [Command]
    public void CmdSetPhantomTraps(int index, int turns)
    {
        SetPhantomTraps(index, turns);
    }
    [ClientRpc]
    public void RpcSetPhantomTraps(int index, int turns)
    {
        GameState.Instance.phantomTraps[index] = turns;
    }
    #endregion
    #region SetFascultoTraps
    public void SetFascultoTraps(int index, int turns)
    {
        GameState.Instance.fascultoTraps[index] = turns;
        if (isServer)
        {
            RpcSetFascultoTraps(index, turns);
        }
        else
        {
            CmdSetFascultoTraps(index, turns);
        }

    }
    [Command]
    public void CmdSetFascultoTraps(int index, int turns)
    {
        SetFascultoTraps(index, turns);
    }
    [ClientRpc]
    public void RpcSetFascultoTraps(int index, int turns)
    {
        GameState.Instance.fascultoTraps[index] = turns;
    }
    #endregion
    #region RemoveItem
    public void RemoveItem(int index, string item)
    {
        if (isServer)
        {
            GameState.Instance.items[index].Remove(item);
            RpcRemoveItem(index, item);
        }
        else
        {
            CmdRemoveItem(index, item);
        }

    }
    [Command]
    public void CmdRemoveItem(int index, string item)
    {
        RemoveItem(index, item);
    }
    [ClientRpc]
    public void RpcRemoveItem(int index, string item)
    {
        if (!isServer)
        {
            GameState.Instance.items[index].Remove(item);
        }
    }
    #endregion
    #region AddItem
    public void AddItem(int index, string item)
    {
        if (isServer)
        {
            GameState.Instance.items[index].Add(item);
            RpcAddItem(index, item);
        }
        else
        {
            CmdAddItem(index, item);
        }
    }
    [Command]
    public void CmdAddItem(int index, string item)
    {
        AddItem(index, item);
    }
    [ClientRpc]
    public void RpcAddItem(int index, string item)
    {
        if (!isServer)
        {
            GameState.Instance.items[index].Add(item);
        }
    }
    #endregion
    #region SetQuarantine
    public void SetQuarantine(int index, int turns)
    {
        GameState.Instance.quarantined[index] = turns;
        if (isServer)
        {
            RpcSetQuarantine(index, turns);
        }
        else
        {
            CmdSetQuarantine(index, turns);
        }
    }
    [Command]
    public void CmdSetQuarantine(int index, int turns)
    {
        SetQuarantine(index, turns);
    }
    [ClientRpc]
    public void RpcSetQuarantine(int index, int turns)
    {
        GameState.Instance.quarantined[index] = turns;
    }
    #endregion
    #region RemoveUsedEnergyDrink
    public void RemoveUsedEnergyDrink(bool usedEnergyDrink)
    {
        GameState.Instance.usedEnergyDrink.Remove(usedEnergyDrink);
        if (isServer)
        {
            RpcRemoveEnergyDrink(usedEnergyDrink);
        }
        else
        {
            CmdRemoveEnergyDrink(usedEnergyDrink);
        }
    }
    [Command]
    public void CmdRemoveEnergyDrink(bool usedEnergyDrink)
    {
        RemoveUsedEnergyDrink(usedEnergyDrink);
    }
    [ClientRpc]
    public void RpcRemoveEnergyDrink(bool usedEnergyDrink)
    {
        GameState.Instance.usedEnergyDrink.Remove(usedEnergyDrink);
    }
    #endregion
    #region AddUsedEnergyDrink
    public void AddUsedEnergyDrink(bool usedEnergyDrink)
    {
        GameState.Instance.usedEnergyDrink.Add(usedEnergyDrink);
        if (isServer)
        {
            RpcAddUsedEnergyDrink(usedEnergyDrink);
        }
        else
        {
            CmdAddUsedEnergyDrink(usedEnergyDrink);
        }
    }
    [Command]
    public void CmdAddUsedEnergyDrink(bool usedEnergyDrink)
    {
        AddUsedEnergyDrink(usedEnergyDrink);
    }
    [ClientRpc]
    public void RpcAddUsedEnergyDrink(bool usedEnergyDrink)
    {
        GameState.Instance.usedEnergyDrink.Add(usedEnergyDrink);
    }
    #endregion
    #region SetIsGuessing
    public void SetIsGuessing(int index, bool isGuessing)
    {
        GameState.Instance.isGuessing[index] = isGuessing;
        if (isServer)
        {
            RpcSetIsGuessing(index, isGuessing);
        }
        else
        {
            CmdSetIsGuessing(index, isGuessing);
        }
    }
    [Command]
    public void CmdSetIsGuessing(int index, bool isGuessing)
    {
        SetIsGuessing(index, isGuessing);
    }
    [ClientRpc]
    public void RpcSetIsGuessing(int index, bool isGuessing)
    {
        GameState.Instance.isGuessing[index] = isGuessing;
    }
    #endregion
    #region  SetReadyToPlay
    public void SetReadyToPlay(int index, bool readyToPlay)
    {
        GameState.Instance.readyToPlay[index] = readyToPlay;
        if (isServer)
        {
            RpcSetReadyToPlay(index, readyToPlay);
        }
        else
        {
            CmdSetReadyToPlay(index, readyToPlay);
        }
    }
    [Command]
    public void CmdSetReadyToPlay(int index, bool readyToPlay)
    {
        SetReadyToPlay(index, readyToPlay);
    }
    [ClientRpc]
    public void RpcSetReadyToPlay(int index, bool readyToPlay)
    {
        GameState.Instance.readyToPlay[index] = readyToPlay;
    }
    #endregion
    ///////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////
    #region ConnectedPlayerUp
    public void ConnectedPlayerUp()
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


   

}
