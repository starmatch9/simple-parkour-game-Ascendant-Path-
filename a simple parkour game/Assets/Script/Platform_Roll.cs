using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Roll : MonoBehaviour
{
    public float rollSpeed = 10.0f;
    //��Ϊ�漰����ײ�����£�ʹ����Ҫ�ƶ�����
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
