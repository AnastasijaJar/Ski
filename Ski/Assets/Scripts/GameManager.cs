using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DateTime raceStart;
    private TimeSpan raceTime;
    private bool racing= false;
    public delegate void TimerEvent();
    private void OnEnable()
    {
        StartGate.StartRace += StartRace;
        FinishGate.FinishRace += FinishRace;
    }

    void FinishRace()
    {
        Debug.Log("Finishing race from game manager");
        racing = false;
    }
    void StartRace()
    {
        raceStart = DateTime.Now;
        Debug.Log("Starting race from game manager");
    }
    
    void Update()
    {
        TimeSpan raceTime = DateTime.Now - raceStart;
        Debug.Log("RACE TIME" + raceTime);
    }
}
