using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Camera_3rd : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] Inputsystem inputsystem;
    [SerializeField] float _mouseSensitivity;
    public Transform _target_player;
    [SerializeField] private float _distanceFromTarget_player;
    [SerializeField] private float _smoothTime;
    [SerializeField] float _rotationXMinMax;
    public GameObject player;
    public bool _is_player;
    private float _rotationY;
    private float _rotationX;
    private Vector3 _currentRotation;
    private Vector3 _smoothVelocity = Vector3.zero;
    private void Start()
    {
        for (int i = 0; i < player.transform.childCount; i++)
        {
            if (player.transform.GetChild(i).name == "Camera Target Player")
            {
                _target_player = player.transform.GetChild(i);
                break;
            }
        }
        this.transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        _rotationY += inputsystem._MouseX * _mouseSensitivity ;
        _rotationX += inputsystem._MouseY * _mouseSensitivity ;
        _rotationX = Mathf.Clamp(_rotationX,-_rotationXMinMax, _rotationXMinMax);
        Vector3 nextRotation = new Vector3(_rotationX, _rotationY);
        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;
        if(_is_player)
        {
            transform.position = _target_player.position - transform.forward * _distanceFromTarget_player;
        }
    }
}
