using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomAway : MonoBehaviour
{
    [SerializeField] private float speed;

    public bool zoomAway = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomAway)
        {
            Debug.Log("Here");
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
    }
}
