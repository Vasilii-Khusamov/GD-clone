using System;
using UnityEngine;

public class ImpulseMover : MonoBehaviour
{
	public float force;
	public Rigidbody2D rb;

	private Lazy<CollisionGroundCounter> _lazyCollisionGroundCounter;

	private void Start()
	{
		if (force == 0) 
		{
			Debug.Log("Внимание, параметр force нужно задать значением, отличное от нуля.");
		}

		_lazyCollisionGroundCounter = new Lazy<CollisionGroundCounter>(() => gameObject.GetComponent<CollisionGroundCounter>());
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKey(KeyCode.Space) && (_lazyCollisionGroundCounter is null || _lazyCollisionGroundCounter.Value.isGrounded))
		{
			Vector3 upVector = -(Physics2D.gravity * rb.gravityScale).normalized;
			rb.linearVelocity = upVector * force;
		}
	}
}