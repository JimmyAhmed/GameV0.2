using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] Enemy;
    public Transform[] point;
    public float spawnRate = 2f;
    public float nextEnemy;

    private void Update()
    {
        StartCoroutine(waitStarting());
    }

    IEnumerator waitStarting()
    {
        yield return new WaitForSeconds(5);
        spawnEnemy();

    }

    private void spawnEnemy()
    {
        if (Time.time > nextEnemy)
        {
            nextEnemy = Time.time + spawnRate;
            if (spawnRate > 1)
            {
                spawnRate -= 0.01f;
            }
            
            GameObject newEnemy = Instantiate(Enemy[Random.Range(0,Enemy.Length)], point[Random.Range(0,point.Length)].position, Quaternion.identity);

        }
    }



}
