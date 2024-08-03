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

            // �÷��̾��� ü���� �������� ����
            // ü���� <=0 ���� �� ������ ���� �޴��� �̵�����, ������ �������� ������ �� �ִ� UI�� ����.

            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            // ü�� ���� �ڵ带 ���� ����
            player.currentHp = player.currentHp - 1;
            PlayerUI.SliderValueChange(player.currentHp);
            // ���� �������� üũ �ϴ� ����
            if (player.currentHp <= 0)
            {
                MainController.instance.GameOver();
            }

            
        }
    }

    
}