using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Killer : MonoBehaviour
{
	public GameObject deathEffectPrefab;
	public event Action OnPlayerDeath;

	private CollisionGroundCounter _collisionGroundCounter;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		_collisionGroundCounter = gameObject.GetComponentsInChildren<CollisionGroundCounter>()[1];	
	}

	// Update is called once per frame
	void Update()
	{
		if (_collisionGroundCounter.isGrounded)
		{
			KillHero();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Deadly"))
		{
			KillHero();
		}
	}

	private void KillHero() 
	{
		OnPlayerDeath?.Invoke();
		Instantiate(deathEffectPrefab, transform.position, new Quaternion());
		Destroy(gameObject);
	}
}
