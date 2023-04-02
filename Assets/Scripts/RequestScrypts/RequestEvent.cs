using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class RequestEvent : MonoBehaviour
{
    private Requestable _requestableItem;

    public void SetRequestableItem(Requestable _NewRequestableItem)
    {
        _requestableItem = _NewRequestableItem;
    }




    public void OnRequestEvent()
    {
        if(_requestableItem != null)
            if (_requestableItem.GetComponent<Dispenser>() != null)
                _requestableItem.transform.GetComponent<Dispenser>().Request();
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
