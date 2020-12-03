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
    public CapsuleCollider2D cc2;
    private Vector2 sizeC;
    private Vector2 sizeC2;

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
      
        sizeC = cc2.size;
        sizeC2 = new Vector2(0.01f, 0.014f);
    }

    //different from update, is dependant from the system not the game update rate
    void FixedUpdate()
    {
        // movement 
        if (Input.GetKey(shift))
        {
            speed = 0.5f;
            cc2.size = new Vector2(0.01f, 0.014f);
        }
        else
        {
            speed = 1f;
            cc2.size = new Vector2(0.05f, 0.07f);
        }
        rb.MovePosition(rb.position + movement * MOVESPEED * speed * Time.fixedDeltaTime);

       
    }
}
