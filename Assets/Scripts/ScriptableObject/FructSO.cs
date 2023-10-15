using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Fruct", menuName = "ScriptableObjects/Fruct", order = 1)]
public class FructSO : ScriptableObject
{
    public FuctFormFactor[] fuctFormFactors => _fuctFormFactors;
    public int count => _count;
    
    [SerializeField] private FuctFormFactor[] _fuctFormFactors;
    [SerializeField] private int _count;

}
[Serializable]
public class FuctFormFactor
{
    public Sprite sprite;
    public int bonus;
    public PhysicsMaterial2D physicsMaterial2D;
}
