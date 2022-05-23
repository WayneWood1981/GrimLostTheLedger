using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrapTrigger : MonoBehaviour
{
    GameManager gameManager;

    AudioSource audioSource;

    [SerializeField] ParticleSystem feathers;

    [SerializeField] TextMeshProUGUI chickenCountText;

    [SerializeField] AudioClip trapSound;

    private int chickenCount = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        chickenCountText.text = "0";
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Chicken")
        {
            
            other.transform.GetComponent<Die>().Death();
            feathers.Play();
            chickenCount++;
            chickenCountText.text = chickenCount.ToString();

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
