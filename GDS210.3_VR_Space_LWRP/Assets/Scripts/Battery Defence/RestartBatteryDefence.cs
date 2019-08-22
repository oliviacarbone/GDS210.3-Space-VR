using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class RestartBatteryDefence : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public GameObject startGameButton;

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
        {

            if (grabAction.GetLastStateDown(handType))
            {
                SceneManager.LoadScene("BatteryDefence");
            }
        }
    }    
    
}
