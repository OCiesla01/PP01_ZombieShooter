using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayerScript : MonoBehaviour
{

    private GameObject player;
    private PlayerScript playerScript;
    private Rigidbody zombieRb;
    private Vector3 stopZombies;
    private float moveSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        zombieRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerScript.isAlive)
        {
            Vector3 moveTowardsPlayer = (player.transform.position - transform.position).normalized;
            zombieRb.velocity = moveTowardsPlayer * moveSpeed;
        }
        else
        {
            zombieRb.velocity = stopZombies;
        }
    }
}
