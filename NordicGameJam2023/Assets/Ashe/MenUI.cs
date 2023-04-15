using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenUI : MonoBehaviour
{
    Transform _RandomSpawnLocation;
    [SerializeField]
    float minXRange;
    float maxXRange;
    float minYRange;
    float maxYRange;
    GameObject _player;
    GameObject _cannon;
    GameObject _shield;
    GameObject _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _RandomSpawnLocation.transform.position = new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0);
}

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddPlayer()
    {
        Instantiate(_player, _RandomSpawnLocation.transform.position, Quaternion.identity);
        Instantiate(_cannon, _RandomSpawnLocation.transform.position, Quaternion.identity);
        Instantiate(_shield, _RandomSpawnLocation.transform.position, Quaternion.identity);
    }
}
