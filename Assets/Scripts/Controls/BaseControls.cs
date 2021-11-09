using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseControls : MonoBehaviour
{
    [SerializeField] protected BaseTank tank;

    public void MoveHandler(Vector2 moveDirection)
    {
        if(tank == null)
        {
            Debug.LogError("tank is null");
            return;
        }
        tank.Move(moveDirection);
    }

    public void ShootHandler()
    {
        if (tank == null)
        {
            Debug.LogError("tank is null");
            return;
        }
        tank.Shoot();
    }
}
