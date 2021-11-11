using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotTank : BaseTank
{
    [SerializeField] private List<BaseBonus> _bonuses;
    public override void Death()
    {
        Destroy(gameObject);
        _playerStats.AddScore(100);
        TrySpawnBonus();
    }

    public void TrySpawnBonus()
    {
        int num = Random.Range(0, 30);
        if (num < 20)
        {
            return;
        }
        int index = Random.Range(0, _bonuses.Count);
        Instantiate(_bonuses[index].gameObject, transform.position, Quaternion.identity);
    }
}
