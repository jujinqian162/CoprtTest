using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI 
{
    public Text text1;
    public Text text2;
    public Text Text1
    {
        get { return text1; }
    }
    public Text Text2
    {
        get { return text2; }
    }

    public void Awake()
    {
        if (text1 == null || text2 == null) Debug.LogError("no prefabs");
    }
    

}
