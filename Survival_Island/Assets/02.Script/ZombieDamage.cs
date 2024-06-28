using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    [Header("컴포넌트")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;

    [Header("관련 변수")]
    public string playerTag = "Player";
    public string bulletTag = "BULLET";
    public string HitStr = "HitTrigger";
    public string dieStr = "DieTrigger";
    public int hitCount = 0;
    public bool IsDie = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capCol = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision col)    //충돌 감지하는
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 8000f;    //충돌할 때 무게 증가
            rb.freezeRotation = false;
        }

        else if(col.gameObject.CompareTag(bulletTag))
        {
            Destroy(col.gameObject);
            animator.SetTrigger(HitStr);

            if(++hitCount == 5)
            {
                ZombieDie();
            }
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag(playerTag))
            rb.mass = 75f;
    }

    void ZombieDie()
    {
        animator.SetTrigger(dieStr);
        capCol.enabled = false; //죽었을 때 Collider비활성화해서 못따라오게

        rb.isKinematic = true; //물리력 제거
        IsDie = true;

    }
}
