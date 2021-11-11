using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : BaseTank
{
    [SerializeField] GameOverUI _gameOverUi;
    public override void Death()
    {
        _gameOverUi.OpenGameOverUi();
        _gameOverUi.SetLoseText();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseBonus bonus = collision.GetComponent<BaseBonus>();

        if(bonus != null)
        {
            bonus.TakeBonus();
        }
    }

    public void SpeedUp(float bonus)
    {
        if (_speed > 10)
        {
            return;
        }
        StartCoroutine(ChangeSpeed(bonus));
    }

    private IEnumerator ChangeSpeed(float bonus)
    {
        _speed += bonus;
        yield return new WaitForSeconds(5.0f);
        _speed -= bonus;
    }
}
