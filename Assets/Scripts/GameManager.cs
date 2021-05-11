using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private GameObject[] butterflies;
    public GameObject player;
    private PlayerMovement playerM;

    // Start is called before the first frame update
    void Start()
    {
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
            playerM.numJumps = 2;
        }
    }
}
