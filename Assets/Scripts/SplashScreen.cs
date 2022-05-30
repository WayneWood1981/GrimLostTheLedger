using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartingScreen", 3.0f);
    }

    private void StartingScreen()
    {
        SceneManager.LoadScene(1);
    }
}
