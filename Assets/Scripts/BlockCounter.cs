using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField] GameObject arrowSprite;
    [SerializeField] GameObject directionChanger;

    public Vector3 currentVector;

    private bool isAmovingBlock;

    public int blockCount;

    private void Start()
    {
        ShowArrowSprite(false);
        ActivateDirectionChanger(false);
    }

    public void AddCountToBlock()
    {
        blockCount++;
        

        if(blockCount > 4)
        {

            blockCount = 0;
            isAmovingBlock = false;
            
        }
        if(blockCount > 0)
        {
            ChangeBlockRotation();
            ActivateDirectionChanger(true);
            ShowArrowSprite(true);
            

            isAmovingBlock = true;
        }
        else
        {
            ShowArrowSprite(false);
            ActivateDirectionChanger(false);
        }

    }

    private void ShowArrowSprite(bool isShown)
    {
        arrowSprite.SetActive(isShown);
    }

    private void ActivateDirectionChanger(bool isActivated)
    {
        directionChanger.SetActive(isActivated);
    }

    private void ChangeBlockRotation()
    {
        transform.Rotate(Vector3.up * 90);
        currentVector = transform.forward;
        
    }

    public bool IsThisBlockAMovingBlock()
    {
        return isAmovingBlock;
    }
}
