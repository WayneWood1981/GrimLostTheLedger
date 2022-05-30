using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingMen : MonoBehaviour
{

    Vector3 startingPOsition;
    // Start is called before the first frame update
    void Start()
    {
        startingPOsition = transform.position;
        Invoke("ReplaceMen", 10.0f);
    }


    private void ReplaceMen()
    {
        transform.position = startingPOsition;
    }
}
