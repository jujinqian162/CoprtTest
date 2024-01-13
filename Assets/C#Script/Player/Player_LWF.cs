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
        Debug.Log("item_list_index: " + _item_index);
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_unPickup_item.Count != 0) { 
                _itemList.Add(_unPickup_item[0]);
                _unPickup_item[0].destroy();
                //_unPickup_item.Remove(_unPickup_item[0]);
                _item_index = _itemList.Count - 1;
                _pUI.show_has_picked();

                Debug.Log("Add item");
            }   else  Debug.Log("No item to add");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _item_index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _item_index = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _item_index = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _item_index = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _item_index = 4;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            throwItem(_itemList[_item_index]);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            useItem();
        }
    }
    

    public override void attack()
    {
        if (pre_bullet == null) { Debug.LogError("no pre_bullet"); return; }
        GameObject instantiatedPrefab = Instantiate(pre_bullet);
        Bullet script = instantiatedPrefab.GetComponent<Bullet>();
        script._direction = transform.position;
    }
    
    public override void PickupItem(Item item)
    {
        if (item == null) return;   
        _itemList.Add(item);
    }
    public override void throwItem(Item item)
    {
        Debug.Log("throw Item");
        if (item == null) return;
        _itemList.Remove(item);
    }
    public override void useItem()
    {
        if (_item_index >= _itemList.Count) Debug.LogError("useItem: out of index");
        _itemList[_item_index].Use();
    }
    public override void addUnPickUpItem(Item item)
    {
        _unPickup_item.Add(item);
    }
    public override void removeUnPickUpItem(Item item)
    {
        _unPickup_item.Remove(item);
    }
    private void AddResistance()
    {
        if (!_use_resistance) return;
        Vector2 v = _rb.velocity;
        if (v.magnitude < _resistance_delta) return;
        _rb.AddForce((-v.normalized) * _resistance * (v.magnitude + 1f));
    }
    private void changeItem(int index)
    {
        if (index >= _itemList.Count) Debug.LogError("changeItem: out of index");
        _item_index = index;
    }
}
