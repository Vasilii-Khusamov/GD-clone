using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoRestarter : MonoBehaviour
{
    public float restartDelay;

    private float _restartTimer = 0;
    private Lazy<GameObject> _hero;

    private void Start()
    {
        _hero = new Lazy<GameObject>(() => GameObject.Find("Hero"));
    }

    void Update()
    {
        if (_restartTimer >= restartDelay)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        if (_hero.Value == null && _restartTimer < restartDelay)
        {
            _restartTimer += Time.deltaTime;
        }
    }
}
