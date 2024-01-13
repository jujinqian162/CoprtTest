using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    UIsystem _UISystem;
    private void Awake()
    {
        InitSystem();
        _UISystem.Awake();
    }
    void Start()
    {
        _UISystem.Start();
    }

    // Update is called once per frame
    void Update()
    {
        _UISystem.Update();
    }
    private void InitSystem() {
        _UISystem = new UIsystem();
    }
}
