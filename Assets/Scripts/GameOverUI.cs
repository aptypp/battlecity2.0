using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private TMP_Text _resultText;
    public void OpenGameOverUi()
    {
        _panel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void SetWinText()
    {
        _resultText.text = "You win!!!";
    }

    public void SetLoseText()
    {
        _resultText.text = "You lose :(";
    }
}
