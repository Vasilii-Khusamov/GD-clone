using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    private float musicVolume = 1f;
    [SerializeField]private AudioSource audioSource;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource.volume = musicVolume;

    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
        audioSource.volume = musicVolume;
    }
    public void SetPause(bool isEnabled)
    {
        if (isEnabled)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelData levelData = Resources.Load<LevelData>($"{scene.name}");

        Killer killer = FindAnyObjectByType<Killer>();
        if (killer != null)
        {
            killer.OnPlayerDeath += StopMusic;
        }

        if (levelData == null)
        {
            audioSource.Stop();
            return;
        }
        if (levelData.music == null) return;


        audioSource.PlayOneShot(levelData.music);
    }
}
