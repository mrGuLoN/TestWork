using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _damageLayer;
    [SerializeField] private int _health;
    [SerializeField] private float _timerNonDamage, _speedPlayer;

    private bool _isNonDamage =false;
    void Start()
    {
        EventController.Instance.Moved.AddListener(PlayerMove);
        DOTween.Init();
        transform.DORotate(new Vector3(0, 0, 360), 0.5f,RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
        StartCoroutine(UpdateHealth());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator UpdateHealth()
    {
        yield return new WaitForSeconds(0.1f);
        EventController.Instance.Damage?.Invoke(-1*_health);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !_isNonDamage)
        {
            _isNonDamage = true;
            EventController.Instance.Damage?.Invoke(1);
            transform.DOShakePosition(_timerNonDamage, new Vector3(0.1f, 0.1f, 0),15);
            StartCoroutine(NonDamageTimer());
        }
    }

    private void PlayerMove(Vector3 point)
    {
        if (!_isNonDamage)
            transform.DOMove( point, _speedPlayer).SetSpeedBased().SetEase(Ease.Linear);    
    }

    IEnumerator NonDamageTimer()
    {
        yield return new WaitForSeconds(_timerNonDamage+0.1f);
        _isNonDamage = false;
    }




}
