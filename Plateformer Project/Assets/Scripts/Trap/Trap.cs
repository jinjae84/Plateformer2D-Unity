using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 충돌하기 위해서는 두 물체 중 한 물체는 Rigidbody(2D)를 컴포넌트로 소유해야하며,
// 두 물체 전부다 Collider를 갖고 있어야 한다.
// 플레이어와 충돌하면 충돌했을 시점에 이벤트(기능을) 작동한다.
public class Trap : MonoBehaviour
{
    // 충돌 이벤트를 작성할 때, 모든 오브젝트를 대상으로 작성할 일은 거의 없다.
    // 성능 적인 면에서도 비효율적입니다.
    // 충돌 이벤트가 특정 대상만 작동하도록 태그(꼬리표) 달아준다. - 개별 오브젝트 한 개씩 태그 지정.
    // Tag - 낱개의 충돌 이벤트에서 사용
    // Layer - 이벤트를 작동 할 때 특정 대상만 분류해주는 역할.
    // 그룹 단위의 구별을 할 때 사용한다.
    // Collider 2D이고 Rigidbody 2D 여야한다. 필수조건

    protected bool isWorking = false;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어 태그를 갖고 있는가?
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Player가 함정에 피격 당함. (Collision 충돌).");
        }
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player가 함정에 피격 당함. (Trigger 충돌).");
        }
        
    }
}
