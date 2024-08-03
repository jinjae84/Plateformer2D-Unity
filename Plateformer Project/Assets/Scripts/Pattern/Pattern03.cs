using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    public Transform StartPos;       // 원을 방사할 위치
    public int bulletCount;          // 탄막의 갯수
    public float bulletSpeed;        // 탄막의 속도
    public GameObject bulletPrefab;  // 탄막 프리팹

    private int MaxBulletCount;
    // 몇 마리 소환할 것인가?

    private void Awake()
    {
        MaxBulletCount = bulletCount;
    }


    private void OnEnable()
    {
        //InvokeRepeating(nameof(CreateEnemyInstance), spawnCycle, 1);
        StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int count = 0;

        yield return new WaitForSeconds(1f);
        
        while (count < MaxBulletCount)
        {
            CircleEmit();
            count++;
            yield return new WaitForSeconds(1f);
        }
        gameObject.SetActive(false);
    }

    void CircleEmit()
    {
        float angle = 360 / (float)bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab,
                StartPos.position, Quaternion.identity);

            float bulletAngle = angle * i;  //
            float x = Mathf.Cos(bulletAngle * Mathf.PI / 180);
            float y = Mathf.Sin(bulletAngle * Mathf.PI / 180);

            // 각도로 부터 원점에서 시야 각도의 vector2 값을 구하는 공식

            bullet.GetComponent<MoveMentTransform2D>().MoveSpeed(bulletSpeed);
            bullet.GetComponent<MoveMentTransform2D>().MoveTo(new Vector2(x, y));
        }
    }

   

}

