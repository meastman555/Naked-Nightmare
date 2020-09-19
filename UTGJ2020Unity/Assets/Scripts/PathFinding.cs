using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{

    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float enemySpeed;

    //for rotation stuff, uncomment when ready to test
    //[SerializeField]
    //private int[] rotatePoints;

    //[SerializeField]
    //private float[] rotateDegrees;

    private int waypointIndex = 0;

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
        if (waypointIndex <= waypoints.Length - 1)
        {
            //moving towards the next node in cycle
            transform.position = Vector2.MoveTowards(transform.position, 
                waypoints[waypointIndex].transform.position, enemySpeed * 
                Time.deltaTime);

            //when we get there, increment to the next node
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
                //if point is a certain "rotate" point, denoted by path indecies
                //we only want to do this when we get to the final point
                    //check corresponding rotation array for the angle to rotate over
                //each enemy has to hard code their own rotation nodes and degrees from their unique path

            }
        }
        //wrapping around to the beginning of cycle
        if(waypointIndex >= waypoints.Length - 1)
        {
            waypointIndex = 0;
        }
    }
}
