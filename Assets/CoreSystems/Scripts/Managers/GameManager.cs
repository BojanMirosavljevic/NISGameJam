using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{
    [SerializeField] private Transform StageHolder;

    [SerializeField] private List<StageObject> StagesIntro;
    [SerializeField] private List<StageObject> StagesScenario1;

    private Scene level;
    private int stagesTotal;
    private int stagesCounter;

    private List<StageObject> CurrentScenario;

    private void Start()
    {
        GameSystem.Instance.Level = 1;

        switch(GameSystem.Instance.Level)
        {
            case 0:
            {
                CurrentScenario = StagesIntro;
                break;
            }
            case 1:
            {
                CurrentScenario = StagesScenario1;
                break;
            }
        }

        stagesCounter = 0;
        stagesTotal = CurrentScenario.Count;
        SpawnNewStage();
    }

    private void SpawnNewStage()
    {
        Instantiate(CurrentScenario[stagesCounter], StageHolder);
        stagesCounter++;
    }

    public void NotifyFinishedStage()
    {
        if (stagesCounter >= stagesTotal)
        {
            //passed level!
            Debug.LogError("All stages passed for level: " + level);
        }
        else
        {
            SpawnNewStage();
        }
    }
}
