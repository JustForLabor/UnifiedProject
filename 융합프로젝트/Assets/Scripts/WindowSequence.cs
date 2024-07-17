using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class WindowSequence : MonoBehaviour
{
    public RainSequence rainSequence; // RainSequence 스크립트 할당

    public GameObject leftWindow;
    public GameObject rightWindow;

    private Vector3 originRotationLeft; // 초기 회전 상태
    private Vector3 originRotationRight;


    void Start()
    {
        rainSequence = FindObjectOfType<RainSequence>();

        rainSequence.onRaining += closeWindow; // 비가 올 때 이벤트 구독
        rainSequence.offRaining += openWindow; // 날이 갤 때 이벤트 구독

        originRotationLeft = leftWindow.transform.rotation.eulerAngles;
        originRotationRight = rightWindow.transform.rotation.eulerAngles;

        openWindow(null, null);
    }

    private void openWindow(object sender, EventArgs eventArgs)
    {
        Debug.Log("window open");

        Vector3 goalRotationLeft = originRotationLeft + new Vector3(0, -140, 0);
        Vector3 goalRotationRight = originRotationRight + new Vector3(0, 140, 0);

        leftWindow.transform.DORotate(goalRotationLeft, 3);
        rightWindow.transform.DORotate(goalRotationRight, 3);

    }

    private void closeWindow(object sender, EventArgs eventArgs)
    {
        Debug.Log("window close");

        leftWindow.transform.DORotate(originRotationLeft, 3);
        rightWindow.transform.DORotate(originRotationRight, 3);
    }
}
