using UnityEngine;

public class ForceMover : MonoBehaviour
{
   public Vector2 direction;
   public float acceleration;
   public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(direction.normalized * acceleration * Time.fixedDeltaTime);
    }
}
