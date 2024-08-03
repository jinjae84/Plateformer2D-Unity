using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    public GameObject[] patterns;

    [Header("Current Pattern Info")]
    public int patternIndex = 0;
    public GameObject currentPattern;

    bool patternStart = false;
    
    void PatternStart()
    {
        
        ChangePattern();
        patternStart = false;

    }

    private void Awake()
    {
        foreach (var pattern in patterns)
        {
            pattern.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        //if(MainController.instance.isGameStart == false) return;

        if (patternStart == true && MainController.instance.isGameStart == true)
        {
            PatternStart();
        }


        if (MainController.instance.isGameStart && currentPattern.activeSelf == false)
        {
            ChangePattern();
        }
    }

    // 0 ~ 9 .. 순차적으로 실행되는 코드 구현.
    // 0 ~ 9 랜덤으로 한개씩 실행되도록 하고 싶을 수 있다.

    public void ChangePattern()
    {
        currentPattern = patterns[patternIndex]; // 패턴s 배열에 담겨있는 게임오브젝트로 패턴을 관리한다.
        currentPattern.gameObject.SetActive(true);

        patternIndex++;

        if(patternIndex >= patterns.Length)
        {
            patternIndex = 0;
        }

    }
}
