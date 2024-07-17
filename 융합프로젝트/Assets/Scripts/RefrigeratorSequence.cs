using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RefrigeratorSequence : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    private Vector3 originRotationLeft;
    private Vector3 originRotationRight;


    public float sensorTime; // 문이 자동으로 열리기까지의 대기 시간

    bool isTriggered = false; // 플레이어가 범위 내에 있는지 여부
    bool isDoorOpened = false; // 문이 열렸는지 여부
    float timer; // 플레이어가 대기한 시간을 담을 변수

    private void Start() 
    {
        originRotationLeft = leftDoor.transform.rotation.eulerAngles;
        originRotationRight = rightDoor.transform.rotation.eulerAngles;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            timer = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isTriggered == true && other.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            Debug.Log(timer);

            if (timer > sensorTime)
            {
                DoorOpen();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
        timer = 0f;

        if (isDoorOpened == true)
        {
            DoorClose();
        }
    }

    private void DoorOpen()
    { 
        Vector3 goalRotationLeft = originRotationLeft + new Vector3(0, 130, 0);
        Vector3 goalRotationtRight = originRotationRight + new Vector3(0, -130, 0);

        isDoorOpened = true;

        leftDoor.transform.DORotate(goalRotationLeft, 2);
        rightDoor.transform.DORotate(goalRotationtRight, 2);
    }

    private void DoorClose()
    {
        isDoorOpened = false;

        leftDoor.transform.DORotate(originRotationLeft, 2);
        rightDoor.transform.DORotate(originRotationRight, 2);
    }
}
