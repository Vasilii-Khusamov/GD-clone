using UnityEngine;

/**
 * Компонент для проверки соприкосновения объекта  
 * с игровыми объектами, у которых выставлен тег 'Ground'.
 */ 
public class CollisionGroundCounter : MonoBehaviour
{
	private int _numberOfCollisionsWithGround = 0;

	/**
	 * Возвращает true, если есть соприкосновение с игровым объектам, 
	 * у которых выставлен тег 'Ground'.
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
