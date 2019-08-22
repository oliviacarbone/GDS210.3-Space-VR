using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ResourceScript : MonoBehaviour
{
    //moves the resource after spawning
    public float thrust;
    public float thrust2;
    public Rigidbody rb;
    //a count down to ensure the object is deleted if it flies away
    public float countDown = 20f;

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    // Start is called before the first frame update
    void Start()
    {
        controllerPose = FindObjectOfType<SteamVR_Behaviour_Pose>();
        countDown = 25f;
        thrust = 100f;
        thrust2 = 3f;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust);
    }

    // Update is called once per frame
    void Update()
    {

        countDown -= Time.deltaTime;

        if (countDown < 0f)
        {
            Destroy(gameObject);
        }


        
    }

    //moves the resource after spawning
    void FixedUpdate()
    {
     
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LeftController" || other.gameObject.tag == "RightController")
        {
            if (grabAction.GetLastStateDown(handType))
            {
                rb.useGravity = true;
                rb.freezeRotation = false;
            }

        }
        else if (other.gameObject.tag == ("conveyor"))
        {
            rb.velocity = Vector3.left * thrust2;
        }
    }

}
