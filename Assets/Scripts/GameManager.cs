using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject[] butterflies;
    public GameObject player;
    private PlayerMovement playerM;
    public GameObject uiObject;

    // Start is called before the first frame update
    void Start()
    {
        uiObject = GameObject.FindWithTag("bftag");
        uiObject.SetActive(false);
        butterflies = GameObject.FindGameObjectsWithTag("bf");
        playerM = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        butterflies = GameObject.FindGameObjectsWithTag("bf");
        if (butterflies.Length == 0)
        {
            Debug.Log("0 bfs");
            playerM.doubleJump = true;
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");

        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
