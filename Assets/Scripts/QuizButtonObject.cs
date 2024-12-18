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
            Bg.color = new Color(0.3170529f, 0.735849f, 0.239498f, 1f);
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
