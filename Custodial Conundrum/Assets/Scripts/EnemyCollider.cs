using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    // Instantiate a Prefab with an attached Bucket script

    public GameObject bucket;
    public GameObject player;

    public BoxCollider enemyCollider;

    BucketAction bucketScript;
    
    void Start()
    {
        bucketScript = transform.parent.GetComponent<BucketAction>();  
    }

    private void OnTriggerStay(Collider other)
    {
        bool spilled = bucketScript.GetSpilled();
        if (other.gameObject.tag == "Teacher")
        {
            TeacherController teacherScript = other.gameObject.transform.parent.GetComponent<TeacherController>();
            if (spilled) {
                teacherScript.StepInSpill(bucket);
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