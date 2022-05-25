using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAvatar : MonoBehaviour
{

    [SerializeField] SkinnedMeshRenderer rend;
    [SerializeField] Material material1;
    [SerializeField] Material material2;

    

    public void Switch()
    {
        Material[] mats = new Material[] { material1, material2 };
        rend.materials = mats;
        
        
    }
}
