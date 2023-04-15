using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenUI : MonoBehaviour
{
    int _amountOfPlayers;
    bool _gameStarted;
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
    [SerializeField]
    GameObject _startPortal;
    [SerializeField]
    public List<string> _playerList = new List<string>();
    [SerializeField]
    List<GameObject> _portalList = new List<GameObject>();
    public int activePortals;
    //bool colliding;

    public portal0 p0 = new portal0();
    public portal1 p1 = new portal1();

    void Start()
    {
        //_RandomSpawnLocation.transform.position = new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0);
        _amountOfPlayers = 0;
        _gameStarted = false;
        //colliding = false;
        activePortals = 0;

        p0 = GetComponent<portal0>();
        p1 = GetComponent<portal1>();
    }
    void Update()
    {
        if (_gameStarted == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddPlayer();
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartGame();
        }*/

        StartGame();
    }

    void AddPlayer()
    {
        if (_amountOfPlayers == 1)
        {
            Instantiate(_cannon, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
            Instantiate(_shield, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
            Instantiate(_shop, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
            Instantiate(_control, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
            _portalList[0].SetActive(true);
        }

        if (_amountOfPlayers == 2)
        {
            _portalList[1].SetActive(true);
        }

        if (_amountOfPlayers == 3)
        {
            _portalList[2].SetActive(true);
        }

        if (_amountOfPlayers == 4)
        {
            Instantiate(_cannon, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
            _portalList[3].SetActive(true);
        }


        GameObject _playerPrefab = Instantiate(_player, new Vector3(Random.Range(minXRange, maxXRange), Random.Range(minYRange, maxYRange), 0), Quaternion.identity);
        _playerPrefab.gameObject.name = "Player" + _amountOfPlayers;
        _playerList.Add(new string("Player" + _amountOfPlayers));
        _amountOfPlayers += 1;
        Debug.Log("players "+_amountOfPlayers);
        Debug.Log("portaler "+activePortals);
        activePortals = p0.collisionPortal0 + p1.collisionPortal1;
        Debug.Log("players "+_amountOfPlayers);
        Debug.Log("portaler "+activePortals);
        

    }

    void StartGame()
    {
        /*if (activePortals == _amountOfPlayers)
        {
            _startMenu.SetActive(false);
            _gameStarted = true;
        }*/
    }
}
