using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeroRotator : MonoBehaviour
{
    private bool isRotating = false;
    private float currentAngle = 0f;
    [SerializeField] private float rotationSpeed = 360f;
    CollisionGroundCounter counter;
    Rigidbody2D rb;
    SpriteRenderer[] sprites;
    void Start()
    {
        counter = GetComponent<CollisionGroundCounter>();
        rb = GetComponent<Rigidbody2D>();
        sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isRotating = !counter.isGrounded;
        if (isRotating)
        {
            SetRotation(currentAngle + -rotationSpeed * Time.deltaTime * Mathf.Sign(rb.gravityScale));
        }
        else
        {
            float restAngle = Mathf.Round(currentAngle / 90f) * 90f;
            SetRotation(Mathf.Lerp(currentAngle, restAngle, 1 - Mathf.Exp(20 * -Time.deltaTime)));
        }
    }

    void SetRotation(float angle)
    {
        currentAngle = angle;
        foreach (var s in sprites)
        {
            s.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
