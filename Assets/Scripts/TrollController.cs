using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TrollController : MonoBehaviour {

    NavMeshAgent _troll;
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
        _troll = GetComponent<NavMeshAgent>();
        //_troll.SetDestination(castle.position);
        _troll.SetDestination(GameController.GC_ST.Castle.transform.position);
        _troll.speed = GameController.GC_ST.SpeedTrolls;
        soundDead = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}