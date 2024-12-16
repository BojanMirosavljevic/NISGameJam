using UnityEngine;

public class StageObject : MonoBehaviour
{
    void OnDestroy()
    {
        GameManager.Instance.NotifyFinishedStage();
    }
}
