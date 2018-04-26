using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovmentPrototype : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;

    public GameObject healthbar;
    private GameFlow gameFlow;
    
    void Awake()
    {
        healthbar = GameObject.Find("Canvas/Healthbar");
        gameFlow = healthbar.GetComponent<GameFlow>();
    }
	
	void Update () 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.7f)
        {
            Flip();
            if (hit.collider.tag == "Player")
            {
                //Debug.Log("Player health: " + gameFlow.CurrentHP);
                //gameFlow.CurrentHP -=100;
                GameFlow.CurrentHP -= 100;
            }          
        }
	}

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else {
            XMoveDirection = 1;
        }
    }
}
