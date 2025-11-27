using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    public Transform jukebox; 
    public List<Transform> waypoints; 
    public float moveSpeed = 1.5f;

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;
    private bool isGoingToJukebox = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;       
        if (waypoints.Count > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
        else
        {            
            GoToJukebox();
        }
    }
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (!isGoingToJukebox)
            {               
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;              
                if (currentWaypointIndex == 0)
                {
                    GoToJukebox();
                }
                else
                {
                    agent.SetDestination(waypoints[currentWaypointIndex].position);
                }
            }
            
            else
            {
                agent.isStopped = true;
            }
        }
    }

    void GoToJukebox()
    {
        isGoingToJukebox = true;        
        agent.SetDestination(jukebox.position);
    }
}
