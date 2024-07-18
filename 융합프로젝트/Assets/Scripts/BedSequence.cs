using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System;

public class BedSequence : MonoBehaviour // 침대, TV 동작
{
    public Vector3 fromAngle; // 초기 회전
    public Vector3 toAngle; // 목표 회전
    [SerializeField] GameObject bedComponent; // 침대 회전 오브젝트
    [SerializeField] GameObject television; // TV 오브젝트

    public CloakSequence cloakSequence;

    private void Start()
    {
        cloakSequence.onDay += BedUp;
        cloakSequence.onDay += televisionUp;
        
        cloakSequence.onNight += BedDown;
        cloakSequence.onNight += televisionDown;
    }

    public void BedUp(object sender, EventArgs e)
    {
        bedComponent.transform.DORotate(toAngle, 3);
    }

    public void BedDown(object sender, EventArgs e)
    {
        bedComponent.transform.DORotate(fromAngle, 3);
    }

    public void televisionUp(object sender, EventArgs e)
    {
        Transform tf = television.transform;
        tf.DOMove(new Vector3(25.5f,3.5f,22f), 3);       
    }

    public void televisionDown(object sender, EventArgs e)
    {
        Transform tf = television.transform;
        tf.DOMove(new Vector3(25.5f,0.5f,22f), 3);
    }
}
