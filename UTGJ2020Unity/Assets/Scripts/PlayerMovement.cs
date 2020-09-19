using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    //if not initialized in editor default value is 10
    [SerializeField] float speed = 10;
    [SerializeField] Sprite[] sprites;

    private int spriteIndex;
    private bool facingRight = true;

    private SpriteRenderer sr;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform tf;
    private Vector3 myScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
        myScale = tf.localScale;
        anim.Play("Idle");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
    }

    //Checks input and handles movement
    void HandleMovement(){
        //moving in all 4 directions
        if(Input.GetKey(KeyCode.W)){
            rb.velocity = Vector2.up * speed;
            sr.sprite = sprites[2];
            anim.Play("RunBack");
        }
        else if(Input.GetKey(KeyCode.S)){
            rb.velocity = Vector2.down * speed;
            sr.sprite = sprites[0];
            anim.Play("RunForward");
        }
        else if(Input.GetKey(KeyCode.A)){
            rb.velocity = Vector2.left * speed;
            sr.sprite = sprites[3];
            anim.Play("RunSide");
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.velocity = Vector2.right * speed;
            sr.sprite = sprites[1];
            anim.Play("RunSide");
        }
        //stationary
        else
        {
            rb.velocity = Vector2.zero;
            anim.Play("Idle");
        }

        if(rb.velocity.x > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if(rb.velocity.x < 0 && facingRight)
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        facingRight = !facingRight;
        myScale.x *= -1;
        tf.localScale = myScale;
    }

}
