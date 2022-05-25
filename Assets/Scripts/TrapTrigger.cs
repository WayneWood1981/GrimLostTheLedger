using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrapTrigger : MonoBehaviour
{
    GameManager gameManager;

    Locomotion locomotion;

    AudioSource audioSource;

    [SerializeField] TextMeshProUGUI deadGuyCountText;

    [SerializeField] AudioClip trapSound;

    [SerializeField] AudioClip laugh;

    [SerializeField] AudioClip organ;

    [SerializeField] GameObject zombie;


    private int deadGuyCount = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        deadGuyCountText.text = "0";
        
    }

    private void Organ()
    {
        audioSource.PlayOneShot(organ);
        locomotion.isGoingToHell = true;
        locomotion.GetComponent<Animator>().SetBool("isGoingToHell", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "DeadGuy")
        {
            other.transform.tag = "Ghost";
            other.transform.GetComponent<SwitchAvatar>().Switch();
            locomotion = other.GetComponent<Locomotion>();
            audioSource.PlayOneShot(laugh);
            Invoke("Organ", 1.0f);
            
            deadGuyCount++;
            deadGuyCountText.text = deadGuyCount.ToString();

            switch (transform.parent.name)
            {
                case "Saw Trap":
                    gameManager.sawTrapKills++;
                    audioSource.PlayOneShot(trapSound);
                    break;
                case "Spike Trap":
                    gameManager.spikeTrapKills++;
                    audioSource.PlayOneShot(trapSound);
                    break;
                case "Fire Trap":
                    gameManager.fireTrapKills++;
                    audioSource.PlayOneShot(trapSound);
                    break;
                case "Boiler Trap":
                    gameManager.boilerTrapKills++;
                    audioSource.PlayOneShot(trapSound);
                    break;

                default:
                    break;
            }

        }
    }
}
