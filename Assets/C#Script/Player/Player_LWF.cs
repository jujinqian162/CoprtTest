using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LWF : IPlayer
{
    const float crunning_force = 8.5f;
    const float cshift_running_force = 3f;
    public float _resistance_delta = 0.01f;
    public float _resistance = 0.9f;
    public float _running_force = 8.5f;
    public bool _use_resistance = true;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
    }
    protected override void Start()
    {
        base.Start();
        transform.position = new Vector2(0, 0);
        _resistance_delta = 0.01f;
        _resistance = 0.9f;
        _running_force = crunning_force;
    }

    protected override void Update()
    {
        base.Update();
        InputProcess();
        AddResistance();
    }

    private void InputProcess()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb.AddForce(new Vector2(-1, 0) * _running_force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.AddForce(new Vector2(0, -1) * _running_force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(new Vector2(1, 0) * _running_force);
        }
        if (Input.GetKey(KeyCode.W))
        {
            _rb.AddForce(new Vector2(0, 1) * _running_force);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _running_force = cshift_running_force;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _running_force = crunning_force;
        }
    }
    
    private void AddResistance()
    {
        if (!_use_resistance) return;
        Vector2 v = _rb.velocity;
        if (v.magnitude < _resistance_delta) return;
        _rb.AddForce((-v.normalized) * _resistance * (v.magnitude + 1f));
    }
    public override void attack()
    {
        if (pre_bullet == null) { Debug.LogError("no pre_bullet"); return; }
        GameObject instantiatedPrefab = Instantiate(pre_bullet);
        Bullet script = instantiatedPrefab.GetComponent<Bullet>();
        script._direction = transform.position;
    }


}
