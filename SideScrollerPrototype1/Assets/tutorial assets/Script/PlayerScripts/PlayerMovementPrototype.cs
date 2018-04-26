using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPrototype : MonoBehaviour {
        
    public int playerSpeed = 10;
    public bool faceRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;

    void Update()
    {
        PlayerMove ();
        PlayerRayCast();
    }

    void PlayerMove()
    {
        //CONTROLS 
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump") && isGrounded == true)
        {
            Jump();
        }
        //PLAYER DIRECTION
        if (moveX < 0.0f && faceRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && faceRight == true)
        {
            FlipPlayer();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("player collided with " + col.collider.name);
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void PlayerRayCast() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.distance < 0.9f && hit.collider.tag == "Enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
           

        }

    }
}
