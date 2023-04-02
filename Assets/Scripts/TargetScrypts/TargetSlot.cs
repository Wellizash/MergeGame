using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSlot : MonoBehaviour
{
    public Targetable targetItem { get; set; }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GetItem(Targetable NewTargetItem)
    {
        targetItem = NewTargetItem;

        if (transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);

        Targetable mItem = Instantiate(NewTargetItem, transform.position, transform.rotation);
        mItem.transform.SetParent(transform, false);
        mItem.transform.position = transform.position;
    }

}
