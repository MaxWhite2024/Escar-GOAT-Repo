using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] RectTransform dialogueBox;
    [SerializeField] TMP_Text dialogueText;

    private Vector2 dialogueBoxEndPos;

    public enum DialogueType
    {
        HighScore
    }

    private void Start()
    {
        dialogueBoxEndPos = dialogueBox.anchoredPosition;
        //DisplayDialogue(DialogueType.HighScore);
    }

    private void OnEnable()
    {
        dialogueBoxEndPos = dialogueBox.anchoredPosition;
        dialogueBox.gameObject.SetActive(false);
        DisplayDialogue(DialogueType.HighScore);
    }

    public void DisplayDialogue(DialogueType dialogueType)
    {
        dialogueBox.anchoredPosition = new Vector2(dialogueBoxEndPos.x, -dialogueBox.sizeDelta.y);
        dialogueBox.gameObject.SetActive(true);

        string textToDisplay = dialogueText.text;
        dialogueText.text = "";

        DOTweenTMPAnimator textAnimator = new DOTweenTMPAnimator(dialogueText);

        Sequence dialogueSequence = DOTween.Sequence();
        dialogueSequence.Append(dialogueBox.DOAnchorPos(dialogueBoxEndPos, 0.66f, false).SetEase(Ease.OutBack));

        dialogueSequence.Join(dialogueText.DOText(textToDisplay, 1));
    }
}