using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

	public int playerSpeed = 10;
    public bool faceRight = true;
    public int playerJumpPower = 1250;
    private float moveX;
    public KeyCode sprint;

	void Update () {
		moveX = Input.GetAxis("Horizontal");
	}
}
