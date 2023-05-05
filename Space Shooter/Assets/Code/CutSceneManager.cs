using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class CutSceneManager : MonoBehaviour
{
    public static CutSceneManager Instance;

    public Transform container;
    public Vector3 startPosition;
    public Vector3 middlePosition;
    public Vector3 endPosition;
    public float secondsToMoveToMiddle;
    public float secondsToWaitMiddle;


    public Image portrait;
    public TextMeshProUGUI characterNameTMP;
    public TextMeshProUGUI introBarkTMP;

    public Sprite vicPortrait;
    public Sprite perryPortrait;
    public Sprite beePortrait;
    public Sprite francoisPortrait;
    public Sprite hwhatPortrait;
    public Sprite jimothyPortrait;

    private void Awake()
    {
        Instance = this;
    }

    public void Activate(HUD.CharacterEnum characterEnum, string characterName, string bark)
    {
        if (characterEnum == HUD.CharacterEnum.vic)
        {
            portrait.sprite = vicPortrait;
        }
        else if (characterEnum == HUD.CharacterEnum.captainPerry)
        {
            portrait.sprite = perryPortrait;
        }
        else if (characterEnum == HUD.CharacterEnum.queenBee)
        {
            portrait.sprite = beePortrait;
        }
        else if (characterEnum == HUD.CharacterEnum.francois)
        {
            portrait.sprite = francoisPortrait;
        }
        else if (characterEnum == HUD.CharacterEnum.admiralHwhat)
        {
            portrait.sprite = hwhatPortrait;
        }
        else if (characterEnum == HUD.CharacterEnum.jimothy)
        {
            portrait.sprite = jimothyPortrait;
        }


        Animate();
        characterNameTMP.SetText(characterName);
        introBarkTMP.SetText(bark);
    }

    public void Animate()
    {
        StartCoroutine(AnimateCo());
    }

    private IEnumerator AnimateCo()
    {
        container.localPosition = startPosition;
        container.DOLocalMove(middlePosition, secondsToMoveToMiddle);
        yield return new WaitForSeconds(secondsToMoveToMiddle);
        yield return new WaitForSeconds(secondsToWaitMiddle);
        container.DOLocalMove(endPosition, secondsToMoveToMiddle);
    }
}
