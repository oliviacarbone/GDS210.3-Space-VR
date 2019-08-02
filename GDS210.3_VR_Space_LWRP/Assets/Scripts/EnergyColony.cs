using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyColony : MonoBehaviour
{

    public ColonyResources colResEnergy;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Energy")
        {
            
            colResEnergy.IncreaseEnergy();
             Destroy(col.gameObject);
        }
    }
   
}
