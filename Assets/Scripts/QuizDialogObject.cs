using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizDialogObject : StageObject
{

    [Header("References")]
    public Sprite DialogPersonSprite;
    public List<DialogueText> Messages;

    [Header("References")]
    [SerializeField] private Image DialogPerson;
    [SerializeField] private Transform MessagesRoot;
    [SerializeField] private Button ButtonLoadMore;
    [SerializeField] private QuizObject QuizQuestion;
    [SerializeField] private Transform QuizHolder;


    [Header("Prefabs")]
    [SerializeField] private MessageObject MessageLeft;
    [SerializeField] private MessageObject MessageRight;

    private int messageCount;
    private bool quizSolved;

    public void Start()
    {
        DialogPerson.sprite = DialogPersonSprite;

        TryLoadMessage();

        ButtonLoadMore.onClick.AddListener(TryLoadMessage);
    }

    private void TryLoadMessage()
    {
        if (messageCount >= Messages.Count)
        {
            QuizObject qo = Instantiate(QuizQuestion, QuizHolder);
            qo.onClose = ExitDialogue;
            
            ButtonLoadMore.gameObject.SetActive(false);
        }
        else 
        {
            //instantiate message
            if (Messages[messageCount].Direction == DialogueDirection.Left)
            {
                MessageObject mo = Instantiate(MessageLeft, MessagesRoot);
                mo.Init(Messages[messageCount]);
            }
            else if (Messages[messageCount].Direction == DialogueDirection.Right)
            {
                MessageObject mo = Instantiate(MessageRight, MessagesRoot);
                mo.Init(Messages[messageCount]);
            }

            messageCount++;
            
            ButtonLoadMore.gameObject.SetActive(true);
        }
    }

    private void ExitDialogue()
    {
        Destroy(gameObject);
    }
}