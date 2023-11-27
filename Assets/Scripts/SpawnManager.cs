using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;

    private float timeBetweenObstacles = 2f;
    private float startDelay = 1.5f;

    [SerializeField] private GameObject[] obstaclesArray;

    private Vector3 spawnPos;

    private void Awake()
    {
        spawnPos = new Vector3(20, 0, 0);
    }

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();

        InvokeRepeating("InstatiateRandomObstacle",
            startDelay, timeBetweenObstacles);
    }

    private void Update()
    {
        if (playerControllerScript.isGameOver)
        {
            CancelInvoke("InstatiateRandomObstacle");
        }
    }

    private void InstatiateRandomObstacle()
    {
        int randomIndex = Random.Range(0, obstaclesArray.Length);
        Instantiate(obstaclesArray[randomIndex],
                spawnPos,
                Quaternion.identity);
    }
}
