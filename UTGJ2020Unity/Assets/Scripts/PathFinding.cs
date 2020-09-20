using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float enemySpeed;

    private int waypointIndex = 0;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //starts movement cycle at the first point in cycle 
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {   
        //we are still in cycle
        if (waypointIndex < waypoints.Length)
        {
            //moving towards the next node in cycle
            transform.position = Vector2.MoveTowards(transform.position, 
                waypoints[waypointIndex].transform.position, enemySpeed * 
                Time.deltaTime);

            //when we get there, increment to the next node
            if ((transform.position - waypoints[waypointIndex].transform.position).magnitude <= Mathf.Epsilon)
            {
                waypointIndex += 1;
            }
        }
        //wrapping around to the beginning of cycle
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

    //Rotates the detection cone based on the direction of velocity
    //only moves in cardinal directions
    public Vector3 GetVelocity(){
        return Vector3.Normalize(waypoints[waypointIndex].transform.position - transform.position) * enemySpeed;
    }
}
