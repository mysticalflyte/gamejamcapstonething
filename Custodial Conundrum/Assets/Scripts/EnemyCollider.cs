using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    // Instantiate a Prefab with an attached Bucket script

    public GameObject bucket;
    public GameObject filledBucket;
    public GameObject spilledBucket;
    public GameObject player;

    public BoxCollider enemyCollider;

    BucketState bucketScript;
    
    void Start()
    {
        bucketScript = bucket.GetComponent<BucketState>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        bucketState spillState = bucketScript.GetBucketState();
        if (other.gameObject.tag == "Teacher")
        {
            TeacherController teacherScript = other.gameObject.transform.parent.GetComponent<TeacherController>();
            if (spillState == bucketState.spilled) {
                bucketScript.SetBucketState(bucketState.teacher);
                teacherScript.StepInSpill(bucket, filledBucket, spilledBucket);
            //     // Do something...
            }
        }
        if (other.gameObject.tag == "Student") {
            // if (spilled) {
                // Do something...
            // }
        }
    }
}