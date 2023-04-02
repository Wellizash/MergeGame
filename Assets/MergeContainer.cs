using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataMergeContainer", menuName = "ScriptableObjects/MergeContainer", order = 1)]
public class MergeContainer : ScriptableObject
{
    [SerializeField]
    public List<Sprite> mergeSprites = new List<Sprite>();
}
