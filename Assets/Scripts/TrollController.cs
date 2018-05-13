using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TrollController : MonoBehaviour {

    NavMeshAgent _troll;

    public float speed;
    private Transform target;
    private int waveIndex = 0;

    public float StartHealth = 100;
    public float Health;
    //public static 
    private AudioSource soundDead;
    [Header("Unity Stuff")]
    public Image HealthBar;
   // public Transform castle;
    // Use this for initialization
    void Start()
    {
        Health = StartHealth;
        //_troll = GetComponent<NavMeshAgent>();
        ////_troll.SetDestination(castle.position);
        //_troll.SetDestination(GameController.GC_ST.Castle.transform.position);
        //_troll.speed = GameController.GC_ST.SpeedTrolls;

        target = WayPoints.points[0];

        soundDead = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
 
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            //transform.LookAt(target.transform);

            Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, speed * 0.2f, 0.1f);
            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);

            if (Vector3.Distance(transform.position, target.position) <= 0.03f)
            {
                GetNextWayPoint();
            }
           
        }
    }

    private void GetNextWayPoint()
    {      
        waveIndex++;
        target = WayPoints.points[waveIndex];
        if (waveIndex >= WayPoints.points.Length - 1)
        {
           // Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Life")
        {
            PlayerStats.Life--;
            WaveSpawner.EnemiesAlive--;
            soundDead.Play();
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Life")
        //{
        //    PlayerStats.Life--;
        //    WaveSpawner.EnemiesAlive--;
        //    soundDead.Play();
        //    Destroy(gameObject);
        //}
    }
    private void OnEnable()
    {
        //_troll.SetDestination(GameController.GC_ST.Castle.transform.position);
    }
    public void Destroy_enemy()
    {
        Destroy(gameObject);
        PlayerStats.Money += 5;
        WaveSpawner.EnemiesAlive--;
    }
}