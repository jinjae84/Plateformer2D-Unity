using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPattern : MonoBehaviour
{
    public GameObject PotionPrefab;
    
    public int spawnCount = 1;
    
    public float spawnCycle = 5f;

    private void OnEnable()
    {
       
        StartCoroutine(SpawnPotion());
    }

    private void OnDisable()
    {
        StopCoroutine(SpawnPotion());
    }

    IEnumerator SpawnPotion()
    {
        
        yield return new WaitForSeconds(1f);

        int repeatTime = 5;

        for (int i = 0; i < repeatTime; i++)
        {
            CreatePotionInstance(spawnCount);
            yield return new WaitForSeconds(spawnCycle);
        }

        gameObject.SetActive(false);
    }

    private void CreatePotionInstance(int count)
    {

        for (int i = 0; i < count; i++)
        {
            float randomValue = Random.Range(-16, 16);
            Vector3 spawnPosition = new Vector3(randomValue, 9, 0);
            Instantiate(PotionPrefab, spawnPosition, Quaternion.identity);
        }
    }

}
