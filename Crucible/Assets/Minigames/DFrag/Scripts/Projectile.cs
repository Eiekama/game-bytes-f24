using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    // private Rigidbody rb; 
     
    // private bool targetHit; 
    // private void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player1Movement>() != null) {
            MinigameController.Instance.AddScore(2, 1);
        } else
        if (collision.gameObject.GetComponent<Player2Movement>() != null) {
            MinigameController.Instance.AddScore(1, 1);
        }
        // Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        // enemy.TakeDamage(damage);
        // Destroy(gameObject);
    }
}

