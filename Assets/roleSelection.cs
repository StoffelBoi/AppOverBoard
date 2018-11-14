using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class RoleSelection : MonoBehaviour
{
    private int[] mainsquare = new int[] { 2, 3 };
    private GameState gs;
    private int selectedRoles;
    public Button btn_doctor;
    public Button btn_policeMan;
    public Button btn_privateDetective;
    public Button btn_psychic;
    public Button btn_psychologist;
    public Button btn_reporter;

    public Canvas roleSelection;
    public Canvas waiting;

    public GameObject waitingController;

    private RoleSelection scriptRoleSelection;
    private PlayerCount scriptPlayerCount;

    // Use this for initialization
    private void Awake()
    {
        scriptRoleSelection = this.GetComponent<RoleSelection>();
        scriptRoleSelection.enabled = false;
    }
    void Start()
    {
        btn_doctor.onClick.AddListener(DoctorClick);
        btn_policeMan.onClick.AddListener(PoliceClick);
        btn_privateDetective.onClick.AddListener(DetectivClick);
        btn_psychic.onClick.AddListener(PsychicClick);
        btn_psychologist.onClick.AddListener(PsychologistClick);
        btn_reporter.onClick.AddListener(ReporterClick);
        selectedRoles = 0;
        
        scriptPlayerCount = waitingController.GetComponent<PlayerCount>();

    }

    void setCriminalRole()
    {
        System.Random rn = new System.Random();
        int Role = rn.Next(1, 5);
        int targetPlace = rn.Next(1, 4);
        int player = rn.Next(0, GameState.playerCount);
        GameState.criminal = GameState.roles[player];
        switch (Role)
        {
            case 1:
                GameState.criminalRole = "Bomber";
                switch (targetPlace)
                {
                    case 1:
                        GameState.targetPlace = 5;
                        break;
                    case 2:
                        GameState.targetPlace = 8;
                        break;
                    case 3:
                       GameState.targetPlace = 7;
                        break;
                }
                break;
            case 2:
               GameState.criminalRole = "Bio-Terrorist";
                switch (targetPlace)
                {
                    case 1:
                        GameState.targetPlace = 1;
                        break;
                    case 2:
                        GameState.targetPlace = 10;
                        break;
                    case 3:
                        GameState.targetPlace = 12;
                        break;
                }
                break;
            case 3:
                GameState.criminalRole = "Meisterdieb";
                switch (targetPlace)
                {
                    case 1:
                        GameState.targetPlace = 4;
                        break;
                    case 2:
                        GameState.targetPlace = 8;
                        break;
                    case 3:
                        GameState.targetPlace = 12;
                        break;
                }
                break;
            case 4:
                GameState.criminalRole = "Kultist";
                switch (targetPlace)
                {
                    case 1:
                        GameState.targetPlace = 6;
                        break;
                    case 2:
                        GameState.targetPlace = 7;
                        break;
                    case 3:
                        GameState.targetPlace = 5;
                        break;
                }
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Selected Player Count: " + selectedRoles);
        if (selectedRoles == GameState.playerCount)
        {
            setCriminalRole();
            roleSelection.enabled = false;
            waiting.enabled = true;
            scriptPlayerCount.enabled = true;
            scriptRoleSelection.enabled = false;
        }
    }



    void DoctorClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_doctor.interactable = false;
        //roleSelection.enabled = false;
        //waiting.enabled = true;
        GameState.roles.Add("Doctor");
        GameState.currentPlace.Add(mainsquare);
        selectedRoles++;
    }

    void PoliceClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_policeMan.interactable = false;
        //roleSelection.enabled = false;
        //waiting.enabled = true;
        GameState.roles.Add("Police");
        GameState.currentPlace.Add(mainsquare);
        selectedRoles++;
    }

    void DetectivClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_privateDetective.interactable = false;
        //roleSelection.enabled = false;
        //waiting.enabled = true;
        GameState.roles.Add("Detective");
        GameState.currentPlace.Add(mainsquare);
        selectedRoles++;
    }

    void PsychicClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychic.interactable = false;
        //roleSelection.enabled = false;
        //waiting.enabled = true;
        GameState.roles.Add("Psychic");
        GameState.currentPlace.Add(mainsquare);
        selectedRoles++;
    }

    void PsychologistClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychologist.interactable = false;
        //roleSelection.enabled = false;
        //waiting.enabled = true;
        GameState.roles.Add("Psychologist");
        GameState.currentPlace.Add(mainsquare);
        selectedRoles++;
    }

    void ReporterClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_reporter.interactable = false;
        //roleSelection.enabled = false;
        //waiting.enabled = true;
        GameState.roles.Add("Reporter");
        GameState.currentPlace.Add(mainsquare);
        selectedRoles++;
    }
}
