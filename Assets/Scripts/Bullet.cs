using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    private Transform target;
    public int Score;
    public float speed;

    public float explosionRadius;

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
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
        Destroy(target.gameObject);
    }

    void Explode()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Troll")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }

    void Damage(Transform enemy)
    {
        //GameObject Score_text = GameObject.Find("Score");
        //Score++;
        //Score_text.GetComponent<Text>().text = "Score: "+Score;
        PlayerStats.Money += 10;
        Destroy(enemy.gameObject);
    }
}
