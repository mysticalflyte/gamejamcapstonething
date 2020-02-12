using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Instantiate a Prefab with an attached Bucket script
    public GameObject bucket;
    public GameObject filledBucket;
    public GameObject spilledBucket;
    public GameObject player;

    private float R_lastPressed;

    BucketState bucketScript;

    void Start()
    {
        bucketScript = transform.parent.GetComponent<BucketState>();  
        R_lastPressed = Time.time;
    }

    void Update()
    {
        bucketState spillState = bucketScript.GetBucketState();
        // R was pressed, spill the bucket
        if (Input.GetKeyDown(KeyCode.R) && (spillState == bucketState.held) && (Time.time - R_lastPressed) > .5f )
        {
            bucketScript.SetBucketState(bucketState.spilled);
            bucket.transform.position = player.transform.rotation * (player.transform.position + new Vector3(0f,0f,1f));
            spilledBucket.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        bucketState spillState = bucketScript.GetBucketState();
        if (other.gameObject.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.R) && 
                (spillState == bucketState.spilled || spillState == bucketState.filled)) {
                R_lastPressed = Time.time;
                spilledBucket.GetComponent<Renderer>().enabled = false;
                filledBucket.GetComponent<Renderer>().enabled = false;
                bucketScript.SetBucketState(bucketState.held);
            }
        }
    }
}