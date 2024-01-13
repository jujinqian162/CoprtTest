using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour 
{
    public Text _show_PickUp;
    public Text _show_has_picked;


    void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");
        _show_PickUp = canvas.GetComponentsInChildren<Text>()[0];
        _show_has_picked = canvas.GetComponentsInChildren<Text>()[1];
        if (_show_PickUp == null || _show_has_picked == null) Debug.LogError("no prefabs");
    }
    void Start()
    {
        hide_pick_up_text();
        _show_has_picked.enabled = false;
    }
    public void show_pick_up_text()
    {
        _show_PickUp.enabled = true;

    }
    public void hide_pick_up_text()
    {
        _show_PickUp.enabled = false;
    }
    public void show_has_picked()
    {
        StartCoroutine(showToast(_show_has_picked));
    }

    private IEnumerator showToast(Text t ,int time = 1)
    {
        t.enabled = true;
        yield return new WaitForSeconds(time);
        t.enabled = false;
    }
}
