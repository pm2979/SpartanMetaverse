using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerController player { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        player = FindObjectOfType<PlayerController>();
        player.Init(this);
    }

}
