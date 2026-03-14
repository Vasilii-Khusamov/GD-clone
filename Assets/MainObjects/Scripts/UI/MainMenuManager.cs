using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject levelSelect;
    [SerializeField] GameObject settingsPanel;
    public void Start()
    {
        levelSelect.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }
    public void Play()
    {
        Back();
        levelSelect.SetActive(true);
    }
    public void OpenSettings()
    {
        Back();
        settingsPanel.SetActive(true);
    }
    public void Back()
    {
        levelSelect.SetActive(false);
        settingsPanel.SetActive(false);
    }
}
