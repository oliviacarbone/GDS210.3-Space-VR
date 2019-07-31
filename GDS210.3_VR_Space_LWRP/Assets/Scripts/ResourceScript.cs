using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    public float countDown = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        countDown -= Time.deltaTime;

        if (countDown < 0f)
        {
            Destroy(gameObject);
        }
        
    }


}
