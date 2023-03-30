using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaGirlController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    // Start is called before the first frame update
    private int currentAnimation = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = 1;
        var velocityY = rb.velocity.y;

        rb.velocity = new Vector2(0, velocityY);

         //Run
        if(Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 2;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }

        //Slide
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)){
            currentAnimation = 4;
            rb.velocity = new Vector2(-5, velocityY);
            sr.flipX = true;
        }
        if(Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)){
            currentAnimation = 4;
            rb.velocity = new Vector2(5, velocityY);
            sr.flipX = false;
        }
        //Throw
        if(Input.GetKey(KeyCode.A)){
            currentAnimation = 3;
        }
        //Attack
        if(Input.GetKey(KeyCode.S)){
            currentAnimation = 5;
        }
        //Dead
        if(Input.GetKey(KeyCode.D)){
            currentAnimation = 6;
        }

        animator.SetInteger("Estado", currentAnimation);
    }
}
