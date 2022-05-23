using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupTrigger : MonoBehaviour
{
    private string thisTag;

    // Start is called before the first frame update
    void Start()
    {
        thisTag = this.transform.tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Chicken")
        {
            //Destroy(other.transform.gameObject);
            other.transform.GetComponent<Die>().Death();
            GameObject endCoup = GameObject.FindGameObjectWithTag("End");
            endCoup.GetComponentInParent<ChickenCoup>().AddChickenToSafety();
        }
        
    }
}
