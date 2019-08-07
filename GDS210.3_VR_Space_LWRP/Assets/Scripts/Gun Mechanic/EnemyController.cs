using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public GameObject[] posPoints;
    private GameObject currentPoint;
    private int index;
    public NavMeshAgent agent;
    public bool positioning;
    public bool positioned;

    void Start()
    {
        positioning = false;    
    }

    void Update()
    {
        //InvokeRepeating("RandomPoint", 2, 10);

        if (positioning == false)
        {
            RandomPoint();
        }      
    }

    void RandomPoint()
    {
        string destination;

        index = Random.Range(0, posPoints.Length);
        currentPoint = posPoints[index];
        print (currentPoint.name);

        destination = currentPoint.name;
         
        agent.SetDestination(currentPoint.transform.position);

        positioning = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PositionPoint")
        {
            positioned = true;
            positioning = false;
            print("Positioned!");
        }
    }
}
