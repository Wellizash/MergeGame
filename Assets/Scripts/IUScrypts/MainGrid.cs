using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGrid : MonoBehaviour
{
    public List<Transform> slots;

    void Start()
    {
        foreach (Transform child in transform)
            slots.Add(child);
    }


    void Update()
    {
        
    }
}
