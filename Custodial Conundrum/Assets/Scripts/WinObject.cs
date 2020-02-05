using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinObject : MonoBehaviour
{
    bool interactable;
    bool interacted;
    public Text winText;
    public AudioSource winSound;
    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
        interacted = false;
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                winText.enabled = true;
                winSound.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
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
