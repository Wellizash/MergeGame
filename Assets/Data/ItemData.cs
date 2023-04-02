using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New ItemData", menuName = "ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public Image _itemIcon { get; set; }
    public string _itemName { get; set; }
}
