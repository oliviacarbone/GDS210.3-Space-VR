using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class VRSceneChange : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean touchButton;

    public SceneManagement sceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        sceneManagement = FindObjectOfType<SceneManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
