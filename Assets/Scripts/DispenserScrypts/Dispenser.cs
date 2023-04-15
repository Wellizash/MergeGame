using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField] private Transform itemPrefab;
    [SerializeField] private DispenderDataContainer dispenderDataConainer;

    public void Request()
    {
        Transform newItem = Instantiate(itemPrefab, transform.position, transform.rotation);

        int mergeContainerIndex = Random.Range(0, dispenderDataConainer.dispenderDataContainerList.Count);
        MergeContainer newMergeConteiner = dispenderDataConainer.dispenderDataContainerList[mergeContainerIndex];      

        ElementMovement newItemElementMovement =  newItem.GetComponent<ElementMovement>();

        if (newItemElementMovement != null)
        {
            newItemElementMovement.SetMergeContainer(newMergeConteiner);
        }
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}