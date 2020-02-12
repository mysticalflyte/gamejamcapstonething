using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeacherController : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentdestination;
    private NavMeshAgent nav;
    private enum state { Patrol, Detect, Stop, RemoveSpill};
    private state currentstate;
    private Transform target;
    public bool looping = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;
        currentstate = state.Patrol;
        Patrol();
        // StartCoroutine(WaitForAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentstate == state.Patrol)
        {
            CheckPaintingAlert();
            if (!nav.pathPending && nav.remainingDistance < 0.5f)
            {
                Patrol();
            }
        }
    }


    // Attempt to get the alert from a painting if it's within range
    void CheckPaintingAlert()
    {
        //Debug.Log("CHECKING FOR PAINTING ALERT...");
        AlertRange painting = GameObject.FindWithTag("Painting").GetComponent<AlertRange>();
        if (painting != null)
        {
            // Debug.Log("PAINTING FOUND! NOT NULL!");
            if (painting.GetAlerting())
            {
                // Debug.Log("SWITCHING TO STOP STATE");
                target = painting.transform.parent.transform;
                nav.destination = target.position;
                currentstate = state.Stop;
            }
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
                nav.Stop();
            }
        }
    }

    public void StepInSpill(GameObject bucket, GameObject filledBucket, GameObject spilledBucket) {
        BucketState bucketScript = bucket.GetComponent<BucketState>();

        Vector3 targetPosition = waypoints[currentdestination].position;
        nav.destination = transform.position;
        currentstate = state.Stop;

        StartCoroutine(CleanUpSpill(bucketScript, spilledBucket, filledBucket, targetPosition));
    }

    private IEnumerator CleanUpSpill (BucketState bucketScript, 
                                      GameObject spilledBucket,
                                      GameObject filledBucket,
                                      Vector3 targetPosition) 
    {
        // Wait for 5 seconds while we clean up the spill
        yield return new WaitForSeconds(5);
        nav.destination = targetPosition;
        currentstate = state.Patrol;
        bucketScript.SetBucketState(bucketState.filled);

        spilledBucket.GetComponent<Renderer>().enabled = false;
        filledBucket.GetComponent<Renderer>().enabled = true;
    }

    /*public void Detect(Transform player) {
        nav.speed += 3;
        nav.destination = player.position;
        target = player;
        currentstate = state.Detect;
    }*/
}
