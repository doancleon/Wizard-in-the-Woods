using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFire : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D wandRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        wandRigidBody.velocity = transform.right * speed;
    }


}
