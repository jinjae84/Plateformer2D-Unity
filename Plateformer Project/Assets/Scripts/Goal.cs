using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject goalObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 목표 지점에 도착했습니다.");

            goalObject.SetActive(true);
            if(goalObject.GetComponent<TMP_Text>() != null )
            {
                TMP_Text goalText = goalObject.GetComponent<TMP_Text>();
                goalText.text = "게임 클리어!";
            }
            
        }
    }

}
