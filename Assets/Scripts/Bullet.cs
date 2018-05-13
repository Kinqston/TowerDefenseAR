using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public Transform parent;
    public int Score;
    public float speed;
    private Sounds song;
    public float Damage_bullet;

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
        gameObject.transform.LookAt(target.transform);
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
        //Debug.Log(enemy.gameObject.GetComponent<TrollController>().Health);
        enemy.gameObject.GetComponent<TrollController>().Health -= Damage_bullet;
        enemy.gameObject.GetComponent<TrollController>().HealthBar.fillAmount = enemy.gameObject.GetComponent<TrollController>().Health/enemy.gameObject.GetComponent<TrollController>().StartHealth;
        if (enemy.gameObject.GetComponent<TrollController>().Health <= 0)
        {

            // Debug.Log("kill");
            // song.playSoundDeadMob(enemy.gameObject);
            enemy.tag = "Untagged";
            enemy.GetComponent<Animator>().SetBool("Dead", true);
            enemy.GetComponent<BoxCollider>().enabled = false;
            // Destroy(enemy.gameObject);          
        }
    }
}
