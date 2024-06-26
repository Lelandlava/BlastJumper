using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Nathon Polling
public class SlamAttack : MonoBehaviour
{
    private Rigidbody rb;
    public float slamSpeed = 70;
    public float currentSpeed;
    public bool allowSlam = false;
    public Text speedText;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the text with the current speed
        speedText.text = "Speed: " + currentSpeed.ToString("F2"); // F2 formats to two decimal places

        // Check if Rigidbody is not null
        if (rb != null)
        {
            currentSpeed = rb.velocity.magnitude;
            // Access and print the velocity of the Rigidbody
            //Debug.Log("Velocity: " + rb.velocity.magnitude);
            //Store the variable
            
        }
        else
        {
            // check if Rigidbody is not found
            Debug.LogError("Rigidbody component not found!");
        }

        //Check if speed allows a slam
        if(currentSpeed >= slamSpeed)
        {
            allowSlam = true;
        }
        else
        {
            allowSlam = false;
        }
    }
}
