using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTest : MonoBehaviour
{
    [SerializeField]
    Renderer renderColor;

    public void Hit()
    {
        renderColor.material.color = Color.red;

        Invoke("ChangeColor", 2);
    }

    void ChangeColor()
    {

        renderColor.material.color = Color.white;
    }

}
