using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    public Transform[] spawnPositions;
    public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {


            int spawnedEnemy = Random.Range(0, enemies.Length);
            int lane = Random.Range(0, spawnPositions.Length);

            Instantiate(enemies[spawnedEnemy], spawnPositions[lane].position, transform.rotation);


        }

    }

    void Move()
    {

    }
}
