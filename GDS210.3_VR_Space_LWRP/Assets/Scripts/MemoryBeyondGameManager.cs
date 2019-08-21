using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MemoryBeyondGameManager : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public GameObject startButton;

    public MemoryBeyondLogic mBL;

    private void Awake()
    {
        startButton.SetActive(true);
        controllerPose = FindObjectOfType<SteamVR_Behaviour_Pose>();
    }

    private void OnMouseDown()
    {
        mBL.StartGame();
        gameObject.SetActive(false);
        Debug.Log("Deleted");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "LeftController" || other.gameObject.tag == "RightController")
        {
            if (grabAction.GetLastStateDown(handType))
            {
                if (startButton)
                {
                    Debug.Log("test");
                    //mBL.state = MemoryBeyondLogic.StartTheGameState.Start;
                    mBL.StartGame();
                }
            }
        }
    }
}
