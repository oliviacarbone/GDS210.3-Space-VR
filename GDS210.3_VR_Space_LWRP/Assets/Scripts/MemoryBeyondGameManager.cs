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
    public GameObject restartButton;

    public MemoryBeyondLogic mBL;

    private void Awake()
    {
        startButton.SetActive(true);
        restartButton.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (grabAction.GetLastStateDown(handType))
            {
                if (startButton)
                {
                    Debug.Log("fuck");
                    mBL.StartGame();
                }

                if (restartButton)
                {
                    mBL.RestartGame();
                }
            }
        }
    }
}
