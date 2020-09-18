using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float fov;
    [SerializeField] float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug to test with rotation
        //if(Input.GetKey(KeyCode.Space)){
        //    transform.Rotate(0, 0, 100 * Time.deltaTime);
        //}
    }

    //adapted from Unity docs on Vector3.angle and forum on basic cone FOV
    void FixedUpdate(){
        //calculates the direction vector, distance between two objects (magnitude of distance), and angle between axis and direction
        Vector3 directionVector = transform.position - player.transform.position;
        float distance = directionVector.magnitude;
        //transform.right could be changed depending on starting rotation of enemies
        float angle = Vector3.Angle(directionVector, transform.right);
        //conditions for detection
        if(angle < (fov / 2f) && distance <= maxDistance){
            Debug.DrawLine(transform.position, player.transform.position, Color.red);
            //detection has occurred, call movement script to follow
            //or game just fails?
        }
        //safety (so do nothing?)
        else{
            Debug.DrawLine(transform.position, player.transform.position, Color.green);
        }
    }
}
