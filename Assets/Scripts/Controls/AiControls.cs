using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControls : BaseControls
{
    private MapGenerator _mapGenerator;

    private Vector2 _direction = new Vector2();

    private float _timer = 0;
    private float _shootTimer = 0;
    private const float _resetTimerTime = 0.6f;
    private const float _shootTimerTime = 0.8f;

    private void Awake()
    {
        _mapGenerator = FindObjectOfType<MapGenerator>();
        BotChangeDirection();
    }

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        _shootTimer += Time.fixedDeltaTime;

        MoveKeyHandler();
        ShootKeyHandler();
    }

    private void MoveKeyHandler()
    {
        

        if (_timer > _resetTimerTime)
        {
            BotChangeDirection();
            _timer = 0;
        }
        MoveHandler(_direction);
    }

    private void BotChangeDirection()
    {
        int num = Random.Range(0, 100);
        if (num < 30)
        {
            _direction.x = 1;
            _direction.y = 0;
        }
        else if (num > 30 && num < 61)
        {
            _direction.x = -1;
            _direction.y = 0;
        }
        else if (tank.transform.position.y > 1.5f)
        {
            if (num > 60 && num < 91)
            {
                _direction.x = 0;
                _direction.y = -1;
            }
            else
            {
                _direction.x = 0;
                _direction.y = 1;
            }
        }
    }

    private void ShootKeyHandler()
    {
        if (_shootTimer > _shootTimerTime)
        {
            ShootHandler();
            _shootTimer = 0;
        }
       
    }
    
}
