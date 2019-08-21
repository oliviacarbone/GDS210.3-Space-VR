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
    private bool shouldTeleport;
    // Start is called before the first frame update
    void Start()
    {
        //Spawn the aiming laser.
        aimLaser = Instantiate(aimLaserPrefab);
        teleLaser = Instantiate(teleLaserPrefab);

        aimLaser.transform.parent = gameObject.transform;
        teleLaser.transform.parent = gameObject.transform;

        aimLaserTransform = aimLaser.transform;
        teleLaserTransform = teleLaser.transform;

        reticle = Instantiate(teleportReticlePrefab);
        reticle.transform.parent = gameObject.transform;

        teleportReticleTransform = reticle.transform;

        aimLaser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (teleportAction.GetState(handType))
        {
            aimLaser.SetActive(true);
            reticle.SetActive(true);

            RaycastHit hit;

            if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, teleportMask))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
                reticle.SetActive(true);

                teleportReticleTransform.position = hitPoint + teleportReticleOffset;

                shouldTeleport = true;
            }
        }
        else
        {
            teleLaser.SetActive(false);
            reticle.SetActive(false);
        }
        if(teleportAction.GetStateUp(handType) && shouldTeleport)
        {
            TeleportTo();
 
        }
        else
        {
            aimLaser.SetActive(false);
            reticle.SetActive(false);
        }
    }

    void ShowLaser(RaycastHit hit)
    {
        teleLaser.SetActive(true);
        aimLaser.SetActive(false);
        teleLaserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, 0.5f);

        teleLaserTransform.LookAt(hitPoint);

        teleLaserTransform.localScale = new Vector3(teleLaserTransform.localScale.x, teleLaserTransform.localScale.y, hit.distance);
    }

    void TeleportTo()
    {
        shouldTeleport = false;
        reticle.SetActive(false);

        Vector3 difference = cameraRigTransform.position - headTransform.position;

        difference.y = 0;

        cameraRigTransform.position = hitPoint + difference;
    }
}
