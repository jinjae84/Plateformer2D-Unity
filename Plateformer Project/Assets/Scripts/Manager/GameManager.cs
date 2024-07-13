using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int difficulty;  // 0 : 이지, 1 : 노말, 2 : 하드

    public float score;
    

    private void Update()
    {
        score += Time.deltaTime * (difficulty+1);

        if (Input.GetKeyDown(KeyCode.S))
        {
            if(score > PlayerPrefs.GetFloat(GameData.BestScore))
            PlayerPrefs.SetFloat(GameData.BestScore, score);
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(GameData.GameDifficulty))
        {
            difficulty = PlayerPrefs.GetInt(GameData.GameDifficulty);
        }
        
    }

    public string ReturnCurrentDifficulty()
    {
        string name = null;

        switch (difficulty)
        {
            case 0:
                name = "이지";
                break;
            case 1:
                name = "노말";
                break;
            case 2:
                name = "하드";
                break;
            default:
                name = $"키 : {difficulty} 존재하지 않는 키 값입니다.";
                break;
        }
        
        return $"선택한 난이도 : {name}";
    }

    public void SaveGameDifficulty()
    {
        PlayerPrefs.SetInt(GameData.GameDifficulty, difficulty); // GameDifficulty 이름으로. difficulty변수(정수) 저장.
        
    }

    public void SaveBestScore()
    {
        PlayerPrefs.SetFloat(GameData.BestScore, score);
    }
}
