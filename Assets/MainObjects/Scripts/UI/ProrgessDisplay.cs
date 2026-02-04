using UnityEngine;
using UnityEngine.UI;

public class ProrgessDisplay : MonoBehaviour
{
    [SerializeField] LevelScreenManager levelScreenManager;
    private string levelName;
    void Start()
    {
        if (levelScreenManager._level == null) return;
        
        levelName = levelScreenManager._level.name;
        float progress = PlayerPrefs.GetFloat(levelName + ".progress");
        Slider slider = gameObject.GetComponent<Slider>();
        slider.value = progress;
    }

    void Update()
    {
        
    }
}
