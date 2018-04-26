using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovmentProto : MonoBehaviour{

    public int playerSpeed = 10;
    public bool faceRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public KeyCode sprint;

    void Update()
    {
        PlayerMove();

    }

    void PlayerMove()
    {
        //CONTROLS 
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButton("Jump"))
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
    }

    void FlipPlayer()
    {
        faceRight = !faceRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

    }
}
