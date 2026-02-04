using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject levelSelect;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }
    public void Play()
    {
        levelSelect.SetActive(true);
    }
    public void Back()
    {
        levelSelect.SetActive(false);
    }
}
