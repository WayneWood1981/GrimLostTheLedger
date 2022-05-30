using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupTrigger : MonoBehaviour
{
    private string thisTag;

    GameManager gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        thisTag = this.transform.tag;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "DeadGuy")
        {
            //Destroy(other.transform.gameObject);
            other.transform.tag = "DeadGuyStart";
            other.transform.GetComponent<Die>().GoToHeaven();
            other.transform.GetComponent<Animator>().SetBool("isGoingToHeaven", true);
            gameManager.sendToHeavens++;
            gameManager._SendToHeavenNumber--;
            gameManager.UpdateTextMeshPros();
            GameObject endCoup = GameObject.FindGameObjectWithTag("End");
            endCoup.GetComponentInParent<ChickenCoup>().AddHumanToSafety();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "DeadGuyStart")
        {
            
            other.transform.tag = "DeadGuy";
        }
    }

}
