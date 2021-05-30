using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFire : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D wandRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        wandRigidBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "bf" || enemy.gameObject.tag == "bat" || enemy.gameObject.tag == "spider")
        {
            Destroy(gameObject);
        }
    }


}
