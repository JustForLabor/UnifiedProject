using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class RainSequence : MonoBehaviour
{
    public KeyCode activateKey; // 작동 키
    public ParticleSystem rainParticle; // 비 파티클
    private bool isRainActivated = false; // 비 활성화 여부
    public event EventHandler onRaining; // 비 활성화 시 송출되는 이벤트
    public event EventHandler offRaining; // 비 비활성화 시 송출되는 이벤트

    void Update()
    {
        if (Input.GetKeyDown(activateKey))
        {
            ToggleRain();
        }
    }

    void ToggleRain() // 비 활성화 / 비활성화
    {
        if (isRainActivated == false)
        {
            rainParticle.Play();
            isRainActivated = true;
            InvokeEvent(onRaining);
        }
        else
        {
            rainParticle.Stop();
            isRainActivated = false;
            InvokeEvent(offRaining);
        }
    }

    private void InvokeEvent(EventHandler eventHandler) // 이벤트 호출 함수
    {
        if (eventHandler != null)
        {
            eventHandler.Invoke(this, EventArgs.Empty);
        }
    }
}
