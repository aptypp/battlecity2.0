using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBotTank : BotTank
{
    public override void Death()
    {
        Destroy(gameObject);
        _playerStats.AddScore(250);
        TrySpawnBonus();
    }
}
