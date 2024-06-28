using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    [Header("������Ʈ")]
    public Rigidbody rb;
    public CapsuleCollider capCol;
    public Animator animator;

    [Header("���� ����")]
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

    private void OnCollisionEnter(Collision col)    //�浹 �����ϴ�
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            rb.mass = 8000f;    //�浹�� �� ���� ����
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
        capCol.enabled = false; //�׾��� �� Collider��Ȱ��ȭ�ؼ� ���������

        rb.isKinematic = true; //������ ����
        IsDie = true;

    }
}
