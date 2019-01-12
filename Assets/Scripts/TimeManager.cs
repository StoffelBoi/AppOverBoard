using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
public class TimeManager : MonoBehaviour
{
    private Stopwatch stopwatch;
    public static TimeManager Instance;
    public int elapsedMinutes;
    public int elapsedHours;
    private bool started;
    private string criminalRole;
    public bool getAway;
    public Stopwatch getAwayTime;
    private Player player;
    public int speed = 1;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    // Use this for initialization
    void Start()
    {
        started = false;
        stopwatch = new Stopwatch();
        criminalRole = "";
        getAway = false;
        getAwayTime = new Stopwatch();
    }

    public void startTimer()
    {
        player = GameState.Instance.localPlayer.GetComponent<Player>();
        stopwatch.Start();
        started = true;
        criminalRole = GameState.Instance.criminalRole;
        if (criminalRole == "Inferno" || criminalRole == "Dr.Mortifier")
        {
            player.SetTargetTime(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            GameState.Instance.elapsedSeconds = (speed * (int)(stopwatch.ElapsedMilliseconds / 1000));
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
            player.SetElapsedTime("" + elapsedHours + ":" + minutes + ":" + seconds);


            //Inferno Test:
            if (criminalRole == "Inferno")
            {
                if (GameState.Instance.elapsedSeconds > 3000)
                {
                    player.SetTargetTime(false);
                    player.SetDraw(true);
                }
            }
            //Dr.Mortifier Test:
            if (criminalRole == "Dr.Mortifier")
            {
                if (GameState.Instance.planted)
                {
                    if (!getAway)
                    {
                        player.SetTargetTime(false);
                        getAway = true;
                        getAwayTime.Start();
                    }
                    if (getAwayTime.ElapsedMilliseconds / 1000 >= 600)
                    {
                        if (calculateGetAway())
                        {
                            player.SetCriminalWin(true);
                        }
                        else
                        {
                            player.SetDraw(true);
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
                        player.SetTargetTime(true);
                        hitTime = true;
                    }
                    else
                    {
                        player.SetTargetTime(false);
                    }
                }
            }

            //Fasculto Test:
            if (criminalRole == "Fasculto")
            {
                if (GameState.Instance.elapsedSeconds > 2400)
                {
                    player.SetTargetTime(true);
                }
                if (GameState.Instance.elapsedSeconds > 3600)
                {
                    player.SetTargetTime(false);
                    player.SetDraw(true);
                }
            }



        }
    }

    public bool calculateGetAway()
    {
        int distance = 0;
        int[] start = findPosition(GameState.Instance.targetPlace);
        int criminalID = -1;
        for (int i = 0; i < GameState.Instance.playerCount; i++)
        {
            if (GameState.Instance.roles[i] == GameState.Instance.criminal)
            {
                criminalID = i;
            }
        }
        int[] end = GameState.Instance.currentPlace[criminalID];
        distance += Math.Abs(start[0] - end[0]);
        distance += Math.Abs(start[1] - end[1]);
        return (distance >= 5);
    }
    int[] findPosition(int place)
    {
        int[] position = new int[2];
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (GameState.Instance.board[i, j] == place)
                {
                    position[0] = i;
                    position[1] = j;
                }
            }
        }
        return position;
    }
}