using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour 
{
    // Start is called before the first frame update
    protected Rigidbody2D _rb;
    protected PlayerUI _pUI;
    protected List<Item> _itemList = new List<Item>();
    protected int _item_index = 0;
    protected List<Item> _unPickup_item = new List<Item>();
    public GameObject pre_bullet;
    public PlayerUI playerUI
    {
        get { return _pUI; }
    }
    public Rigidbody2D rigidBody
    {
        get { return _rb; }
    }
    protected virtual void Awake()
    {
        GameObject _UIob = GameObject.Find("UIsystem");
        _pUI = _UIob.GetComponentInChildren<PlayerUI>(); 
        if ( _pUI == null ) { Debug.LogError("Component nulll!"); }
        Debug.Log("Awake IPlayer");
    }
    protected virtual void Start()
    {
        Debug.Log("Init IPlayer");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log("IPlayer update");
        if (Input.GetMouseButtonDown(0))
        {
            attack(); 
            Debug.LogWarning("attack");
        }
    }
    public virtual void attack() => Debug.Log("Player attack");
    public virtual void PickupItem(Item item) { }
    public virtual void throwItem(Item item) { }
    public virtual void useItem() { }
    public virtual void addUnPickUpItem(Item item) { }
    public virtual void removeUnPickUpItem(Item item) { }



}
