using UnityEngine;
using UnityEngine.UI;

public class QuizButtonObject : MonoBehaviour
{
    public QuizObject Parent;
    public bool Selected;
    public Image Bg;
    public GameObject Checkmark;

    public void Toggle()
    {
        if (Parent.NoMultipleChoice)
        {
            Parent.UnselectAllButtons();
        }
        Selected = !Selected;
        UpdateUI();
        Parent.UpdateButtons();
    }

    public void UpdateUI()
    {
        Checkmark.SetActive(Selected);
    }

    public void SetCorrect(bool correct)
    {
        if (Selected && correct)
        {
            Bg.color = Color.green;
        }
        else if (Selected && !correct)
        {
            Bg.color = Color.gray;
        }
        else if (!Selected && correct)
        {
            Bg.color = Color.yellow;
        }
        
    }
}
