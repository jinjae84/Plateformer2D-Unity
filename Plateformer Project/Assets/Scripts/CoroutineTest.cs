using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("그냥 호출");
        StartCoroutine(CoTest()); 
        SubTest();
        Debug.Log("그냥 호출2");
    }

    IEnumerator CoTest()
    {
        Debug.Log("[코루틴] : 01 호출");
        yield return new WaitForSeconds(1);
        Debug.Log("[코루틴] : 02 호출");
        yield return new WaitForSeconds(2);
        Debug.Log("[코루틴] : 03 호출");
    }
    // Update is called once per frame
    void SubTest()
    {
        Debug.Log("[서브 테스트 함수] : 01호출");
        Debug.Log("[서브 테스트 함수] : 02호출");
        Debug.Log("[서브 테스트 함수] : 03호출");
    }
}
