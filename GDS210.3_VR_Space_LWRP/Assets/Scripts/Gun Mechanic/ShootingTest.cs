using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTest : MonoBehaviour
{
    [SerializeField]
    Renderer renderColor;

    public void Hit()
    {
        //Turns test drown red if hit 
        renderColor.material.color = Color.red;

        //Calls ChangeColor() after 2 seconds
        Invoke("ChangeColor", 2);
    }

    void ChangeColor()
    {
        //Turns Test drone green
        renderColor.material.color = Color.white;
    }

}
