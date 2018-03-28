using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Transform Troll;
    public Transform PointSpawn;

    public float TimeBetweenWave = 5f;
    public float countdown = 2f;
    private int WaveNumber;
    private int waveindex = 0;
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWave;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        WaveNumber++;
        for (int i = 0; i < WaveNumber; i++)
        {
            SpawnTroll();
            yield return new WaitForSeconds(0.5f);
        }      
    }

    private void SpawnTroll()
    {
        Instantiate(Troll, PointSpawn.position, PointSpawn.rotation);
    }
}
