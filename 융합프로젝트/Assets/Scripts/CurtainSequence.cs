using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using System;

public class CurtainSequence : MonoBehaviour // 커튼 동작
{
    public RainSequence rainSequence; // RainSequence 스크립트 할당
    public GameObject curtain;

    private Vector3 originPosition;
    private Vector3 originScale;

    private Vector3 goalPosition = new Vector3(-3.35f, 0.1f ,0);
    private Vector3 goalScale = new Vector3(13, 6, 0.1f);

    private void Start()
    {
        rainSequence.onRaining += shutCurtain; // 비가 올 때 이벤트 구독
        rainSequence.offRaining += wideCurtain; // 날이 갤 때 이벤트 구독

        originPosition = curtain.transform.localPosition;
        originScale = curtain.transform.lossyScale;

        Debug.Log(originScale);

        wideCurtain(null, null);
    }

    private void shutCurtain(object sender, EventArgs eventArgs)
    {
        curtain.transform.DOLocalMove(goalPosition, 2);
        curtain.transform.DOScale(goalScale, 2);
    }

    private void wideCurtain(object sender, EventArgs eventArgs)
    {
        curtain.transform.DOLocalMove(originPosition, 2);
        curtain.transform.DOScale(originScale, 2);
    }
}
