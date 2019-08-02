using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterColony : MonoBehaviour
{
    public ColonyResources colResWater;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Water")
        {

            colResWater.IncreaseWater();
            Destroy(col.gameObject);
        }
    }

}
