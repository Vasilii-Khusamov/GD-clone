using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class OrbBehaviour : MonoBehaviour
{
    private bool _isAlowedToJump = false;


    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isAlowedToJump = true;
        } else if (Input.GetButtonUp("Jump"))
        {
            _isAlowedToJump = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("Jump") && other.gameObject.CompareTag("Player") && _isAlowedToJump)
        {
            _isAlowedToJump = false;
            Jump(other);
        }
    }
    abstract protected void Jump(Collider2D other);
}