using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcter_spawoner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;
    public GameObject charcter_player;
    [SerializeField] GameObject[] charcter_spawon;
    public static int index = 0;
    private void Start()
    {
        _set_charcter();
        assing_player();
    }
    public void assing_player()
    {
        parent.GetComponent<Player_Move>()._player = charcter_spawon[index].gameObject;
        charcter_spawon[index].transform.position = parent.transform.position;
    }
    public void _set_charcter()
    {
        charcter_player = Instantiate(charcter_spawon[index],new Vector3(parent.transform.position.x, parent.transform.position.y - 0.9f, parent.transform.position.z), Quaternion.identity, parent.transform);
        assing_player();
    }
}
