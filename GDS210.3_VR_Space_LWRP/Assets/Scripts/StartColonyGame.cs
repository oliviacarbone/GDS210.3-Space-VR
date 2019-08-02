using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class StartColonyGame : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public GameObject startGameButton;
   
    public bool startGame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (grabAction.GetLastStateDown(handType))
        {
            if (startGameButton)
            {
                startGame = true;

            }
        }
        

    }

  
}
