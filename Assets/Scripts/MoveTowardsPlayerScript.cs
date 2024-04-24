using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveTowardsPlayerScript : MonoBehaviour
{

    private GameObject player;
    private Transform playerTransform;
    private PlayerScript playerScript;
    private Rigidbody zombieRb;
    public float moveSpeed;
    private float rotationSpeed = 5.0f;
    private float rotationDistance = 30.0f;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        zombieRb = GetComponentInChildren<Rigidbody>();

        if (playerScript != null)
        {
            playerTransform = player.transform;
        }
    }

    void FixedUpdate()
    {
        if (playerScript.isAlive)
        {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }
    }

    // Move zombie towards player
    private void MoveTowardsTarget()
    {
        if (player != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            zombieRb.velocity = direction * moveSpeed;
        }
    }

    // Rotate zombie towards player, only when distance between zombie and player is less than rotation distance (30 units)
    private void RotateTowardsTarget()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < rotationDistance)
        {
            Vector3 targetDirection = (playerTransform.position - transform.position).normalized;
            float singleStep = rotationSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            Quaternion rotation = Quaternion.LookRotation(newDirection);
            zombieRb.MoveRotation(rotation);
        }
    }
}
