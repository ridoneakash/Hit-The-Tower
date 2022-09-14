using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour
{
    [Header("Attributes")]

    public float fireRate = 1.0f;
    public float turnSpeed = 10.0f;
    public float range = 15.0f;

    [Header("Unity Setup Field")]

    public Transform partToRotate;
    public Transform target;

    
    private string enemyTag = "Enemy";
    private float fireCountDwon = 0f;

    public GameObject bulletPrefbs;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("Findtarget", 0.0f, 0.5f);
    }

    void Findtarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;


        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                nearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;

        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;

        if (dir != Vector3.zero)
        {
            Quaternion LookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, LookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        
        

        if (fireCountDwon <= 0f)
        {
            Shoot();
            fireCountDwon = 1f / fireRate;

        }
        fireCountDwon -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
    void Shoot()
    {
     GameObject bulletGo = (GameObject)Instantiate(bulletPrefbs, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet!=null){
            bullet.Seek(target);

        }

    }
}
