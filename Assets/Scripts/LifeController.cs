using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {

    private AudioSource songLost;
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "")
    //    Destroy(gameObject);
    //    Destroy(other.gameObject);
    //    Debug.Log("qq");
    //}
    private void Start()
    {
        songLost = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        songLost.Play();
    }

}
