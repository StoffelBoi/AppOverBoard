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
    public Button btn_ok;
    public Button btn_Menu;
    public Button btn_Back;

    public Image doctor_selectedBG;
    public Image police_selectedBG;
    public Image detective_selectedBG;
    public Image psychic_selectedBG;
    public Image psychologist_selectedBG;
    public Image reporter_selectedBG;

    public bool okPressed = false;
    public bool selected=false;
    private Player player;
    void Start()
    {
        btn_Menu.onClick.AddListener(UIManager.Instance.OpenMenu);
        btn_doctor.onClick.AddListener(DoctorClick);
        btn_policeMan.onClick.AddListener(PoliceClick);
        btn_privateDetective.onClick.AddListener(DetectiveClick);
        btn_psychic.onClick.AddListener(PsychicClick);
        btn_psychologist.onClick.AddListener(PsychologistClick);
        btn_reporter.onClick.AddListener(ReporterClick);
        btn_ok.onClick.AddListener(okClick);
        btn_Back.onClick.AddListener(backClick);
    }
    void OnEnable()
    {
        doctor_selectedBG.gameObject.SetActive(false);
        police_selectedBG.gameObject.SetActive(false);
        detective_selectedBG.gameObject.SetActive(false);
        psychic_selectedBG.gameObject.SetActive(false);
        psychologist_selectedBG.gameObject.SetActive(false);
        reporter_selectedBG.gameObject.SetActive(false);
        btn_ok.interactable = false;
        btn_Back.interactable = false;
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
        if (selected)
        {
            btn_ok.interactable = true;
        }
        else
        {
            btn_ok.interactable = false;
        }
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
        else if(!okPressed)
        {
            btn_doctor.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Police"))
        {
            btn_policeMan.interactable = false;
        }
        else if (!okPressed)
        {
            btn_policeMan.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Detective"))
        {
            btn_privateDetective.interactable = false;
        }
        else if (!okPressed)
        {
            btn_privateDetective.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Psychic"))
        {
            btn_psychic.interactable = false;
        }
        else if (!okPressed)
        {
            btn_psychic.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Psychologist"))
        {
            btn_psychologist.interactable = false;
        }
        else if (!okPressed)
        {
            btn_psychologist.interactable = true;
        }
        if (GameState.Instance.roles.Contains("Reporter"))
        {
            btn_reporter.interactable = false;
        }
        else if (!okPressed)
        {
            btn_reporter.interactable = true;
        }
    }



    void DoctorClick()
    {

        doctor_selectedBG.gameObject.SetActive(true);
        police_selectedBG.gameObject.SetActive(false);
        detective_selectedBG.gameObject.SetActive(false);
        psychic_selectedBG.gameObject.SetActive(false);
        psychologist_selectedBG.gameObject.SetActive(false);
        reporter_selectedBG.gameObject.SetActive(false);

        player.SetRole(player.id, "Doctor");
        initializingPlayer();
        selected = true;
    }

    void PoliceClick()
    {
        doctor_selectedBG.gameObject.SetActive(false);
        police_selectedBG.gameObject.SetActive(true);
        detective_selectedBG.gameObject.SetActive(false);
        psychic_selectedBG.gameObject.SetActive(false);
        psychologist_selectedBG.gameObject.SetActive(false);
        reporter_selectedBG.gameObject.SetActive(false);

        player.SetRole(player.id, "Police");
        initializingPlayer();
        selected = true;
    }

    void DetectiveClick()
    {
        doctor_selectedBG.gameObject.SetActive(false);
        police_selectedBG.gameObject.SetActive(false);
        detective_selectedBG.gameObject.SetActive(true);
        psychic_selectedBG.gameObject.SetActive(false);
        psychologist_selectedBG.gameObject.SetActive(false);
        reporter_selectedBG.gameObject.SetActive(false);

        player.SetRole(player.id, "Detective");
        initializingPlayer();
        selected = true;
    }

    void PsychicClick()
    {
        doctor_selectedBG.gameObject.SetActive(false);
        police_selectedBG.gameObject.SetActive(false);
        detective_selectedBG.gameObject.SetActive(false);
        psychic_selectedBG.gameObject.SetActive(true);
        psychologist_selectedBG.gameObject.SetActive(false);
        reporter_selectedBG.gameObject.SetActive(false);

        player.SetRole(player.id, "Psychic");
        initializingPlayer();
        selected = true;
    }

    void PsychologistClick()
    {
        doctor_selectedBG.gameObject.SetActive(false);
        police_selectedBG.gameObject.SetActive(false);
        detective_selectedBG.gameObject.SetActive(false);
        psychic_selectedBG.gameObject.SetActive(false);
        psychologist_selectedBG.gameObject.SetActive(true);
        reporter_selectedBG.gameObject.SetActive(false);

        player.SetRole(player.id, "Psychologist");
        initializingPlayer();
        selected = true;
    }

    void ReporterClick()
    {
        doctor_selectedBG.gameObject.SetActive(false);
        police_selectedBG.gameObject.SetActive(false);
        detective_selectedBG.gameObject.SetActive(false);
        psychic_selectedBG.gameObject.SetActive(false);
        psychologist_selectedBG.gameObject.SetActive(false);
        reporter_selectedBG.gameObject.SetActive(true);


        player.SetRole(player.id, "Reporter");
        initializingPlayer();
        selected = true;
    }

    void okClick()
    {
        okPressed = true;
        btn_policeMan.interactable = false;
        btn_doctor.interactable = false;
        btn_privateDetective.interactable = false;
        btn_psychic.interactable = false;
        btn_psychologist.interactable = false;
        btn_reporter.interactable = false;
        
        player.SetSelectedRoles(GameState.Instance.selectedRoles+1);
        btn_Back.interactable = true;
        selected = false;
    }

    void backClick()
    {
        okPressed = false;
        btn_policeMan.interactable = true;
        btn_doctor.interactable = true;
        btn_privateDetective.interactable = true;
        btn_psychic.interactable = true;
        btn_psychologist.interactable = true;
        btn_reporter.interactable = true;

        doctor_selectedBG.gameObject.SetActive(false);
        police_selectedBG.gameObject.SetActive(false);
        detective_selectedBG.gameObject.SetActive(false);
        psychic_selectedBG.gameObject.SetActive(false);
        psychologist_selectedBG.gameObject.SetActive(false);
        reporter_selectedBG.gameObject.SetActive(false);








        player.SetSelectedRoles(GameState.Instance.selectedRoles - 1);
        btn_Back.interactable = false;
        player.SetRole(player.id, "");
        

    }
    void initializingPlayer()
    {
        player.SetMoney(player.id, 6);
        player.SetTrueUnsolveds(player.id, 0);
        player.SetTrueSolveds(player.id, 0);
        player.SetUnsolvedHints(player.id, 0);
        player.SetSolvedHints(player.id, 0);
        player.SetIsDisabled(player.id, 0);
        player.SetIsMovementManipulated(player.id, false);
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
        player.SetCurrentPlace(player.id, 3, 2 );
        addingHintBoards();
    }
    void addingHintBoards()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                player.SetNotFoundTrue(player.id, i, j, 0);
                player.SetNotFoundFalse(player.id, i, j, 0);
            }
        }
    }
}
