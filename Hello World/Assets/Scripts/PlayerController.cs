using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // trats of player
    public float runSpeed;  // speed
    public float jump;      // strength of jump
    public float dashDist;  // distance of dash
    public float dashCooldown; // min time between dashes
    private int maxJumps;   // number of performable jumps
    public Rigidbody2D rb;
    public Transform tr;

    // jumping stuff
    private int numJumps; // number of jumps since touching ground
    private bool justJumped; // whether jump button has been
                             // released since last press

    // double tap stuff
    private float doubleTapTime; // time frame within which a double
                                // tap would be registered
    
    // dashing stuff
    private float lastDashPress;   // time the last side has been pressed
    private bool justMoved;      // checks whether the right or left movement
                                 // has been released since 
    private int dashDir;      // direction of the dash
    private float timeSinceDash; // time since last dash

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();

        numJumps = 0; 
        maxJumps = 2;

        doubleTapTime = .2f;

        lastDashPress = Time.time;
        timeSinceDash = 0;

        justJumped = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        numJumps = 0;

        // fall into death zone
        if (collision.gameObject.tag == "DeathField")
            tr.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(getHorizontalMovment(), getVerticalMovement());

        
    }
    
    private float getHorizontalMovment()
    {
        int horizontal = (int) Input.GetAxisRaw("Horizontal");
        float velx = rb.velocity.x;


        if(horizontal == 0) // not moving
        {  
            justMoved = false;
        }
        else // moving
        {
            if (!justMoved) // not holding down
            {
                float deltaT = Time.time - lastDashPress;
                lastDashPress = Time.time;

                if (deltaT < doubleTapTime && horizontal == dashDir && timeSinceDash > dashCooldown) // a double tap has taken place
                {
                    Debug.Log("Dash Activated");
                    tr.Translate(dashDist * horizontal, 0, 0);
                    timeSinceDash = 0;
                }
                else
                {
                    timeSinceDash += deltaT;
                }

                dashDir = horizontal;
            }
            
            justMoved = true;
        }

        velx = horizontal * runSpeed; // run

        return velx;
    }

    private float getVerticalMovement()
    {
        int vertical = (int)Input.GetAxisRaw("Jump");
        float vely = rb.velocity.y;

        if (vertical > 0 && numJumps < maxJumps && !justJumped)
        {
            vely = jump;
            justJumped = true;
            numJumps++;
        }
        else if (vertical <= 0)
        {
            justJumped = false;
        }

        return vely;
    }
}
