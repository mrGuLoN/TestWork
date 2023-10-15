using System;
using DG.Tweening;
using UnityEngine;

public class FructController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int bonus;
    public Collider2D collider;

    [SerializeField] private float _amountANimation, _speed;

    private EventController _event;
    void Start()
    {
        DOTween.Init();
        transform.DOScale(transform.localScale * (1 + _amountANimation), _speed).SetLoops(-1, LoopType.Yoyo);
        _event = EventController.Instance;
    }

 
    private void OnTriggerEnter2D(Collider2D other)
    {
        _event.FructPickUp?.Invoke(bonus);
        Destroy(this.gameObject);
    }

}
