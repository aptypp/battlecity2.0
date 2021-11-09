using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BaseTank _owner;
    private Vector2 _moveDirection;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Rigidbody2D _rigidbody;

    public void SetOwner(BaseTank tank)
    {
        if(_owner != null)
        {
            return;
        }

        _owner = tank;
    }

    public void SetMoveDirection(Vector2 direction)
    {
        if (_moveDirection != Vector2.zero)
        {
            return;
        }

        _moveDirection = direction;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.MovePosition((Vector2)transform.position + _moveDirection * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BaseBlock block = collision.transform.GetComponent<BaseBlock>();

        if(block != null)
        {
            block.Damage();
        }

        BaseTank botTank = collision.transform.GetComponent<BotTank>();

        if (botTank != null)
        {
            if(_owner.GetType() == typeof(PlayerTank))
            {
                botTank.TakeDamage();
            }
        }

        BaseTank playerTank = collision.transform.GetComponent<PlayerTank>();

        if (playerTank != null)
        {
            if (_owner.GetType() == typeof(BotTank))
            {
                playerTank.TakeDamage();
            }
        }

        Tower tower = collision.transform.GetComponent<Tower>();

        if (tower != null)
        {
            tower.Destruct();
        }
        Destroy(gameObject);
    }
}
