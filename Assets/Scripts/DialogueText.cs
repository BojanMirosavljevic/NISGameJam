using System;

[Serializable]
public class DialogueText
{
    public DialogueDirection Direction;
    public string Text;

    public int Height = 50;
    public int Width = 475;
}

public enum DialogueDirection
{
    Middle,
    Left,
    Right
}