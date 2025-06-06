using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");
    private static readonly int IsDie = Animator.StringToHash("IsDie");

    public Animator playerAnimator;
    public Animator vehicleAnimator;

    public void Move(Vector2 obj, AnimatorType animatorType)
    {
        playerAnimator.SetBool(IsMoving, obj.magnitude > .5f); // 이동 벡터의 크기를 이용해서 bool 값 반환
    }

    public void Die(AnimatorType animatorType)
    {
        vehicleAnimator.SetInteger(IsDie, 1);
    }

    public void Damage()
    {
        playerAnimator.SetBool(IsDamage, true); // 피격 애니메이션
    }

    public void InvincibilityEnd() // 무적이 끝나는 시간
    {
        playerAnimator.SetBool(IsDamage, false);
    }
}

public enum AnimatorType
{
    Player = 0,
    Vehcle
}
