using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer : MonoBehaviour 
{
    // Start is called before the first frame update
    protected Rigidbody2D _rb;
    public GameObject pre_bullet;
    public Rigidbody2D rigidBody
    {
        get { return _rb; }
    }
    protected virtual void Awake()
    {
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
}
