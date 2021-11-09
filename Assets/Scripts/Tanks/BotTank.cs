using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTank : BaseTank
{
    public override void Death()
    {
        Destroy(gameObject);
        _playerStats.AddScore(100);
    }
}
