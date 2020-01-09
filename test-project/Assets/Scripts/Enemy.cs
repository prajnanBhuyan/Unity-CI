﻿using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 100;

    [SerializeField]
    float shotCounter;

    [SerializeField]
    float minTimeBetweenShots = 0.2f;

    [SerializeField]
    float maxTimeBetweenShots = 3f;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    float projectileSpeed = 10f;

    [SerializeField]
    GameObject deathVFX;

    [SerializeField]
    float durationOfExplosion = 1f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        // TODO: Have a behaviour for the firing pattern so that some 
        //      enemies can fire towards the player and not always downwards
        GameObject laser = Instantiate
            (projectile,
            transform.position,
            Quaternion.identity) as GameObject;

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
            ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        var explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }
}
