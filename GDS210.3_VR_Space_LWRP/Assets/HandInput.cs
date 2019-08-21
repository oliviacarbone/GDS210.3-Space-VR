using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInput : MonoBehaviour
{
    HandController myHandController;
    // Start is called before the first frame update
    void Start()
    {
        myHandController = GetComponentInChildren<HandController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Oculus_GearVR_LIndexTrigger") > 0)
        {
            myHandController.ScaleClawAnimation(Mathf.Clamp(Input.GetAxis("Oculus_GearVR_LIndexTrigger"), 0f, 0.99f));
        }

        if (Input.GetAxis("Oculus_GearVR_RIndexTrigger") > 0)
        {
            myHandController.ScaleClawAnimation(Mathf.Clamp(Input.GetAxis("Oculus_GearVR_LIndexTrigger"), 0f, 0.99f));
        }
    }
}
