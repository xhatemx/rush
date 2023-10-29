using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class Lobby_manger : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField input;
    public void create_server()
    {
        PhotonNetwork.CreateRoom(input.text);
    }
    public void join_server()
    {
        PhotonNetwork.JoinRoom(input.text);
    }
    public override void OnCreatedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }

}
