using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Rigidbody2D;
    public CapsuleCollider2D CapsuleCollider2D;

    public PlayerUI PlayerUI;
    
    
    void LoadComponents()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        CapsuleCollider2D = GetComponent<CapsuleCollider2D>();

        PlayerUI = FindObjectOfType<PlayerUI>();
    }

    private void Awake()
    {
        LoadComponents();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{collision.gameObject.name}");

            // 플레이어의 체력이 떨어지는 로직
            // 체력이 <=0 같을 때 게임을 메인 메뉴로 이동할지, 게임을 종료할지 선택할 수 있는 UI를 띄운다.

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            // 체력 감소 코드를 먼저 실행
            player.currentHp = player.currentHp - 1;
            PlayerUI.SliderValueChange(player.currentHp);
            // 게임 오버인지 체크 하는 로직
            if (player.currentHp <= 0)
            {
                MainController.instance.GameOver();
            }

            
        }
    }

    
}
