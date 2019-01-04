using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class RoleSelection : MonoBehaviour
{
    public Button btn_doctor;
    public Button btn_policeMan;
    public Button btn_privateDetective;
    public Button btn_psychic;
    public Button btn_psychologist;
    public Button btn_reporter;
    private Player player;
    void Start()
    {
        
        btn_doctor.onClick.AddListener(DoctorClick);
        btn_policeMan.onClick.AddListener(PoliceClick);
        btn_privateDetective.onClick.AddListener(DetectiveClick);
        btn_psychic.onClick.AddListener(PsychicClick);
        btn_psychologist.onClick.AddListener(PsychologistClick);
        btn_reporter.onClick.AddListener(ReporterClick);
    }
    void OnEnable()
    {
        player = GameState.Instance.localPlayer.GetComponent<Player>();
    }
    void setCriminalRole()
    {
        System.Random rn = new System.Random();
        int Role = rn.Next(1, 5);
        int targetPlace = rn.Next(1, 4);
        int playerNumber = rn.Next(0, GameState.Instance.playerCount);
        player.SetCriminal(GameState.Instance.roles[playerNumber]);
        switch (Role)
        {
            case 1:
                player.SetCriminalRole("Inferno");
                player.AddQuestPlace(13);
                player.AddQuestPlace(12);
                player.AddQuestPlace(11);
                switch (targetPlace)
                {
                    case 1:
                        player.SetTargetPlace(5);
                        break;
                    case 2:
                        player.SetTargetPlace(8);
                        break;
                    case 3:
                        player.SetTargetPlace(7);
                        break;
                }
                break;
            case 2:
                player.SetCriminalRole("Dr.Mortifier");
                player.AddQuestPlace(15);
                player.AddQuestPlace(12);
                player.AddQuestPlace(14);
                switch (targetPlace)
                {
                    case 1:
                        player.SetTargetPlace(1);
                        break;
                    case 2:
                        player.SetTargetPlace(17);
                        break;
                    case 3:
                        player.SetTargetPlace(12);
                        break;
                }
                break;
            case 3:
                player.SetCriminalRole("Phantom");
                player.AddQuestPlace(9);
                player.AddQuestPlace(11);
                player.AddQuestPlace(18);
                switch (targetPlace)
                {
                    case 1:
                       player.SetTargetPlace(4);
                        break;
                    case 2:
                       player.SetTargetPlace(8);
                        break;
                    case 3:
                       player.SetTargetPlace(12);
                        break;
                }
                break;
            case 4:
                player.SetCriminalRole("Fasculto");
                player.AddQuestPlace(18);
                player.AddQuestPlace(14);
                player.AddQuestPlace(17);
                switch (targetPlace)
                {
                    case 1:
                        player.SetTargetPlace(6);
                        break;
                    case 2:
                        player.SetTargetPlace(7);
                        break;
                    case 3:
                        player.SetTargetPlace(5);
                        break;
                }
                break;
        }
        //Debug.Log(GameState.Instance.criminalRole + " played by " + GameState.Instance.criminal);
    }
    // Update is called once per frame
    void Update()
    {
        int selectedRoles = 0;
        for (int i = 0; i < 6; i++)
        {
            if (GameState.Instance.roles[i] != "")
            {
                selectedRoles++;
            }
        }
        player.SetSelectedRoles(selectedRoles);
        if (GameState.Instance.selectedRoles == GameState.Instance.playerCount)
        {
            setCriminalRole();
            player.SetPlayerState(0, "Movement");
            UIManager.Instance.BoardAssembly();
        }
        if (GameState.Instance.roles.Contains("Doctor"))
        {
            btn_doctor.interactable = false;
        }
        else
        {
            btn_doctor.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Police"))
        {
            btn_policeMan.interactable = false;
        }
        else
        {
            btn_policeMan.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Detective"))
        {
            btn_privateDetective.interactable = false;
        }
        else
        {
            btn_privateDetective.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Psychic"))
        {
            btn_psychic.interactable = false;
        }
        else
        {
            btn_psychic.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Psychologist"))
        {
            btn_psychologist.interactable = false;
        }
        else
        {
            btn_psychologist.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Reporter"))
        {
            btn_reporter.interactable = false;
        }
        else
        {
            btn_reporter.interactable = true;
        }
    }



    void DoctorClick()
    {
        player.SetRole(player.id, "Doctor");
        initializingPlayer();
    }

    void PoliceClick()
    {
        player.SetRole(player.id, "Police");
        initializingPlayer();
    }

    void DetectiveClick()
    {
        player.SetRole(player.id, "Detective");
        initializingPlayer();
    }

    void PsychicClick()
    {
        player.SetRole(player.id, "Psychic");
        initializingPlayer();
    }

    void PsychologistClick()
    {
        player.SetRole(player.id, "Psychologist");
        initializingPlayer();
    }

    void ReporterClick()
    {
        player.SetRole(player.id, "Reporter");
        initializingPlayer();
    }

    void initializingPlayer()
    {
        player.SetMoney(player.id, 6);
        player.SetTrueUnsolveds(player.id, 0);
        player.SetTrueSolveds(player.id, 0);
        player.SetUnsolvedHints(player.id, 0);
        player.SetSolvedHints(player.id, 69);
        player.SetIsDisabled(player.id, 0);
        player.SetIsManipulated(player.id, false);
        player.SetSkillUsed(player.id, false);
        player.SetPlayerState(player.id, "Waiting");
        player.SetLastTransaction(player.id, "Nichts");
        player.SetLastAction(player.id, "Nichts");
        player.SetSolvedFacts(player.id, 0);
        player.SetPlayerFact(player.id, "");
        player.SetRoleFact(player.id, "");
        player.SetPlaceFact(player.id, "");
        player.SetPlayerWin(player.id, false);
        player.SetPlayerLost(player.id, false);
        player.SetCurrentPlace(player.id, new int[] { 2, 3 });
        addingHintBoards();
    }
    void addingHintBoards()
    {
        int[,] notFoundTrue = new int[6, 7];
        int[,] notFoundFalse = new int[6, 7];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                notFoundTrue[i, j] = 0;
                notFoundFalse[i, j] = 0;
            }
        }
        GameState.Instance.notFoundTrue.Add(notFoundTrue);
        GameState.Instance.notFoundFalse.Add(notFoundFalse);
    }
}
