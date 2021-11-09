using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBonus : BaseBonus
{
    private PlayerStats _playerStats;
    [SerializeField] int _scoreBonus = 200;

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();    
    }
    public override void TakeBonus()
    {
        _playerStats.AddScore(_scoreBonus);
        Destroy(gameObject);
    }
}
