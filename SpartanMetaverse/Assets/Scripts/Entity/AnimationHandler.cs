using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");

    protected Animator animator;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f); // �̵� ������ ũ�⸦ �̿��ؼ� bool �� ��ȯ
    }

    public void Damage()
    {
        animator.SetBool(IsDamage, true); // �ǰ� �ִϸ��̼�
    }

    public void InvincibilityEnd() // ������ ������ �ð�
    {
        animator.SetBool(IsDamage, false);
    }
}
