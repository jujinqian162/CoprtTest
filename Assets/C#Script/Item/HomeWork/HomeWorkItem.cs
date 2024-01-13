using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorkItem : Item
{
    public HomeWorkItem(GameObject _go)
    {
        _item_object = _go;
    }

    public override void destroy()
    {
        HomeWork _hw = _item_object.GetComponent<HomeWork>();
        _hw.destory();
    }

    public override void Use()
    {
        Debug.Log("Use home work item");
        //TODO UI ...
    }

}
