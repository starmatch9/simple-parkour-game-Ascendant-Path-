using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{
    Animator animator;
    //角色的死亡关系到游戏的结束
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
            //游戏结束
            gameManager.ResetScene();
        }
    }
}
