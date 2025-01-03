using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SingleImageObject : StageObject
{
    public int WaitForNext = 5;
    [SerializeField] private Button ButtonNextStage;
    public string PlaySound;

    public void Start()
    {
        if (PlaySound == "Znakovi")
        {
            AudioSystem.Instance.PlaySoundZnakovi();
        }
        AudioSystem.Instance.PlayMusicDialog();

        ButtonNextStage.gameObject.SetActive(true);
        ButtonNextStage.interactable = false;

        StartCoroutine(EnableNextSoon());

        ButtonNextStage.onClick.AddListener(ExitSingleImageObject);
    }

    private IEnumerator EnableNextSoon()
    {
        yield return new WaitForSecondsRealtime(WaitForNext);

        ButtonNextStage.interactable = true;
    }

    private void ExitSingleImageObject()
    {
        Destroy(gameObject);
    }
}