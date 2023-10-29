using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Inputsystem : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [Header("Jump key")]
    public KeyCode _jump;
    [field: Header("Vertical name")]
    public string _Vertical_Name;
    [field: Header("Horizontal name")]
    public string _Horizontal_Name;
    public string _MouseX_Name;
    public string _MouseY_Name;
    public KeyCode _F = KeyCode.F;
    public KeyCode SprintKey = KeyCode.LeftShift;
    public bool  _Mouse_enable;
    public bool _Key_enable;
    public float _Vertical { get; set; }
    public float _Horizontal { get; set; }
    public float _Firebutton { get; set; }
    public float _aimbutton { get; set; }
    public float _MouseX { get; set; }
    public float _MouseY { get; set; }
    // Update is called once per frame
    void Update()
    { 
        if(_Mouse_enable)
        {
            _MouseX = Input.GetAxis(_MouseX_Name);
            _MouseY = Input.GetAxis(_MouseY_Name);
        }
        if(_Key_enable)
        {
            _Horizontal = Input.GetAxis(_Horizontal_Name);
            _Vertical = Input.GetAxis(_Vertical_Name);
        }
    }
}
