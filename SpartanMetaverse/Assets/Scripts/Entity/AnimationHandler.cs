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
        animator.SetBool(IsMoving, obj.magnitude > .5f); // 이동 벡터의 크기를 이용해서 bool 값 반환
    }

    public void Damage()
    {
        animator.SetBool(IsDamage, true); // 피격 애니메이션
    }

    public void InvincibilityEnd() // 무적이 끝나는 시간
    {
        animator.SetBool(IsDamage, false);
    }
}
