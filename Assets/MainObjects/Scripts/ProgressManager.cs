using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    private float bestProgress = 0;
    [SerializeField] GameObject player;
    private float startPos;
    [SerializeField] GameObject endPortal;
    private float endPortalPos;
    private PortalWinner portalWinner;
    private Killer killer;
    public event Action<float> OnBest;
    void Start()
    {
        startPos = player.transform.position.x;
        endPortalPos = endPortal.transform.position.x;
        bestProgress = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + ".progress", 0);
        killer = player.GetComponent<Killer>();
        portalWinner = endPortal.GetComponent<PortalWinner>();
        killer.OnPlayerDeath += RecordProgress;
        portalWinner.OnWin += RecordProgress;
    }
    void Update()
    {
        
    }
    private void RecordProgress()
    {
        float progress = GetProgress();
        if (progress > bestProgress)
        {
            bestProgress = Mathf.Min(progress, 1);
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + ".progress", bestProgress);
            OnBest?.Invoke(bestProgress);
            //Debug.Log("New best: " + Mathf.CeilToInt(bestProgress * 100) + "%");
        }
    }
    private float GetProgress()
    {
        float currentPlayerPos = player.transform.position.x;
        float relativePlayerPos = currentPlayerPos - startPos;
        float distanceToEnd = endPortalPos - startPos;
        return Mathf.Abs(relativePlayerPos / distanceToEnd);
    }
    void OnDisable()
    {
        if (killer != null)
        {
            killer.OnPlayerDeath -= RecordProgress;
        }
    }
}
