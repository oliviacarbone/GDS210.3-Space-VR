using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class RestartBatteryDefence : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public GameObject startGameButton;

    public GameObject battery;
    public EnemyRandomSpawn ERS;

    private void Start()
    {
        ERS = FindObjectOfType<EnemyRandomSpawn>();
    }

    private void OnTriggerStay(Collider col)
    {
        if (ERS.buttonState == EnemyRandomSpawn.StartState.DoNothing)
        {
            if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
            {

                if (grabAction.GetLastStateDown(handType))
                {
                    ERS.buttonState = EnemyRandomSpawn.StartState.Start;
                    Instantiate(battery);
                }
            }
        }
    }    
    
}
