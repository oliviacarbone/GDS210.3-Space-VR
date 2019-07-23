using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //A reference to our rigidbody.
    private Rigidbody myRigidBody;
    //A reference to our main camera.
    private Camera mainCamera;
    //The length of our camera ray.
    public float rayLength;

    //A reference to our shot.
    public GameObject shot;
    //Where the shot will spawn.
    public Transform shotSpawn;
    //Our fire rate.
    public float fireRate;
    //A variable that helps with our fire rate.
    private float nextFire;

    void Start()
    {
        //Gets our rigidbody component.
        myRigidBody = GetComponent<Rigidbody>();
        //Finds our camera in the scene.
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        MouseRaycast();

        /*If we press the fire button and enough time has elapsed,
         *since our last shot, calls the ShotSpawn function. 
         */
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            ShotSpawn();
        }
    }

    //Handles how our player rotates in the world.
    void MouseRaycast()
    {
        //Draws a  ray to wherever the mouse is.
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        //The point in space we want our player to look at.
        Vector3 pointToLook = cameraRay.GetPoint(rayLength);
        //Draws a blue line along our look direction in the shape and length of our ray.
        Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

        //Rotates our player to the space we want them to look at.
        transform.LookAt(pointToLook);
    }

    //Handles how we shoot.
    void ShotSpawn()
    {
        //Handles our shooting cooldown. Sets nextfire to Time.time + the fireRate.
        nextFire = Time.time + fireRate;
        //Spawns our shot at our spawners location and rotation.
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
    }
}
