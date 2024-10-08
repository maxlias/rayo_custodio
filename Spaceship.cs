﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour {

    public float speed;
    public float shotDelay;
    public GameObject bullet;
    public GameObject explosion;

    // Instance of bullets with position
    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    public void Move(Vector2 direction)
    {
         GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
}
