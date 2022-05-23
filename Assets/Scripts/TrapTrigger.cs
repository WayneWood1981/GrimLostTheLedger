using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrapTrigger : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] ParticleSystem feathers;

    [SerializeField] TextMeshProUGUI chickenCountText;

    private int chickenCount = 0;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        chickenCountText.text = "0";
        Debug.Log(gameObject.name);
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
                    break;
                case "Spike Trap":
                    gameManager.spikeTrapKills++;
                    break;
                case "Fire Trap":
                    gameManager.fireTrapKills++;
                    break;
                case "Boiler Trap":
                    gameManager.boilerTrapKills++;
                    break;

                default:
                    break;
            }

        }
    }
}
