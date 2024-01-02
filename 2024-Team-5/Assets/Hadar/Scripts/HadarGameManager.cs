using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadarGameManager : MonoBehaviour
{
    public static HadarGameManager instance {private set; get;}
    [SerializeField] private GameObject activePlayer;
    [SerializeField] private GameObject[] players;
    private void Awake()
    {
        instance = this;
    }

    public GameObject GetActivePlayer()
    {
        return activePlayer;
    }

    private void Start()
    {
        activePlayer.GetComponent<PlayerMovment>().setActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchPlayer();
        }
    }
    
    private void SwitchPlayer()
    {
        var index = Array.IndexOf(players, activePlayer);
        Debug.Log($"index: {index}");
        index++;
        if (index >= players.Length) { index = 0; }
        activePlayer = players[index];
        foreach (var player in players)
        {
            var playerMovement = player.GetComponent<PlayerMovment>();
            
            if (player == activePlayer)
            {
                playerMovement.setActive(true);
            }
            else
            {
                playerMovement.setActive(false);

            }
        }
    }
}
