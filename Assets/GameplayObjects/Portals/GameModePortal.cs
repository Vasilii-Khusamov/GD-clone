using UnityEngine;

public class GameModePortal : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameModeSwitcher.Switch(collision.gameObject, gameMode);
    }
}
