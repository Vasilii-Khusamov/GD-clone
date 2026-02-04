using TMPro;
using UnityEngine;

public class NewBestTextAnimation : MonoBehaviour
{
    [SerializeField] private ProgressManager progressManager;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        progressManager.OnBest += PlayAnimation;
        gameObject.SetActive(false);
    }
    private void PlayAnimation(float bestProgress)
    {
        gameObject.SetActive(true);
        text.text = $"New best!\n{Mathf.CeilToInt(bestProgress * 100f)}%";
    }
}
