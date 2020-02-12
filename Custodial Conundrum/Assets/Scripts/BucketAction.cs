using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketAction : MonoBehaviour
{
    // Instantiate a Prefab with an attached Bucket script

    bool spilled;
    public GameObject bucket;
    public GameObject player;

    public SphereCollider playerCollider;

    void Start()
    {
        spilled = true;
    }

    public void SetSpilled(bool spill_state)
    {
        spilled = spill_state;
    }

    public bool GetSpilled()
    {
        return spilled;
    }

}