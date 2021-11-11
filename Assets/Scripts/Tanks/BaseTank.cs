using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTank : MonoBehaviour
{
    [SerializeField] protected int _healthPoint = 1;
    [SerializeField] protected float _speed = 1.0f;
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected Transform _bulletSpawnPosition;

    protected PlayerStats _playerStats;

    protected Vector2 _moveDirection;

    protected Bullet _currentBullet;

    public float Speed { get => _speed; }
    public int HealthPoint { get => _healthPoint; }

    private void Start()
    {
        _moveDirection = transform.up;
        _playerStats = FindObjectOfType<PlayerStats>();
    }

    public void Move(Vector2 direction)
    {
        _moveDirection = direction;
        Rotate();
        _rigidbody.MovePosition((Vector2)transform.position + _moveDirection * _speed * Time.fixedDeltaTime);
    }

    protected void Rotate()
    {
        float angle = 0;
        if(_moveDirection.x != 0)
        {
            angle = -90 * _moveDirection.x;
        }
        if(_moveDirection.y != 0)
        {
            angle = 90 * (1  - _moveDirection.y);
        }
        
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void Shoot()
    {
        if(_currentBullet != null)
        {
            return;
        }

        _currentBullet = Instantiate(_bulletPrefab, _bulletSpawnPosition.position, Quaternion.identity);
        _currentBullet.SetOwner(this);
        _currentBullet.SetMoveDirection(_moveDirection);
    }

    public void TakeDamage()
    {
        _healthPoint--;
        if (_healthPoint > 0)
        {
            return;
        }

        Death();
    }

    public abstract void Death();
}
