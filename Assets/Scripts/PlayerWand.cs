using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWand : MonoBehaviour
{
    public Transform wandDirection;
    public GameObject starFire;
    Vector2 direction;

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)wandDirection.position;
        FaceMouse();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void FaceMouse()
    {
        wandDirection.transform.right = direction; 
    }


    void Shoot()
    {
        GameObject starF = Instantiate(starFire, wandDirection.position, wandDirection.rotation);
        Destroy(starF, 1);
    }
}
