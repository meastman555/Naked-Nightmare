using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassmateAnimation : MonoBehaviour
{

	private Animator anim;
	private Rigidbody2D rb;
    private Transform tf;

    private Vector3 myScale;
    private Vector3 prevPos;
    private Vector3 newPos;
    private Vector3 velocity;

    private bool facingRight = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        myScale = tf.localScale;
        prevPos = tf.position;
        newPos = tf.position;
    }

    private void Update()
    {

        newPos = tf.position;
        velocity = (newPos - prevPos) / Time.fixedDeltaTime;
        prevPos = newPos;

        if(velocity.x > 0.1 || velocity.x < -0.1)
        {
            anim.Play("ClassMateSide");
        }
        else if(velocity.y < -0.1)
        {
            anim.Play("ClassMateForward");
        }
        else if(velocity == Vector3.zero)
        {
            anim.Play("ClassMateIdle");
        }
        else if(velocity.y > 0.1)
        {
            anim.Play("ClassMateBack");
        }

        if(velocity.x > 0.1 && !facingRight)
        {
            FlipSprite();
        }
        if (velocity.x < -0.1 && facingRight)
        {
            FlipSprite();
        }
        print(gameObject.name + ": " + "x: " + velocity.x + "y: " + velocity.y);
    }

    void FlipSprite()
    {
        facingRight = !facingRight;
        myScale.x *= -1;
        tf.localScale = myScale;
    }



}
