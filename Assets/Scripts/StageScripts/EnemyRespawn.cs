using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRespawn : MonoBehaviour
{
    [SerializeField] private Transform[] _corners;
    [SerializeField] private EnemySO _enemySetting;
    [SerializeField] private Enemy _emptyPref;

        void Start()
    {
        for (int i = 0; i < _enemySetting.enemyCount; i++)
        {
            RespawnOneEnemy(0);
        }
    }


    private void RespawnOneEnemy(int i)
    {
        int intEnemy = Random.Range(0, _enemySetting.enemySprite.Length);
        float randomX =  Random.Range(_corners[0].position.x,_corners[1].position.x);
        float randomY =  Random.Range(_corners[0].position.y,_corners[1].position.y);
        float scale = Random.Range(_enemySetting.minScale, _enemySetting.maxScale);
        Vector2 direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;  
        
        
        Enemy enemy = Instantiate(_emptyPref,transform);
        var transform1 = enemy.transform;
        transform1.position = new Vector3(randomX, randomY, 0);
        transform1.localScale = new Vector2(scale, scale);
        enemy.spriteRenderer.sprite = _enemySetting.enemySprite[intEnemy].sprite;

        if (_enemySetting.enemySprite[intEnemy].isRound)
        {
            enemy.transform.gameObject.AddComponent<CircleCollider2D>().sharedMaterial = _enemySetting.enemySprite[intEnemy].physicsMaterial2D;
        }
        else
        {
            enemy.transform.gameObject.AddComponent<BoxCollider2D>().sharedMaterial = _enemySetting.enemySprite[intEnemy].physicsMaterial2D;
        }

        enemy.rigidbody2d.gravityScale = 0;
        enemy.rigidbody2d.angularDrag = 0;
        enemy.rigidbody2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        enemy.rigidbody2d.sharedMaterial = _enemySetting.enemySprite[intEnemy].physicsMaterial2D;
        enemy.rigidbody2d.velocity = direction*Random.Range(_enemySetting.minSpeed,_enemySetting.maxSpeed);
        enemy.rigidbody2d.angularVelocity = Random.Range(_enemySetting.minRotateSpeed, _enemySetting.maxRotateSpeed);
    }
}
