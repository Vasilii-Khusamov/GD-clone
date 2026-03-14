using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    Slider slider;
    MusicManager musicManager;
    void Start()
    {
        slider = GetComponent<Slider>();
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            slider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", slider.value);
            OnValueChanged(slider.value);
        }
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    public void OnValueChanged(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        if (musicManager == null)
        {
            musicManager = MusicManager.instance;
        }
        if (musicManager != null)
        {
            musicManager.UpdateVolume(value);
        }
    }
}
