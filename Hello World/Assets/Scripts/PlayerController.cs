using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float runSpeed;
    public float jump;
    public float dash;
    public Rigidbody2D rb;

    private int numJumps; // number of jumps since touching ground
    private int maxJumps;   // number of performable jumps

    private bool justJumped; // whether jump button has been
                             // released since last press

    private float doubleTapTime; // time frame within which a double
                                // tap would be registered
    
    private int numDashTaps;        // number of times run has been pressed
    private float lastDashPress;   // time the last side has been pressed

    private bool stillMoving;      // checks whether the right or left movement
                                   // has been released since 

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        numJumps = 0; 
        maxJumps = 2; 

        justJumped = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        numJumps = 0;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float velx = rb.velocity.x;

        velx = horizontal * runSpeed;

        return velx;
    }

    private float getVerticalMovement()
    {
        float vertical = Input.GetAxisRaw("Jump");
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
