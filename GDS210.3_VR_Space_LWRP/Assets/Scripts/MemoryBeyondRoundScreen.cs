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
        roundText.text = "Round " + mBL.round;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
