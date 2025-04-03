using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Obstacle : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject monster;
    GameObject current;
    public float rollSpeed = 10.0f;
    //��Ϊ�漰����ײ�����£�ʹ����Ҫ�ƶ�����
    Rigidbody2D rb;
    //���������
    public Queue<GameObject> pool = new Queue<GameObject>();
    //��ʼ�������
    void InitializePool()
    {
        //�ڳ��д�����������
        for (int i = 0; i < 2; i++)
        {
            GameObject obj1 = Instantiate(obstacle1);
            obj1.SetActive(false);
            pool.Enqueue(obj1);//�������
            GameObject obj2 = Instantiate(obstacle2);
            obj2.SetActive(false);
            pool.Enqueue(obj2);//�������
            GameObject obj3 = Instantiate(monster);
            obj3.SetActive(false);
            pool.Enqueue(obj3);//�������
        }
    }
    //�Ӷ�������ȡ����
    public GameObject GetObject()
    {
        return pool.Dequeue();//Ȣһ���������Ԫ��
    }
    //���ն���
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
    void Start()
    {
        InitializePool();
        current = GetObject();
        current.SetActive(true);
        rb = current.GetComponent<Rigidbody2D>();
        //�������λ�����������õ����ɵ��λ��
        rb.position = transform.position;
    }
    void Update()
    {
        //-20Ϊ�������Χ�����������
        if (current.transform.position.x <= -20)
        {
            ReturnObject(current);
            current = GetObject();
            current.SetActive(true);
            rb = current.GetComponent<Rigidbody2D>();
            Collider2D collider = current.GetComponent<Collider2D>();
            collider.enabled = true;
            //�������λ�����������õ����ɵ��λ��
            rb.position = transform.position;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * rollSpeed * Time.fixedDeltaTime);
    }
}
