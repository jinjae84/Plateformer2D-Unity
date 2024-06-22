using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    // 오디오소스 컴포넌트를 추가해주세요.
    public AudioSource[] sfx;
    public AudioSource[] bgm;

    // 현재 실행하고 있는 BGMIndex 번호
    public int bgmIndex = 0;
    public int sfxIndex = 0;
    // 이벤트 함수 Start , Update 조건문

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

    public void PlayBGM(int bgmIndex) // bgmIndex에 해당하는 BGM을 실행하는 함수
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
        // 이전에 실행된 BGM은 멈춰라.
        StopBGM();
        // bgmIndex가 랜덤한 값을 가지고, 그 값을 실행하면된다.
        int randomIndex  = Random.Range(0, bgm.Length);
        PlayBGM(randomIndex);
    }

    public void PlaySFX(int sfxIndex)
    {
        if(sfxIndex < sfx.Length) // sfx.Length 큰 수를 받으면 배열초과 에러가 발생한다.
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
