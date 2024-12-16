using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SingleImageObject : StageObject
{
    [SerializeField] private Button ButtonNextStage;


    public void Start()
    {
        ButtonNextStage.gameObject.SetActive(true);
        ButtonNextStage.interactable = false;

        StartCoroutine(EnableNextSoon());

        ButtonNextStage.onClick.AddListener(ExitSingleImageObject);
    }

    private IEnumerator EnableNextSoon()
    {
        yield return new WaitForSecondsRealtime(5);

        ButtonNextStage.interactable = true;
    }

    private void ExitSingleImageObject()
    {
        Destroy(gameObject);
    }
}