using System;
using UnityEditor;
using UnityEngine;

// ���� ������ public private protected
public class PlayerController : MonoBehaviour
{
    // Start, Update ����Ƽ �̺�Ʈ �Լ��� ���� �̸��� �ִ��� ����
    // ���� �̸��� ������? ����Ƽ���� ���س��� ���� �ð��� �� �Լ��� ����

    // Start is called before the first frame update
    // ù �������� �ҷ����� ���� (�ѹ�) �����Ѵ�. �ѹ���!

    // �ӵ�, ����
    [Header("�̵�")]
    public float movespeed = 7f;    // ĳ������ �̵� �ӵ�
    public float JumpForce = 15f;
    private float moveInput;   // �÷��̾��� ���� �� ��ǲ ������ ����

    public Transform startTransform;  // ĳ���Ͱ� ������ ��ġ
    public Rigidbody2D rigidbody2D;   // ����(��ü) ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded;           // true : ĳ���Ͱ� ���� �� �� �ִ� ����, false : ���� ����
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    [Header("Flip")]
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private int facingDirection = 1;
    [Header("������")]
    public bool isTouchingWall;
    public bool isWallSliding;
    public bool isWallJumping;
    public float wallJumpFoce = 8f;
    public float wallSlideSpeed = 1f;
    public float wallCheckDistance = 0.1f;
    public LayerMask wallLayer;

    public Animator animator;
    private bool isMove;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log("Hello Unity");
        // ���� �� ��ġ <= ���ο� x, y �����ϴ� ������ Ÿ��( ���� x��ǥ, 10 y��ǥ)
        // transform.position = new Vector2(transform.position.x, 10);

        // ���� �� ��ġ�� startTransform���� ����
        InitializePlayerStatus();

    }

    void InitializePlayerStatus()
    {
        transform.position = startTransform.position;
        rigidbody2D.velocity = Vector2.zero;
        facingRight = true;
        spriteRenderer.flipX = false;
    }

    // Update is called once per frame
    // 1 ������ ���� ȣ��ȴ�. - �ݺ������� ����
    void Update()
    {
        // �Լ� �̸� �տ� ���콺Ŀ���� �ΰ� Ctrl + R + R
        HandleAnimation();
        CollisionCheck();
        HandleInput();
        HandleFlip();
        Move();

        FallDownCheck();

    }

    private void FallDownCheck()
    {
        // y�� ���̰� Ư�� �������� ���� �� ������ ������ �����Ѵ�.
        if(transform.position.y < -16)
        {
            InitializePlayerStatus();
        }
    }

    private void HandleAnimation()
    {
        // rigidbody.velocity : ���� rigidbody �ӵ� = 0 �������� �ʴ� ����, !=0 �����̰� �ִ� ����
        isMove = rigidbody2D.velocity.x != 0;  //   1 != 0 ? true
        animator.SetBool("isMove", isMove);
        animator.SetBool("isGrounded", isGrounded);
        // SetFloat �Լ��� ���ؼ� y�ִ��� �� 1�� ��ȯ... y �ּ��� �� -1�� ��ȯ
        // ���� Ű�� ������, ���������� y ���� ����, �߷¿� ���ؼ� ���� y �ӵ� -���� �������̴ϴ�.
        animator.SetFloat("yVelocity", rigidbody2D.velocity.y);
    }

    /// <summary>
    /// ������ �� �� ������ �ƴ��� üũ �ϴ��� ��� -> Collider Check
    /// </summary>
    private void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
    }
    /// <summary>
    /// �÷��̾��� �Է� ���� �޾ƿ;� �մϴ�. a,d Ű���� �� �� Ű�� ������ �� -1 ~ 1 ��ȯ�ϴ� Ŭ����
    /// </summary>
    private void HandleInput()
    {
        moveInput = Input.GetAxis("Horizontal");

        JumpButton();
    }

    private void HandleFlip()
    {
        // ������ �������� �ٶ󺸰� ���� ��
        if(facingRight && moveInput < 0)
        {
            Flip();
        }
        // ���� �������� �ٶ󺸰� ���� ��
        else if(!facingRight && moveInput > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        spriteRenderer.flipX = !facingRight;
    }

    private void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }
    }
    /// <summary>
    /// ���� : Y Position _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ�ȴ�.
    /// </summary>
    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(movespeed * moveInput, rigidbody2D.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }

}