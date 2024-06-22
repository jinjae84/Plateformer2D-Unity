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
    public float movespeed = 5f;    // ĳ������ �̵� �ӵ�
    public float JumpForce = 12f;
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
    public float wallJumpForce = 12f;
    public float wallSlideSpeed = 2f;
    public float wallCheckDistance = 0.6f;
    public LayerMask wallLayer;

    public Animator animator;
    private bool isMove;
    

    [SerializeField] ParticleController particleController;

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
        //transform.position = startTransform.position;
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
        
        CheckWallSliding();
        CheckWallJump();

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
        if (Input.GetKeyDown(KeyCode.F))
        {
            particleController.PlayParticle();
        }
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
        Debug.Log("�ٶ󺸴� ����: " + facingDirection);
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
        // ���� ���� ���.
        // SFX �迭�� ��ϵ� ȿ���� ��� ���� 2�� Jump1�� �ش���.
        AudioManager.instance.PlaySFX(2);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
    }

    private void CheckWallSliding()
    {
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, wallLayer);
        isWallSliding = isTouchingWall && !isGrounded && rigidbody2D.velocity.y < 0;

        if (isWallSliding)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -wallSlideSpeed);
            animator.SetBool("WallJump", isWallSliding);
        }
        
    }

    private void CheckWallJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isWallSliding || isTouchingWall))
        {
            Vector2 jumpDirection = Vector2.up;
            if (isWallSliding)
            {
                jumpDirection = new Vector2(-facingDirection, 1).normalized;
            }
            Debug.Log("��������: " + jumpDirection);
            Debug.Log("����Ȯ��: " + facingDirection);
            rigidbody2D.velocity = jumpDirection.normalized * JumpForce;

        }
    }



    private void SetWallJumpingToFalse()
    {
        isWallJumping = false;
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(movespeed * moveInput, rigidbody2D.velocity.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));

        Gizmos.color = Color.blue;
        Vector2 wallCheckStart = transform.position;
        Vector2 wallCheckEnd = wallCheckStart + Vector2.right * facingDirection * wallCheckDistance;
        Gizmos.DrawLine(wallCheckStart, wallCheckEnd);
    }

}
