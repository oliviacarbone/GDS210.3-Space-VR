using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class StartColonyGame : MonoBehaviour
{
    //To prevent spamming the start button.
    public enum ButtonState { Start, DoNothing };
    public ButtonState state = ButtonState.Start;

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public GameObject startGameButton;
    //To start the timer.
    public TimeScript time;
    //
    public ScoreScript restartScore;
   
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
        if (state == ButtonState.Start)
        {
            if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
            {

                if (grabAction.GetLastStateDown(handType))
                {
                    if (startGameButton)
                    {
                        //FindObjectOfType<AudioManager>().Play("CM_Theme");
                        restartScore.gameIsOver = false;
                        time.StartTheGame();
                        startGame = true;
                        state = ButtonState.DoNothing;
                    }
                }
            }
        }
        
    }


}
