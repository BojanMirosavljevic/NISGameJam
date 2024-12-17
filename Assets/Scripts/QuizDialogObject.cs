using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizDialogObject : StageObject
{
    public int WaitForNext = 3;

    [Header("References")]
    public Sprite DialogPersonSprite;
    public List<DialogueText> Messages;
    [SerializeField] private Button ButtonNext;

    [Header("References")]
    [SerializeField] private Image DialogPerson;
    [SerializeField] private Transform MessagesRoot;
    [SerializeField] private QuizObject QuizQuestion;
    [SerializeField] private Transform QuizHolder;


    [Header("Prefabs")]
    [SerializeField] private MessageObject MessageLeft;
    [SerializeField] private MessageObject MessageRight;

    public void Start()
    {
        ButtonNext.interactable = false;

        DialogPerson.sprite = DialogPersonSprite;

        TryLoadMessage();

        ButtonNext.onClick.AddListener(() =>
        {
            QuizObject qo = Instantiate(QuizQuestion, QuizHolder);
            qo.onClose = ExitDialogue;
        });

        StartCoroutine(EnableNextSoon());
    }

    private void TryLoadMessage()
    {
        foreach(var Message in Messages)
        {
            //instantiate message
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
    }

    private IEnumerator EnableNextSoon()
    {
        yield return new WaitForSecondsRealtime(WaitForNext);

        ButtonNext.interactable = true;
    }


    private void ExitDialogue()
    {
        Destroy(gameObject);
    }
}