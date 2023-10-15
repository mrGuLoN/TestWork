using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public UnityEvent<int> Damage;
    public UnityEvent<int> FructPickUp;
    public UnityEvent<Vector3> Moved;
    public UnityEvent Dead;
   
    public static EventController Instance;

    void Awake()
    {
        Instance = this;
    }
}
