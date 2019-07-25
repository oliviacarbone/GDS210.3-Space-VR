using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryBeyondButtons : MonoBehaviour
{
    public Material lightMat;
    public Material darkMat;

    private Renderer rend;

    public MemoryBeyondLogic mBL;

    public int buttonNumber;
    public delegate void ClickEv(int number);
    public event ClickEv OnClick;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    private void OnMouseDown()
    {
        if (mBL.player)
        {
            ClickedColor();
            OnClick.Invoke(buttonNumber);
        }
    }

    private void OnMouseUp()
    {
        UnclickedColor();
    }

    public void ClickedColor()
    {
        rend.sharedMaterial = lightMat;
    }

    public void UnclickedColor()
    {
        rend.sharedMaterial = darkMat;
    }        
}
