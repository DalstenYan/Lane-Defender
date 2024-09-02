using System.Collections;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    public Transform[] spawnPositions;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());

    }

    // Update is called once per frame
    void Update()
    {

        

    }

    IEnumerator SpawnEnemy()
    {
        
        int spawnedEnemy = Random.Range(0, enemies.Length);
        int lane = Random.Range(0, spawnPositions.Length);

        Instantiate(enemies[spawnedEnemy], spawnPositions[lane].position, transform.rotation);
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnEnemy());
    }
}


