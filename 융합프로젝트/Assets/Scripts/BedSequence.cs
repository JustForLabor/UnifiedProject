using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class BedSequence : MonoBehaviour
{
    public Vector3 fromAngle; // 초기 회전
    public Vector3 toAngle; // 목표 회전
    [SerializeField] GameObject bedComponent; // 침대 회전 오브젝트
    [SerializeField] GameObject television; // TV 오브젝트
    private bool isBedRotated = false;
    private bool isTVMoved = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BedMovement();
            televisionMovement();
        }  
    }

    public void BedMovement()
    {
        if (isBedRotated == false)
            {
                bedComponent.transform.DORotate(toAngle, 3, RotateMode.LocalAxisAdd);
                isBedRotated = !isBedRotated;
            }

            else
            {
                bedComponent.transform.DORotate(fromAngle, 3);
                isBedRotated = !isBedRotated;
            }
    }

    public void televisionMovement()
    {
        Transform tf = television.transform;
        if (isTVMoved == false)
        {
            tf.DOMove(new Vector3(25.5f,3.5f,22f), 3);
            isTVMoved = !isTVMoved;
        }
        else
        {
            tf.DOMove(new Vector3(25.5f,0.5f,22f), 3);
            isTVMoved = !isTVMoved;
        }
        
    }
}
