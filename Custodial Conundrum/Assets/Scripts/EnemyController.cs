using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentdestination;
    private NavMeshAgent nav;
    private enum state { Patrol, Detect };
    private state currentstate;
    private Transform target;
    public bool looping = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;
        nav.Warp(transform.position);
        currentstate = state.Patrol;
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
        currentdestination = (currentdestination + 1);
        if (looping) {
            currentdestination %= waypoints.Length;
        }
        else {
            if (currentdestination == waypoints.Length + 1) {
                nav.isStopped = true;
            }
        }
    }

    /*public void Detect(Transform player) {
        nav.speed += 3;
        nav.destination = player.position;
        target = player;
        currentstate = state.Detect;
    }*/
}
