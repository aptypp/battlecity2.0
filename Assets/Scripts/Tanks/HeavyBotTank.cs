using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBotTank : BotTank
{
    public override void Death()
    {
        Destroy(gameObject);
        _playerStats.AddScore(500);
        TrySpawnBonus();
    }
}
