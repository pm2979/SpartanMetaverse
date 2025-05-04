using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = UnityEngine.Animator.StringToHash("IsMove");
    private static readonly int IsDamage = UnityEngine.Animator.StringToHash("IsDamage");
    private static readonly int IsDie = UnityEngine.Animator.StringToHash("IsDie");

    public Animator animator;

    public void Move(Vector2 obj, AnimatorType animatorType)
    {
        animator.SetBool(IsMoving, obj.magnitude > .5f); // �̵� ������ ũ�⸦ �̿��ؼ� bool �� ��ȯ
    }

    public void Die(AnimatorType animatorType)
    {
        //animator.SetInteger(IsDie, 1);
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

public enum AnimatorType
{
    Player = 0,
    Vehcle
}
