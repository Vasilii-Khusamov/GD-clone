using TMPro;
using UnityEngine;

public class AttemptCounter : MonoBehaviour
{
    static public AttemptCounter instance;
    private TextMeshProUGUI text;
    private static int attempts = 0;
    void Start()
    {
        if(instance != null) Destroy(this);
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Attempt " + attempts;
        attempts++;
    }
    void OnDisable()
    {
        if (instance != this) return;
        instance = null;
    }
    public void Reset()
    {
        attempts = 0;
    }
}