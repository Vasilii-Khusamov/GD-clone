using UnityEngine;

public class SpeedPortal : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        
        TranslateMover mover = collision.gameObject.GetComponent<TranslateMover>();
        if (mover == null) return;

        mover.speed = speed;
    }
}
