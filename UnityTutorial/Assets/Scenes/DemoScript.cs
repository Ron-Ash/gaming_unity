using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// If we want to have our own classes but we want unity to recognise and display its data.
// So we need to add the [System.Serializable] directive that will make Unity recognise it.
[System.Serializable]
public class MyDateClass{
    public int myInt;
    public string myString;
}

public class DemoScript : MonoBehaviour {

    public Light myLight;
    public MyDateClass myData;

    private Rigidbody myRigidbody;
    private Rigidbody copyOfMyRigidbody;

    // Order of Event execution: https://docs.unity3d.com/Manual/ExecutionOrder.html 

    // Awake is used to initialize any variables or game state before the game starts. 
    // it is called Before the Start function. It will be called on the first frame of the game if the object is intiantiated.
    // If you create the object during the game, it will be called then. If the object is not active, it will be called when the
    // object becomes active
    // Awake is called only once during the lifetime of the script instance. 
    // Awake is called after all objects are initialized so you can safely speak to other objects or query them using for example GameObject.FindWithTag. 
    public void Awake()
    {
        int number = AddNumbers(2,9);
        Debug.Log(number);

        myRigidbody = GetComponent <Rigidbody>();                                           // will return the Rigidbody component of the current game object
        copyOfMyRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();     // will find the 1st game object with Tag "Player" and will get the Rigidbody component from it.
    }

    // Will be called after Awake if the object is active
    private void Start()
    {
            
    }
    
    // Called automatically by Unity for every component in the scene, on every frame,  BEFORE Unity Renders the Frame. 
    public void Update()
    {
        // check the input key from the user:
        if(Input.GetKeyDown("space"))
        {
            ToggleLight();
        }      
        
    }


    // Called when we want to do physics work, we can use the FixedUpdate to call the update at regular intervals and not once per-frame.
    // Used for long calculations that we don't want to do for every single frame.
    private void FixedUpdate()
    {
        
    }

    // Will be called after all the regular Updates.
    // Used when the updates can change the data we need to perform this LateUpdate
    private void LateUpdate()
    {
        
    }

    private void ToggleLight()
    {
        myLight.enabled = !myLight.enabled;
    }

    private int AddNumbers(int num1, int num2)
    {
        return (num1 + num2);
    }


}
