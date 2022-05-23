using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    private AudioSource audioSource;

    private MouseAudioScript mouseAudioScript;

    public int turnCount;

    List<BlockCounter> blocks;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new List<BlockCounter>();
        audioSource = GetComponent<AudioSource>();
        mouseAudioScript = GetComponent<MouseAudioScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameManager.isGameOver)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == "Grass")
                {
                    BlockCounter blocksCounter = hit.transform.GetComponent<BlockCounter>();


                    if (!blocksCounter.IsThisBlockAMovingBlock()) // if we click on it and its blank
                    {
                        if(turnCount != gameManager.amountOfTurns) // and we have turns left
                        {
                            if (!blocks.Contains(blocksCounter)) // if not already in list.. add it
                            {
                                blocks.Add(blocksCounter);
                                gameManager.turnsLeft -= 1;
                                turnCount = blocks.Count;
                                blocksCounter.AddCountToBlock();
                                audioSource.PlayOneShot(mouseAudioScript.pops[blocksCounter.blockCount]);
                            }
                            
                        }
                        else
                        {
                            blocksCounter.GetComponentInChildren<Animator>().SetTrigger("OnShake");
                            audioSource.PlayOneShot(mouseAudioScript.error);
                            return;
                        }
                            
                            
                        
                    }
                    else                                            // if we click and it has an arrow on it.
                    {

                        if(blocksCounter.blockCount == 4)
                        {
                            blocks.Remove(blocksCounter);
                            gameManager.turnsLeft += 1;
                            turnCount = blocks.Count;
                            blocksCounter.AddCountToBlock();
                            audioSource.PlayOneShot(mouseAudioScript.pops[blocksCounter.blockCount]);
                        }
                        else
                        {
                            blocksCounter.AddCountToBlock();
                            audioSource.PlayOneShot(mouseAudioScript.pops[blocksCounter.blockCount]);
                        }
                        

                    }
                    

                    hit.transform.GetComponentInChildren<Animator>().SetTrigger("OnClick");
                }

                if(hit.transform.tag == "Start")
                {
                   
                    hit.transform.GetComponentInParent<ChickenCoup>().hasStartedSpawning = true;
                }
                
            }
        }
    }
}
