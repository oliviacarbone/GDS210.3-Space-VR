using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    //This script is made for Battery Defence
    private ECList posList;
    private GameObject currentPoint;
    private int index;
    public NavMeshAgent agent;
    public int waitTime = 10;
    public GameObject battery;

    void Awake()
    {
        posList = FindObjectOfType<ECList>();    
    }

    void Start()
    {
        //Start after 2 seconds and repeat every waitTime value
        InvokeRepeating("RandomPoint", 2, waitTime);
    }

    void Update()
    {
        LookTowards();    
    }

    void LookTowards()
    {
        //Makes the enemies always look at the battery
        transform.LookAt(battery.transform.position);
    }

    void RandomPoint()
    {
        //Picks a random value from the list's range
        index = Random.Range(0, posList.posPoints.Count);

        //Stops repoicking from the list
        if (currentPoint != null)
        {
            posList.posPoints.Add(currentPoint);
        }

        //Assigns the chosen index to currentPoint
        currentPoint = posList.posPoints[index];
        print (currentPoint.name);

        //Stops other enemies from picking the same point
        posList.posPoints.RemoveAt(index);
         
        //Moves the enemy to the chosen point
        agent.SetDestination(currentPoint.transform.position);        
    }

    
}
