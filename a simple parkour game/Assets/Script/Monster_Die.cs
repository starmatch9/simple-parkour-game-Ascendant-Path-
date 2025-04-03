using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        //��ΪҪ���ص��������ϣ�����Ҫ��ȡ������Ķ�����
        animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            animator.SetBool("die", true);
            //��Ҫ�����ɵ�ű�������ʹ��ָ�
            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;
        }
    }
}
