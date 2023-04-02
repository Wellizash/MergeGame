using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    TargetPanel _targetPanel;
    public string Name { get; set; }



    void Start()
    {
        Name = transform.name;
        _targetPanel = FindObjectOfType<TargetPanel>();
    }

    private void OnMouseDown()
    {
        if (_targetPanel != null)
            _targetPanel.TargetEvent(this);
    }

    void Update()
    {
        
    }
}
