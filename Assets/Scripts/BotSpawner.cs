using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private int _botCount = 5;

    [SerializeField] private List<BaseTank> _botTankPrefabs = new List<BaseTank>();

    [SerializeField] private List<BotSpawnPoint> _botSpawnPoints = new List<BotSpawnPoint>();

    private List<BaseTank> _currentTanks = new List<BaseTank>();

    private int _currentSpawnPointIndex = 0;

    public int AliveBotsCount()
    {
        return _botCount + _currentTanks.Count;
    }

    private void Update()
    {
        DeleteNullBots();
        if (_currentTanks.Count < _botSpawnPoints.Count && _botCount > 0)
        {
            TrySpawnBot();
        }
    }

    private void DeleteNullBots()
    {
        int index = 0;
        do
        {
            if (_currentTanks.Count == 0)
            {
                return;
            }

            if (_currentTanks[index] == null)
            {
                _currentTanks.Remove(_currentTanks[index]);
                continue;
            }
            index++;
        } while (index < _currentTanks.Count);
    }

    private void TrySpawnBot()
    {
        int index = Random.Range(0, _botTankPrefabs.Count);
        
        if(_currentTanks.Count < _botSpawnPoints.Count && _botCount > 0)
        {
            SpawnBot(index, _botSpawnPoints[_currentSpawnPointIndex].transform.position);
            _currentSpawnPointIndex++;
            _currentSpawnPointIndex %= _botSpawnPoints.Count;
        }
    }

    private void SpawnBot(int index, Vector3 point)
    {
        GameObject temp = Instantiate(_botTankPrefabs[index].gameObject, point, Quaternion.identity);
        _currentTanks.Add(temp.GetComponent<BaseTank>());
        _botCount--;
    }

    public void AddSpawnPoint(BotSpawnPoint point)
    {
        _botSpawnPoints.Add(point);
    }

}
