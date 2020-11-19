using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
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
            moveSpeed = 10f;
        }
        else
        {
            moveSpeed = 5f;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
       
    }
}
