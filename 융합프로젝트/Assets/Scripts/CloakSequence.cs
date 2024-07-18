using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloakSequence : MonoBehaviour // 시계 동작
{
    //------------------------ 이벤트 ------------------------------------
    public EventHandler onDay; // 아침이 될 때 호출
    public EventHandler onNight; // 저녁이 될 때 호출

    private bool isOnDayAvailable = true;
    private bool isOnNightAvailable = true;

    //------------------------ 시계 동작 관련 변수 ------------------------
    enum TimeState {
        AM,
        PM
    }
    public int minute;
    public int hour;
    private TimeState timeState= TimeState.AM; // 오전 오후 대입
    public float timeGap; // 1분 지나가는데 걸리는 시간
    public TextMeshPro timerText;
    public TextMeshPro timeStateText;
    
    void Start()
    {
        StartCoroutine(nameof(CloakWork));
    }

    void Update()
    {
        if (timeState == TimeState.AM && hour == 7 && minute >= 0 && isOnDayAvailable)
        {
            InvokeEvent(onDay);
            StartCoroutine(EventCoolDown(isOnDayAvailable));
        }
        if (timeState == TimeState.PM && hour == 10 && minute >= 0 && isOnNightAvailable)
        {
            InvokeEvent(onNight);
            StartCoroutine(EventCoolDown(isOnNightAvailable));
        }
    }

    private IEnumerator CloakWork() // 시계 동작 코루틴
    {
        while (true)
        {
            yield return new WaitForSeconds(timeGap);
            TimeRefresh();
            TextRefresh();
        }
    }

    private void TimeRefresh() // 시간 설정
    {
        minute += 1;

        if (minute >= 60)
        {
            hour += 1;
            minute -= 60;
        }

        if (hour > 12)
        {
            hour -= 12;

            if (timeState == TimeState.AM)
            {timeState = TimeState.PM;}
            else
            {timeState = TimeState.AM;}
        }
    }

    private void TextRefresh() // 텍스트 설정
    {
        string minuteString;
        string hourString;
        string timeStateString;

        if (minute < 10)
        {
            minuteString = $"0{minute}";
        }
        else
        {
            minuteString = $"{minute}";
        }

        if (hour < 10)
        {
            hourString = $"0{hour}";
        }
        else
        {
            hourString = $"{hour}";
        }

        if (timeState == TimeState.AM)
        {
            timeStateString = "AM";
        }
        else
        {
            timeStateString = "PM";
        }

        timerText.text = $"{hourString} : {minuteString}";
        timeStateText.text = timeStateString;
    }

    private void InvokeEvent(EventHandler eventHandler) // 이벤트 호출 메서드
    {
        if (eventHandler != null)
        {
            eventHandler.Invoke(this, EventArgs.Empty);
        }
    }

    private IEnumerator EventCoolDown(bool isAvailable) // 이벤트 발동 쿨타임
    {
        yield return new WaitForSeconds(3);
        isAvailable = true;
    }
}
