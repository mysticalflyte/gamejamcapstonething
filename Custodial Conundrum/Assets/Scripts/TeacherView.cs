using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherView : MonoBehaviour
{
    public float detectionAngle = 45.0f;
    private bool detecting = false;
    private RaycastHit hit;
    private Transform player;
    int layerMask = 1 << 8;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (detecting) {
            checkSight();
        }
    }

    private void checkSight() {
        Vector3 playerdir = (player.position - transform.position).normalized;
        Vector3 teacherdir = transform.forward;
        if (Mathf.Abs(Vector3.Angle(playerdir, teacherdir)) <= detectionAngle)
        {
            if (Physics.Raycast(transform.position, playerdir, out hit)) {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.DrawLine(player.position, transform.position, Color.green);
                    Debug.Log("In Angle!");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            Debug.Log("Player Detected!");
            player = other.transform;
            detecting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            player = null;
            detecting = false;
        }
    }
}
