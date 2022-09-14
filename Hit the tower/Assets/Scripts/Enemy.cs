using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private Transform target;
    private int waypointIndex = 0;
    private void Start()
    {
        target = WayPoint.points[0];
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
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
         target =  WayPoint.points[waypointIndex];
    }
}
