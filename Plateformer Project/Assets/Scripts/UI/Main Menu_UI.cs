using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI currentScroeText;





    private void Update()
    {
        levelText.text = GameManager.Instance.ReturnCurrentDifficulty();
        currentScroeText.text =$"���� ���� : {GameManager.Instance.score}";
        bestScoreText.text = $"�ְ� ���� : {PlayerPrefs.GetFloat(GameData.BestScore)}";
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchMenuTo(GameObject uiMenu) // ��ư�� ���� ��ų �Լ� �̸� (MainMenu_UI�ݰ�, ���ϴ� UI ����)
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false); // MainMenu ������ �ڽĵ��� ���� ��Ȱ��ȭ ���Ѷ�.
        }

        uiMenu.SetActive(true); // ��� ������Ʈ�� Ȱ��ȭ ���Ѷ�.
    }

    public void ReturnCurrentDifficulty()
    {
        GameManager.Instance.ReturnCurrentDifficulty();
    }
    public void SaveGameDifficulty()
    {
        GameManager.Instance.SaveGameDifficulty();
    }
}
