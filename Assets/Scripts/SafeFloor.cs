using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeFloor : MonoBehaviour
{
    private GameObject bird;

    AudioSource audioSource;

    [SerializeField]

    AudioClip[] flapSounds;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Chicken")
        {
            other.GetComponent<Locomotion>().isFlyingAway = true;
            audioSource.PlayOneShot(flapSounds[Random.Range(0, flapSounds.Length)]);
            other.GetComponent<Die>().FlownAway();
            ChickenCoup homeCoup = FindObjectOfType<ChickenCoup>();
            homeCoup.AddChickenToSafety();
        }
    }

    
}
