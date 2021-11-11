using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private GameOverUI _gameOverUi;

    private void Start()
    {
        _gameOverUi = FindObjectOfType<GameOverUI>();
    }
    public void Destruct()
    {
        _gameOverUi.OpenGameOverUi();
        _gameOverUi.SetLoseText();
    }
}
