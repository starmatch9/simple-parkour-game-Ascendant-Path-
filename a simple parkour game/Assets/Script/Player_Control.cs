using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    Animator animator;
    Rigidbody2D body;
    public float jumpVelocity = 20;
    //用来判断角色是否在平台上
    bool onPlatform = true;
    bool isAttack = false;
    public GameObject weapon;
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //按键J用来检测跳跃（暂定）
        if (onPlatform && Input.GetKeyDown(KeyCode.K))
        {
            body.velocity = new Vector2 (body.velocity.x, jumpVelocity);
        }
        //按住空格检测滑板车
        if (Input.GetKey(KeyCode.L))
        {
            animator.SetBool("isKickBoard", true);
        }
        else
        {
            animator.SetBool("isKickBoard", false);
        }
        if (!isAttack && Input.GetKey(KeyCode.J) && onPlatform)
        {
            isAttack = true;
            StartCoroutine(Attack());
        }
    }
    //这里同之前的文章一样，记得改平台的图层名称用来识别
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            onPlatform = true;
            animator.SetBool("isJump", false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            onPlatform = true;
            animator.SetBool("isJump", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            onPlatform = false;
            animator.SetBool("isJump", true);
        }
    }
    IEnumerator Attack()
    {
        animator.SetBool("isAttack", true);
        weapon.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("isAttack", false);
        weapon.SetActive(false);
        //等等一段时间后才能进行下一次攻击，相当于冷却时间
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }
    public void startRun()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("start", true);
    }
}
