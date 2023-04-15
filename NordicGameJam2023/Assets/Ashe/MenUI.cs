using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenUI : MonoBehaviour
{
    int _amountOfPlayers;
    //Transform _RandomSpawnLocation;
    [SerializeField]
    float minXRange;
    [SerializeField]
    float maxXRange;
    [SerializeField]
    float minYRange;
    [SerializeField]
    float maxYRange;
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GameObject _cannon;
    [SerializeField]
    GameObject _shield;
    [SerializeField]
    GameObject _startMenu;
    [SerializeField]
    GameObject _control;
    [SerializeField]
    GameObject _shop;

    // Start is called before the first frame update
    void Awake()
    {
        //_RandomSpawnLocation.transform.position = new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0);
        _amountOfPlayers = 0;
        Instantiate(_cannon, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
        Debug.Log("Cannon spawned in Awake.");
        Instantiate(_shield, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
        Debug.Log("Shield spawned in Awake.");
        Instantiate(_shop, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
        Instantiate(_control, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPlayer();
        }
    }

    void AddPlayer()
    {
        _amountOfPlayers +=1;
        Instantiate(_player, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
        Debug.Log("Player spawned in AddPlayer.");
        //Instantiate(_shield, _RandomSpawnLocation.transform.position, Quaternion.identity);

        Debug.Log("Players: "+_amountOfPlayers);

        if (_amountOfPlayers == 4)
        {
            Instantiate(_cannon, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
            Debug.Log("Cannon spawned in AddPlayer.");
        }
    }
}
