using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1.5f;
    private float jumpH = 7.5f;
    private bool grounded = true;
    public Transform feet;
    public LayerMask groundL;
    public Animator walk_animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * jumpH, ForceMode2D.Impulse);
        }

        //check if player is on the ground
        grounded = Physics2D.OverlapCircle(feet.position, .2f, groundL);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))   //left
        {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            rb.transform.Translate(new Vector2(speed/10f, 0));
            if (grounded)
            {
                StartCoroutine("walk_animation");
            }
        }
        else if (Input.GetKey(KeyCode.D))   //right
        {
            rb.transform.rotation = Quaternion.Euler(Vector3.forward);
            rb.transform.Translate(new Vector2(speed/10f, 0));
            if (grounded)
            {
                StartCoroutine("walk_animation");
            }

        }
    }
    IEnumerator walk_animation()
    {
        walk_animator.SetBool("Walking", true);
        yield return new WaitForSeconds(0.01f);
        walk_animator.SetBool("Walking", false);
    }

}
