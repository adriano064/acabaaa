using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public Transform Posicaoinicial;
    public movimento controler;

    private void Awake()
    {
        controler = FindObjectOfType<movimento>();
    }

    private void Start()
    {
        Posicaoinicial.transform.position = controler.gameObject.transform.position;
    }

    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (var player in players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
            }
        }

        if (aliveCount <= 1)
        {
            Invoke(nameof(NewRound), 3f);
        }
    }

    private void NewRound()
    {
        controler.gameObject.transform.position = Posicaoinicial.transform.position;
        controler.gameObject.SetActive(true);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
