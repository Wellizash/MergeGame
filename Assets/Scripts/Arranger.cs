using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    public static bool mouseButtonReleased = true;
    private RaycastHit2D hit;

    //Фушкция, осуществляющая посик слота под бъектом
    //Возвращает: компонент Transform этого слота или null
    public Transform CheckClot()
    {
        gameObject.layer = 2;
        hit = Physics2D.Raycast(transform.position, -Vector2.up);
        gameObject.layer = 0;
        return hit && (hit.transform.tag == "Slot") ? hit.transform : null;
    }


    public void OnMouseDown()
    {
        mouseButtonReleased = false;
    }

    public void OnMouseUp()
    {
        mouseButtonReleased = true;
        Transform slot = CheckClot();
        if (slot) InserteInSlot(slot);
    }

    private void InserteInSlot(Transform slot)
    {
        transform.position = slot.position;
    }

    void Start()
    {
        CheckClot();
    }
    void Update()
    {
        if (mouseButtonReleased)
        {
            Transform slot = CheckClot();
            if (slot) InserteInSlot(slot);
        }

    }
}
