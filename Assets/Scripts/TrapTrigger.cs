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
            other.GetComponent<Die>().Death();
            other.transform.GetComponent<SwitchAvatar>().Switch();
            locomotion = other.transform.GetComponent<Locomotion>();
            audioSource.PlayOneShot(laugh);
            Invoke("Organ", 0.5f);
            
            deadGuyCount++;
            deadGuyCountText.text = deadGuyCount.ToString();

            switch (transform.parent.name)
            {
                case "Saw Trap":
                    gameManager.sawTrapKills++;
                    gameManager._sawNumber--;
                    gameManager.UpdateTextMeshPros();
                    audioSource.PlayOneShot(trapSound);
                    break;
                case "Spike Trap":
                    gameManager.spikeTrapKills++;
                    gameManager._spikeNumber--;
                    gameManager.UpdateTextMeshPros();
                    audioSource.PlayOneShot(trapSound);
                    break;
                case "Fire Trap":
                    gameManager.fireTrapKills++;
                    gameManager._flameNumber--;
                    gameManager.UpdateTextMeshPros();
                    audioSource.PlayOneShot(trapSound);
                    break;
                case "Boiler Trap":
                    gameManager.boilerTrapKills++;
                    gameManager._boilNumber--;
                    gameManager.UpdateTextMeshPros();
                    audioSource.PlayOneShot(trapSound);
                    break;

                default:
                    break;
            }

        }
    }
}
