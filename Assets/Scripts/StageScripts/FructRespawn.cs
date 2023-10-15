using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FructRespawn : MonoBehaviour
{
    [SerializeField] private Transform[] _corners;
    [SerializeField] private FructSO _fructSo;
    [SerializeField] private FructController _fructPref;
    void Start()
    {
        for (int i = 0; i < _fructSo.count; i++)
        {
            RespawnOneFruct(0);
        }
        EventController.Instance.FructPickUp.AddListener(RespawnOneFruct);
    }

    private void OnDisable()
    {
        EventController.Instance.FructPickUp.RemoveListener(RespawnOneFruct);
    }

    private void RespawnOneFruct(int i)
    {
        int randomFruct = Random.Range(0, _fructSo.fuctFormFactors.Length);
        float randomX =  Random.Range(_corners[0].position.x,_corners[1].position.x);
        float randomY =  Random.Range(_corners[0].position.y,_corners[1].position.y);
        var fruct = Instantiate(_fructPref, new Vector3(randomX, randomY, 0), quaternion.identity,transform);
        fruct.spriteRenderer.sprite = _fructSo.fuctFormFactors[randomFruct].sprite;
        fruct.bonus = _fructSo.fuctFormFactors[randomFruct].bonus;
        fruct.collider.sharedMaterial = _fructSo.fuctFormFactors[randomFruct].physicsMaterial2D;
    }
}
