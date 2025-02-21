using System;
using UnityEngine;

public class JumpPadBehavior : MonoBehaviour
{
    public float launchForce = 20;
    public float angularForce = 40;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D otherRigidbody2D = other.gameObject.GetComponent<Rigidbody2D>();
        
        
        Vector3 upVector = -(Physics2D.gravity * otherRigidbody2D.gravityScale).normalized;
        otherRigidbody2D.linearVelocity = upVector * launchForce;
        otherRigidbody2D.AddTorque(-angularForce * Math.Sign(otherRigidbody2D.gravityScale));
    }
}
