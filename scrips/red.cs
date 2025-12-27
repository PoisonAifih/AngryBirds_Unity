using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour
{

    public Rigidbody2D rb;
    public Rigidbody2D hook;
    public float maks = 2f;
    public SpringJoint2D sj;
    public float diley = 1f;
    public float reloadwait = 2f;
    public UIManager manager;

    private bool click = false;
    void Update()
    {
        if (click == true)
        {
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mouse, hook.position) > maks)
                rb.position = hook.position + (mouse - hook.position).normalized * maks;
            else
                rb.position = mouse;
        }
    }
    void OnMouseDown()
    {
        click = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        click = false;
        rb.isKinematic = false;
        StartCoroutine(LemparDelay());
    }
    IEnumerator LemparDelay()
    {
        yield return new WaitForSeconds(diley);
        sj.enabled = false;
        yield return new WaitForSeconds(reloadwait);
        manager.reload();
    }
}

