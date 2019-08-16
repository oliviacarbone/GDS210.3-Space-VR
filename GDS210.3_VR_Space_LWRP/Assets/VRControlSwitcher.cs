using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;
public class VRControlSwitcher : MonoBehaviour
{
    public GameObject leftGun;
    public GameObject rightGun;

    public GameObject leftController;
    public GameObject rightController;

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean handheldSwitch;

    bool gunsActive;
    
     
    void Awake()
    {
        leftGun = GameObject.FindWithTag("LeftGun");
        rightGun = GameObject.FindWithTag("RightGun");
        leftController = GameObject.FindWithTag("LeftController");
        rightController = GameObject.FindWithTag("RightController");


        leftGun.SetActive(false);
        rightGun.SetActive(false);
        gunsActive = false;
    }
  

    // Update is called once per frame
    void Update()
    {
        if (handheldSwitch.GetState(handType) && SceneManager.GetActiveScene().name == "BatteryDefence")
        {
            EquipSwitch();
        }
    }

    void EquipSwitch()
    {
        if(gunsActive == false)
        {

            leftGun.SetActive(false);
            rightGun.SetActive(false);

            leftController.GetComponent<PickupTest>().enabled = true;
            leftController.GetComponent<Teleport>().enabled = true;

            rightController.GetComponent<PickupTest>().enabled = true;
            rightController.GetComponent<Teleport>().enabled = true;

            gunsActive = true;
        }
        else if(gunsActive == true)
        {
            leftGun.SetActive(true);
            rightGun.SetActive(true);

            leftController.GetComponent<PickupTest>().enabled = false;
            leftController.GetComponent<Teleport>().enabled = false;

            rightController.GetComponent<PickupTest>().enabled = false;
            rightController.GetComponent<Teleport>().enabled = false;

            gunsActive = false;
        }
    }
}
