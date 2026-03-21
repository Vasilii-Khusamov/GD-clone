using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class OrbBehaviour : MonoBehaviour
{
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
        if (Input.GetButton("Jump") && other.gameObject.CompareTag("Player") && _isAlowedToJump)
        {
            _isAlowedToJump = false;
            //OnJumpOrbActivate?.Invoke(other);
            Jump(other);
        }
    }
    abstract protected void Jump(Collider2D other);
}