using UnityEngine;
using Valve.VR;

public class StartBatteryDefence : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    public GameObject startGameButton;

    public EnemyRandomSpawn ERS;

    //public enum ButtonState { Start, DoNothing};
    // public ButtonState state = ButtonState.Start;

    public TimeScript time;

    public ScoreScript restartScore;

    public bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
        controllerPose = FindObjectOfType<SteamVR_Behaviour_Pose>();
        ERS = FindObjectOfType<EnemyRandomSpawn>();

        restartScore = FindObjectOfType<ScoreScript>();
        time = FindObjectOfType<TimeScript>();

       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider col)
    {
        if (ERS.buttonState == EnemyRandomSpawn.StartState.Start)
        {
            if (col.gameObject.tag == "LeftController" || col.gameObject.tag == "RightController")
            {

                if (grabAction.GetLastStateDown(handType))
                {
                    // if (startGameButton)
                    // {
                    ERS.state = EnemyRandomSpawn.SpawnState.Countdown;
                    ERS.buttonState = EnemyRandomSpawn.StartState.DoNothing;

                    print("Start Button Pressed");
                        ERS.nextWave = 0;
                        //startGame = true;
                        //restartScore.gameIsOver = false;
                        //time.StartTheGame();
                    //}
                }
            }
        }
    }
}

