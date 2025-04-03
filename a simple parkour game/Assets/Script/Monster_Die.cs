using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Die : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        //因为要挂载到父物体上，所以要获取子物体的动画器
        animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            animator.SetBool("die", true);
            //需要在生成点脚本中重新使其恢复
            Collider2D collider = GetComponent<Collider2D>();
            collider.enabled = false;
        }
    }
}
