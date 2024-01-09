using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D _rb;
    public Vector3 _direction;
    public float _speed = 10f;
    const float _t = 1f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        transform.position = _direction + new Vector3(0f, 0.8f, 0f);
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = target - new Vector2(transform.position.x,transform.position.y);//
        float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        transform.position = transform.position + new Vector3(direction.normalized.x, direction.normalized.y, 0f) * _t;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        if (out_of_space()) destory();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") return;
        destory();
    }
    private void destory()
    {
        Destroy(gameObject);
    }
    private bool out_of_space()
    {
        if ((transform.position.x > 40) || (transform.position.y > 30)
            || (transform.position.x < -40) || (transform.position.y < -30))
            return true;
        return false;
    }
}
