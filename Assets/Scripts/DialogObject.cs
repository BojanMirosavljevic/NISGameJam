using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogObject : StageObject
{
    public int WaitForNext = 5;

    [Header("References")]
    public Sprite DialogPersonSprite;
    public List<DialogueText> Messages;

    [Header("References")]
    [SerializeField] private Image DialogPerson;
    [SerializeField] private Transform MessagesRoot;
    [SerializeField] private Button ButtonNextStage;


    [Header("Prefabs")]
    [SerializeField] private MessageObject MessageLeft;
    [SerializeField] private MessageObject MessageRight;

    [SerializeField] private Button ButtonNotes;
    [SerializeField] private Button ButtonCloseNotes;
    [SerializeField] private GameObject StageNotes;

    public void Start()
    {
        AudioSystem.Instance.PlayMusicDialog();

        ButtonNextStage.interactable = false;

        DialogPerson.sprite = DialogPersonSprite;

        LoadMessages();

        ButtonNextStage.onClick.AddListener(() =>
        {
            AudioSystem.Instance.PlayButtonSound();
            ExitDialogue();
        });


        if (ButtonNotes != null)
        {
            ButtonNotes.gameObject.SetActive(true);
            ButtonNotes.onClick.AddListener(ShowNotes);
            ButtonCloseNotes.onClick.AddListener(CloseNotes);
        }
    }

    private void LoadMessages()
    {
        foreach(var Message in Messages)
        {
            if (Message.Direction == DialogueDirection.Left)
            {
                MessageObject mo = Instantiate(MessageLeft, MessagesRoot);
                mo.Init(Message);
            }
            else if (Message.Direction == DialogueDirection.Right)
            {
                MessageObject mo = Instantiate(MessageRight, MessagesRoot);
                mo.Init(Message);
            }
        }

        StartCoroutine(EnableNextSoon());
    }

    private IEnumerator EnableNextSoon()
    {
        yield return new WaitForSecondsRealtime(WaitForNext);

        ButtonNextStage.interactable = true;
    }

    private void ShowNotes()
    {
        StageNotes.SetActive(true);
    }

    private void CloseNotes()
    {
        StageNotes.SetActive(false);
    }
    

    private void ExitDialogue()
    {
        Destroy(gameObject);
    }
}