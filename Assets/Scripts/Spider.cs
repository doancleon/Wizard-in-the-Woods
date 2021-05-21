using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float walkDist = 5;
    private Vector3 changedPos;
    public Transform player;
    private float chaseRange = 5f;
    private Rigidbody2D spiderrb;
    private float chaseMoveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        spiderrb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);


        if (distToPlayer < chaseRange)
        {
            moveSpider();
        }
        else
        {
            changedPos = transform.position;
            changedPos.x += (Mathf.PingPong(Time.time, walkDist) - (walkDist / 2)) * .005f;

            transform.position = changedPos;
        }
    }

    void moveSpider()
    {
        if (transform.position.x < player.position.x)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * chaseMoveSpeed / 2f;

        }
        else
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * chaseMoveSpeed / 2f;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}