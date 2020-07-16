using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour // it gets stuff from unity
{
    // considered bad practice to have variables be public
    private Rigidbody2D rb; // this is the player, we make this so we can call the player within our code
    private Animator anim;
    private enum State {idle, running, jumping};
    private State state = State.idle;

    private void Start()
    {
        // this allows you to use Player's Rigidbody and Animator (since PlayerController is connected to Player)
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        float hDirection = Input.GetAxis("Horizontal"); // we are using Unity's built in input stuff now,
        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        else if (hDirection > 0)    
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        else
        {
  
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 30f); // the rb.velocity.x keeps it going at pre-existing speed
            state = State.jumping;
        }
        VelocityState();
        anim.SetInteger("state", (int)state); // now the anim class knows to change the animation for run/idle/jump
    }
    private void VelocityState()
    {
        if(state == State.jumping)
        {

        }
        if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            // Moving
            state = State.running;
        }

        else
        {
            state = State.idle;
        }
    }
}
