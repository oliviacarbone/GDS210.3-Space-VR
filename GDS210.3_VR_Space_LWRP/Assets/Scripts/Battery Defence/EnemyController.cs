using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //This script is made for Battery Defence
    private ECList posList;
    private GameObject currentPoint;
    private int index;
    public NavMeshAgent agent;
    public int waitTime = 10;
    public GameObject battery;
    public bool dead = false;
    public bool playerDead = false;
    private GameObject cam;

    public float enemyDamage = 0.01f;

    void Awake()
    {
        posList = FindObjectOfType<ECList>();
        battery = GameObject.FindGameObjectWithTag("Battery");
        cam = GameObject.FindGameObjectWithTag("PlayerCamera");
    }

    void Start()
    {
        //Start and repeat every waitTime value
        InvokeRepeating("RandomPoint", 0, waitTime);
    }

    void Update()
    {
        LookTowards();
        DroneSpeed();
    }

    void LookTowards()
    {
        //Makes the enemies always look at the battery
        if (dead == false)
        {
            transform.LookAt(battery.transform.position);
        }

        if(playerDead == true)
        {
            transform.LookAt(cam.transform.position);
        }
    }

    void RandomPoint()
    {
        //Picks a random value from the list's range
        index = Random.Range(0, posList.posPoints.Count);

        //Stops repoicking from the list
        if (currentPoint != null)
        {
            ReturnPoint();
        }

        //Assigns the chosen index to currentPoint
        currentPoint = posList.posPoints[index];
        print (currentPoint.name);

        //Stops other enemies from picking the same point
        posList.posPoints.RemoveAt(index);

        //Moves the enemy to the chosen point
        agent.SetDestination(currentPoint.transform.position);
    }

    void DroneSpeed()
    {
        agent.speed = Vector3.Distance(transform.position, currentPoint.transform.position);
    }

    public void ReturnPoint()
    {
        posList.posPoints.Add(currentPoint);
    }
}
