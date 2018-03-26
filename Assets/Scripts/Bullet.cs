using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Transform target;
    public float speed;

    public void Rage(Transform _target) {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float DistanceFrame = speed * Time.deltaTime;
        if (dir.magnitude <= DistanceFrame)
        {
            Hit();
            return;
        }
        transform.Translate(dir.normalized * DistanceFrame, Space.World);
	}

    private void Hit()
    {
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}
