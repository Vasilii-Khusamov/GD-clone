using System;
using UnityEngine;

public class ImpulseMover : MonoBehaviour
{
	public float force;
	public Rigidbody2D rb;

	private CollisionGroundCounter _collisionGroundCounter;

	private void Start()
	{
		if (force == 0) 
		{
			Debug.Log("Внимание, параметр force нужно задать значением, отличное от нуля.");
		}

		_collisionGroundCounter = gameObject.GetComponent<CollisionGroundCounter>();
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKey(KeyCode.Space) && (_collisionGroundCounter is null || _collisionGroundCounter.isGrounded))
		{
			Vector3 upVector = -(Physics2D.gravity * rb.gravityScale).normalized;
			rb.linearVelocity = upVector * force;
		}
	}
}