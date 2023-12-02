using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
    WALKING,
    RUNNING
}

public class PlayerMovement : MonoBehaviour
{
    public MovementState moveState;
    private Rigidbody2D rb;
    [Range(1.5f,3f)] 
    public float runningMultiplier;
    public float speed;
    public Vector2 orientation;
    public Vector2 lastOrientation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveState = MovementState.WALKING;
    }

    void Update()
    {
        GetInput();
        Move();
    }

    void GetInput()
    {
        moveState = MovementState.WALKING;

        // initial test

        // if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        // {
        //     rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized  * speed;
        // }
        // else
        // {
        //     rb.velocity = Vector2.zero;
        // }    

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // optimization test

        // if(horizontal != 0f)
        // {
        //     if(horizontal > 0.6f)
        //     {
        //         horizontal = 1f;
        //     }
        //     else if(horizontal > 0f)
        //     {
        //         horizontal = 0.35f;
        //     }
        //     else if(horizontal < -0.6f)
        //     {
        //         horizontal = -1f;
        //     }
        //     else if(horizontal < -0f)
        //     {
        //         horizontal = -0.35f
        //     }
        // }

        // kinda working test

        // if(horizontal > 0f)
        // {
        //     if(horizontal > 0.6f)
        //     {
        //         horizontal = 1f;
        //     }
        //     else
        //     {
        //         horizontal = 0.35f;
        //     }
        // }
        // else if(horizontal < 0f)
        // {
        //     if(horizontal < -0.6f)
        //     {
        //         horizontal = -1f;
        //     }
        //     else
        //     {
        //         horizontal = -0.35f;
        //     }
        // }
        // if(vertical > 0f)
        // {
        //     if(vertical > 0.5f)
        //     {
        //         vertical = 1f;
        //     }
        //     else
        //     {
        //         vertical = 0.5f;
        //     }
        // }
        // else if(vertical < 0f)
        // {
        //     if(vertical < -0.5f)
        //     {
        //         vertical = -1f;
        //     }
        //     else
        //     {
        //         vertical = -0.5f;
        //     }
        // }

        // idk test

        if(horizontal > 0f)
        {
            if(horizontal > 0.6f)
            {
                moveState = MovementState.RUNNING;
            }
            horizontal = 1f;
        }
        else if(horizontal < 0f)
        {
            if(horizontal < -0.6f)
            {
                moveState = MovementState.RUNNING;
            }
            horizontal = -1f;
        }
        if(vertical > 0f)
        {
            if(vertical > 0.5f)
            {
                moveState = MovementState.RUNNING;
            }
            vertical = 1f;
        }
        else if(vertical < 0f)
        {
            if(vertical < -0.5f)
            {
                moveState = MovementState.RUNNING;
            }
            vertical = -1f;
        }

        orientation = new Vector2(horizontal, vertical);

        //preciso otimizar essa checagem!

        if(orientation != Vector2.zero && orientation != lastOrientation)
        {
            lastOrientation = orientation;
        }

        // dont have any idea what it is

        // if(horizontal > 0)
        // {
        //     if(vertical > 0)
        //     {
        //         orientation = new Vector2(horizontal, Input.GetAxisRaw("Vertical")).normalized;
        //     }
        //     else if(vertical < 0)
        //     {
        //         orientation = new Vector2(horizontal, Input.GetAxisRaw("Vertical")).normalized;
        //     }
        //     else
        //     {
        //         orientation = new Vector2(horizontal, Input.GetAxisRaw("Vertical")).normalized;
        //     }
        // }
        // else if(horizontal < 0)
        // {
        //     if(Input.GetAxisRaw("Vertical") > 0)
        //     {
        //         orientation = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //     }
        //     else if(Input.GetAxisRaw("Vertical") < 0)
        //     {
        //         orientation = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //     }
        //     else
        //     {
        //         orientation = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //     }
        // }
        // else
        // {
        //     rb.velocity = Vector2.zero;
        // }    
    }

    void Move()
    {
        if(moveState == MovementState.RUNNING)
        {
            rb.velocity = orientation.normalized * runningMultiplier * speed;
        }
        else
        {
            rb.velocity = orientation.normalized * speed;
        }
    }
}
