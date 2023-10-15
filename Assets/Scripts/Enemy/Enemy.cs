using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer=> _spriteRenderer;
    public Rigidbody2D rigidbody2d=> _rigidbody2d;
    
    [SerializeField]private SpriteRenderer _spriteRenderer;
    [SerializeField]private Rigidbody2D _rigidbody2d;
}
