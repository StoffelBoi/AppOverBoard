using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class TimeManager : MonoBehaviour {
    private Stopwatch stopwatch;
    public static TimeManager Instance;
    public string elapsedTime;
    public int elapsedSeconds;
    public int elapsedMinutes;
    public int elapsedHours;
    private bool started;
    private string criminalRole;
    public bool getAway;
    private Stopwatch getAwayTime;
    public bool targetTime;

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
        elapsedTime="0:00:00";
        targetTime = false;
        criminalRole = "";
        getAway = false;
        getAwayTime = new Stopwatch();
	}

    public void startTimer()
    {
        stopwatch.Start();
        started = true;
        criminalRole = GameState.criminalRole;
        if (criminalRole == "Inferno"||criminalRole=="Dr.Mortifier")
        {
            targetTime = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (started)
        {
            elapsedSeconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
            elapsedMinutes = elapsedSeconds / 60;
            elapsedHours = elapsedMinutes / 60;
            string seconds = "" + (elapsedSeconds % 60);
            if (seconds.Length == 1)
            {
                seconds = "0" + seconds;
            }
            string minutes = "" + (elapsedMinutes % 60);
            if (minutes.Length == 1)
            {
                minutes = "0" + minutes;
            }
            elapsedTime = "" + elapsedHours + ":" + minutes + ":" + seconds;


            //Inferno Test:
            if (criminalRole == "Inferno")
            {
                if (elapsedSeconds > 3000)
                {
                    targetTime = false;
                    GameState.draw = true;
                }
            }
            //Dr.Mortifier Test:
            if(criminalRole == "Dr.Mortifier")
            {
                if (GameState.planted)
                {
                    if (!getAway)
                    {
                        targetTime = false;
                        getAway = true;
                        getAwayTime.Start();
                    }
                    if(getAwayTime.ElapsedMilliseconds / 1000 >= 600)
                    {
                        if(Place.Instance.calculateGetAway())
                        {
                            GameState.criminalWin = true;
                        }
                        else
                        {
                            GameState.draw = true;
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
                    if ((i + 20 <= elapsedMinutes && i + 25 > elapsedMinutes) || (i + 45 <= (elapsedSeconds / 60) && i + 50 > (elapsedSeconds / 60)) || (i + 70 <= (elapsedSeconds / 60) && i + 75 > (elapsedSeconds / 60)) || (i + 95 <= (elapsedSeconds / 60) && i + 100 > (elapsedSeconds / 60)))
                    {
                        targetTime = true;
                        hitTime = true;
                    }
                    else
                    {
                        targetTime = false;
                    }
                }
            }
            
            //Fasculto Test:
            if(criminalRole == "Fasculto")
            {
                if (elapsedSeconds > 2400)
                {
                    targetTime = true;
                }
                if (elapsedSeconds > 3600)
                {
                    targetTime = false;
                    GameState.draw = true;
                }
            }



        }
    }
}
