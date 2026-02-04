using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoRestarter : MonoBehaviour
{
    [SerializeField] private float restartDelay;
    [SerializeField] private GameObject player;
    private Restarter restarter;
    private Killer killer;
    void Start()
    {
        killer = player.GetComponent<Killer>();
        restarter = GetComponent<Restarter>();
        killer.OnPlayerDeath += Restart;
    }
    void Restart()
    {
        StartCoroutine("Wait");
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(restartDelay);
        restarter.Restart();
        yield return null;
    }
    void OnDisable()
    {
        if (killer is not null) killer.OnPlayerDeath -= Restart;
    }
}
