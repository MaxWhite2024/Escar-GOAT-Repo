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
        //dialogueText.text = "";

        DOTweenTMPAnimator textAnimator = new DOTweenTMPAnimator(dialogueText);

        Sequence dialogueSequence = DOTween.Sequence();
        dialogueSequence.Append(dialogueBox.DOAnchorPos(dialogueBoxEndPos, 0.66f, false).SetEase(Ease.OutBack));

        //Vector3 currCharOffset = textAnimator.GetCharOffset(0);
        //dialogueSequence.Join(textAnimator.DOPunchCharOffset(0, currCharOffset + new Vector3(0, 30, 0), 0.5f));

        for (int i = 0; i < textAnimator.textInfo.characterCount; ++i)
        {
            textAnimator.SetCharColor(i, new Color(0, 1, 1, 0));
            textAnimator.SetCharRotation(i, new Vector3(0, 0, 270));
            textAnimator.SetCharOffset(i, new Vector3(100, 0, 0));
        }


        for (int i = 0; i < textAnimator.textInfo.characterCount; ++i)
        {
            if (!textAnimator.textInfo.characterInfo[i].isVisible) continue;
            Vector3 currCharOffset = textAnimator.GetCharOffset(i);
            dialogueSequence.Insert(0.33f + i * 0.02f,
                textAnimator.DOColorChar(i, Color.white, 0.5f));
            dialogueSequence.Join(textAnimator.DORotateChar(i, Vector3.zero, 0.5f, RotateMode.Fast));
            dialogueSequence.Join(textAnimator.DOOffsetChar(i, Vector3.zero, 0.5f));
        }

        dialogueSequence.AppendInterval(3);
        dialogueSequence.Append(dialogueBox.DOAnchorPos(new Vector2(dialogueBoxEndPos.x, -dialogueBox.sizeDelta.y),
            0.66f, false).SetEase(Ease.InBack).OnComplete(() => dialogueBox.gameObject.SetActive(false)));
    }
}