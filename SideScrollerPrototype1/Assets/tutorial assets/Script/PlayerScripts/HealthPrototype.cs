using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPrototype : MonoBehaviour {

    public bool Died;
    public int Health;


    void Start() {
        Died = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            Die();
        }

    }

        void Die (){
            SceneManager.LoadScene("Prototype1");
        }


    
}
