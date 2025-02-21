using System;
using UnityEngine;
using UnityEngine.Serialization;

public class YellowOrbBehaviour : MonoBehaviour
{
    public float jumpForce = 15;
    public float angularForce = 40;

    private bool _isAlowedToJump = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isAlowedToJump = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.Space) && other.gameObject.CompareTag("Player") && _isAlowedToJump)
        {
            _isAlowedToJump = false;
            Rigidbody2D heroRigidbody2D = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 upVector = -(Physics2D.gravity * heroRigidbody2D.gravityScale).normalized;
            
            heroRigidbody2D.linearVelocity = upVector * jumpForce;
            heroRigidbody2D.AddTorque(-angularForce * Math.Sign(heroRigidbody2D.gravityScale));
        }
    }
}