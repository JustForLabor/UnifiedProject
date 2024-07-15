using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorSequence : MonoBehaviour
{
    [SerializeField] float rotationAmount;
    [SerializeField] GameObject door;
    private bool isDoorOpened = false;
    private Vector3 originRotation;
    private Vector3 goalRotation;

    private void Start()
    {
        originRotation = door.transform.rotation.eulerAngles;    
    }

    private void Update()
    {
        Debug.DrawRay(door.transform.position, Vector3.right, Color.cyan, -1);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            DoorOpen(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            DoorClose();
        }
    }

    private void DoorOpen(GameObject player)
    {
        if (isDoorOpened == false)
        {
            Vector3 toPlayer = player.transform.position -  door.transform.position;
            float dotProduct = Vector3.Dot(door.transform.right, toPlayer);
            Vector3 goalRotation;

            Debug.Log(dotProduct);

            if (dotProduct > 0) // 플레이어가 문 앞일 때
            {
                goalRotation = originRotation + new Vector3(0, -rotationAmount, 0);
                door.transform.DORotate(goalRotation, 1);
                isDoorOpened = true;
            }
            else // 플레이어가 문 뒤일 때
            {
                goalRotation = originRotation + new Vector3(0, +rotationAmount, 0);
                door.transform.DORotate(goalRotation, 1);
                isDoorOpened = true;
            }
        }
    }

    private void DoorClose()
    {
        door.transform.DORotate(originRotation, 1);
        isDoorOpened = false;
    }
}
