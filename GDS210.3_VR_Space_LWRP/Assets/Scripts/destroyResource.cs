using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyResource : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Oxygen"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Energy"))
        {
            Destroy(other.gameObject);
        }
    }
}
