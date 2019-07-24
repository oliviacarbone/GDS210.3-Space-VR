using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPatternArrays : MonoBehaviour
{
    public MeshRenderer[] colours;

    private int randomColour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartGame()
    {
        randomColour = Random.Range(0, colours.Length);

        colours[randomColour].GetComponent < MeshRenderer >().material = 
    }
}
