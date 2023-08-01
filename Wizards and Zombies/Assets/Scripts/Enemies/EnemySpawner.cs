using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float waveTime;
    [SerializeField] int difStart;
    [SerializeField] int difMax;
    [SerializeField] float spawnDist;
    [SerializeField] float difIncTime;
    GameObject player;
    int dif;
    float timerSinceSpawn;
    float timerDifInc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dif = difStart;
        SpawnWave();
    }

    // Update is called once per frame
    void Update()
    {
        timerDifInc += Time.deltaTime;
        timerSinceSpawn += Time.deltaTime;
        if (timerDifInc >= difIncTime && dif < difMax)
        {
            timerDifInc -= difIncTime;
            dif++;
        }
        if (timerSinceSpawn >= waveTime)
        {
            timerSinceSpawn -= waveTime;
            SpawnWave();
        }
    }
    void SpawnWave()
    {
        for (int i = 0; i < dif; i++)
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector3 spawnPos = new Vector3(spawnDist * Mathf.Cos(angle), spawnDist * Mathf.Sin(angle), 0);
        spawnPos += player.transform.position;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
