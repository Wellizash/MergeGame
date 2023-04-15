using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DispenderDataContainer", menuName = "ScriptableObjects/DispenderDataContainer", order = 1)]
public class DispenderDataContainer : ScriptableObject
{
    [SerializeField] public List<MergeContainer> dispenderDataContainerList = new List<MergeContainer>();
}
