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
    //To start the timer.
    public TimeScript time;
   
    public bool startGame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //startGame = true;
    }

    // Update is called once per frame
    void Update()
    {

     
        

    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Fuck");
            if (grabAction.GetLastStateDown(handType))
            {
                if (startGameButton)
                {
                    time.StartTheGame();
                    startGame = true;

                }
            }
        }
        
    }


}
