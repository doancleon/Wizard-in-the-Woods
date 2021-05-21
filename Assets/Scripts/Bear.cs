using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public float walkDist = 5;
    private Vector3 changedPos;
    public GameObject honey;
    public Transform player;
    private float chaseRange = 5f;
    private Rigidbody2D bearrb;
    private float chaseMoveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        bearrb = this.GetComponent<Rigidbody2D>();
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
            moveBear();
        }
       else
        {
            changedPos = transform.position;
            changedPos.x += (Mathf.PingPong(Time.time, walkDist) - (walkDist / 2)) * .005f;

            transform.position = changedPos;
        }
    }

    void moveBear()
    {
        if (transform.position.x < player.position.x)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * chaseMoveSpeed/1.5f;

        }
        else 
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * chaseMoveSpeed/1.5f;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<honey>())
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("FirstScene");
        }
    }

}
