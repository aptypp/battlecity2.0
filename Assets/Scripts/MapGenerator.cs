using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _mapSize;

    public Vector2Int MapSize { get => _mapSize; }

    [SerializeField] private BorderBlock _borderPrefab;
    [SerializeField] private BrickBlock _brickPrefab;
    [SerializeField] private GameObject _towerPrefab;
    [SerializeField] private BotSpawner _botSpawnerPrefab;
    [SerializeField] private List<BaseBonus> _bonuses;

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

    private void Update()
    {
        _timer += Time.time;
        if(_timer > _bonusTime)
        {
            SpawnBonus();
            _timer = 0;
        }
    }

    private void SpawnBonus()
    {
        Vector3 newPosition = new Vector3();
        newPosition.x = Random.Range(1, _mapSize.x - 1);
        newPosition.y = Random.Range(3, _mapSize.y - 1);

        int num = Random.Range(0, _bonuses.Count);

        Instantiate(_bonuses[num].gameObject, newPosition, Quaternion.identity);
    }


    //тут будет страшно
    public void GenerateMap()
    {
        Instantiate(_towerPrefab, new Vector3(_mapSize.x/2 - 1, 1, 0), Quaternion.identity);
        Instantiate(_botSpawnerPrefab.gameObject, new Vector3(1, _mapSize.y - 2, 0), Quaternion.identity);
        Instantiate(_botSpawnerPrefab.gameObject, new Vector3(_mapSize.x/2, _mapSize.y - 2, 0), Quaternion.identity);
        Instantiate(_botSpawnerPrefab.gameObject, new Vector3(_mapSize.x - 2, _mapSize.y - 2, 0), Quaternion.identity);
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
