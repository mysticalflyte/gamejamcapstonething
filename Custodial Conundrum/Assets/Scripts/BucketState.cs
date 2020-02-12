using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bucketState { spilled, filled, held, teacher};

public class BucketState : MonoBehaviour
{
    // Instantiate a Prefab with an attached Bucket script

    public bucketState currentState;
    public GameObject filledBucket;
    public GameObject spilledBucket;
    public GameObject player;

    void Start()
    {
        currentState = bucketState.held;
        spilledBucket.GetComponent<Renderer>().enabled = false;
        filledBucket.GetComponent<Renderer>().enabled = false;
    }

    public void SetBucketState(bucketState new_state)
    {
        currentState = new_state;
    }

    public bucketState GetBucketState()
    {
        return currentState;
    }

}