using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryBeyondRoundScreen : MonoBehaviour
{
    public Text roundText;
    public MemoryBeyondLogic mBL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Round();
    }

    public void Round()
    {
        if (mBL.roundScreen == true)
        {
            roundText.text = "round: " + mBL.round;
        }
    }
}
