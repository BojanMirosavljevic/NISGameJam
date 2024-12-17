using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizObject : MonoBehaviour
{
    public QuizCorrectSelection CorrectSelection;
    public bool Mandatory;

    public bool NoMultipleChoice;

    public Button Button1;
    public Button Button2;

    public QuizButtonObject QuizButton1;
    public QuizButtonObject QuizButton2;

    public Button ConfirmChoice;

    public GameObject CorrectMessage;
    public GameObject IncorrectMessage;

    public Button NextButton;

    public Action onClose;

    private void Start()
    {
        Button1.onClick.AddListener(QuizButton1.Toggle);
        Button2.onClick.AddListener(QuizButton2.Toggle);

        ConfirmChoice.onClick.AddListener(Confirm);
    }

    public void UnselectAllButtons()
    {
        if (QuizButton1.Selected)
        {
            QuizButton1.Selected = false;
            QuizButton1.UpdateUI();
        }
        if (QuizButton2.Selected)
        {
            QuizButton2.Selected = false;
            QuizButton2.UpdateUI();
        }
    }

    public void UpdateButtons()
    {
        ConfirmChoice.interactable = QuizButton1.Selected || QuizButton2.Selected;
    }

    private void Confirm()
    {
        bool correct = false;

        if (CorrectSelection == QuizCorrectSelection.Both)
        {
            QuizButton1.SetCorrect(true);
            QuizButton2.SetCorrect(true);

            correct = QuizButton1.Selected && QuizButton2.Selected;
        }
        else if (CorrectSelection == QuizCorrectSelection.Left)
        {
            QuizButton1.SetCorrect(true);
            QuizButton2.SetCorrect(false);

            correct = QuizButton1.Selected && !QuizButton2.Selected;
        }
        else if (CorrectSelection == QuizCorrectSelection.Right)
        {
            QuizButton1.SetCorrect(false);
            QuizButton2.SetCorrect(true);

            correct = !QuizButton1.Selected && QuizButton2.Selected;
        }
        else if (CorrectSelection == QuizCorrectSelection.Left)
        {
            correct = true;
        }

        CorrectMessage.SetActive(correct);
        IncorrectMessage.SetActive(!correct);

        NextButton.gameObject.SetActive(true);
        NextButton.onClick.AddListener(CloseQuiz);
    }

    private void CloseQuiz()
    {
        onClose?.Invoke();
        Destroy(gameObject);
    }

}

public enum QuizCorrectSelection
{
    None = 0,
    Left = 1,
    Right = 2,
    Both = 3
}