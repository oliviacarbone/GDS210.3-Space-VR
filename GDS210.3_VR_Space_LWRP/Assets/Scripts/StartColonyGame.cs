using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartColonyGame : MonoBehaviour
{
    public float thrust = 3000000f;
    public Rigidbody rb;
    public bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
        startGame = true;
        rb.AddForce(transform.forward * thrust);
    }
}
