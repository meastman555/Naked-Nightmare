using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //if not initialized in editor default value is 10
    [SerializeField] float speed = 10;
    [SerializeField] Sprite[] sprites;

    private int spriteIndex;
    private SpriteRenderer sr;

    private Animator anim;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
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
        }
        else if(Input.GetKey(KeyCode.S)){
            rb.velocity = Vector2.down * speed;
            sr.sprite = sprites[0];
            anim.enabled = true;
            anim.Play("RunForward");
        }
        else if(Input.GetKey(KeyCode.A)){
            rb.velocity = Vector2.left * speed;
            sr.sprite = sprites[3];
        }
        else if(Input.GetKey(KeyCode.D)){
            rb.velocity = Vector2.right * speed;
            sr.sprite = sprites[1];
        }
        //stationary
        else
        {
            rb.velocity = Vector2.zero;
            anim.enabled = false;
        }
    }
}
