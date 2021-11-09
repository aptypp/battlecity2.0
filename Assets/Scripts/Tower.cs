using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameOverUI _gameOverPanel;

    private void Start()
    {
        _gameOverPanel = FindObjectOfType<GameOverUI>();
    }
    public void Destruct()
    {
        _gameOverPanel.OpenGameOverUi();
    }
}
