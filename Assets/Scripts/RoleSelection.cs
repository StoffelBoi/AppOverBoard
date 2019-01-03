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
                GameState.Instance.questPlaces.Add(13);
                GameState.Instance.questPlaces.Add(12);
                GameState.Instance.questPlaces.Add(11);
                switch (targetPlace)
                {
                    case 1:
                        GameState.Instance.targetPlace = 5;
                        break;
                    case 2:
                        GameState.Instance.targetPlace = 8;
                        break;
                    case 3:
                       GameState.Instance.targetPlace = 7;
                        break;
                }
                break;
            case 2:
               GameState.Instance.criminalRole = "Dr.Mortifier";
                GameState.Instance.questPlaces.Add(15);
                GameState.Instance.questPlaces.Add(12);
                GameState.Instance.questPlaces.Add(14);
                switch (targetPlace)
                {
                    case 1:
                        GameState.Instance.targetPlace = 1;
                        break;
                    case 2:
                        GameState.Instance.targetPlace = 17;
                        break;
                    case 3:
                        GameState.Instance.targetPlace = 12;
                        break;
                }
                break;
            case 3:
                GameState.Instance.criminalRole = "Phantom";
                GameState.Instance.questPlaces.Add(9);
                GameState.Instance.questPlaces.Add(11);
                GameState.Instance.questPlaces.Add(18);
                switch (targetPlace)
                {
                    case 1:
                        GameState.Instance.targetPlace = 4;
                        break;
                    case 2:
                        GameState.Instance.targetPlace = 8;
                        break;
                    case 3:
                        GameState.Instance.targetPlace = 12;
                        break;
                }
                break;
            case 4:
                GameState.Instance.criminalRole = "Fasculto";
                GameState.Instance.questPlaces.Add(18);
                GameState.Instance.questPlaces.Add(14);
                GameState.Instance.questPlaces.Add(17);
                switch (targetPlace)
                {
                    case 1:
                        GameState.Instance.targetPlace = 6;
                        break;
                    case 2:
                        GameState.Instance.targetPlace = 7;
                        break;
                    case 3:
                        GameState.Instance.targetPlace = 5;
                        break;
                }
                break;
        }
        Debug.Log(GameState.Instance.criminalRole + " played by " + GameState.Instance.criminal);
    }
    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance.selectedRoles == GameState.Instance.playerCount)
        {
            setCriminalRole();
            GameState.Instance.playerState[0] = "Movement";
            UIManager.Instance.BoardAssembly();
            
        }
    }



    void DoctorClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_doctor.interactable = false;
        GameState.Instance.roles.Add("Doctor");
        initializingPlayer();
    }

    void PoliceClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_policeMan.interactable = false;
        GameState.Instance.roles.Add("Police");
        initializingPlayer();
    }

    void DetectiveClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_privateDetective.interactable = false;
        GameState.Instance.roles.Add("Detective");
        initializingPlayer();
    }

    void PsychicClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychic.interactable = false;
        GameState.Instance.roles.Add("Psychic");
        initializingPlayer();
    }

    void PsychologistClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychologist.interactable = false;
        GameState.Instance.roles.Add("Psychologist");
        initializingPlayer();
    }

    void ReporterClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_reporter.interactable = false;
        GameState.Instance.roles.Add("Reporter");
        initializingPlayer();
    }
    void initializingPlayer()
    {
        GameState.Instance.currentPlace.Add(new int[] { 2, 3 });
        GameState.Instance.money.Add(6);
        GameState.Instance.trueUnsolveds.Add(0);
        GameState.Instance.trueSolveds.Add(0);
        GameState.Instance.unsolvedHints.Add(0);
        GameState.Instance.solvedHints.Add(0);
        GameState.Instance.isDisabled.Add(0);
        GameState.Instance.isManipulated.Add(false);
        GameState.Instance.skillUsed.Add(false);
        GameState.Instance.items.Add(new List<string>());
        GameState.Instance.lastTransaction.Add("Nichts");
        GameState.Instance.lastAction.Add("Nichts");
        GameState.Instance.playerState.Add("Waiting");

        GameState.Instance.solvedFacts.Add(0);
        GameState.Instance.playerFact.Add("");
        GameState.Instance.roleFact.Add("");
        GameState.Instance.placeFact.Add("");
        GameState.Instance.playerWin.Add(false);
        GameState.Instance.playerLost.Add(false);
        addingHintBoards();
        GameState.Instance.localPlayer.GetComponent<Player>().SelectedRolesUp();
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
