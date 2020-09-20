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

    public PathFinding path;

    private bool isResetting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //adapted from Unity docs on Vector3.angle and forum on basic cone FOV
    void FixedUpdate(){
        //vector between player and enemy, then magnitude of it
        Vector3 directionVector = path.GetVelocity();
        Vector3 playerVector = player.transform.position -  transform.position;
        float distance = playerVector.magnitude;
        //calculates angle between the direction vector and the left unit vector
        //stays left even when emeny fov rotates
        float angle = Vector3.Angle(directionVector, playerVector);
        //conditions for detection (within fov and certain distance from enemy)
        if(angle < (fov / 2f) && distance <= maxDistance){
            //player is within vision cone, but have to check if there is anything in the way
            RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, masks);
            //we have hit the player, so DO stuff (access enemy movement, game over?)
            if(hit.collider != null && hit.collider.tag == "Player" && !isResetting){
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;                                   
                player.GetComponent<Animator>().Play("Caught");
                Invoke("Reset", 0.66f);
                Debug.DrawLine(transform.position, hit.point, Color.red);
                //Debug.Log("Hit player");
                isResetting = true;
            } 
            //enemy sees an object in front of you, this technically should do nothing, but for testing
            else{
                //Debug.DrawLine(transform.position, player.transform.position, Color.blue);
                //Debug.Log("Hit object in front of player");
            }
        }
        //you are completely outside the fov range, so do nothing, but for testing
        else{
            //Debug.DrawLine(transform.position, player.transform.position, Color.green, 20f);
        }
        transform.rotation = Quaternion.LookRotation(Vector3.forward, path.GetVelocity());
    }

    void Reset(){
        player.transform.position = new Vector3(8.92f, 1.33f, 0);
        player.GetComponent<PlayerMovement>().enabled = true;
        isResetting = false;
    }
}
