using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaggetItemName : MonoBehaviour
{
    private TMP_Text _itemName;

    void Start()
    {
        _itemName = GetComponent<TMP_Text>();
    }

    void Update()
    {
        
    }

    public void SetItemName(string NewItemNAme)
    {
        _itemName.text = NewItemNAme;
    }
}
