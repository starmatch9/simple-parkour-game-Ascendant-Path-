using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{
    Animator animator;
    //��ɫ��������ϵ����Ϸ�Ľ���
    public GameManager gameManager;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Monster"))
        {
            animator.SetBool("die", true);
            //��Ϸ����
            gameManager.ResetScene();
        }
    }
}
