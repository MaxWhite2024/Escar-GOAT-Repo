using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Serialization;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] RectTransform dialogueBox;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] private float scoreMilestionDialogueCooldownInSeconds = 30;
    [FormerlySerializedAs("startingDialogueSetSo")] [SerializeField] DialogueSetSO startingDialogueSet;
    [FormerlySerializedAs("scoreMilestoneDialogueSetSo")] [SerializeField] DialogueSetSO scoreMilestoneDialogueSet;
    [FormerlySerializedAs("damageTakenDialogueSetSo")] [SerializeField] DialogueSetSO damageTakenDialogueSet;

    private Vector2 dialogueBoxEndPos;
    bool isDialogueBeingDisplayed = false;
    private bool canScoreMilestoneDialogueBeDisplayed = true;
    
    private void OnEnable()
    {
        PlayerStats.onNewScoreMilestone.AddListener(() =>
        {
            if (canScoreMilestoneDialogueBeDisplayed)
            {
                //DisplayDialogue(scoreMilestoneDialogueSet);
                StartCoroutine(DisplayDialogueCoroutine(scoreMilestoneDialogueSet));
                StartCoroutine(ScoreMilestoneDialogueCooldownCoroutine());
            }
        });
        
        PlayerStats.onPlayerDamageTaken.AddListener(() =>StartCoroutine(DisplayDialogueCoroutine(damageTakenDialogueSet)));
        dialogueBoxEndPos = dialogueBox.anchoredPosition;
        dialogueBox.gameObject.SetActive(false);
        StartCoroutine(DisplayDialogueCoroutine(startingDialogueSet));
    }
    
    private void OnDisable()
    {
        PlayerStats.onNewScoreMilestone.RemoveAllListeners();
        PlayerStats.onPlayerDamageTaken.RemoveAllListeners();
    }

    public void DisplayDialogue(DialogueSetSO dialogueSet)
    {
        if (isDialogueBeingDisplayed)
        {
            return;
        }
        
        int dialogueIndex = UnityEngine.Random.Range(0, dialogueSet.dialogueGroups.Length);

        dialogueBox.anchoredPosition = new Vector2(dialogueBoxEndPos.x, -dialogueBox.sizeDelta.y);
        dialogueBox.gameObject.SetActive(true);
        OpenDialogueBox();

        Sequence fullDialogueSequence = DOTween.Sequence();

        for (int i = 0; i < dialogueSet.dialogueGroups[dialogueIndex].dialogueLines.Length; i++)
        {
            string textToDisplay = dialogueSet.dialogueGroups[dialogueIndex].dialogueLines[i];

            fullDialogueSequence.AppendCallback(() => {
                DisplayDialogueLine(textToDisplay); 
            });

            fullDialogueSequence.AppendInterval(4);
        }

        fullDialogueSequence.AppendCallback(CloseDialogueBox);
    }    
    public IEnumerator DisplayDialogueCoroutine(DialogueSetSO dialogueSet)
    {
        if (isDialogueBeingDisplayed)
        {
            yield break;
        }
        
        int dialogueIndex = UnityEngine.Random.Range(0, dialogueSet.dialogueGroups.Length);

        dialogueBox.anchoredPosition = new Vector2(dialogueBoxEndPos.x, -dialogueBox.sizeDelta.y);
        dialogueBox.gameObject.SetActive(true);
        OpenDialogueBox();

        Sequence fullDialogueSequence = DOTween.Sequence();

        for (int i = 0; i < dialogueSet.dialogueGroups[dialogueIndex].dialogueLines.Length; i++)
        {
            string textToDisplay = dialogueSet.dialogueGroups[dialogueIndex].dialogueLines[i];

            fullDialogueSequence.AppendCallback(() => {
                StartCoroutine(DisplayDialogueLineCoroutine(textToDisplay)); 
            });

            fullDialogueSequence.AppendInterval(4);
        }

        fullDialogueSequence.AppendCallback(CloseDialogueBox);
        
        yield break;
    }

    private void DisplayDialogueLine(string textToDisplay)
    {
        dialogueText.text = textToDisplay;

        DOTweenTMPAnimator textAnimator = new DOTweenTMPAnimator(dialogueText);

        for (int i = 0; i < textAnimator.textInfo.characterCount; ++i)
        {
            textAnimator.SetCharColor(i, new Color(0, 1, 1, 0));
            textAnimator.SetCharRotation(i, new Vector3(0, 0, 270));
            textAnimator.SetCharOffset(i, new Vector3(100, 0, 0));
        }

        Sequence dialogueLineSequence = DOTween.Sequence();
        for (int i = 0; i < textAnimator.textInfo.characterCount; ++i)
        {
            //Escape loop if text is not visible
            if (!textAnimator.textInfo.characterInfo[i].isVisible)
            {
                continue;
            }

            //Animate in the text
            dialogueLineSequence.Insert(0.33f + i * 0.02f,
                textAnimator.DOColorChar(i, Color.white, 0.5f));
            dialogueLineSequence.Join(textAnimator.DORotateChar(i, Vector3.zero, 0.5f, RotateMode.Fast));
            dialogueLineSequence.Join(textAnimator.DOOffsetChar(i, Vector3.zero, 0.5f));
        }
    }    
    
    private IEnumerator DisplayDialogueLineCoroutine(string textToDisplay)
    {
        dialogueText.text = textToDisplay;

        DOTweenTMPAnimator textAnimator = new DOTweenTMPAnimator(dialogueText);

        for (int i = 0; i < textAnimator.textInfo.characterCount; ++i)
        {
            textAnimator.SetCharColor(i, new Color(0, 1, 1, 0));
            textAnimator.SetCharRotation(i, new Vector3(0, 0, 270));
            textAnimator.SetCharOffset(i, new Vector3(100, 0, 0));
        }

        Sequence dialogueLineSequence = DOTween.Sequence();
        for (int i = 0; i < textAnimator.textInfo.characterCount; ++i)
        {
            //Escape loop if text is not visible
            if (!textAnimator.textInfo.characterInfo[i].isVisible)
            {
                continue;
            }

            //Animate in the text
            dialogueLineSequence.Insert(0.33f + i * 0.02f,
                textAnimator.DOColorChar(i, Color.white, 0.5f));
            dialogueLineSequence.Join(textAnimator.DORotateChar(i, Vector3.zero, 0.5f, RotateMode.Fast));
            dialogueLineSequence.Join(textAnimator.DOOffsetChar(i, Vector3.zero, 0.5f));
        }

        yield break;
    }

    public void OpenDialogueBox()
    {
        isDialogueBeingDisplayed = true;
        dialogueBox.DOAnchorPos(dialogueBoxEndPos, 0.66f, false).SetEase(Ease.OutBack);
    }

    public void CloseDialogueBox()
    {
        dialogueBox.DOAnchorPos(new Vector2(dialogueBoxEndPos.x, -dialogueBox.sizeDelta.y),
            0.66f, false).SetEase(Ease.InBack).OnComplete(() =>
        {
            isDialogueBeingDisplayed = false;
            dialogueBox.gameObject.SetActive(false);
        });
    }

    IEnumerator ScoreMilestoneDialogueCooldownCoroutine()
    {
        canScoreMilestoneDialogueBeDisplayed = false;

        yield return new WaitForSeconds(scoreMilestionDialogueCooldownInSeconds);
        
        canScoreMilestoneDialogueBeDisplayed = true;
    }
    
}