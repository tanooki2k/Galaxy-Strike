using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] private string[] timelineTextLines;
    [SerializeField] private TMP_Text dialogueText;

    private int _currentLine;

    public void NextDialogueLine()
    {
        _currentLine++;
        dialogueText.text = timelineTextLines[_currentLine];
    }
}
