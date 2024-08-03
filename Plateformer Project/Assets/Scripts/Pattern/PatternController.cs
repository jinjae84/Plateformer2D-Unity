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

    // 0 ~ 9 .. ���������� ����Ǵ� �ڵ� ����.
    // 0 ~ 9 �������� �Ѱ��� ����ǵ��� �ϰ� ���� �� �ִ�.

    public void ChangePattern()
    {
        currentPattern = patterns[patternIndex]; // ����s �迭�� ����ִ� ���ӿ�����Ʈ�� ������ �����Ѵ�.
        currentPattern.gameObject.SetActive(true);

        patternIndex++;

        if(patternIndex >= patterns.Length)
        {
            patternIndex = 0;
        }

    }
}
