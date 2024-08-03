using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    public Transform StartPos;       // ���� ����� ��ġ
    public int bulletCount;          // ź���� ����
    public float bulletSpeed;        // ź���� �ӵ�
    public GameObject bulletPrefab;  // ź�� ������

    private int MaxBulletCount;
    // �� ���� ��ȯ�� ���ΰ�?

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

            // ������ ���� �������� �þ� ������ vector2 ���� ���ϴ� ����

            bullet.GetComponent<MoveMentTransform2D>().MoveSpeed(bulletSpeed);
            bullet.GetComponent<MoveMentTransform2D>().MoveTo(new Vector2(x, y));
        }
    }

   

}

