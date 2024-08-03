using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    public GameObject enemyPrefab;

    // 몇 마리 소환할 것인가?
    public int spawnCount = 5;
    // 몇 초를 주기로 생성할 것인가?
    public float spawnCycle = 1f;

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
        // 패턴이 시작되기 전에 사운드를 추가할 수 있습니다.
        // 전조 알림.
        yield return new WaitForSeconds(1f);

        int repeatTime = 5;

        for (int i = 0; i < repeatTime; i++)
        {
            CreateEnemyInstance(spawnCount);
            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);
    }

    private void CreateEnemyInstance(int count)
    {

        for (int i = 0; i < count; i++)
        {
            float randomValue = Random.Range(-16, 16);
            Vector3 spawnPosition = new Vector3(randomValue, 9, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

}

