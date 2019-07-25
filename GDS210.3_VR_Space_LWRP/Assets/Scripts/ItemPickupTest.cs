using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ItemPickupTest : MonoBehaviour
{
    //create reference to the input from controllers
    public SteamVR_Input_Sources hands;

    //an example of an action, can be any data type
    public SteamVR_Action_Boolean isPressed;

    //public reference that lets you link the above action to an input on the controller
    public bool PressButton()
    {
        return isPressed.GetStateDown(hands);
    }


    // Update is called once per frame
    void Update()
    {
        //do the thing
        if (PressButton())
        {
            print("ButtonPressed");
        }
    }
}
