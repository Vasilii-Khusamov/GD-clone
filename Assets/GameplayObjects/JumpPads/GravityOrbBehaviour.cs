using UnityEngine;

public class GravityOrbBehaviour : OrbBehaviour
{
    [SerializeField] private float jumpForce = 15;
    override protected void Jump(Collider2D other)
    {
        Rigidbody2D heroRigidbody2D = other.gameObject.GetComponent<Rigidbody2D>();
        Vector2 upVector = -(Physics2D.gravity * heroRigidbody2D.gravityScale).normalized;

        heroRigidbody2D.linearVelocity = upVector * jumpForce;
        heroRigidbody2D.gravityScale *= -1;
    }
}
