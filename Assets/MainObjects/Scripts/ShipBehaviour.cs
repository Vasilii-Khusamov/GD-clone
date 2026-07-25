using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField] private float flyingForce = 10;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private float maxAngle = 50;
    private Rigidbody2D rb;
    private Transform sprite;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentsInChildren<Transform>()[1];
    }

    void Update()
    {
        if ( Input.GetButton("Jump"))
        {
            Vector2 up = -transform.up * Physics2D.gravity * rb.gravityScale;
            rb.AddForce(up * flyingForce * Time.deltaTime);
        }

        float newVelosityY = Mathf.Clamp(rb.linearVelocity.y, -maxSpeed, maxSpeed);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, newVelosityY);

        float angle = Mathf.Lerp(-maxAngle, maxAngle, (rb.linearVelocity.y + maxSpeed) / (2 * maxSpeed));
        SetRotation(angle);
    }


    void SetRotation(float angle)
    {
        sprite.rotation = Quaternion.Euler(0, 0, angle);
    }
}
