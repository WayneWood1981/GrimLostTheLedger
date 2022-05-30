using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeFloor : MonoBehaviour
{
    [SerializeField] AudioClip organ;


    private GameObject bird;

    AudioSource audioSource;

    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "DeadGuy")
        {
            other.GetComponent<Locomotion>().isGoingToHeaven = true;
            audioSource.PlayOneShot(organ);
            other.GetComponent<Die>().LostSoul();
            
        }
    }

    
}
