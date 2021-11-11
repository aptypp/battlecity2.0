using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _score;
    private int _enemiesCount;
    private float _tankSpeed;
    private int _healthPoint;
    
    [SerializeField] private PlayerTank _playerTank;
    [SerializeField] private BotSpawner[] _botSpawner;
    [SerializeField] GameOverUI _gameOverUi;

    public int Score { get => _score; }
    public int EnemiesCount { get => _enemiesCount; }
    public float TankSpeed { get => _tankSpeed; }
    public int HealthPoint { get => _healthPoint; }

    public void Init()
    {
        _playerTank = FindObjectOfType<PlayerTank>();
        _botSpawner = FindObjectsOfType<BotSpawner>();
    }

    private void Update()
    {
        UpdateData();
        CheckEnemiesAlive();
    }

    private void UpdateData()
    {
        if(_botSpawner.Length == 0 || _playerTank == null)
        {
            Init();
        }

        _tankSpeed = _playerTank.Speed;
        _enemiesCount = 0;
        _healthPoint = _playerTank.HealthPoint;
        foreach(BotSpawner spawner in _botSpawner)
        {
            _enemiesCount += spawner.AliveBotsCount();
        }
    }

    private void CheckEnemiesAlive()
    {
        if (_enemiesCount > 0)
        {
            return;
        }

        _gameOverUi.OpenGameOverUi();
        _gameOverUi.SetWinText();
    }

    public void AddScore(int score)
    {
        _score += score;
    }
    
}
