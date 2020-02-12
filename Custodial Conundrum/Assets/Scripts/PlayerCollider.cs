using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Instantiate a Prefab with an attached Bucket script

    public GameObject bucket;
    public GameObject player;

    public SphereCollider playerCollider;

    private float R_lastPressed;

    BucketAction bucketScript;

    void Start()
    {
        bucketScript = transform.parent.GetComponent<BucketAction>();  
        R_lastPressed = Time.time;
    }

    void Update()
    {
        bool spilled = bucketScript.GetSpilled();
        // R was pressed, spill the bucket
        if (Input.GetKeyDown(KeyCode.R) && !spilled && (Time.time - R_lastPressed) > .5f )
        {
            bucketScript.SetSpilled(true);
            bucket.transform.position = player.transform.rotation * (player.transform.position + new Vector3(0f,0f,1f));
            bucket.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        bool spilled = bucketScript.GetSpilled();
        if (other.gameObject.tag == "Player") {
            if (Input.GetKeyDown(KeyCode.C)) {
                Debug.Log(other.gameObject.name);
            }
            if (Input.GetKeyDown(KeyCode.R) && spilled) {
                R_lastPressed = Time.time;
                bucket.GetComponent<Renderer>().enabled = false;
                bucketScript.SetSpilled(false);
            }
        }
    }
}