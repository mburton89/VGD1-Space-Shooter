using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startGameButton;
    [SerializeField] Button leftShipButton;
    [SerializeField] Button rightShipButton;

    int playerShipIndex;
    [SerializeField] List<GameObject> playerShips;

    void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        leftShipButton.onClick.AddListener(CycleShipsLeft);
        rightShipButton.onClick.AddListener(CycleShipsRight);
    }

    void StartGame()
    {
        PlayerPrefs.SetInt("PlayerShipChoice", playerShipIndex);
        SceneManager.LoadScene(1);
    }

    void CycleShipsLeft()
    {
        if (playerShipIndex > 0)
        {
            playerShipIndex--;
        }
        else
        {
            playerShipIndex = playerShips.Count - 1;
        }

        foreach (GameObject ship in playerShips)
        {
            ship.SetActive(false);
        }

        playerShips[playerShipIndex].SetActive(true);
    }

    void CycleShipsRight()
    {
        if (playerShipIndex < playerShips.Count - 1)
        {
            playerShipIndex++;
        }
        else
        {
            playerShipIndex = 0;
        }

        foreach (GameObject ship in playerShips)
        {
            ship.SetActive(false);
        }

        playerShips[playerShipIndex].SetActive(true);
    }
}
