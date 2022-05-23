using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenCoup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chickenCount;

    [SerializeField] GameObject chicken;

    [SerializeField] Transform chickenSpawnPoint;
    
    [SerializeField] int chickensToSpawn;

    [Range(1.5f, 5f)]
    [SerializeField] float spawnSpeed;

    private GameManager gameManager;

    private int savedChickens = 0;

    public bool hasStartedSpawning = false;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        chickensToSpawn = gameManager.chickenNumber;

        if(transform.tag == "Start")
        {
            chickenCount.text = chickensToSpawn.ToString();
        }
        else
        {
            chickenCount.text = savedChickens.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStartedSpawning && transform.tag == "Start")
        {
            for (int i = 0; i < chickensToSpawn; i++)
            {
                Invoke("SpawnChicken", i * spawnSpeed);
            }
            
            hasStartedSpawning = false;
        }

        
    }

    private void SpawnChicken()
    {
        Instantiate(chicken, chickenSpawnPoint.position, Quaternion.Euler(0, 180f, 0));
        chickensToSpawn--;
        chickenCount.text = chickensToSpawn.ToString();
    }

    public void AddChickenToSafety()
    {
        savedChickens++;
        chickenCount.text = savedChickens.ToString();

    }
}
