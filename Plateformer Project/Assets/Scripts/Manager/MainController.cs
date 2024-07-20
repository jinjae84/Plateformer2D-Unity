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
        CurrentScore.text = $"현재 점수 : {GameManager.Instance.score}";
        Level.text = $"현재 레벨 : {GameManager.Instance.ReturnCurrentDifficulty}";
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
            BestScore.text = $"최고 점수 : {GameManager.Instance.score}";
        }
        else
        {
            BestScore.text=$"최고 점수 : {PlayerPrefs.GetFloat(GameData.BestScore)}";
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
