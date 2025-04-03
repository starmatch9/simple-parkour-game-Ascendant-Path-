using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Roll : MonoBehaviour
{
    public float rollSpeed = 10.0f;
    void Update()
    {
        if (transform.position.x <= -40)
        {
            transform.position = new Vector3(40, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector2.left * rollSpeed * Time.deltaTime);
    }
}
