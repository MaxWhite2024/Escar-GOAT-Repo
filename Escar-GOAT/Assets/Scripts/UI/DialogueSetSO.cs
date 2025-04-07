using System;
using UnityEngine;

[Serializable]
public class DialogueGroup
{
    public string[] dialogueLines;
}

[CreateAssetMenu(fileName = "DialogueSet", menuName = "new DialogueSet")]
public class DialogueSetSO : ScriptableObject
{
    
    public DialogueGroup[] dialogueGroups;
}
