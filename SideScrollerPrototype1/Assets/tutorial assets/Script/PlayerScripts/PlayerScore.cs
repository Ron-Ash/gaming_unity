using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    private float timeleft = 121;
    public int playerScore = 0;
    public GameObject timeleftUI;
    public GameObject playerScoreUI;
    
 	
	// Update is called once per frame
	void Update () {
        timeleft -= Time.deltaTime;
        timeleftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeleft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeleft < 0.1f)
        {
            SceneManager.LoadScene("Prototype1");
        }
        
	}

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "End")
        { 
        Debug.Log("This is the end");
        CountScore(); }
        if (trig.gameObject.name == "Coin")
        { playerScore = playerScore + 100;
            Destroy(trig.gameObject);
        }

    }

    void CountScore()
    {
        playerScore = playerScore + (int)(timeleft * 10);
        Debug.Log(playerScore);

    }
}
