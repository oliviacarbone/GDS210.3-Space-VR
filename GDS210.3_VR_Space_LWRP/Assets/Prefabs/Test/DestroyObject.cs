using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBox", 2f);
    }

    void DestroyBox()
    {
        Destroy(gameObject);
    }
}
