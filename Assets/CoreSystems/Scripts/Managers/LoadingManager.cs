using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : StaticInstance<LoadingManager>
{
    [SerializeField] List<Button> Levels;
    [SerializeField] AudioClip LoadingMusic;
    
    private void Start()
    {
        StartCoroutine(LoadingQueue());
    }

    private IEnumerator LoadingQueue()
    {
        yield return new WaitUntil(() => Systems.Instance.IsInitialized());

        AudioSystem.Instance.PlayMusicLoading();

        SetupLevelButtons();

        QueueSystem.Instance.RunNext();
    }

    private void SetupLevelButtons()
    {
        Levels[0].onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            GameSystem.Instance.LoadLevel(0);
        });
        Levels[1].onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            GameSystem.Instance.LoadLevel(1);
        });
        Levels[2].onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            GameSystem.Instance.LoadLevel(2);
        });
    }
}
