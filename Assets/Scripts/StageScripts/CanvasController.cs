using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance =null;

    public int currentScore => _currentScore;
    
   
    [SerializeField] private Text _score;
    [SerializeField] private Text _health;
    [SerializeField] private HiscoreScripts _hiscoreScripts;
    [SerializeField] private GameObject _stage, _gameCanvas;
    
    private int _currentScore ;
    private int _currentHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        EventController.Instance.FructPickUp.AddListener(UpdateScore);
        EventController.Instance.Damage.AddListener(UpdateHealth);
        EventController.Instance.Dead.AddListener(OnHiScore);
        _score.text = "Score: 0";
    }

    private void OnHiScore()
    {
        _hiscoreScripts.gameObject.SetActive(true);
        _stage.SetActive(false);
        _gameCanvas.SetActive(false);
    }

    // Update is called once per frame
    private void UpdateScore(int score)
    {
        _currentScore += score;
        _score.text = "Score: " + _currentScore;
    }

    private void UpdateHealth(int damage)
    {
        _currentHealth -= damage;
        _health.text = "Health: " + _currentHealth;
        if (_currentHealth <= 0)
        {
            EventController.Instance.Dead.Invoke();
        }
    }
}
