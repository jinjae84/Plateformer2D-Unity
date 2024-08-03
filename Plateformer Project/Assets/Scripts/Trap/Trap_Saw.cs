using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Trap_Saw : Trap
{
    public Animator anim;
    public Transform[] movePositions;        // ��Ϲ����� �̵��� ����
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

    private void Update() // ��ǻ�� ���� ������ �޴´�.
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
        // ������� 0.0016 ��
        transform.position = Vector3.MoveTowards(transform.position, movePositions[moveIndex].position, speed * Time.deltaTime);
        
        // ���ǹ� - ������ ��ǥ�� �������� �����ߴ���?
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
        // ���� ��ǥ ������ ������.. move Index = 0.
        

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
