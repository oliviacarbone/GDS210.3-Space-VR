using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OTest_Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Resource"))
        {
            Destroy(other.gameObject);
        }
    }
}
