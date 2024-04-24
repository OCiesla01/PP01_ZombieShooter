using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private float speed = 10.0f;
    private AudioSource zombieDeathAudio;
    private UIManager uiManager;
    private SpawnManagerScript spawnManagerScript;

    void Start()
    {
        zombieDeathAudio = GameObject.Find("ZombieDeathAudio").GetComponent<AudioSource>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManagerScript>();
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spawnManagerScript.UpdateZombiesSpeed();
            uiManager.zombiesKilled += 1;
            zombieDeathAudio.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
