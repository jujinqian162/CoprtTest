using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player_JJQ : IPlayer2
{

    const float crunning_force = 8.5f;
    const float cshift_running_force = 3f;
    public float _resistance_delta = 0.01f;
    public float _resistance = 0.9f;
    public float _running_force = 8.5f;
    public bool _use_resistance = true;


    public Player_JJQ(GameObject go)
    {
        _player = go;
    }
    public override void Awake()
    {
        base.Awake();
        _rb = _player.GetComponent<Rigidbody2D>();
    }
    public override void Start()
    {
        base.Start();
        _resistance_delta = 0.01f;
        _resistance = 0.9f;
        _running_force = crunning_force;
    }
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        InputProcess();
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
    //public override void attack()
    //{
    //    base.attack();
    //    if (pre_bullet == null) { Debug.LogError("no pre_bullet"); return; }
    //    GameObject instantiatedPrefab = Object.Instantiate(pre_bullet);
    //    Bullet script = instantiatedPrefab.GetComponent<Bullet>();
    //    script._direction = _player.transform.position;
    //}

    public override void UpdateAlways()
    {
        base.UpdateAlways();
        AddResistance();
    }


}
