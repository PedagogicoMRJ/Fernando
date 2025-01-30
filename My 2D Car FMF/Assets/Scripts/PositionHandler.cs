using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PositionHandler : MonoBehaviour
{

    UIHandler leaderboardUIHandler;

    public List<LapCounter> lapCounters = new List<LapCounter>();

    void Awake()
    {

        LapCounter[] lapCountersArray = FindObjectsOfType<LapCounter>();

        lapCounters = lapCountersArray.ToList<LapCounter>();

        foreach (LapCounter lapCounter in lapCounters)

            lapCounter.OnPassCheckpoint += OnPassCheckpoint;

        leaderboardUIHandler = FindObjectOfType<UIHandler>();

    }

    void Start()
    {

        leaderboardUIHandler.UpdateList(lapCounters);
    }

    void OnPassCheckpoint(LapCounter lapCounter)
    {

        Debug.Log($"Evento: Carro {lapCounter.gameObject.name} passou o checkpoint");

        lapCounters = lapCounters.OrderByDescending(s => s.GetNCheckpointPassed()).ThenBy(s => s.GetNCheckpointPassed()).ToList();

        int carPosition = lapCounters.IndexOf(lapCounter) + 1;

        lapCounter.SetCarPosition(carPosition);

        leaderboardUIHandler.UpdateList(lapCounters);
    }
}