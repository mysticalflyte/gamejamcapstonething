using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 cameradistance;
    [Range(0.01f, 1.0f)]
    public float smoothing = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        cameradistance = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 pos = player.position + cameradistance;
        pos = Vector3.Lerp(transform.position, pos, smoothing);
        transform.position = pos;
        //adds weird rotation when added, check in actual game
        //transform.LookAt(player);
    }
}
