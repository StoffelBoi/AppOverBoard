using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class TimeManager : MonoBehaviour {
    private Stopwatch stopwatch;
    public static TimeManager Instance;
    public int elapsedMinutes;
    public int elapsedHours;
    private bool started;
    private string criminalRole;
    public bool getAway;
    private Stopwatch getAwayTime;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    // Use this for initialization
    void Start () {
        started = false;
        stopwatch = new Stopwatch();
        GameState.Instance.elapsedTime ="0:00:00";
        GameState.Instance.targetTime = false;
        criminalRole = "";
        getAway = false;
        getAwayTime = new Stopwatch();
	}

    public void startTimer()
    {
        stopwatch.Start();
        started = true;
        criminalRole = GameState.Instance.criminalRole;
        if (criminalRole == "Inferno"||criminalRole=="Dr.Mortifier")
        {
            GameState.Instance.targetTime = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            GameState.Instance.elapsedSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
            elapsedMinutes = GameState.Instance.elapsedSeconds / 60;
            elapsedHours = elapsedMinutes / 60;
            string seconds = "" + (GameState.Instance.elapsedSeconds % 60);
            if (seconds.Length == 1)
            {
                seconds = "0" + seconds;
            }
            string minutes = "" + (elapsedMinutes % 60);
            if (minutes.Length == 1)
            {
                minutes = "0" + minutes;
            }
            GameState.Instance.elapsedTime = "" + elapsedHours + ":" + minutes + ":" + seconds;


            //Inferno Test:
            if (criminalRole == "Inferno")
            {
                if (GameState.Instance.elapsedSeconds > 3000)
                {
                    GameState.Instance.targetTime = false;
                    GameState.Instance.draw = true;
                }
            }
            //Dr.Mortifier Test:
            if(criminalRole == "Dr.Mortifier")
            {
                if (GameState.Instance.planted)
                {
                    if (!getAway)
                    {
                        GameState.Instance.targetTime = false;
                        getAway = true;
                        getAwayTime.Start();
                    }
                    if(getAwayTime.ElapsedMilliseconds / 1000 >= 600)
                    {
                        if(Place.Instance.calculateGetAway())
                        {
                            GameState.Instance.criminalWin = true;
                        }
                        else
                        {
                            GameState.Instance.draw = true;
                        }
                        
                    }
                }
            }

            //Phantom Test:
            if (criminalRole == "Phantom")
            {
                bool hitTime = false;
                for (int i = 0; i < 600 && !hitTime; i += 100)
                {
                    if ((i + 20 <= elapsedMinutes && i + 25 > elapsedMinutes) || (i + 45 <= (GameState.Instance.elapsedSeconds / 60) && i + 50 > (GameState.Instance.elapsedSeconds / 60)) || (i + 70 <= (GameState.Instance.elapsedSeconds / 60) && i + 75 > (GameState.Instance.elapsedSeconds / 60)) || (i + 95 <= (GameState.Instance.elapsedSeconds / 60) && i + 100 > (GameState.Instance.elapsedSeconds / 60)))
                    {
                        GameState.Instance.targetTime = true;
                        hitTime = true;
                    }
                    else
                    {
                        GameState.Instance.targetTime = false;
                    }
                }
            }
            
            //Fasculto Test:
            if(criminalRole == "Fasculto")
            {
                if (GameState.Instance.elapsedSeconds > 2400)
                {
                    GameState.Instance.targetTime = true;
                }
                if (GameState.Instance.elapsedSeconds > 3600)
                {
                    GameState.Instance.targetTime = false;
                    GameState.Instance.draw = true;
                }
            }



        }
    }
}
