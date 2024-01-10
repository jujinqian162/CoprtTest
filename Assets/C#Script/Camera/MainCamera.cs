using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MainCamera : MonoBehaviour
{
    Rigidbody2D _rb;
    MyInput _im;
    Camera _cm;
    
    const float _resistance_delta = 0.01f;
    public float _resistance = 2.5f;
    public float _scroll_speed = 0.3f;
    public bool _use_resistance = true;
    public float _camera_nomove_ranges = 3f;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();  
        _cm = GetComponent<Camera>();
        _im = new MyInput();
        _im.Awake();
    }
    void Start()
    {
        _resistance = 2.5f;
        _scroll_speed = 0.3f;
        _im.Start();
    }

// Update is called once per frame
void Update()
    {
        _im.Update();
        _Input();
        //MoveToPlayer(_player);
        MoveToPlayer2(_im.player);
        AddResistance(); //加阻力
    }
    
    private void _Input()
    {
        float scInput = Input.GetAxis("Mouse ScrollWheel");
        
        if (scInput > 0)
        {
            if (_cm.orthographicSize >= 3)
            _cm.orthographicSize -= _scroll_speed;
        } 
        else if (scInput < 0)
        {
            if (_cm.orthographicSize <= 11)
            _cm.orthographicSize += _scroll_speed;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            //TODO
        }
    }
    private void MoveToPlayer(IPlayer p)
    {
        if (is_player_in_ranges(p)) return;
        float _diff = (transform.position - p.transform.position).magnitude - _camera_nomove_ranges;
        _rb.AddForce((p.transform.position - transform.position).normalized * _diff * _diff); // 力的大小与距离的二次方成正比
    }
    private void MoveToPlayer2(IPlayer2 p)
    {
        if (is_player2_in_ranges(p)) return;
        float _diff = (transform.position - p.player.transform.position).magnitude - _camera_nomove_ranges;
        _rb.AddForce((p.player.transform.position - transform.position).normalized * _diff * _diff); // 力的大小与距离的二次方成正比
    }
    private bool is_player2_in_ranges(IPlayer2 p)
    {
        return (transform.position - p.player.transform.position).magnitude < _camera_nomove_ranges;
    }
    private bool is_player_in_ranges(IPlayer p)
    {
        return (transform.position - p.transform.position).magnitude < _camera_nomove_ranges;
    }
    private void AddResistance()
    {
        if (!_use_resistance) return;
        Vector2 v = _rb.velocity;
        if (v.magnitude < _resistance_delta) return; //速度小于一定值无阻力
        _rb.AddForce((-v.normalized) * _resistance * (v.magnitude + 1f)); // 阻力与速度成一次函数
    }
}
