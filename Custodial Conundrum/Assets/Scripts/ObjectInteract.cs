using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    bool interactable;
    bool interacted;
    public AudioSource breakSound;
    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
        interacted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("Painting WAS INTERACTED WITH!!!!");
                transform.parent.GetComponent<Rigidbody>().useGravity = true;
                breakSound.Play();
                interacted = true;
            }
        }
    }

    public bool GetInteracted()
    {
        return interacted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactable = false;
        }
    }
}
