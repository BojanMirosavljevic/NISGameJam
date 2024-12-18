using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingObject : StageObject
{
    [SerializeField] private Button ButtonNext;
    [SerializeField] private Button ButtonNotes;
    [SerializeField] private Button ButtonCloseNotes;
    [SerializeField] private GameObject StageNotes;
    [SerializeField] private List<Button> Clickables;
    [SerializeField] private List<QuizObject> QuizQuestions;
    [SerializeField] private Transform QuizHolder;

    [SerializeField] private int MandatoryTotal;

    private int SelectableTotal;
    private int SelectableMandatoryCounter;

    private List<int> FinishedClickables;

    public string PlaySound;

    public void Start()
    {
        if (PlaySound == "OdaberiteRadnike")
        {
            AudioSystem.Instance.PlaySoundOdaberiteRadnike();
        }
        AudioSystem.Instance.PlayMusicSelecting();

        FinishedClickables = new List<int>();

        ButtonNotes.gameObject.SetActive(true);
        ButtonNotes.onClick.AddListener(ShowNotes);
        ButtonCloseNotes.onClick.AddListener(CloseNotes);

        SelectableTotal = Clickables.Count;

        ButtonNext.onClick.AddListener(EndStage);

        Clickables[0].onClick.AddListener(() => {
            QuizObject qo = Instantiate(QuizQuestions[0], QuizHolder);
            qo.onClose = CheckEndStage;
            if(qo.Mandatory)
            {
                SelectableMandatoryCounter++;
            }
            FinishedClickables.Add(0);
            Clickables[0].image.color = new Color(0.7f,0.5f,0.3f,0.5f);
            Clickables[0].interactable = false;
        });

        Clickables[1].onClick.AddListener(() => {
            QuizObject qo = Instantiate(QuizQuestions[1], QuizHolder);
            qo.onClose = CheckEndStage;
            if(qo.Mandatory)
            {
                SelectableMandatoryCounter++;
            }
            FinishedClickables.Add(1);
            Clickables[1].image.color = new Color(0.7f,0.5f,0.3f,0.5f);
            Clickables[1].interactable = false;
        });

        Clickables[2].onClick.AddListener(() => {
            QuizObject qo = Instantiate(QuizQuestions[2], QuizHolder);
            qo.onClose = CheckEndStage;
            if(qo.Mandatory)
            {
                SelectableMandatoryCounter++;
            }
            FinishedClickables.Add(2);
            Clickables[2].image.color = new Color(0.7f,0.5f,0.3f,0.5f);
            Clickables[2].interactable = false;
        });
    }

    private void ShowNotes()
    {
        StageNotes.SetActive(true);
    }

    private void CloseNotes()
    {
        StageNotes.SetActive(false);
    }

    private void CheckEndStage()
    {
        if (SelectableMandatoryCounter >= MandatoryTotal)
        {
            if (FinishedClickables.Count >= SelectableTotal)
            {
                EndStage();
            }
            else
            {
                ButtonNext.gameObject.SetActive(true);
            }
        }
    }

    private void EndStage()
    {
        if (FinishedClickables.Count >= SelectableTotal)
        {
            ExitSelectingObject();
        }
        else
        {
            for(int i = 0; i < SelectableTotal; i++)
            {
                if (FinishedClickables.Contains(i))
                {
                    continue;
                }

                QuizObject qo = Instantiate(QuizQuestions[i], QuizHolder);
                if(qo.Mandatory)
                {
                    SelectableMandatoryCounter++;
                }
                FinishedClickables.Add(i);
                Clickables[i].interactable = false;
                Clickables[i].image.color = new Color(0.7f,0.5f,0.3f,0.5f);

                qo.onClose = EndStage;
                break;
            }
        }
    }

    private void ExitSelectingObject()
    {
        Destroy(gameObject);
    }
}