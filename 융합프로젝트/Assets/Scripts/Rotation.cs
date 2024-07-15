using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    public Vector3 fromAngle; // 초기 회전
    public Vector3 toAngle; // 목표 회전
    private bool isRotated;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isRotated == false)
            {
                transform.DORotate(toAngle, 3);
                isRotated = !isRotated;
            }

            else
            {
                transform.DORotate(fromAngle, 3);
                isRotated = !isRotated;
            }
        }
    }
}
