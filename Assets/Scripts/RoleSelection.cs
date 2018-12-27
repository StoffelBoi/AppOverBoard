using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class RoleSelection : MonoBehaviour
{
    private int selectedRoles;
    public Button btn_doctor;
    public Button btn_policeMan;
    public Button btn_privateDetective;
    public Button btn_psychic;
    public Button btn_psychologist;
    public Button btn_reporter;

    void Start()
    {
        btn_doctor.onClick.AddListener(DoctorClick);
        btn_policeMan.onClick.AddListener(PoliceClick);
        btn_privateDetective.onClick.AddListener(DetectivClick);
        btn_psychic.onClick.AddListener(PsychicClick);
        btn_psychologist.onClick.AddListener(PsychologistClick);
        btn_reporter.onClick.AddListener(ReporterClick);
        selectedRoles = 0;

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
                GameState.criminalRole = "Inferno";
                GameState.questPlaces.Add(13);
                GameState.questPlaces.Add(12);
                GameState.questPlaces.Add(11);
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
               GameState.criminalRole = "Dr.Mortifier";
                GameState.questPlaces.Add(15);
                GameState.questPlaces.Add(12);
                GameState.questPlaces.Add(14);
                switch (targetPlace)
                {
                    case 1:
                        GameState.targetPlace = 1;
                        break;
                    case 2:
                        GameState.targetPlace = 17;
                        break;
                    case 3:
                        GameState.targetPlace = 12;
                        break;
                }
                break;
            case 3:
                GameState.criminalRole = "Phantom";
                GameState.questPlaces.Add(9);
                GameState.questPlaces.Add(11);
                GameState.questPlaces.Add(18);
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
                GameState.criminalRole = "Fasculto";
                GameState.questPlaces.Add(18);
                GameState.questPlaces.Add(14);
                GameState.questPlaces.Add(17);
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
        Debug.Log(GameState.criminalRole + " played by " + GameState.criminal);
    }
    // Update is called once per frame
    void Update()
    {
        if (selectedRoles == GameState.playerCount)
        {
            setCriminalRole();
            GameState.playerState[0] = "Movement";
            UIManager.Instance.Waiting();
            
        }
    }



    void DoctorClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_doctor.interactable = false;
        GameState.roles.Add("Doctor");
        initializingPlayer();

        selectedRoles++;
    }

    void PoliceClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_policeMan.interactable = false;
        GameState.roles.Add("Police");
        initializingPlayer();

        selectedRoles++;
    }

    void DetectivClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_privateDetective.interactable = false;
        GameState.roles.Add("Detective");
        initializingPlayer();
       
        selectedRoles++;
    }

    void PsychicClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychic.interactable = false;
        GameState.roles.Add("Psychic");
        initializingPlayer();
  
        selectedRoles++;
    }

    void PsychologistClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychologist.interactable = false;
        GameState.roles.Add("Psychologist");
        initializingPlayer();
  
        selectedRoles++;
    }

    void ReporterClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_reporter.interactable = false;
        GameState.roles.Add("Reporter");
        initializingPlayer();
        selectedRoles++;
    }
    void initializingPlayer()
    {
        GameState.currentPlace.Add(new int[] { 2, 3 });
        GameState.money.Add(6);
        GameState.trueUnsolveds.Add(0);
        GameState.trueSolveds.Add(0);
        GameState.unsolvedHints.Add(0);
        GameState.solvedHints.Add(0);
        GameState.isDisabled.Add(0);
        GameState.isManipulated.Add(false);
        GameState.skillUsed.Add(false);
        GameState.items.Add(new List<string>());
        GameState.lastTransaction.Add("Nichts");
        GameState.lastAction.Add("Nichts");
        GameState.playerState.Add("Waiting");

        GameState.solvedFacts.Add(0);
        GameState.playerFact.Add("");
        GameState.roleFact.Add("");
        GameState.placeFact.Add("");
        GameState.playerWin.Add(false);
        GameState.playerLost.Add(false);
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
        GameState.notFoundTrue.Add(notFoundTrue);
        GameState.notFoundFalse.Add(notFoundFalse);
    }
}
