using UnityEngine;

/**
 * ��������� ��� �������� ��������������� �������  
 * � �������� ���������, � ������� ��������� ��� 'Ground'.
 */ 
public class CollisionGroundCounter : MonoBehaviour
{
	private int _numberOfCollisionsWithGround = 0;

	/**
	 * ���������� true, ���� ���� ��������������� � ������� ��������, 
	 * � ������� ��������� ��� 'Ground'.
	 */
	public bool isGrounded { get => _numberOfCollisionsWithGround > 0; }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			_numberOfCollisionsWithGround++;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			_numberOfCollisionsWithGround--;
		}
	}
}
