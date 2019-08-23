using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Teleport : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean teleportAction;

    public GameObject aimLaserPrefab;
    public GameObject teleLaserPrefab;
    private GameObject aimLaser;
    private GameObject teleLaser;
    private Transform aimLaserTransform;
    private Transform teleLaserTransform;
    private Vector3 hitPoint;

    public Transform cameraRigTransform;
    public GameObject teleportReticlePrefab;
    private GameObject reticle;
    private Transform teleportReticleTransform;
    public Transform headTransform;
    public Vector3 teleportReticleOffset;
    public LayerMask teleportMask;
<<<<<<< HEAD
    public bool shouldTeleport;

    public LineRenderer lineR;

    bool showLine;
=======
    private bool shouldTeleport;
>>>>>>> d29c5b1c41890510b48e8a0516cf30e6a957ac7b
    // Start is called before the first frame update
    void Start()
    {
        //Spawn the aiming laser.
<<<<<<< HEAD
        //aimLaser = Instantiate(aimLaserPrefab);
       //teleLaser = Instantiate(teleLaserPrefab);
=======
        aimLaser = Instantiate(aimLaserPrefab);
        teleLaser = Instantiate(teleLaserPrefab);
>>>>>>> d29c5b1c41890510b48e8a0516cf30e6a957ac7b

        aimLaser.transform.parent = gameObject.transform;
        teleLaser.transform.parent = gameObject.transform;

        aimLaserTransform = aimLaser.transform;
        teleLaserTransform = teleLaser.transform;

<<<<<<< HEAD
       // reticle = Instantiate(teleportReticlePrefab);
       // reticle.transform.parent = gameObject.transform;

       // teleportReticleTransform = reticle.transform;
=======
        reticle = Instantiate(teleportReticlePrefab);
        reticle.transform.parent = gameObject.transform;

        teleportReticleTransform = reticle.transform;
>>>>>>> d29c5b1c41890510b48e8a0516cf30e6a957ac7b

        aimLaser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

<<<<<<< HEAD
       
        if (teleportAction.GetStateDown(handType))
        {

            showLine = true;
=======
        
        if (teleportAction.GetState(handType))
        {
            
>>>>>>> d29c5b1c41890510b48e8a0516cf30e6a957ac7b

            RaycastHit hit;

            Debug.DrawRay(controllerPose.transform.position, transform.forward * 100, Color.blue);
            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
            {
                
                hitPoint = hit.point;
<<<<<<< HEAD
                //ShowTeleLaser(hit);
                //reticle.SetActive(true);
=======
                ShowTeleLaser(hit);
                reticle.SetActive(true);
>>>>>>> d29c5b1c41890510b48e8a0516cf30e6a957ac7b

                //teleportReticleTransform.position = hitPoint + teleportReticleOffset;

                shouldTeleport = true;
                
                
            }
            else
            {
                hitPoint = hit.point;
                ShowAimLaser(hit);
                reticle.SetActive(true);
                teleportReticleTransform.position = hitPoint + teleportReticleOffset;

                
            }
        }
        /*else
        {
            teleLaser.SetActive(false);
            reticle.SetActive(false);
        }*/
        if(teleportAction.GetStateUp(handType) && shouldTeleport)
        {
            TeleportTo();
 
        }
<<<<<<< HEAD
       /* else if (teleportAction.GetStateUp(handType))
        {
            showLine = false;
        }*/
        /*
=======
>>>>>>> d29c5b1c41890510b48e8a0516cf30e6a957ac7b
        else
        {
            aimLaser.SetActive(false);
            reticle.SetActive(false);
        }
    }

    void ShowAimLaser(RaycastHit hit)
    {
        aimLaser.SetActive(true);
        teleLaser.SetActive(false);

        aimLaserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, 0.5f);

        aimLaserTransform.LookAt(hitPoint);

        aimLaser.transform.localScale = new Vector3(aimLaserTransform.localScale.x, aimLaserTransform.localScale.y, hit.distance);

    }
    void ShowTeleLaser(RaycastHit hit)
    {
        teleLaser.SetActive(true);
        aimLaser.SetActive(false);
        teleLaserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, 0.5f);

        teleLaserTransform.LookAt(hitPoint);

        teleLaserTransform.localScale = new Vector3(teleLaserTransform.localScale.x, teleLaserTransform.localScale.y, hit.distance);
    }

<<<<<<< HEAD
    void ShowLine()
    {

        if (showLine == true)
        {
            Debug.Log("Line On");
            lineR.enabled = true;
            //set the start position of the line renderer
            lineR.SetPosition(0, transform.position);
            //set the end position of the line renderer
            lineR.SetPosition(1, transform.position + transform.forward * 100);
            //set the color of the line renderer
            lineR.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (showLine == false)
        {
            Debug.Log("Line Off");
            lineR.enabled = false;
        }
    }

=======
>>>>>>> d29c5b1c41890510b48e8a0516cf30e6a957ac7b
    void TeleportTo()
    {
        cameraRigTransform.position = hitPoint;
        shouldTeleport = false;
        showLine = false;
        // Vector3 difference = cameraRigTransform.position - headTransform.position;
        // cameraRigTransform.position = hitPoint + difference;


        //reticle.SetActive(false);




        //difference.y = 0;


    }
}
