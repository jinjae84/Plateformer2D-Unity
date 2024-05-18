using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTest : MonoBehaviour
{

    public GameObject TestObject;
    // NullRefence에러. 변수에 데이터가 없어서 발생하는 에러다. 해결하기 위해서 데이터 초기화.
    // 생성(초기화) 이벤트 함수에 데이터 변수를 할당하는 작업.
    // Awake -> OnEnable -> Start
    private void Awake()
    {
        Debug.Log("Awake 실행");
        TestObject = new GameObject();
    }

    private void Start()
    {
        Debug.Log("Start 실행");
        TestObject.SetActive(false);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable 실행");
    }

    private void Update()
    {
        Debug.Log("Update 실행");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate 실행");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate 실행");
    }
}
