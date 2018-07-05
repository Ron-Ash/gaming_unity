using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerSystemPrototype : MonoBehaviour {

    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    Vector3 mousePosition;
    Camera mainCamera;
    PlayerMobility playerMobility;
    float zValue = 0.0f;
    float mod = 0.05f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMobility = player.GetComponent<PlayerMobility>();
        mainCamera = GetComponent<Camera>();
        mainCamera = Camera.main;
        mainCamera.orthographicSize = 2.5f;
    }

    void FixedUpdate()
    {
        cameraEffects();

        if(Input.GetKey(KeyCode.LeftShift))
        {
            mainCamera.orthographicSize = 25f;
            playerMobility.setMoving(false);
            lookAhead();
        }
        else
        {
            mainCamera.orthographicSize = 2.5f;
            followPlayer();
        }  
    }

    void followPlayer()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }

    void lookAhead()
    {
        Vector3 cameraPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 direction = cameraPosition-this.transform.position;
        transform.Translate(direction * 1 * Time.deltaTime);
    }

    void cameraEffects()
    {
        if(playerMobility.moving == true)
        {
            Vector3 rotation = new Vector3(0, 0, zValue);
            this.transform.eulerAngles = rotation;
            zValue += mod;

            if(transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f)
            {
                mod = -0.05f;
            }

            else if(transform.eulerAngles.z < 355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.05f;
            }
        }
    }
}
