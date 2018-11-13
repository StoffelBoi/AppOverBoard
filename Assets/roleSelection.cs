using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class roleSelection : MonoBehaviour
{
    private gameState gs;
    private int selectedRoles;
    public Button btn_doctor;
    public Button btn_policeMan;
    public Button btn_privateDetective;
    public Button btn_psychic;
    public Button btn_psychologist;
    public Button btn_reporter;

    // Use this for initialization
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

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Selected Player Count: " + selectedRoles);
        if (selectedRoles == gameState.playerCount)
        {
            SceneManager.LoadScene("Waiting");
        }
    }



    void DoctorClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_doctor.interactable = false;
        //SceneManager.LoadScene("Waiting");
        gameState.roles.Add("Doctor");
        selectedRoles++;
    }

    void PoliceClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_policeMan.interactable = false;
        //SceneManager.LoadScene("Waiting");
        gameState.roles.Add("Police");
        selectedRoles++;
    }

    void DetectivClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_privateDetective.interactable = false;
        //SceneManager.LoadScene("Waiting");
        gameState.roles.Add("Detective");
        selectedRoles++;
    }

    void PsychicClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychic.interactable = false;
        //SceneManager.LoadScene("Waiting");
        gameState.roles.Add("Psychic");
        selectedRoles++;
    }

    void PsychologistClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_psychologist.interactable = false;
        //SceneManager.LoadScene("Waiting");
        gameState.roles.Add("Psychologist");
        selectedRoles++;
    }

    void ReporterClick()
    {
        //string in gamestate setzen
        //player count erhöhen für waiting scene
        btn_reporter.interactable = false;
        //SceneManager.LoadScene("Waiting");
        gameState.roles.Add("Reporter");
        selectedRoles++;
    }
}
