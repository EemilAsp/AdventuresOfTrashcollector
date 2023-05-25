using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShooter : MonoBehaviour
{
   public GameObject projectilePrefab;
    public Transform projectileSpawnPoint; 
    public float shootingInterval = 5f;
    public GameObject playerCharacter; 
    private float timer = 0f;
    public float projectileSpeed = 10f;

    private void Update()
    {
        timer += Time.deltaTime; // Increment the timer

        // Check if it's time to shoot
        if (timer >= shootingInterval)
        {
            ShootProjectile();
            timer = 0f; // Reset the timer
        }
    }

    private void ShootProjectile()
    {
        Vector2 direction = playerCharacter.transform.position - projectileSpawnPoint.position;
        direction.Normalize();

        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        // Code to customize the projectile (e.g., set velocity, add force, etc.) goes here
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        projectileRigidbody.velocity = direction * projectileSpeed;
        projectileRigidbody.AddForce(direction * 10f, ForceMode2D.Impulse);
    }
}
