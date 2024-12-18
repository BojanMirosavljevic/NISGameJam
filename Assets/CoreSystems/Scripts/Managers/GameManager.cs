using System.Collections.Generic;
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
    [SerializeField] private List<StageObject> StagesScenario2;

    private Scene level;
    private int stagesTotal;
    private int stagesCounter;

    private List<StageObject> CurrentScenario;

    private void Start()
    {
        OptionsMenuObject.SetActive(false);

        ButtonShowOptions.onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            OptionsMenuObject.SetActive(true);
        });
        ButtonBackToMenu.onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            SceneSystem.Instance.LoadScene(Scene.Loading);
        });
        ButtonRestartLevel.onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            SceneSystem.Instance.LoadScene(Scene.Game);
        });
        ButtonContinueLevel.onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            OptionsMenuObject.SetActive(false);
        });
        
        GameSystem.Instance.Level = 2;

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
            case 2:
            {
                CurrentScenario = StagesScenario2;
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
