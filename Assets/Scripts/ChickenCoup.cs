using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenCoup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chickenCount;

    [SerializeField] GameObject chicken;

    [SerializeField] Transform chickenSpawnPoint;
    
    [SerializeField] int humansToSpawn;

    [SerializeField] AudioClip spawnSounds;

    [SerializeField] AudioClip escapedHuman;

    private AudioSource audioSource;

    [Range(1.5f, 5f)]
    [SerializeField] float spawnSpeed;

    private GameManager gameManager;

    private int savedChickens = 0;

    public bool hasStartedSpawning;

    private int spawnNumber = 0;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        humansToSpawn = gameManager.deadGuyNumber;
        audioSource = GetComponent<AudioSource>();
        if(transform.tag == "Start")
        {
            chickenCount.text = humansToSpawn.ToString();
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
            for (int i = 0; i < humansToSpawn; i++)
            {
                Invoke("SpawnHuman", i * spawnSpeed);
            }
            
            hasStartedSpawning = false;
        }

        
    }

    public void StartSpawning()
    {
        hasStartedSpawning = true;
    }

    private void SpawnHuman()
    {
        Instantiate(chicken, chickenSpawnPoint.position, transform.rotation);
        
        audioSource.PlayOneShot(spawnSounds);
        spawnNumber++;
        
        humansToSpawn--;
        chickenCount.text = humansToSpawn.ToString();
    }

    public void AddHumanToSafety()
    {
        savedChickens++;
        chickenCount.text = savedChickens.ToString();
        audioSource.PlayOneShot(escapedHuman);

    }
}
