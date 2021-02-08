using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public float speed;
    public float powerupStrength = 15;
    public bool hasPowerup;
    public GameObject powerupIndicator;

    GameObject focalPoint;

    void Start()
    {
        // Make a reference to the Rigidbody component
        playerRb = gameObject.GetComponent<Rigidbody>();

        // Find the focal point object in the scene
        focalPoint = GameObject.Find("Focalpoint");
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        // Set the powerup indicator position to the players postion with an offset
        powerupIndicator.transform.position = transform.position + Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision) 
    {
        // If player collides with enemy while they have an active powerup
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Reference to the enemy RigidBody
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            // Get the direction from the player to the enemy
            Vector3 awayFromPlayer = (collision.gameObject.transform.position
            - transform.position);

            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);

            // Push enemy away from player
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collided with has the tag Powerup
        if (other.CompareTag("Powerup"))
        {
            // Enable the powerup on the player
            hasPowerup = true;

            // Set the powerup indicator to active so the player can see it
            powerupIndicator.gameObject.SetActive(true);

            // Start the coroutine to disable the powerup
            StartCoroutine(PowerupCountDownRoutine());

            // Destroy the Powerup object
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCountDownRoutine() {
        yield return new WaitForSeconds(7);
        hasPowerup = false;

        // Deactivate the powerup indicator
        powerupIndicator.gameObject.SetActive(false);

    }

}
