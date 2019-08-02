using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MemoryBeyondButtons : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;

    private GameObject collidingObject;
    private GameObject objectInHand;

    public Material lightMat;
    public Material darkMat;

    private Renderer rend;
    private Renderer[] testRend;

    public MemoryBeyondLogic mBL;

    public int buttonNumber;
    public delegate void ClickEv(int number);
    public event ClickEv OnClick;

    void Awake()
    {
        testRend = GetComponentsInChildren<Renderer>();

        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
    }

    void Update()
    {
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                if (mBL.player)
                {
                    ClickedColor();
                    OnClick.Invoke(buttonNumber);
                }
            }
        }

        if (grabAction.GetLastStateUp(handType))
        {
            UnclickedColor();
        }
    }

    private void OnMouseDown()
    {
        if (mBL.player)
        {
            ClickedColor();
            OnClick.Invoke(buttonNumber);
        }
    }

    private void OnMouseUp()
    {
        UnclickedColor();
    }

    public void ClickedColor()
    {
        //rend.sharedMaterial = lightMat;
        foreach (Renderer r in testRend)
        {
            r.enabled = true;
            r.sharedMaterial = lightMat;
        }
        foreach (Renderer r in testRend)
        {
            r.enabled = true;
            r.sharedMaterial = lightMat;
        }
    }

    public void UnclickedColor()
    {
        //rend.sharedMaterial = darkMat;
        foreach (Renderer r in testRend)
        {
            r.enabled = true;
            r.sharedMaterial = darkMat;
        }
    }

    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }
}
