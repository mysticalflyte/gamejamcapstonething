using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentListenRange : MonoBehaviour
{
    private Transform playerPos;
    private Canvas messageCanvas;
    private bool closeRange;
    private bool listenRange;

    // Start is called before the first frame update
    void Start()
    {
        closeRange = false;
        listenRange = false;
        messageCanvas = GameObject.Find("MessageCanvas").GetComponent<Canvas>();
        TurnOffSpeech();
    }

    // Update is called once per frame
    void Update()
    {
        if (listenRange && !closeRange) 
        {
            TurnOnSpeech();
        }
        else
        {
            TurnOffSpeech();
        }
    }

    private void TurnOnSpeech()
    {
        Debug.Log("Turned on speech!!");
        messageCanvas.enabled = true;
    }

    private void TurnOffSpeech()
    {
        //Debug.Log("Turned off speech!!");
        messageCanvas.enabled = false;
    }

    public void SetCloseRange( bool inRange)
    {
        closeRange = inRange;
    }

    public void SetListenRange(bool inRange)
    {
        listenRange = inRange;
    }


}
