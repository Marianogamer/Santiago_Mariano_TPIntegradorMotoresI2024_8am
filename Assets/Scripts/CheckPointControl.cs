using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointControl : MonoBehaviour
{
    CheckPoint[] checkpoints;
    CheckPoint nextCheckPoint;

    int checkPointsReached;
    float lapStartTime;
    float fastestLapTime;

    [SerializeField] Text LapTimeText;
    [SerializeField] Text fastestLapTimeText;

    void Start()
    {
        checkpoints = GetComponentsInChildren<CheckPoint>();
        StartLap();
    }

    void UpdateFastestLapTime(float time)
    {
        fastestLapTime = time;
        fastestLapTimeText.text = FormatTime(fastestLapTime);
    }

    void Update()
    {
        LapTimeText.text = FormatTime(Time.time - lapStartTime);
        
    }

    string FormatTime(float time)
    {
        System.TimeSpan t = System.TimeSpan.FromSeconds(time);
        return string.Format("{0:D2}:{1:D2}.{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
    }

    public void EndLap()
    {
        float lapTime = Time.time - lapStartTime;

        print(lapTime);

        if (lapTime < fastestLapTime || fastestLapTime == 0)
        {
            UpdateFastestLapTime(lapTime);
        }

        StartLap();
    }

    void StartLap()
    {
        lapStartTime = Time.time;
        checkPointsReached = 1;
        nextCheckPoint = checkpoints[checkPointsReached];
    }

    internal void CheckpointReached(CheckPoint checkpoint)
    {
        if (nextCheckPoint != checkpoint)
            return;

        print("Checkpoint");

        checkPointsReached++;


        if (checkpoint.IsStartFinish)
        {
            EndLap();
            return;
        }

        if (checkPointsReached == checkpoints.Length)
        {
            checkPointsReached = 0;
        }

        nextCheckPoint = checkpoints[checkPointsReached];
    }
}
