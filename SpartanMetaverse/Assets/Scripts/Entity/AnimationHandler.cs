using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsDie = Animator.StringToHash("IsDie");

    [SerializeField]protected Animator[] animator;

    protected virtual void Awake()
    {
        animator = GetComponentsInChildren<Animator>();
    }

    public void Move(Vector2 obj, AnimatorType animatorType)
    {
        animator[(int)animatorType].SetBool(IsMoving, obj.magnitude > .5f); // �̵� ������ ũ�⸦ �̿��ؼ� bool �� ��ȯ
    }

    public void Die(AnimatorType animatorType)
    {
        animator[(int)animatorType].SetInteger(IsDie, 1);
    }

    public void Damage()
    {
        animator[(int)AnimatorType.Player].SetBool(IsDamage, true); // �ǰ� �ִϸ��̼�
    }

    public void InvincibilityEnd() // ������ ������ �ð�
    {
        animator[(int)AnimatorType.Player].SetBool(IsDamage, false);
    }
}

public enum AnimatorType
{
    Player = 0,
    Vehcle
}
