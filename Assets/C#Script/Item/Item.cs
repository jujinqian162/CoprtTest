using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    protected GameObject _item_object;
    public abstract void Use();
    public abstract void destroy();
}
