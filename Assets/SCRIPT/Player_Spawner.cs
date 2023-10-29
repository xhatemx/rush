using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player_Spawner : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _player_Camera;
    public GameObject player_copy;
    public GameObject _player_Camera_copy;

    void Awake()
    {
        _player_Camera_copy = PhotonNetwork.Instantiate(_player_Camera.name, ground.transform.position, Quaternion.identity);
        player_copy =  PhotonNetwork.Instantiate(player.name, ground.transform.position, Quaternion.identity);
      //  _player_Camera_copy.GetComponent<Camera_3rd>().view = _player_Camera_copy.GetComponent<PhotonView>();
        player_copy.GetComponent<Movement_manger>().camera_3Rd = _player_Camera_copy;
        player_copy.GetComponent<Player_Move>()._ground = ground;
        _player_Camera_copy.GetComponent<Camera_3rd>().player = player_copy;
        player = player_copy;
        _player_Camera = _player_Camera_copy;
    }
}
