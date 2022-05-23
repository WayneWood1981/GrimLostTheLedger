using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public int turnCount;

    List<BlockCounter> blocks;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new List<BlockCounter>();
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
                            }
                            
                        }
                        else
                        {
                            blocksCounter.GetComponentInChildren<Animator>().SetTrigger("OnShake");
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
                        }
                        else
                        {
                            blocksCounter.AddCountToBlock();

                        }
                        

                    }
                    

                    hit.transform.GetComponentInChildren<Animator>().SetTrigger("OnClick");
                }
                
            }
        }
    }
}
