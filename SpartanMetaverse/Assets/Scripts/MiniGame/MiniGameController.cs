using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameController : MonoBehaviour
{
    protected AnimationHandler animationHandler;
    protected Rigidbody2D _rb;

    float deathCooldown = 0f;
    public bool isDead = false;
    public bool godMode = false;

    protected virtual void Start()
    {
        animationHandler = GetComponent<AnimationHandler>();
        _rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D col) // 충돌
    {
        if (godMode) return;

        if (isDead) return;

        if (col.gameObject.CompareTag("Obstacle")) //
        {
            isDead = true;
            deathCooldown = 1f;

            animationHandler.Die(AnimatorType.Vehcle);
            animationHandler.Damage();
            MiniGameManager.Instance.GameOver();
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Coin")) // 코인 회득 시
        {
            int _coinValue = col.GetComponent<CoinController>().CoinValue;
            ScoreManager.Instance.AddScore(_coinValue); // 스코어 매니저에서 점수 상승
            Destroy(col.gameObject);

        }
    }
}
