using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    private Vector3 direction = Vector3.zero;
    private Vector3 startpos;
    public float speed = 5.0f;
    private float starttime;
    private float waittime = 2.0f;
    private bool moveable;
    private bool walking;
    public AudioSource footsteps;
    private Transform detected;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveable = true;
        walking = false;
        startpos = transform.position;
        starttime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), direction.y, Input.GetAxis("Vertical"));
            direction.x *= speed;
            direction.z *= speed;
            direction = transform.TransformDirection(direction);
            controller.Move(direction * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow)
                || Input.GetKeyDown(KeyCode.DownArrow))
            {
                footsteps.Play();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow)
                || Input.GetKeyUp(KeyCode.DownArrow))
            {
                footsteps.Stop();
            }
        }
        else {
            footsteps.Stop();
            starttime += Time.deltaTime;
            if (starttime > waittime)
            {
                transform.position = startpos;
                if (starttime > waittime * 1.5)
                {
                    moveable = true;
                    starttime = 0.0f;
                    detected.GetComponent<TeacherView>().ResetVars();
                }
            }
        }
    }

    public void Detected(Transform teacher) {
        //Debug.Log("DETECTED");
        //Debug.Log(startpos);
        moveable = false;
        detected = teacher;
    }
}
