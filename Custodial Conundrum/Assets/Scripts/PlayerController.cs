using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    private Vector3 direction = Vector3.zero;
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), direction.y, Input.GetAxis("Vertical"));
        direction.x *= speed;
        direction.z *= speed;
        direction = transform.TransformDirection(direction);
        controller.Move(direction * Time.deltaTime);
    }
}
