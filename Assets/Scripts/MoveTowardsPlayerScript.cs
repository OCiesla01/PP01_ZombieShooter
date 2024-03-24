using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveTowardsPlayerScript : MonoBehaviour
{

    private GameObject player;
    private PlayerScript playerScript;
    private Rigidbody zombieRb;
    private Vector3 stopZombies;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        zombieRb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetDirection = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        if (playerScript.isAlive)
        {
            Vector3 moveTowardsPlayer = (player.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            zombieRb.velocity = moveTowardsPlayer * moveSpeed;
        }
        else
        {
            zombieRb.velocity = stopZombies;
        }
    }
}
