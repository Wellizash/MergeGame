using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TargetPanel : MonoBehaviour
{
    TargetPreviewPanel _targetPreviewPanel;
    Requestable _requestableItem;
    RequestEvent _requestEvent;

    void Start()
    {
        _targetPreviewPanel = FindObjectOfType<TargetPreviewPanel>();
        _requestEvent = FindObjectOfType<RequestEvent>();
        _requestEvent.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        
    }

    public void TargetEvent(Targetable NewTargetItem)
    {
        Debug.Log("TargetEvent");
        if(NewTargetItem.GetComponent<Requestable>())
        {
            _requestEvent.GetComponent<Button>().interactable = true;
            _requestableItem = NewTargetItem.GetComponent<Requestable>();
            _requestEvent.SetRequestableItem(_requestableItem);
        }
        else
            _requestEvent.GetComponent<Button>().interactable = false;

        _targetPreviewPanel.SetPreiewItem(NewTargetItem);
    }


}
