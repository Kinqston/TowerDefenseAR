using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform Troll;
    public Transform PointSpawn;

    public Wave[] waves;

    public static int EnemiesAlive;

    public float TimeBetweenWave;
    private float countdown;
    private int WaveNumber;

    void Update()
    {
        if (EnemiesAlive > 0)
            return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWave;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        Wave wave = waves[WaveNumber];
        PlayerStats.Rounds++;
        for (int i = 0; i < wave.count; i++)
        {
            if (wave.countTroll1 >0 )
            {
                SpawnTroll(wave.troll1);
                wave.countTroll1--;
            }
            if (wave.countTroll2 > 0)
            {
                SpawnTroll(wave.troll2);
                wave.countTroll2--;
            }
            yield return new WaitForSeconds(1f/ wave.rate);
        }
        WaveNumber++;

        if(WaveNumber == wave.count)
        {
            Debug.Log("Win");
        }
    }

    private void SpawnTroll(GameObject enemy)
    {
        Instantiate(enemy, PointSpawn.position, PointSpawn.rotation);
        EnemiesAlive++;
    }
}
