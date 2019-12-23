using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float timer;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnPositionOffset;

    private float originalTimer;

    private float width;
    private float height;

    void Start()
    {
        originalTimer = timer;
        width = Camera.main.orthographicSize;
        height = Camera.main.orthographicSize * Camera.main.aspect;
        StartCoroutine(SpawnEnemy());
    }
   

    private IEnumerator SpawnEnemy()
    {
        int pos = Random.Range(0, 4);
        print(pos);
        switch (pos)
        {
            case 0:

                Instantiate(enemy, new Vector2(width + spawnPositionOffset, Random.Range(-height, height)), Quaternion.identity);
                break;

            case 1:

                Instantiate(enemy, new Vector2(-width - spawnPositionOffset, Random.Range(-height, height)), Quaternion.identity);
                break;

            case 2:

                Instantiate(enemy, new Vector2(Random.Range(-width, width), height + spawnPositionOffset), Quaternion.identity);
                break;

            case 3:
                Instantiate(enemy, new Vector2(Random.Range(-width, width), -height - spawnPositionOffset), Quaternion.identity);
                break;

            default:
                break;
        }   
        
        yield return new WaitForSeconds(timer);

        StartCoroutine(SpawnEnemy());

    }
}
