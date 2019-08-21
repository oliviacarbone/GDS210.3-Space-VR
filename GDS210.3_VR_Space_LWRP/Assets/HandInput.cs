using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class HandInput : MonoBehaviour
{
    HandController myHandController;

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;


    // Start is called before the first frame update
    void Start()
    {
        controllerPose = GetComponentInParent<SteamVR_Behaviour_Pose>();
        myHandController = GetComponent<HandController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (grabAction.GetLastStateDown(handType))
        {
            myHandController.ScaleClawAnimation(0f);
        }

        if (grabAction.GetLastStateUp(handType))
        {
            myHandController.ScaleClawAnimation(0.99f);
        }
        /*if (Input.GetAxis("Oculus_GearVR_LIndexTrigger") > 0)
        {
            myHandController.ScaleClawAnimation(Mathf.Clamp(Input.GetAxis("Oculus_GearVR_LIndexTrigger"), 0f, 0.99f));
        }

        if (Input.GetAxis("Oculus_GearVR_RIndexTrigger") > 0)
        {
            myHandController.ScaleClawAnimation(Mathf.Clamp(Input.GetAxis("Oculus_GearVR_LIndexTrigger"), 0f, 0.99f));
        }*/
    }
}
