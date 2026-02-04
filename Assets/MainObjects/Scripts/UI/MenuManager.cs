using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Restarter))]
public class MenuManager : MonoBehaviour
{
    private bool _isPaused = false;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Restarter _restarter;
    void Start()
    {
        _menu.SetActive(false);
        _restarter = GetComponent<Restarter>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause(!_isPaused);
        }
    } 
    public void Resume()
    {
        SetPause(false);
    }
    public void Restart()
    {
        _restarter.Restart();
        SetPause(false);
    }
    public void Exit()
    {
        SetPause(false);
        SceneManager.LoadScene("MainMenu");
    }
    private void SetPause(bool isPause)
    {
        _isPaused = isPause;
        _menu.SetActive(isPause);
        Time.timeScale = isPause ? 0 : 1;
    }
}