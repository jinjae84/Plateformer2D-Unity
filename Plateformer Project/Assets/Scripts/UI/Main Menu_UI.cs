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
        currentScroeText.text =$"현재 점수 : {GameManager.Instance.score}";
        bestScoreText.text = $"최고 점수 : {PlayerPrefs.GetFloat(GameData.BestScore)}";
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchMenuTo(GameObject uiMenu) // 버튼에 연결 시킬 함수 이름 (MainMenu_UI닫고, 원하는 UI 연다)
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false); // MainMenu 하위의 자식들을 전부 비활성화 시켜라.
        }

        uiMenu.SetActive(true); // 대상 오브젝트를 활성화 시켜라.
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
