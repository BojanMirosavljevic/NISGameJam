using TMPro;
using UnityEngine;

public class MessageObject : MonoBehaviour
{
    [SerializeField] private RectTransform Holder;
    [SerializeField] private RectTransform Message;
    [SerializeField] private TextMeshProUGUI Text;

    public void Init(DialogueText message)
    {
        Holder.sizeDelta = new Vector2(Holder.sizeDelta.x, message.Height);
        Message.sizeDelta = new Vector2(message.Width, message.Height);

        Text.text = message.Text;
    }
}
