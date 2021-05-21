using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        camPos = player.position;
        camPos.z = -30;
        transform.position = camPos;
    }

    // Update is called once per frame
    void Update()
    {
        camPos = player.position;
        camPos.z = -30;
        transform.position = camPos;
    }
}
