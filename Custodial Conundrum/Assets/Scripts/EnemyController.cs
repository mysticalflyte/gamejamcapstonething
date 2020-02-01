using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentdestination;
    private NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;
        Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f) {
            Patrol();
        }
    }

    void Patrol() {
        if (waypoints.Length == 0) {
            return;
        }
        nav.destination = waypoints[currentdestination].position;
        //nav.destination = transform.TransformPoint(nav.destination);
        Debug.Log(nav.destination);
        currentdestination = (currentdestination + 1) % waypoints.Length;
    }
}
