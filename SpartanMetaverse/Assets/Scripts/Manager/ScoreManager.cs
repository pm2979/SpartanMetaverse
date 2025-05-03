using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score { get; private set; }

    protected override void Awake()
    {
        Score = 0;
    }

    public void AddScore(int coin)
    {
        Score += coin;
    }

}
