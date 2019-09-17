using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class ExitTheGame : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
        {
            if (grabAction.GetLastStateDown(handType))
            {
                Application.Quit();
            }
        }
    }
}
