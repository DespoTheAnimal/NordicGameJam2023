using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private List<PlayerInput> players = new List<PlayerInput>();

    [SerializeField] Transform planet;

    private PlayerInputManager playerInputManager;
    // Start is called before the first frame update
    private void Awake()
    {
        playerInputManager = FindAnyObjectByType<PlayerInputManager>();
    }

    private void OnEnable()
    {
        playerInputManager.onPlayerJoined += AddPlayer; 
    }

    private void OnDisable()
    {
        playerInputManager.onPlayerLeft -= AddPlayer;
    }

    public void AddPlayer(PlayerInput player)
    {
        players.Add(player);
        player.transform.SetParent(planet);
        player.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
