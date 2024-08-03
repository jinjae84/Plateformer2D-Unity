using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;        // 톱니바퀴가 이동할 변수
    public float speed = 5f;
    public int moveIndex = 0;
    public bool onGoingFoward = true;
    private SpriteRenderer spriteRenderer;
    public bool IsTrapOn = true;
    public float stopTime = 1;

    private void Start()
    {


        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        isWorking = true;
    }

    private void Update() // 컴퓨터 성능 영향을 받는다.
    {
        anim.SetBool("isWorking", isWorking);
        if (IsTrapOn == true)
        {
            MoveTrap();
        }

        
    }
    IEnumerator ComoveTrap()
    {
        IsTrapOn = false;
        yield return new WaitForSeconds(stopTime);
        IsTrapOn = true;
        
    }

    private void MoveTrap()
    {
        // 평균으로 0.0016 값
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed * Time.deltaTime);
        
        // 조건문 - 함정이 목표한 지점까지 도착했는지?
        if(Vector3.Distance(transform.position, movePositions[moveIndex].position) <= 0.1f)
        {
            StartCoroutine(ComoveTrap());

            if (moveIndex == 0)
            {
                Flip(onGoingFoward);
                onGoingFoward = true;
                
            }
            if (onGoingFoward)
                moveIndex++;
            else
                moveIndex--;

            if(moveIndex >= movePositions.Length)
            {
                moveIndex = movePositions.Length - 1;
                onGoingFoward = false;
            }

            
        }
        // 다음 목표 지점이 없으면.. move Index = 0.
        

    }

    private void Flip(bool isFlip)
    {
        spriteRenderer.flipX = isFlip;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
