using System;
using UnityEngine;

public class ImpulseRotator : MonoBehaviour
{
	public float rotationForce;
	public Rigidbody2D rb;

	private CollisionGroundCounter _collisionGroundCounter;

	private void Start()
	{
		if (rotationForce == 0)
		{
			Debug.Log("��������, �������� rotationForce ����� ������ ���������, �������� �� ����.");
		}

		_collisionGroundCounter = gameObject.GetComponent<CollisionGroundCounter>();
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Space) && (_collisionGroundCounter is null || _collisionGroundCounter.isGrounded))
		{
			rb.angularVelocity = -rotationForce * Math.Sign(rb.gravityScale);
		}
	}
}
