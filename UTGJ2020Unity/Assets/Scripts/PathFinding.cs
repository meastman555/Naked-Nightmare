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
    [SerializeField]
    private int[] rotatePoints;

    [SerializeField]
    private float[] rotateDegrees;

    private int waypointIndex = 0;
    private int rotateIndex = 0;

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
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                //parent moves along the path, but we only want to rotate the child detection object
                if(waypointIndex == rotatePoints[rotateIndex]){
                    Debug.Log(rotateIndex);
                    Debug.Log("rotated " + rotateDegrees[rotateIndex] + " degrees");
                    transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 0, rotateDegrees[rotateIndex]);
                    rotateIndex++;
                }
                waypointIndex += 1;
            }
        }
        //wrapping around to the beginning of cycle
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
            rotateIndex = 0;
        }
    }
}
