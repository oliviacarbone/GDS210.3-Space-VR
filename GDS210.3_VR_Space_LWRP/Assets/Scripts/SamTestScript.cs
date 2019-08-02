using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
public class SamTestScript : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    public float pushYouWeakBishFloat;
    public Text pushYouWeakBishText;
    public GameObject startGameButton;
    // Start is called before the first frame update
    void Start()
    {
        startGameButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (grabAction.GetLastStateDown(handType))
        {
            if (startGameButton)
            {
                //start game here
              
            }
        }
        pushYouWeakBishFloat += Time.deltaTime;
        
        pushYouWeakBishText.text = pushYouWeakBishFloat.ToString("00");
        Debug.Log(pushYouWeakBishFloat);
        
    }
}
