using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInput
{
    // Start is called before the first frame update
    IPlayer2 _p;
    List<IPlayer2> _ps;
    GameObject[] _gs;
    public IPlayer2 player
    {
        get
        {
            return _p;
        }
    }
    public void Awake()
    {
        _gs = GameObject.FindGameObjectsWithTag("Player");
        _ps = IPlayer2.CreatePlayerFormGameObjects(_gs);
        if (_gs.Length == 0) Debug.LogError("no player");
        foreach(IPlayer2 p in _ps)
        {
            p.Awake();
        }
        _p = _ps[0];
    }
    public void Start()
    {
        foreach (IPlayer2 p in _ps)
        {
            p.Start();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            previousPlayer();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextPlayer();
        }
        foreach(IPlayer2 p in _ps)
        {
            p.UpdateAlways();
        }
        _p.Update();
    }
    public void setPlayer(int index)
    {
        _p = _ps[index];
    }
    public void nextPlayer()
    {
        if (_ps.Count == 0) Debug.LogError("player[] no elements");
        int current_index = _ps.IndexOf(_p);
        if (current_index + 1 == _ps.Count)
        {
            _p = _ps[0];
        } else
        {
            _p = _ps[current_index + 1];
        }
    }
    public void previousPlayer()
    {
        if (_ps.Count == 0) Debug.LogError("player[] no elements");
        int current_index = _ps.IndexOf(_p);
        if (current_index == 0)
        {
            _p = _ps[_ps.Count - 1];
        }
        else
        {
            _p = _ps[current_index -1];
        }
    }
}
