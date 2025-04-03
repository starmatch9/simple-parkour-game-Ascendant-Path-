using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Roll : MonoBehaviour
{
    public float rollSpeed = 10.0f;
    //因为涉及到碰撞器更新，使用需要移动刚体
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.x <= -40)
        {
            transform.position = new Vector3(40, transform.position.y, transform.position.z);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * rollSpeed * Time.fixedDeltaTime);
    }
}
