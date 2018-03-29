using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    public AudioClip deadMob;
    public AudioClip buildTower;
    public AudioClip life;

    public void playSoundDeadMob(GameObject gameObject)
    {
        gameObject.GetComponent<AudioSource>().clip = deadMob;
        gameObject.GetComponent<AudioSource>().Play();
    }

    
}
