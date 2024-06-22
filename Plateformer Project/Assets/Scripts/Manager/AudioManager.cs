using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    // ������ҽ� ������Ʈ�� �߰����ּ���.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    // ���� �����ϰ� �ִ� BGMIndex ��ȣ
    public int bgmIndex = 0;
    public int sfxIndex = 0;
    // �̺�Ʈ �Լ� Start , Update ���ǹ�

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void Start()
    {
        //PlayRandomBGM();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayRandomBGM();
        }                

        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayRandomSFX();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerSet();
        }
    }

    private void PlayerSet()
    {
        throw new System.NotImplementedException();
    }

    public void PlayBGM(int bgmIndex) // bgmIndex�� �ش��ϴ� BGM�� �����ϴ� �Լ�
    {
        bgm[bgmIndex].Play();
    }

    private void StopBGM()
    {
        for(int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }

        //foreach(var sound in bgm)
        //{
        //    sound.Stop();
        //}
    }

    public void PlayRandomBGM()
    {
        // ������ ����� BGM�� �����.
        StopBGM();
        // bgmIndex�� ������ ���� ������, �� ���� �����ϸ�ȴ�.
        int randomIndex  = Random.Range(0, bgm.Length);
        PlayBGM(randomIndex);
    }

    public void PlaySFX(int sfxIndex)
    {
        if(sfxIndex < sfx.Length) // sfx.Length ū ���� ������ �迭�ʰ� ������ �߻��Ѵ�.
        {
            sfx[sfxIndex].pitch = Random.Range(0.85f, 1.5f);
            sfx[sfxIndex].Play();
        }
    }

    private void StopSFX()
    {
        for(int i = 0;i < sfx.Length; i++)
        {
            sfx[i].Stop();
        }

    }

    public void PlayRandomSFX()
    {
        StopSFX();
        int randomIndex = Random.Range(0, sfx.Length);
        PlaySFX(randomIndex);
    }
}
