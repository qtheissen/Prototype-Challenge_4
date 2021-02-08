using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    
    Rigidbody enemyRb;
    GameObject player;

    void Start()
    {
        // Get reference to rigidbody
        enemyRb = GetComponent<Rigidbody>();

        // Get reference to player object
        player = GameObject.Find("Player");
    }

   
    void Update()
    {
        // Create a Vector3 for the direction towards the player
        Vector3 lookDirection = (player.transform.position- transform.position).normalized;

        // Apply force to the enemy in the lookDirection direction
        enemyRb.AddForce(lookDirection * speed);    

        // Destroy enemy when they fall off the platform
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }

        
    }
}
