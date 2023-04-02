using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPreviewPanel : MonoBehaviour
{
    TargetSlot _targetSlot;
    TaggetItemName _taggetItemName;
    void Start()
    {
        _targetSlot = FindObjectOfType<TargetSlot>();
        _taggetItemName = FindObjectOfType<TaggetItemName>();
    }

    void Update()
    {
        
    }

    public void SetPreiewItem(Targetable NewTargetItem)
    {
        _targetSlot.GetItem(NewTargetItem);
        _taggetItemName.SetItemName(NewTargetItem.Name);
    }


}
