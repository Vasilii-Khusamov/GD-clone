using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Killer : MonoBehaviour
{
	public GameObject deathEffectPrefab;


	private Lazy<CollisionGroundCounter> _lazyCollisionGroundCounter;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		_lazyCollisionGroundCounter = new Lazy<CollisionGroundCounter>(
			() =>
			{
				CollisionGroundCounter[] children = gameObject.GetComponentsInChildren<CollisionGroundCounter>();
				CollisionGroundCounter innerHitbox = Array.Find(children, child => child.name == "Inner hitbox");
				if (innerHitbox is null)
				{
					Debug.Log("В дочернем объекте не найден компонент CollisionGroundCounter");
				}
				return innerHitbox;
			}
		);
	}

	// Update is called once per frame
	void Update()
	{
		if (_lazyCollisionGroundCounter.Value.isGrounded)
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
		Instantiate(deathEffectPrefab, transform.position, new Quaternion());
		Destroy(this.gameObject);
	}
}
