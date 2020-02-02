using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertRange : MonoBehaviour
{
    //StudentListenRange studentEnemy;
    ObjectInteract paintingInteract;
    bool alerting;

    // Start is called before the first frame update
    void Start()
    {
        // Really convoluted way to get the sibling object I want, I'm sorry!
        paintingInteract = transform.parent.gameObject.transform.GetChild(0).GetComponent<ObjectInteract>();
        alerting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alerting && paintingInteract.GetInteracted())
        {
            Debug.Log("Painting was interacted with from AlertRange!");
            alerting = true;
        }
    }

    public bool GetAlerting()
    {
        return alerting;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Detected in CLOSE RANGE!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Exited from CLOSE RANGE!");
        }
    }
}
