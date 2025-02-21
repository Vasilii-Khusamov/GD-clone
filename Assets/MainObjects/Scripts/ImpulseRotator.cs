using System;
using UnityEngine;

public class ImpulseRotator : MonoBehaviour
{
	public float rotationForce;
	public Rigidbody2D rb;

	private Lazy<CollisionGroundCounter> _lazyCollisionGroundCounter;

	private void Start()
	{
		if (rotationForce == 0)
		{
			Debug.Log("��������, �������� rotationForce ����� ������ ���������, �������� �� ����.");
		}

		_lazyCollisionGroundCounter = new Lazy<CollisionGroundCounter>(() => gameObject.GetComponent<CollisionGroundCounter>());
	}
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.Space) && (_lazyCollisionGroundCounter is null || _lazyCollisionGroundCounter.Value.isGrounded))
		{
			rb.angularVelocity = -rotationForce * Math.Sign(rb.gravityScale);
		}
	}
}
