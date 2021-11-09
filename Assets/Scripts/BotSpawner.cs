using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private int _botCount = 5;

    [SerializeField] private List<BaseTank> _botTankPrefabs;

    private BaseTank _currentTank;

    public int BotCount { get => _botCount; }

    private void Update()
    {
        if(_currentTank == null && _botCount > 0)
        {
            SpawnBot();
        }
    }

    private void SpawnBot()
    {
        int num = Random.Range(0, _botTankPrefabs.Count);
        GameObject temp = Instantiate(_botTankPrefabs[num].gameObject, transform);
        _currentTank = temp.GetComponent<BaseTank>();
        _botCount--;
    }
}
