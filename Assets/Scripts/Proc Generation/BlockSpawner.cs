
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
   [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] int blockNumbers = 5;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float timer = 2f;
    [SerializeField]float minBlockSpawnTime = 0.2f;
    [SerializeField] float spawnArea = 4f;
     int i=0;
    void Start()
    {
      
       StartCoroutine(SpawnBlockRoutine());
    }

    public void DecreaseObstacleSpawnTime(float amnt)
    {
        timer -= amnt;
        if(timer <= minBlockSpawnTime) timer = minBlockSpawnTime;
    }

    IEnumerator SpawnBlockRoutine()
    {
        
        while(true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPos = new Vector3(Random.Range(-spawnArea, spawnArea),transform.position.y, transform.position.z);
            yield return new WaitForSeconds(timer);
            Instantiate(obstaclePrefab, spawnPos, Random.rotation, obstacleParent);
           // i++;
        }
    }

}
