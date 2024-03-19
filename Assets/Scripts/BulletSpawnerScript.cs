using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerScript : MonoBehaviour
{

    private float attackSpeed = 0.5f;
    private float nextTimeToFire = 0f;

    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
