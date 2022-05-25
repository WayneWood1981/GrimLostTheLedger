using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    private Vector3 newVec;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "DirectionChanger")
        {
            newVec = other.transform.GetComponentInParent<BlockCounter>().currentVector;
            Invoke("Wait", 0.4f);

        }

    }

    
    private void Wait()
    {
        
        transform.forward = newVec;
    }
}
