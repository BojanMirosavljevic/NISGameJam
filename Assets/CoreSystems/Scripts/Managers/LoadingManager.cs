using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : StaticInstance<LoadingManager>
{
    [SerializeField] List<Button> Levels;
    
    private void Start()
    {
        StartCoroutine(LoadingQueue());
    }

    private IEnumerator LoadingQueue()
    {
        yield return new WaitUntil(() => Systems.Instance.IsInitialized());

        SetupLevelButtons();

        QueueSystem.Instance.RunNext();
    }

    private void SetupLevelButtons()
    {
        Levels[0].onClick.AddListener(() =>
        {
            SceneSystem.Instance.LoadScene(
                Scene.Game,
                () =>
                {
                    Debug.LogError("Level 0 Loaded");
                }
            );
        });
    }
}
