using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speedPlayer;
    [SerializeField] private Transform[] _corners;

    private Camera _camera;
    private float timer;
    private Transform _playerTransform;
    void Start()
    {
        DOTween.Init();
        _camera = Camera.main;
        _playerTransform = _player.transform;
    }

    
    void Update()
    {
        if (Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 cameraVector =_camera.ScreenToWorldPoint(touch.position);
            
            //Проверка, что не вышли за границы респавна объектов
            if (cameraVector.x < _corners[0].position.x) cameraVector.x = _corners[0].position.x;
            else if (cameraVector.x > _corners[1].position.x) cameraVector.x = _corners[1].position.x;
                
            if (cameraVector.y < _corners[1].position.y) cameraVector.y = _corners[1].position.y;
            else if (cameraVector.y > _corners[0].position.y) cameraVector.y = _corners[0].position.y;

            EventController.Instance.Moved.Invoke(new Vector3(cameraVector.x, cameraVector.y, _playerTransform.position.z));
           
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 cameraVector =_camera.ScreenToWorldPoint(Input.mousePosition);
            
            if (cameraVector.x < _corners[0].position.x) cameraVector.x = _corners[0].position.x;
            else if (cameraVector.x > _corners[1].position.x) cameraVector.x = _corners[1].position.x;

            if (cameraVector.y < _corners[1].position.y) cameraVector.y = _corners[1].position.y;
            else if (cameraVector.y > _corners[0].position.y) cameraVector.y = _corners[0].position.y;

            EventController.Instance.Moved.Invoke(new Vector3(cameraVector.x, cameraVector.y, _playerTransform.position.z));
        }
        
    }

   
}
