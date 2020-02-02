using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRangeDetection : MonoBehaviour
{
    StudentListenRange studentEnemy;

    // Start is called before the first frame update
    void Start()
    {
        studentEnemy = transform.parent.GetComponent<StudentListenRange>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Detected in CLOSE RANGE!");
            studentEnemy.SetCloseRange(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Exited from CLOSE RANGE!");
            studentEnemy.SetCloseRange(false);
        }
    }
}
