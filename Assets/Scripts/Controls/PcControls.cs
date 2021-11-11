using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : BaseControls
{
    private Vector2 _direction;
    private void Update()
    {
        MoveKeyHandler();
        ShootKeyHandler();
    }

    private void FixedUpdate()
    {
        MoveTank();
    }

    private void MoveTank()
    {
        if (_direction == Vector2.zero)
        {
            return;
        }
        MoveHandler(_direction);
    }

    private void MoveKeyHandler()
    {
        _direction = new Vector2();
        
        _direction.x = Input.GetAxis("Horizontal");
        if (_direction.x == 0)
        {
            _direction.y = Input.GetAxis("Vertical");
        }
    }

    private void ShootKeyHandler()
    {
        bool pushed = Input.GetKeyDown(KeyCode.Space);
        if (pushed == false)
        {
            return;
        }
        ShootHandler();
    }
    
}
