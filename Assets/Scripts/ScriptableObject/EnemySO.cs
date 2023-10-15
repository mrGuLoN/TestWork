using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemySO : ScriptableObject
{
    public EnemyFormFactor[] enemySprite => _enemySprite;
    public int enemyCount => _enemyCount;

    public float minScale => _minScale;
    public float maxScale=>_maxScale;
    public float minSpeed =>_minSpeed;
    public float maxSpeed =>_maxSpeed;
    public float minRotateSpeed => _minRotateSpeed;
    public float maxRotateSpeed => _maxRotateSpeed;
    
    [SerializeField] private EnemyFormFactor[] _enemySprite;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _minScale, _maxScale;
    [SerializeField] private float _minSpeed, _maxSpeed;
    [SerializeField] private float _minRotateSpeed, _maxRotateSpeed;
    
}
[Serializable]
public class EnemyFormFactor
{
    public Sprite sprite;
    public bool isRound;
    public PhysicsMaterial2D physicsMaterial2D;
}
