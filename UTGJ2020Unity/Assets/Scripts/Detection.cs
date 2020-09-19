using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    //Make this the detection collision child object!!
    [SerializeField] GameObject player;
    [SerializeField] float fov;
    [SerializeField] float maxDistance;

    public LayerMask masks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug to test with rotation
        if(Input.GetKey(KeyCode.Space)){
            transform.Rotate(0, 0, 100 * Time.deltaTime);
        }
    }

    //adapted from Unity docs on Vector3.angle and forum on basic cone FOV
    void FixedUpdate(){
        //vector between player and enemy, then magnitude of it
        Vector3 directionVector =  player.transform.position - transform.position;
        float distance = directionVector.magnitude;
        //calculates angle between the direction vector and the left unit vector
        //stays left even when emeny fov rotates
        float angle = Vector3.Angle(directionVector, -transform.right);
        //conditions for detection (within fov and certain distance from enemy)
        if(angle < (fov / 2f) && distance <= maxDistance){
            //player is within vision cone, but have to check if there is anything in the way
            RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, masks);
            //we have hit the player, so DO stuff (access enemy movement, game over?)
            if(hit.collider != null && hit.collider.tag == "Player"){
                Debug.DrawLine(transform.position, hit.point, Color.red);
            } 
            //enemy sees an object in front of you, this technically should do nothing, but for testing
            else{
                Debug.DrawLine(transform.position, player.transform.position, Color.blue);
            }
        }
        //you are completely outside the fov range, so do nothing, but for testing
        else{
            Debug.DrawLine(transform.position, player.transform.position, Color.green);
        }
    }
}
