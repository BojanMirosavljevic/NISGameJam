using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : StaticInstance<GameManager>
{
    [SerializeField] private Transform StageHolder;

    [SerializeField] private Button ButtonShowOptions;
    [SerializeField] private GameObject OptionsMenuObject;
    [SerializeField] private Button ButtonBackToMenu;
    [SerializeField] private Button ButtonRestartLevel;
    [SerializeField] private Button ButtonContinueLevel;

    [SerializeField] private List<StageObject> StagesIntro;
    [SerializeField] private List<StageObject> StagesScenario1;

    private Scene level;
    private int stagesTotal;
    private int stagesCounter;

    private List<StageObject> CurrentScenario;

    private void Start()
    {
        OptionsMenuObject.SetActive(false);

        ButtonShowOptions.onClick.AddListener(() => {
            OptionsMenuObject.SetActive(true);
        });
        ButtonBackToMenu.onClick.AddListener(() => {
            SceneSystem.Instance.LoadScene(Scene.Loading);
        });
        ButtonRestartLevel.onClick.AddListener(() => {
            SceneSystem.Instance.LoadScene(Scene.Game);
        });
        ButtonContinueLevel.onClick.AddListener(() => {
            OptionsMenuObject.SetActive(false);
        });
        
        // GameSystem.Instance.Level = 0;

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
        StageObject so = Instantiate(CurrentScenario[stagesCounter], StageHolder);
        so.transform.SetAsFirstSibling();
        stagesCounter++;
    }

    public void NotifyFinishedStage()
    {
        if (stagesCounter >= stagesTotal)
        {
            SceneSystem.Instance.LoadScene(Scene.Loading);
        }
        else
        {
            SpawnNewStage();
        }
    }
}
