using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed = 10.0f;
    private Transform target;
    private int waypointIndex = 0;
    public int value = 50;
    public GameObject deathEffect;

     void Start()
    {
        target = WayPoint.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)  Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

       
        Destroy(gameObject);
    }
    void Update()
    {
        Vector3 dir =  target.position- transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if( Vector3.Distance(transform.position, target.position) <=
            0.4f)
        {
            NextWayPoint();
        }
    }

     void NextWayPoint()
    {
        if (waypointIndex == WayPoint.points.Length-1)
        {
            EndPath();
            
            return;
        }

         waypointIndex++;
         target =  WayPoint.points[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
