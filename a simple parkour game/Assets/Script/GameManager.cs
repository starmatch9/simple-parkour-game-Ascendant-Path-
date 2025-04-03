using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] targets;
    private void Awake()
    {
        //初始化所有的带有标签的物体
        targets = GameObject.FindGameObjectsWithTag("ScriptControl");
        DisableScripts();
        DisableColliders();
    }
    //批量禁用脚本
    public void DisableScripts()
    {
        foreach (GameObject obj in targets)
        {
            //禁用所有继承自MonoBehaviour脚本
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (script != null && script.enabled)
                {
                    script.enabled = false;
                    //这个方法可以用来Debug是否真的禁用了
                    Debug.Log($"已禁用 {obj.name} 上的 {script.GetType().Name}");
                }
            }
        }
    }
    //批量禁用碰撞器和刚体
    public void DisableColliders()
    {
        foreach (GameObject obj in targets)
        {
            //禁用所有碰撞器和刚体（防止人物掉落）
            if (obj.GetComponent<Collider2D>())
            {
                Rigidbody2D[] rbs = obj.GetComponents<Rigidbody2D>();
                foreach (Rigidbody2D rb in rbs)
                {
                    if (rb != null && rb.simulated)
                    {
                        //Rigidbody2D特有的方法，用来定义刚体是否参与物理模拟
                        rb.simulated = false;
                        //这个方法可以用来Debug是否真的禁用了
                        Debug.Log($"已禁用 {obj.name} 上的 {rb.GetType().Name}");
                    }
                }
                Collider2D[] colliders = obj.GetComponents<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    if (collider != null && collider.enabled)
                    {

                        collider.enabled = false;
                        //这个方法可以用来Debug是否真的禁用了
                        Debug.Log($"已禁用 {obj.name} 上的 {collider.GetType().Name}");
                    }
                }
            }
        }
    }
    //批量激活脚本
    public void EnableScripts()
    {
        foreach (GameObject obj in targets)
        {
            //禁用所有继承自MonoBehaviour脚本
            MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                if (script != null && !script.enabled)
                {
                    script.enabled = true;
                    //这个方法可以用来Debug是否真的禁用了
                    Debug.Log($"已禁用 {obj.name} 上的 {script.GetType().Name}");
                }
            }
        }
    }
    //批量激活碰撞器和刚体
    public void EnableColliders()
    {
        foreach (GameObject obj in targets)
        {
            //禁用所有碰撞器和刚体（防止人物掉落）
            if (obj.GetComponent<Collider2D>())
            {
                //先激活碰撞器
                Collider2D[] colliders = obj.GetComponents<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    if (collider != null && !collider.enabled)
                    {

                        collider.enabled = true;
                        //这个方法可以用来Debug是否真的禁用了
                        Debug.Log($"已禁用 {obj.name} 上的 {collider.GetType().Name}");
                    }
                }
                Rigidbody2D[] rbs = obj.GetComponents<Rigidbody2D>();
                foreach (Rigidbody2D rb in rbs)
                {
                    if (rb != null && !rb.simulated)
                    {
                        //Rigidbody2D特有的方法，用来定义刚体是否参与物理模拟
                        rb.simulated = true;
                        //这个方法可以用来Debug是否真的禁用了
                        Debug.Log($"已禁用 {obj.name} 上的 {rb.GetType().Name}");
                    }
                }
            }
        }
    }
    public void ResetScene()
    {
        //等一秒再重新开始
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
