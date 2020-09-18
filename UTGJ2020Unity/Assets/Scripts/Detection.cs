using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float fov;

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
        Vector3 target_direction = transform.position - player.transform.position;
        //second vector should be enemy facing vector?
        //rounds angle just to make things easier
        Vector3 enemy_vector = 
        int angle = (int) Vector3.Angle(target_direction, Vector3.forward);
        //Debug.Log((int)angle);
        if(angle < fov / 2){
            Debug.Log("i can see");
            Debug.DrawLine(transform.position, player.transform.position, Color.red);
            //detection has occurred, call movement script to follow
            //or game just fails?
        }
        else{
            Debug.Log("I cannot see");
            Debug.DrawLine(transform.position, player.transform.position, Color.green);
        }
    }
}
