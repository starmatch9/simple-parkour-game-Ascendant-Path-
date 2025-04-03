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
    //因为涉及到碰撞器更新，使用需要移动刚体
    Rigidbody2D rb;
    //创建对象池
    public Queue<GameObject> pool = new Queue<GameObject>();
    //初始化对象池
    void InitializePool()
    {
        //在池中创建六个对象
        for (int i = 0; i < 2; i++)
        {
            GameObject obj1 = Instantiate(obstacle1);
            obj1.SetActive(false);
            pool.Enqueue(obj1);//放入队列
            GameObject obj2 = Instantiate(obstacle2);
            obj2.SetActive(false);
            pool.Enqueue(obj2);//放入队列
            GameObject obj3 = Instantiate(monster);
            obj3.SetActive(false);
            pool.Enqueue(obj3);//放入队列
        }
    }
    //从对象池里获取对象
    public GameObject GetObject()
    {
        return pool.Dequeue();//娶一个队列里的元素
    }
    //回收对象
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
        //让物体的位置在我们设置的生成点的位置
        rb.position = transform.position;
    }
    void Update()
    {
        //-20为摄像机范围左侧的少许距离
        if (current.transform.position.x <= -20)
        {
            ReturnObject(current);
            current = GetObject();
            current.SetActive(true);
            rb = current.GetComponent<Rigidbody2D>();
            Collider2D collider = current.GetComponent<Collider2D>();
            collider.enabled = true;
            //让物体的位置在我们设置的生成点的位置
            rb.position = transform.position;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * rollSpeed * Time.fixedDeltaTime);
    }
}
