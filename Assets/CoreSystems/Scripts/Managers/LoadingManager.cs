using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : StaticInstance<LoadingManager>
{
    [SerializeField] private Button DUMMY_Button;

    private void Start()
    {
        DUMMY_Button.interactable = false;
        DUMMY_Button.onClick.AddListener(DUMMY_GoToGameScene);

        StartCoroutine(LoadingQueue());
    }

    private IEnumerator LoadingQueue()
    {
        yield return new WaitUntil(() => Systems.Instance.IsInitialized());
        
        QueueSystem.Instance.Enqueue(new QueueDelay(2f));
        QueueSystem.Instance.Enqueue(new CustomQueueItem(EnableButton));

        QueueSystem.Instance.RunNext();
    }

    private void EnableButton()
    {
        DUMMY_Button.interactable = true;
    }
    
    public void DUMMY_GoToGameScene()
    {
        SceneSystem.Instance.LoadScene(
            Scene.Game,
            () =>
            {
                Debug.LogError("SceneChanged");
            }
        );
    }
}
