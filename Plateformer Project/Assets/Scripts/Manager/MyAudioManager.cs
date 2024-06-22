using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioManager : MonoBehaviour
{
    // 오디오소스 컴포넌트를 추가해주세요.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    // 현재 실행하고 있는 BGMIndex 번호
    // 이벤트 함수 Start , Update 조건문

    public void PlayBGM(int bgmIndex)
    {
        bgm[bgmIndex].Play();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaySFX(8);
        }
    }

    private void PlaySFX(int sfxIndex)
    {
        sfx[sfxIndex].Play();
    }
}