using System.Collections.Generic;

public class Level
{
    public List<Stage> Stages;
}

public abstract class Stage
{
    public bool Completed;
    public List<Step> Steps;

    public abstract void Run();
}

public class StageIntro : Stage
{
    public override void Run()
    {
        //run first step
    }
}

public abstract class Step
{
    public string Background;

    public abstract void Show();
}

public class StepDialogue : Step
{
    public string PersonLeft;
    public string PersonRight;
    public List<DialogueText> Messages;

    public override void Show()
    {
        
    }
}

public class DialogueText
{
    public DialogueDirection Direction;
    public string Text;

    public DialogueText(DialogueDirection direction, string text)
    {
        Direction = direction;
        Text = text;
    }
}

public enum DialogueDirection
{
    Middle,
    Left,
    Right
}

public class StepShowNotes : Step
{
    public StepShowNotes()
    {
        Background = "BackgroundNotes";
    }
    public string Image;

    public override void Show()
    {

    }
}

public enum StageType
{
    Confirm,
    Intro,
    Selection,
    Test,
}