using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class Player_Move : MonoBehaviourPunCallbacks
{
    [SerializeField] float player_speed;
    [SerializeField] float player_run_speed;
    [SerializeField] float Jump;
    [SerializeField] LayerMask mask;
    [SerializeField] LayerMask dead;
    [SerializeField] float speed_in_air;
    [SerializeField] float rotationspeed;
    [SerializeField] Inputsystem inputsystem;
    [SerializeField] charcter_spawoner charcter_Spawoner;
    [SerializeField] float Air_distance;
    [SerializeField] Transform checkground;
    [SerializeField] float speed_in_dive;
    [SerializeField] GameObject[] points;
    readonly int iswalk = Animator.StringToHash("iswalk");
    readonly int isjump = Animator.StringToHash("isjump");
    readonly int isjump_idle = Animator.StringToHash("isjump_idle");
    readonly int isruning = Animator.StringToHash("isruning");
    readonly int isruningjump = Animator.StringToHash("isruningjump");
    readonly int isflying = Animator.StringToHash("isflying");
    public GameObject _player;
    public GameObject _ground;
    Rigidbody rg;
    Vector3 Move;
    Animator animator;
    // Update is called once per frame
    void Start()
    {
        animator = charcter_Spawoner.charcter_player.GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        this.transform.rotation = Quaternion.identity;
        Physics.gravity *= 0.7f;
    }
    public void point_check()
    {
        for(int i=0;i < points.Length;i++)
        {
            var v = dis(transform.position, points[i].transform.position);
            if (v < 15f)
            {
                points[i].SetActive(false);
                rg.AddForce(new Vector3(0, 50f,0));
            }
        }
    }
    void LateUpdate()
    {
        Movement();
    }
    private void Update()
    {
        point_check();
    }
    public void Ground_animation(float ver)
    {
        animator.SetBool(iswalk, ver > 0 && is_grounded());
        animator.SetBool(isjump_idle, ver == 0 && !is_grounded() && !_is_in_air());
        animator.SetBool(isjump, ver > 0 && !is_grounded() && !_is_in_air());
        animator.SetBool(isruning, ver > 0 && is_grounded() && Input.GetKey(inputsystem.SprintKey));
        animator.SetBool(isruningjump, ver > 0 && !is_grounded() && Input.GetKey(inputsystem.SprintKey) && !_is_in_air());
    }
    public void Air_animation()
    {
        animator.SetBool(isflying, !is_grounded() && _is_in_air());
    }
    float dis(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }
    void movement()
    {
        Move = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(0, -0.1f, inputsystem._Vertical) * (inputsystem._Vertical > 0 && Input.GetKey(inputsystem.SprintKey) ? player_run_speed : player_speed * Time.deltaTime);
        if (!is_grounded() && !_is_in_air())
        {
            rg.MovePosition(transform.position + Move * speed_in_air);
        }
        else
        {
            rg.MovePosition(transform.position + Move);
        }
        if (is_grounded() && Input.GetKeyDown(inputsystem._jump))
        {
            rg.AddForce(new Vector3(0, Jump, 0));
        }
        if(!is_grounded() && _is_in_air())
        {
            Move = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(inputsystem._Horizontal, (Input.GetKey(inputsystem.SprintKey)) ? 2f : 0, 8f) * speed_in_dive * Time.deltaTime;
            rg.MovePosition(transform.position + Move * speed_in_dive);
        }
        if(is_dead())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    bool is_dead()
    {
        return Physics.CheckSphere(checkground.transform.position, 1f, dead);
    }
    public void Movement()
    {
        Ground_animation(inputsystem._Vertical);
        Air_animation();
        transform.Rotate(0, inputsystem._MouseX * rotationspeed, 0);
        movement();
    }
    bool is_grounded()
    {
        return Physics.CheckSphere(checkground.transform.position, 0.1f, mask);
    }
    bool _is_in_air()
    {
        return dis(new Vector3(0, checkground.transform.position.y, 0), new Vector3(0, _ground.transform.position.y, 0)) > Air_distance + 2 || dis(new Vector3(0, checkground.transform.position.y, 0), new Vector3(0, _ground.transform.position.y, 0)) < Air_distance -2;
    }
}