using UnityEngine;

public class Helicopter : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rg;
    [SerializeField] float _heli_speed;
    [SerializeField] float _heli_rotation_speed;
    [SerializeField] Inputsystem inputsystem;
    [SerializeField] float _addforce_heli;
    [SerializeField] float speed_in_air;
    [SerializeField] Movement_manger movement_Manger;
    Vector3 Move;
    public void give_control(GameObject gameObject)
    {
        inputsystem = gameObject.GetComponent<Inputsystem>();

    }
    void Start()
    {
        inputsystem = movement_Manger.inputsystem;
        transform.rotation = Quaternion.identity;
        rg = this.GetComponent<Rigidbody>();
    }
    void heli_movement()
    {
        Move = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) *  new Vector3(0, 0, inputsystem._Vertical) * _heli_speed * Time.deltaTime;
        if(Input.GetKey(inputsystem.SprintKey))
        {
            rg.AddForce(new Vector3(0, _addforce_heli * Time.deltaTime, 0));
        }
        rg.MovePosition(transform.position + Move * speed_in_air);
        transform.Rotate(0, inputsystem._MouseX * _heli_rotation_speed, 0);
    }
    // Update is called once per frame
    void Update()
    {
        heli_movement();
    }
}
