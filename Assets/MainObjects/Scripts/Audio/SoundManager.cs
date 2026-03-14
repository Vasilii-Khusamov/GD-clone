using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip deathSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player.GetComponent<Killer>().OnPlayerDeath += OnDeath;
    }
    public void OnDeath()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
