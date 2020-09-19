using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

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
        //calculates the direction vector, distance between two objects (magnitude of distance), and angle between axis and direction
        Vector3 directionVector =  player.transform.position - transform.position;
        float distance = directionVector.magnitude;
        //transform.right could be changed depending on starting rotation of enemies
        float angle = Vector3.Angle(directionVector, -transform.right);
        //conditions for detection
        if(angle < (fov / 2f) && distance <= maxDistance){
            //player is within vision cone, but have to check if there is anything in the way
            RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, masks);
            if(hit.collider != null && hit.collider.tag == "Player"){
                Debug.Log("Hit the player!");
                Debug.DrawLine(transform.position, hit.point, Color.red);
            } 
            //detection has occurred, call movement script to follow
            //or game just fails?
            else{
                Debug.Log("Hit object in front of player! (NULL)");
                Debug.DrawLine(transform.position, player.transform.position, Color.blue);

            }
        }
        //safety (so do nothing?)
        else{
            Debug.DrawLine(transform.position, player.transform.position, Color.green);
            Debug.Log("Can't hit player");
        }
    }
}
