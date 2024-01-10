using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer2 
{
    protected Rigidbody2D _rb;
    //public GameObject pre_bullet;
    protected GameObject _player;
    public GameObject player
    {
        get
        {
            return _player;
        }
    }
    public Rigidbody2D rigidBody
    {
        get { return _rb; }
    }
    // Start is called before the first frame update
    public static List<IPlayer2> CreatePlayerFormGameObjects(GameObject[] _gs)
    {
        List<IPlayer2> list = new List<IPlayer2>();
        foreach (GameObject go in _gs)
        {
            list.Add(new Player_JJQ(go));
        }
        return list;
    }
    public virtual void Awake() { }
    public virtual void Start() { }

    public virtual void Update() { } 
    
    public virtual void attack() { }
 
    public virtual void UpdateAlways() { }
}
