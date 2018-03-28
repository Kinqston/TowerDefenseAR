using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    // Use this for initialization
    private Transform target;
    public float range = 15f;
    public string trollTag;
    public Transform rotateTower;
    public float speedRotate;

    public float fireRate = 1f;
    public float fireCountDown = 0f;

    public GameObject bullet_prefab;
    public Transform FirePoint;

    public GameObject DestroyMenu;

    public GameObject PlaceTower;

    void Start () {
        //InvokeRepeating("UpdateTarget", 0f, 0.5f);
        StartCoroutine(UpdateTarget());
	}

    IEnumerator UpdateTarget()
    {
        while (true)
        {
            GameObject[] trolls = GameObject.FindGameObjectsWithTag(trollTag);
            float distance_test = Mathf.Infinity;
            GameObject target_troll_test = null;
            foreach (GameObject troll in trolls)
            {
                float rangetotroll = Vector3.Distance(transform.position, troll.transform.position);
                if (rangetotroll < distance_test)
                {
                    distance_test = rangetotroll;
                    target_troll_test = troll;
                }
                if (target_troll_test != null && distance_test <= range)
                {
                    target = target_troll_test.transform;
                }
                else
                {
                    target = null;
                }
            }
            yield return null;
        }
    }

    //private void UpdateTarget()
    //{
    //    GameObject[] trolls = GameObject.FindGameObjectsWithTag(trollTag);
    //    float distance_test = Mathf.Infinity;
    //    GameObject target_troll_test = null;
    //    foreach (GameObject troll in trolls)
    //    {
    //        float rangetotroll = Vector3.Distance(transform.position, troll.transform.position);
    //        if (rangetotroll < distance_test)
    //        {
    //            distance_test = rangetotroll;
    //            target_troll_test = troll;
    //        }
    //        if (target_troll_test != null && distance_test <= range)
    //        {
    //            target = target_troll_test.transform;
    //        }
    //        else
    //        {
    //            target = null;
    //        }
    //    }
    //}

    // Update is called once per frame
    void Update () {
        if (target == null)
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotate = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotateTower.rotation, lookRotate, Time.deltaTime * speedRotate).eulerAngles;
        rotateTower.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        if (fireCountDown<=0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject Bullet_new = (GameObject)Instantiate(bullet_prefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = Bullet_new.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Rage(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnMouseDown()
    {
        GameObject Upgrade = GameObject.FindGameObjectWithTag("Destroy");
        Upgrade.GetComponent<Canvas>().enabled = true;

        BuildManeger.instant.destroyTower = gameObject;

    }

}
