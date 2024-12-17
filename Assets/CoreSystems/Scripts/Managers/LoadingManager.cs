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
            GameSystem.Instance.LoadLevel(0);
        });
        Levels[1].onClick.AddListener(() =>
        {
            GameSystem.Instance.LoadLevel(1);
        });
        Levels[2].onClick.AddListener(() =>
        {
            GameSystem.Instance.LoadLevel(2);
        });
    }
}
