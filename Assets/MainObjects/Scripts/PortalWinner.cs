using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PortalWinner : MonoBehaviour
{
    public float animationLength;
    public float heroRotationSpeed;
    public AnimationCurve speedOverTime;
    public GameObject winEffect;
    
    private bool _isWinning = false;
    private GameObject _hero;
    private Vector3 _winPosition;
    private float _winTimer = 0;

    void Update()
    {
        if (_isWinning && _winTimer >= animationLength && _hero is not null)
        {
            _isWinning = false;
            Instantiate(winEffect, gameObject.transform.position, new Quaternion());
            Destroy(_hero);
        }
        if (_isWinning && _hero is not null)
        {
            Vector3 heroNewPosition = new Vector3(0, 0, 0);

            float animationProgress = speedOverTime.Evaluate(_winTimer / animationLength);
            
            heroNewPosition.x = Mathf.Lerp(_winPosition.x, gameObject.transform.position.x, animationProgress);
            heroNewPosition.y = Mathf.Lerp(_winPosition.y, gameObject.transform.position.y, animationProgress);
            
            _hero.transform.position = heroNewPosition;
            _hero.transform.Rotate( Vector3.back, heroRotationSpeed * Time.deltaTime * 360);
            _winTimer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isWinning = true;
            _hero = other.gameObject;
            other.GetComponent<DisableHero>().Disable();
            _winPosition = other.gameObject.transform.position;
        }
    }
}
