using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Movement_manger : MonoBehaviourPunCallbacks
{
    public Inputsystem inputsystem;
    public GameObject camera_3Rd;
    Player_Move player_Move;
    void Start()
    {
            inputsystem = this.GetComponent<Inputsystem>();
            player_Move = this.GetComponent<Player_Move>();
            active_player();
    }
    // Update is called once per frame
    void active_player()
    {
        camera_3Rd.GetComponent<Camera_3rd>()._is_player = true;
        player_Move.enabled = true;
    }
}
