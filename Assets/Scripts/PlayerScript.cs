using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 6.0f;
    private float zBound = 10.0f;
    private float xBound = 20.0f;
    private float rotationSpeed = 5.0f;
    public bool isAlive = true;
    [SerializeField] private AudioSource playerDeathAudio;
    [SerializeField] private AudioSource powerupPickupAudio;
    private BulletSpawnerScript bulletSpawnerScript;

    private void Start()
    {
        bulletSpawnerScript = GameObject.Find("BulletSpawner").GetComponent<BulletSpawnerScript>();
    }
    void Update()
    {
        RotatePlayer();
        MovePlayer();
    }

    // Move Player
    void MovePlayer()
    {
        if (isAlive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.right * moveSpeed * horizontalInput * Time.deltaTime, Space.World);
            transform.Translate(Vector3.forward * moveSpeed * verticalInput * Time.deltaTime, Space.World);

            RestrictPlayerMovement();
        }
    }

    // Restricts Player's movement on vertical and horizontal bounds
    void RestrictPlayerMovement()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -xBound, xBound);
        float clampedZ = Mathf.Clamp(transform.position.z, -zBound, zBound);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }

    // Rotate Player
    void RotatePlayer()
    {
        if (isAlive)
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (playerPlane.Raycast(ray, out float distance))
            {
                Vector3 targetPoint = ray.GetPoint(distance);

                Vector3 directionToTarget = targetPoint - transform.position;

                directionToTarget.y = 0;

                if (directionToTarget != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Apply logic when triggered Powerup
        if (other.gameObject.CompareTag("Powerup"))
        {
            powerupPickupAudio.Play();
            bulletSpawnerScript.attackSpeed += .15f;
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        // Apply logic when collided with Enemy
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            playerDeathAudio.Play();
            isAlive = false;
        }
    }
}
