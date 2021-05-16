using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWand : MonoBehaviour
{
    public Transform wandDirection;
    public GameObject bubbleFire;
    public GameObject honeyFire;
    Vector2 direction;
    public Animator attack_animator;
    private bool canShoot = true;
    public bool hasHoney = false;

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)wandDirection.position;
        FaceMouse();
        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine("Attack_Animation");
        }

        if (Input.GetKeyDown(KeyCode.E) && hasHoney == true)
        {
            GameObject honeyF = Instantiate(honeyFire, wandDirection.position, wandDirection.rotation);
            hasHoney = false;
        }
    }


    IEnumerator Attack_Animation()
    {
        attack_animator.SetBool("Attacking", true);
        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(0.4f);
        attack_animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.4f);
        canShoot = true;
    }

    void FaceMouse()
    {
        wandDirection.transform.right = direction; 
    }


    void Shoot()
    {
        GameObject bubbleF = Instantiate(bubbleFire, wandDirection.position, wandDirection.rotation);
        Destroy(bubbleF, 1);

    }
}
