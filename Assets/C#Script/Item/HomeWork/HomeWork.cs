using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWork : MonoBehaviour
{
    // Start is called before the first frame update
    HomeWorkItem _item;
    static int i = 0;
    void Start()
    {
        _item = new HomeWorkItem(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("OnTriggerEnter2D");
            GameObject _GOp = collision.gameObject;
            IPlayer _IPlayer = _GOp.GetComponent<IPlayer>();
            _IPlayer.addUnPickUpItem(_item);
            ++i;
            _IPlayer.playerUI.show_pick_up_text();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            Debug.Log("OnTriggerExit2D");
            GameObject _GOp = collision.gameObject;
            IPlayer _IPlayer = _GOp.GetComponent<IPlayer>();
            _IPlayer.removeUnPickUpItem( _item);
            --i;
            if (i <= 0)
            _IPlayer.playerUI.hide_pick_up_text();
        }
    }
    public void destory()
    {
        Destroy(gameObject);
    }
}
