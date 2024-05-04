using UnityEditor;
using UnityEngine;

// 접근 지정자 public private protected
public class PlayerController : MonoBehaviour
{
    // Start, Update 유니티 이벤트 함수의 같은 이름이 있는지 조사
    // 같은 이름이 있으면? 유니티에서 정해놓은 실행 시간에 그 함수를 실행

    // Start is called before the first frame update
    // 첫 프레임이 불러지기 전에 (한번) 시작한다. 한번만!

    // 속도, 방향
    [Header("이동")]
    public float movespeed = 7f;    // 캐릭터의 이동 속도
    public float JumpForce = 15f;
    private float moveInput;   // 플레이어의 방향 및 인풋 데이터 저장

    public Transform startTransform;  // 캐릭터가 시작할 위치
    public Rigidbody2D rigidbody2D;   // 물리(강체) 기능을 제어하는 컴포넌트

    [Header("점프")]
    public bool isGrounded;           // true : 캐릭터가 점프 할 수 있는 상태, false : 점프 못함
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Debug.Log("Hello Unity");
        // 현재 내 위치 <= 새로운 x, y 저장하는 데이터 타입( 현재 x좌표, 10 y좌표)
        // transform.position = new Vector2(transform.position.x, 10);

        // 현재 내 위치를 startTransform으로 변경
        transform.position = startTransform.position;

    }

    // Update is called once per frame
    // 1 프레임 마다 호출된다. - 반복적으로 실행
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);

        // 플레이어의 입력 값을 받아와야 합니다.

        moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(movespeed * moveInput, rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 점프 : Y Position _ rigidbody Y velocity를 점프 파워만큼 올려주면된다.
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, JumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundDistance));
    }

}
