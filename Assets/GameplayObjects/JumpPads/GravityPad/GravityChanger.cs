using System;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D heroRigidbody2D = other.gameObject.GetComponent<Rigidbody2D>();
        heroRigidbody2D.gravityScale = -heroRigidbody2D.gravityScale;
    }
}
