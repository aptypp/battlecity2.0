using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : BaseBonus
{
    private PlayerTank _playerTank;
    [SerializeField] int _speedBonus = 2;

    private void Start()
    {
        _playerTank = FindObjectOfType<PlayerTank>();    
    }
    public override void TakeBonus()
    {
        _playerTank.SpeedUp(_speedBonus);
        Destroy(gameObject);
    }
}
