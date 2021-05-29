using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour
{
    public int health = 3;
    public float invinDuration = 5.0f;
    public bool invincible = false;
    public float timer;
    SpriteRenderer sr;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bat" || col.gameObject.tag == "spider")
        {
            if (!invincible)
            {
                health -= 1;
            }

            invincible = true;

            if (health <= -1)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("FirstScene");
            }
        }
    }


    void Update()
    {
        if (invincible)
        {
            GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
            timer += Time.deltaTime;
            if (timer % 60 >= invinDuration)
            {
                invincible = false;
                timer = 0.0f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            }
        }
        if (health == 0)
            {
                heart3.enabled = false;
            }
  
        else if (health == 1)
            {
                heart2.enabled = false;
            }
  
        else if (health == 2)
            {
                heart1.enabled = false;
            }
    }   
    
}
