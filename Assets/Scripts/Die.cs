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
        gameManager.chickenNumber -= 1;

        Destroy(this.gameObject);
    }

    public void FlownAway()
    {
        gameManager.chickenNumber -= 1;

        Destroy(this.gameObject, 4.0f);
    }
}
