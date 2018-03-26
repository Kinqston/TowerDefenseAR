using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrollController : MonoBehaviour {

    NavMeshAgent _troll;
   // public Transform castle;
    // Use this for initialization
    void Start()
    {
        _troll = GetComponent<NavMeshAgent>();
        //_troll.SetDestination(castle.position);

        _troll.SetDestination(GameController.GC_ST.Castle.transform.position);
        _troll.speed = GameController.GC_ST.SpeedTrolls;
    }

    // Update is called once per frame
    void Update()
    {

    }
}