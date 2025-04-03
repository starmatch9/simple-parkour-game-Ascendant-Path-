using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    Animator animator;
    Rigidbody2D body;
    public float jumpVelocity = 20;
    //�����жϽ�ɫ�Ƿ���ƽ̨��
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
        //����J���������Ծ���ݶ���
        if (onPlatform && Input.GetKeyDown(KeyCode.K))
        {
            body.velocity = new Vector2 (body.velocity.x, jumpVelocity);
        }
        //��ס�ո��⻬�峵
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
    //����֮ͬǰ������һ�����ǵø�ƽ̨��ͼ����������ʶ��
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
        //�ȵ�һ��ʱ�����ܽ�����һ�ι������൱����ȴʱ��
        yield return new WaitForSeconds(0.5f);
        isAttack = false;
    }
    public void startRun()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("start", true);
    }
}
