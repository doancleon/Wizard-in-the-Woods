using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1.1f;
    private float jumpH = 5.5f;
    private float djumpH = 3f;
    private bool grounded = true;
    public int numJumps = 1;
    public bool doubleJump = false;
    public Transform feet;
    public LayerMask groundL;
    public Animator walk_animator;
    private PlayerWand script;
    public GameObject honey;

    // Start is called before the first frame update
    void Start()
    {
        script = this.GetComponent<PlayerWand>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & grounded)
        {
            numJumps -= 1;
            rb.AddForce(Vector3.up * jumpH, ForceMode2D.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.Space) & numJumps > 0)
        {
            numJumps -= 1;
            rb.AddForce(Vector3.up * djumpH, ForceMode2D.Impulse);
        }

        //check if player is on the ground
        grounded = Physics2D.OverlapCircle(feet.position, .2f, groundL);

        if (doubleJump & grounded)
            numJumps = 1;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))   //left
        {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            rb.transform.Translate(new Vector2(speed/10f, 0));
            if (grounded)
            {
                StartCoroutine("Walk_Animation");
            }
        }
        else if (Input.GetKey(KeyCode.D))   //right
        {
            rb.transform.rotation = Quaternion.Euler(Vector3.forward);
            rb.transform.Translate(new Vector2(speed/10f, 0));
            if (grounded)
            {
                StartCoroutine("Walk_Animation");
            }

        }
    }
    IEnumerator Walk_Animation()
    {
        walk_animator.SetBool("Walking", true);
        yield return new WaitForSeconds(0.01f);
        walk_animator.SetBool("Walking", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<honey>())
        {
            Destroy(collision.gameObject);
            script.hasHoney = true;
        }
    }

}
