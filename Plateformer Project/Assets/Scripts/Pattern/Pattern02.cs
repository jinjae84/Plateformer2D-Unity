using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Pattern02 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject warningSign;

    // �� ���� ��ȯ�� ���ΰ�?
    public int spawnCount = 1;
    // �� �ʸ� �ֱ�� ������ ���ΰ�?
    public float spawnCycle = 0.2f;

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
        // ������ ���۵Ǳ� ���� ���带 �߰��� �� �ֽ��ϴ�.
        // ���� �˸�.
        Vector3 spawnPos = new Vector3(-16.5086f, 0.5134f, 0);
        GameObject warning = Instantiate(warningSign, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        
        Destroy(warning);
        int repeatTime = 20;

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
            float randomValue = Random.Range(7, -10);
            Vector3 spawnPosition = new Vector3(-19, randomValue, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

}

