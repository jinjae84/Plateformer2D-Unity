using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainController : MonoBehaviour
{
    public static MainController instance;

    public GameObject GameOverPanel;

    [Header("Score")]
    public TextMeshProUGUI CurrentScore;
    public TextMeshProUGUI BestScore;
    private float score;

    [Header("Level")]
    public TextMeshProUGUI Level;

    private void Update()
    {
        score = GameManager.Instance.score;
        UpdateGUIText();
    }

    private void UpdateGUIText()
    {
        CurrentScore.text = $"���� ���� : {GameManager.Instance.score}";
        Level.text = $"���� ���� : {GameManager.Instance.ReturnCurrentDifficulty}";
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        if (score > PlayerPrefs.GetFloat(GameData.BestScore))
        {
            PlayerPrefs.SetFloat(GameData.BestScore, score);
            BestScore.text = $"�ְ� ���� : {GameManager.Instance.score}";
        }
        else
        {
            BestScore.text=$"�ְ� ���� : {PlayerPrefs.GetFloat(GameData.BestScore)}";
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    
}
