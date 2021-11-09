using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsVisualizer : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _tankSpeedText;
    [SerializeField] private TMP_Text _enemiesCountText;
    [SerializeField] private TMP_Text _healthPointText;

    public void Update()
    {
        _scoreText.text = "Score: " + _playerStats.Score.ToString();
        _tankSpeedText.text = "Tank speed: " + _playerStats.TankSpeed.ToString();
        _enemiesCountText.text = "Enemies count: " + _playerStats.EnemiesCount.ToString();
        _healthPointText.text = "Health point: " + _playerStats.HealthPoint.ToString();
    }
}
