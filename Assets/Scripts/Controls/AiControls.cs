using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControls : BaseControls
{
    private MapGenerator _mapGenerator;

    private Vector2 _direction = new Vector2();

    private float _timer = 0;

    private const float _resetTimerTime = 1000;
    private const float _shootTimerTime = 700;

    private void Awake()
    {
        _mapGenerator = FindObjectOfType<MapGenerator>();
        BotChangeDirection();
    }

    private void Update()
    {
        MoveKeyHandler();
        ShootKeyHandler();
    }

    private void MoveKeyHandler()
    {
        _timer += Time.time;

        if (_timer > _resetTimerTime)
        {
            BotChangeDirection();
            _timer = 0;
        }
        MoveHandler(_direction);
    }

    private void BotChangeDirection()
    {
        int num = Random.Range(0, 41);
        if (num < 10)
        {
            _direction.x = 1;
            _direction.y = 0;
        }
        else if (num > 10 && num < 21)
        {
            _direction.x = -1;
            _direction.y = 0;
        }
        else if (tank.transform.position.y > 1.5f)
        {
            if (num > 20 && num < 31)
            {
                _direction.y = 0;
                _direction.x = 1;
            }
            else
            {
                _direction.x = 0;
                _direction.y = -1;
            }
        }
    }

    private void ShootKeyHandler()
    {
        if (_timer > _shootTimerTime)
        {
            ShootHandler();
        }
       
    }
    
}
