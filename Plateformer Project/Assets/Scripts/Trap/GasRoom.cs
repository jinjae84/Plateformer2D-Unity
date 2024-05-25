using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GasRoom : MonoBehaviour
{
    private bool isGasState = false;                     // 자기장에 들어가 있는 상태라면... 플레이어의 체력을 1씩 감소 시킨다.

    public float checkTime = 2f;
    public float Timer = 0;
    private int PlayerHP = 100;
    private int Damage = 1;

    // Debug.Log (현재 상태를 출력해보는 코드 작성)
    // Tag를 사용해서 Player와 작동할 수 있도록 작성해보세요.

    public bool isStayOn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            isGasState = true;                                  // Player가 알아야 할 필요성이 있겠죠. PlayerController <- 다른 클래스에서 나의 클래스를 어떻게 접근할 것인가?
            Debug.Log($"플레이어가 현재 가스 진입 상태 : {isGasState}");
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStayOn)
        {
            isGasState = false;
            Debug.Log($"플레이어가 현재 가스 진입 상태 : {isGasState}");
        }
    }


    private void Update()// PlayerController의 Update에서 작성하는게 맞지만
    {
        if (isGasState)  // { } 가스 방에 들어갔을 때의 로직 작성한다. 체력을 깎는 로직을 예시로 작성하였다.
        {
            // 단위 시간을 제어 Time.deltaTime
            
            Timer += Time.deltaTime;
            if (Timer >= checkTime)
            {
                Timer = 0;
                PlayerHP = PlayerHP - Damage;
            }
            PlayerHP = PlayerHP - Damage;
            Debug.Log($"플레이어의 현재 체력 : {PlayerHP}");
        }        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isStayOn)
        {
            Debug.Log($"플레이어가 가스 상태이므로 플레이어의 체력을 감소 시키고 있다.");
            PlayerHP = PlayerHP - Damage;
            Debug.Log($"플레이어의 현재 체력 : {PlayerHP}");
        }
    }
}
