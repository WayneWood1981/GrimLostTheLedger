using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeFloor : MonoBehaviour
{
    private GameObject bird;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Chicken")
        {
            other.GetComponent<Locomotion>().isFlyingAway = true;

            other.GetComponent<Die>().FlownAway();
            ChickenCoup homeCoup = FindObjectOfType<ChickenCoup>();
            homeCoup.AddChickenToSafety();
        }
    }

    
}
