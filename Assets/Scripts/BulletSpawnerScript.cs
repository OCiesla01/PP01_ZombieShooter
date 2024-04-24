using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerScript : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float attackSpeed = .5f;
    private float nextTimeToFire = 0f;

    public AudioSource pistolAudio;
    [SerializeField] private PlayerScript playerScript;

    void Update()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / attackSpeed;
            FireBullet();
        } 
    }

    void FireBullet()
    {
        if (playerScript.isAlive)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            pistolAudio.Play();
        }
    }
}
