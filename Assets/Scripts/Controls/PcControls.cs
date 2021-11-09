using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : BaseControls
{

    private void Update()
    {
        MoveKeyHandler();
        ShootKeyHandler();
    }

    private void MoveKeyHandler()
    {
        Vector2 direction = new Vector2();
        
        direction.x = Input.GetAxis("Horizontal");
        if (direction.x == 0)
        {
            direction.y = Input.GetAxis("Vertical");
        }

        if(direction == Vector2.zero)
        {
            return;
        }
        MoveHandler(direction);
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
