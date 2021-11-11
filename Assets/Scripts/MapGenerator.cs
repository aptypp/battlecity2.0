using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _mapSize;

    [SerializeField] private BotSpawner _botSpawner;

    public Vector2Int MapSize { get => _mapSize; }

    [SerializeField] private BorderBlock _borderPrefab;
    [SerializeField] private BrickBlock _brickPrefab;
    [SerializeField] private GameObject _towerPrefab;
    [SerializeField] private BotSpawnPoint _botSpawnPointPrefab;
    

    private float _timer;
    [SerializeField] private const float _bonusTime = 10000;

    private BaseBlock[,] blocks;

    public BaseBlock GetBlockFromArray(Vector2Int coordinates)
    {
        return blocks[coordinates.x, coordinates.y];
    }

    private void Start()
    {
        blocks = new BaseBlock[_mapSize.y, _mapSize.x];
        GenerateMap();
    }

    private void InstantiateBotSpawnPoint(Vector3 position)
    {
        GameObject temp = Instantiate(_botSpawnPointPrefab.gameObject, position, Quaternion.identity);
        _botSpawner.AddSpawnPoint(temp.GetComponent<BotSpawnPoint>());
    }

    //тут будет страшно
    public void GenerateMap()
    {
        Instantiate(_towerPrefab, new Vector3(_mapSize.x/2 - 1, 1, 0), Quaternion.identity);

        InstantiateBotSpawnPoint(new Vector3(1, _mapSize.y - 2, 0));
        InstantiateBotSpawnPoint(new Vector3(_mapSize.x / 2, _mapSize.y - 2, 0));
        InstantiateBotSpawnPoint(new Vector3(_mapSize.x - 2, _mapSize.y - 2, 0));

        for (int i = 0; i < _mapSize.y; i++)
        {
            for (int j = 0; j < _mapSize.x; j++)
            {
                if(i == 0 || i == _mapSize.y - 1 || j == 0 || j == _mapSize.x - 1)
                {
                    GameObject temp = Instantiate(_borderPrefab.gameObject, new Vector3(i, j, 0), Quaternion.identity);
                    blocks[i, j] = temp.GetComponent<BorderBlock>();
                }
                else if(j > 3 && j < _mapSize.y - 3)
                {
                    int num = Random.Range(0, 100);
                    if(num < 70)
                    {
                        blocks[i, j] = new AirBlock();
                    }
                    else if(num > 70 && num < 95)
                    {
                        GameObject temp = Instantiate(_brickPrefab.gameObject, new Vector3(i, j, 0), Quaternion.identity);
                        blocks[i, j] = temp.GetComponent<BrickBlock>();
                    }  
                    else
                    {
                        GameObject temp = Instantiate(_borderPrefab.gameObject, new Vector3(i, j, 0), Quaternion.identity);
                        blocks[i, j] = temp.GetComponent<BorderBlock>();
                    }
                }
                else
                {
                    blocks[i, j] = new AirBlock();
                }
                
            }
        }
    }

}
