using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void Death()
    {
        gameManager.deadGuyNumber -= 1;

        Destroy(this.gameObject);
    }

    public void GoToHeaven()
    {
        gameManager.deadGuyNumber -= 1;
        Locomotion locomotion = GetComponent<Locomotion>();
        locomotion.isGoingToHeaven = true;
        Destroy(this.gameObject, 6.0f);
    }

    public void FlownAway()
    {
        gameManager.deadGuyNumber -= 1;

        Destroy(this.gameObject, 4.0f);
    }
}
