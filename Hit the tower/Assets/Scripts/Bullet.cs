using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public float explodeRedius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();

        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt( target);

    }
    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explodeRedius > 0f)
        {
            Explode();
        }else
        {
            Damage(target);

        }
        Destroy(gameObject);       
    }

    void Explode()
    {
        Collider[] colliders =  Physics.OverlapSphere(transform.position, explodeRedius);

        foreach ( Collider collider in colliders)
        {
            if (collider.tag == "Enemy" )
            {
                Damage(collider.transform);

            }

        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRedius);
    }
}
