using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : StaticInstance<GameManager>
{
    private void Start()
    {
        Level level = new Level();
        level.Stages = new List<Stage>();

        Stage introStage = new StageIntro();
        var intro1 = new StepDialogue(); //dialog
        intro1.PersonLeft = "DialoguePlayer";
        intro1.PersonRight = "DialogueHR";
        intro1.Messages = new List<DialogueText>()
        {
            new DialogueText(DialogueDirection.Right, "Dobro došli!\nImali smo nekoliko manjih incidenata, pa smo zamolili za dodatnu inspekciju.\nMolim Vas da obratite pažnju na to da li su sva pravila ispostovana."),
            new DialogueText(DialogueDirection.Left, "Vazi, istrazicu!"),
            new DialogueText(DialogueDirection.Right, "Prvo mozete proci kroz pravilnik za sigurnosnu opremu, izvolite!"),
        };

        var intro2 = new StepShowNotes();
        intro2.Image = "NotesObaveze";

        var intro3 = new StepDialogue(); //dialog
        intro3.PersonLeft = "DialoguePlayer";
        intro3.PersonRight = "DialogueHR";
        intro3.Messages = new List<DialogueText>()
        {
            new DialogueText(DialogueDirection.Right, "Pokazacu Vam sigurnosne kamere radnog mesta od pre par sati.\nMolim Vas obelezite sve nepravilnosti.")
        };

        introStage.Steps.Add(intro1);
        introStage.Steps.Add(intro2);
        introStage.Steps.Add(intro3);

        level.Stages.Add(introStage);
    }
}
