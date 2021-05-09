using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public float walkDist = 5;
    private Vector3 changedPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changedPos = transform.position;
        changedPos.x += (Mathf.PingPong(Time.time, walkDist) - (walkDist / 2)) * .005f;

        transform.position = changedPos;
    }
}
