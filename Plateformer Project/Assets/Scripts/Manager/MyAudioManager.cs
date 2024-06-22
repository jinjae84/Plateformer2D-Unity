using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAudioManager : MonoBehaviour
{
    // ������ҽ� ������Ʈ�� �߰����ּ���.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    // ���� �����ϰ� �ִ� BGMIndex ��ȣ
    // �̺�Ʈ �Լ� Start , Update ���ǹ�

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