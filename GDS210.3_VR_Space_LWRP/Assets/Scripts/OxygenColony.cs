using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenColony : MonoBehaviour
{
    public ColonyResources colResOxy;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Oxygen")
        {
            Debug.Log("Oxygen");
            colResOxy.IncreaseOxygen();
            Destroy(col.gameObject);
        }
    }

}
