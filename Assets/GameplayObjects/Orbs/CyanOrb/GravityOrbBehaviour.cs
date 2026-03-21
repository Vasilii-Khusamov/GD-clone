using UnityEngine;

public class GravityOrbBehaviour : OrbBehaviour
{
    [SerializeField] private float jumpForce = 15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    OrbBehaviour jumpOrbBehaviour = GetComponent<OrbBehaviour>();
    //    jumpOrbBehaviour.OnJumpOrbActivate += Jump;
    //}
    //void OnDisable()
    //{
    //    OrbBehaviour jumpOrbBehaviour = GetComponent<OrbBehaviour>();
    //    jumpOrbBehaviour.OnJumpOrbActivate -= Jump;
    //}
    override protected void Jump(Collider2D other)
    {
        Rigidbody2D heroRigidbody2D = other.gameObject.GetComponent<Rigidbody2D>();
        Vector2 upVector = -(Physics2D.gravity * heroRigidbody2D.gravityScale).normalized;

        heroRigidbody2D.linearVelocity = upVector * jumpForce;
        heroRigidbody2D.gravityScale *= -1;
    }
}
