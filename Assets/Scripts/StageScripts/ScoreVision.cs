using UnityEngine;
using UnityEngine.UI;

public class ScoreVision : MonoBehaviour
{
    public Text position => _position;
    
    public Text score => _score;
    [SerializeField] private Text _score,_position;
}
