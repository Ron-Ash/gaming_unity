using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlow : MonoBehaviour {

    public static float CurrentHP = 500;
    public static float MaxHP = 500;
    public static float CurrentSTAM = 10;
    public static float MaxSTAM = 500;
    public Transform HealthMeter;
    public Transform StaminaMeter;
    public KeyCode RunForward;
    public float timecheck = 0;
    public float timecheckrest = 0;

    private int sprintSpeed = 20;


    public GameObject proPlayer;
    public PlayerMovementPrototype playerMovementPrototype;

    void Awake()
    {
        proPlayer= GameObject.Find("ProPlayer");
        playerMovementPrototype = proPlayer.GetComponent<PlayerMovementPrototype>();
    }

    void Start ()
    {
        HealthMeter.GetComponent<Image>().color = new Color(0, 1, 0);

    }
	
	
	void Update ()
    {
        if (CurrentHP == 0)
        {
            SceneManager.LoadScene(0);
        }

        if (CurrentHP < 301)
        {
            HealthMeter.GetComponent<Image>().color = new Color(1, 1, 0);
        }

        if (CurrentHP < 201)
        {
            HealthMeter.GetComponent<Image>().color = new Color(1, 0, 0);
        }

        if (Input.GetKey(RunForward) && CurrentSTAM > 0)
        {
            timecheck += Time.deltaTime;
            playerMovementPrototype.playerSpeed = sprintSpeed;
        }
        if (!Input.GetKey(RunForward))
        {
            playerMovementPrototype.playerSpeed = 10;
            if (CurrentSTAM < MaxSTAM)
            { timecheckrest +=Time.deltaTime; }

            //if(CurrentSTAM < MaxSTAM)
            //{ CurrentSTAM += .1f; }
        }

        if (timecheck > 0.2  && CurrentSTAM > 0)
        {
            timecheckrest = 0;
            timecheck = 0.1f;
            CurrentSTAM -= 2;
        }

        if (timecheckrest > 0.1 )
                {
                    timecheckrest = 0;
                    CurrentSTAM += 0.1f;
                    Debug.Log("+5");
        
                }

        if (CurrentSTAM == MaxSTAM)
        {
            CurrentSTAM += 0;
            timecheckrest = 0;

        }

        HealthMeter.GetComponent<RectTransform>().localScale = new Vector3(CurrentHP / MaxHP, 1, 1);

        StaminaMeter.GetComponent<RectTransform>().localScale = new Vector3(CurrentSTAM / MaxSTAM, 1, 1);
    }

}