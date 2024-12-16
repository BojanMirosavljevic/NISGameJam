using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogObject : StageObject
{

    [Header("References")]
    public Sprite DialogPersonSprite;
    public List<DialogueText> Messages;

    [Header("References")]
    [SerializeField] private Image DialogPerson;
    [SerializeField] private Transform MessagesRoot;
    [SerializeField] private Button ButtonLoadMore;
    [SerializeField] private Button ButtonNextStage;


    [Header("Prefabs")]
    [SerializeField] private MessageObject MessageLeft;
    [SerializeField] private MessageObject MessageRight;

    private int messageCount;

    public void Start()
    {
        DialogPerson.sprite = DialogPersonSprite;

        TryLoadMessage();

        ButtonLoadMore.onClick.AddListener(TryLoadMessage);
        ButtonNextStage.onClick.AddListener(ExitDialogue);
    }

    private void TryLoadMessage()
    {
        if (messageCount < Messages.Count)
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
        }
        
        bool moreIncomingMessages = messageCount < Messages.Count;
        ButtonLoadMore.gameObject.SetActive(moreIncomingMessages);
        ButtonNextStage.gameObject.SetActive(!moreIncomingMessages);
    }

    private void ExitDialogue()
    {
        Destroy(gameObject);
    }
}