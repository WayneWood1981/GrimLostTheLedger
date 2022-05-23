using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UINumberAdjuster : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] TextMeshProUGUI requiredAmountText;

    [SerializeField] public int requiredAmountOfChickens;

    [SerializeField] 


    // Start is called before the first frame update
    void Start()
    {
        switch (transform.tag)
        {
            case "SawUI":
                requiredAmountText.text = gameManager._sawNumber.ToString();
                break;
            case "FlameUI":
                requiredAmountText.text = gameManager._flameNumber.ToString();
                break;
            case "SpearUI":
                requiredAmountText.text = gameManager._spikeNumber.ToString();
                break;
            case "BoilUI":
                requiredAmountText.text = gameManager._boilNumber.ToString();
                break;

            default:
                break;
        }
        
    }


}
