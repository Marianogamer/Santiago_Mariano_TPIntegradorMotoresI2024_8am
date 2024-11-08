using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointControl : MonoBehaviour
{
    CheckPoint[] checkPoints;
    CheckPoint nextCheckPoint;

    int checkPointsReached;
    float lapStartTime;
    float fastestLap;

    [SerializeField] Text lapTimeText;
    [SerializeField] Text fastestLapTimeText;

    void Start()
    {
        checkPoints = GetComponentsInChildren<CheckPoint>();
        StartLap();
    }

    void UpdateFastestLapTime(float time)
    {
        fastestLap = time;
        fastestLapTimeText.text = FormatTime(fastestLap);
    }

    void Update()
    {
        lapTimeText.text = FormatTime(Time.time - lapStartTime);
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

        if (lapTime < fastestLap || fastestLap == 0)
        {
            UpdateFastestLapTime(lapTime);
        }

        StartLap();
    }

    void StartLap()
    {
        lapStartTime = Time.time;
        checkPointsReached = 1;
        nextCheckPoint = checkPoints[checkPointsReached];
    }

    internal void CheckpointReached(CheckPoint checkPoint)
    {
        if (nextCheckPoint != checkPoint)
            return;

        print("Checkpoint");

        checkPointsReached++;

        if (checkPointsReached == checkPoints.Length)
        {
            checkPointsReached = 0;
        }

        if (checkPoint.IsStartFinish)
        {
            return;
        }

        nextCheckPoint = checkPoints[checkPointsReached];
    }
}
