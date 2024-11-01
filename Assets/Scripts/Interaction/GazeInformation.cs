using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GazeInformation : MonoBehaviour
{
    public CardboardReticlePointer reticlePointer;

    public GameObject GetGazedObject()
    {
        if (reticlePointer != null)
        {
            
            return reticlePointer.gameObject;
        }
        else
        {
            Debug.LogError("Reticle pointer not assigned!");
            return null;
        }
    }

    void Update()
    {
        GetGazedObject();
    }

    // You can add more methods to extract specific information 
    // from the gazed object, like its name, tag, components, etc.
}
