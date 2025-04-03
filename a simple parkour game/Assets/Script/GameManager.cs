using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] targets;
    private void Awake()
    {
        //��ʼ�����еĴ��б�ǩ������
        targets = GameObject.FindGameObjectsWithTag("ScriptControl");
        DisableScripts();
        DisableColliders();
    }
    //�������ýű�
    public void DisableScripts()
    {
        foreach (GameObject obj in targets)
        {
            //�������м̳���MonoBehaviour�ű�
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (script != null && script.enabled)
                {
                    script.enabled = false;
                    //���������������Debug�Ƿ���Ľ�����
                    Debug.Log($"�ѽ��� {obj.name} �ϵ� {script.GetType().Name}");
                }
            }
        }
    }
    //����������ײ���͸���
    public void DisableColliders()
    {
        foreach (GameObject obj in targets)
        {
            //����������ײ���͸��壨��ֹ������䣩
            if (obj.GetComponent<Collider2D>())
            {
                Rigidbody2D[] rbs = obj.GetComponents<Rigidbody2D>();
                foreach (Rigidbody2D rb in rbs)
                {
                    if (rb != null && rb.simulated)
                    {
                        //Rigidbody2D���еķ�����������������Ƿ��������ģ��
                        rb.simulated = false;
                        //���������������Debug�Ƿ���Ľ�����
                        Debug.Log($"�ѽ��� {obj.name} �ϵ� {rb.GetType().Name}");
                    }
                }
                Collider2D[] colliders = obj.GetComponents<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    if (collider != null && collider.enabled)
                    {

                        collider.enabled = false;
                        //���������������Debug�Ƿ���Ľ�����
                        Debug.Log($"�ѽ��� {obj.name} �ϵ� {collider.GetType().Name}");
                    }
                }
            }
        }
    }
    //��������ű�
    public void EnableScripts()
    {
        foreach (GameObject obj in targets)
        {
            //�������м̳���MonoBehaviour�ű�
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (script != null && !script.enabled)
                {
                    script.enabled = true;
                    //���������������Debug�Ƿ���Ľ�����
                    Debug.Log($"�ѽ��� {obj.name} �ϵ� {script.GetType().Name}");
                }
            }
        }
    }
    //����������ײ���͸���
    public void EnableColliders()
    {
        foreach (GameObject obj in targets)
        {
            //����������ײ���͸��壨��ֹ������䣩
            if (obj.GetComponent<Collider2D>())
            {
                //�ȼ�����ײ��
                Collider2D[] colliders = obj.GetComponents<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    if (collider != null && !collider.enabled)
                    {

                        collider.enabled = true;
                        //���������������Debug�Ƿ���Ľ�����
                        Debug.Log($"�ѽ��� {obj.name} �ϵ� {collider.GetType().Name}");
                    }
                }
                Rigidbody2D[] rbs = obj.GetComponents<Rigidbody2D>();
                foreach (Rigidbody2D rb in rbs)
                {
                    if (rb != null && !rb.simulated)
                    {
                        //Rigidbody2D���еķ�����������������Ƿ��������ģ��
                        rb.simulated = true;
                        //���������������Debug�Ƿ���Ľ�����
                        Debug.Log($"�ѽ��� {obj.name} �ϵ� {rb.GetType().Name}");
                    }
                }
            }
        }
    }
    public void ResetScene()
    {
        //��һ�������¿�ʼ
        StartCoroutine(ReloadWithFade());
    }
    IEnumerator ReloadWithFade()
    {
        DisableColliders();
        DisableScripts();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
