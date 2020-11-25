using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private const float  MOVESPEED = 5f;
    public float speed = 1f;
    public Rigidbody2D rb;
    private KeyCode shift = KeyCode.LeftShift;
    Vector2 movement; 

    
    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    //different from update, is dependant from the system not the game update rate
    void FixedUpdate()
    {
        // movement 
        if (Input.GetKey(shift))
        {
            speed = 2f;
        }
        else
        {
            speed = 1f;
        }
        rb.MovePosition(rb.position + movement * MOVESPEED * speed * Time.fixedDeltaTime);

       
    }
}
