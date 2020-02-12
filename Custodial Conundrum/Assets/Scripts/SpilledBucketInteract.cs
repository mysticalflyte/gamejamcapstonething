using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpilledBucketInteract : MonoBehaviour
{
    //StudentListenRange studentEnemy;
    ObjectInteract bucketInteract;
    bool alerting;

    // Start is called before the first frame update
    void Start()
    {
        // Really convoluted way to get the sibling object I want, I'm sorry!
        // paintingInteract = transform.parent.gameObject.transform.GetChild(0).GetComponent<ObjectInteract>();
        // alerting = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!alerting && paintingInteract.GetInteracted())
        // {
        //     Debug.Log("Painting was interacted with from AlertRange!");
        //     alerting = true;
        // }
    }

    // public bool GetAlerting()
    // {
    //     return alerting;
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teacher")
        {
            Debug.Log("Teacher stepped in the bucket");
        }
        if (other.gameObject.tag == "Student") {
            Debug.Log("Student stepped in the bucket");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if (other.gameObject.tag == "Player")
        // {
        //     Debug.Log("Player Exited from CLOSE RANGE!");
        // }
    }
}
