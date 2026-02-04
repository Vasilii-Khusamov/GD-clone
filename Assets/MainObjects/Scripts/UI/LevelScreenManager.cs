using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScreenManager : MonoBehaviour
{
    [SerializeField] public LevelData _level;
    [SerializeField] private TextMeshProUGUI _levelLabel;

    public void Start()
    {
        if (_level is null)
        {
            _levelLabel.text = "Error: missing level data.";
            return;
        }
        _levelLabel.text = _level.name;
    }
    public void PlayLevel()
    {
        if (_level is null)
        {
            _levelLabel.text = "Error: missing level data.";
            return;
        }
        SceneManager.LoadScene(_level.name);
    }
}
