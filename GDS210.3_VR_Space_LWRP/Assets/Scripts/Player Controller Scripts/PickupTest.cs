using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class PickupTest : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject;
    private GameObject objectInHand;
    private GameObject sceneChanger;
    public SceneManagement sceneManagement;
    //public int sceneNumber;
    private void Start()
    {
        sceneManagement = FindObjectOfType<SceneManagement>();
    }
    //Sets what the colliding object is, if it can be picked up.
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }
    //If interacting with a scene changer, sets what object the scene changer is.
    private void SetSceneChanger(Collider col)
    {
        if (sceneChanger || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        sceneChanger = col.gameObject;
    }
    //Gets what the colliding object is; checking whether or not it's a Scene Changer.
    public void OnTriggerEnter(Collider other)
    {
        //SetCollidingObject(other);
        if (other.tag == "SceneChange")
        {
            SetSceneChanger(other);
        }
        else
            SetCollidingObject(other);
    }
    public void OnTriggerStay(Collider other)
    {
        //SetCollidingObject(other);
        if (other.tag == "SceneChange")
        {
            SetSceneChanger(other);
        }
        else
            SetCollidingObject(other);
    }
    public void OnTriggerExit(Collider other)
    {
        if(!collidingObject || !sceneChanger)
        {
            return;
        }
        collidingObject = null;
        sceneChanger = null;
    }
    //This function sets the colliding object to be the object in the player's hand.
    private void GrabObject()
    {
        //if(collidingObject.tag == "Props")
        //{
            objectInHand = collidingObject;
            collidingObject = null;

            var joint = AddFixedJoint();
            joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        //}
        
    }
    //This creates a fixed joint between the controller and the grabbed object to connect them
    //and allow them to be picked up.
   private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
    private void ReleaseObject()
    {
        
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }
        objectInHand = null;
    }

    // Update is called once per frame
    void Update()
    {
        //grabAction.GetLastStateDown is triggered when the Grab Action button (the trigger on the controller)
        //Is pushed all the way down, so a click is heard.
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        
        }

        //grabAction.GetLastStateUp is triggered when the Grab Action button is released.
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
            else if (sceneChanger)
            {
                //sceneChanger.GetComponent<SceneSetter>() ;
                sceneManagement.ChangeScene(sceneChanger.GetComponent<SceneSetter>().sceneIndexSetter);
            }
        }
    }
}
