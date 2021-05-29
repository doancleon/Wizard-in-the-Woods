using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public AnimationCurve bounce;
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
        changedPos.x += (Mathf.PingPong(Time.time, walkDist) - (walkDist / 2)) * .01f;
        changedPos.y += Mathf.Lerp(0, bounce.Evaluate(Time.time), Time.time) * .01f; ;

        transform.position = changedPos;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "bubble")
        {
            Destroy(gameObject);
        }
    }
}
