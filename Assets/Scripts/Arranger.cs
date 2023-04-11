using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    public static bool mouseButtonReleased = true;
    private RaycastHit2D hit;
    private Vector2 basePos;

    //Основная функция
    //Вызавает функцию вставляющую предмет в слот
    //Передаёт в нее результат выполнения функции поиска слота под объектом
    public void PlaceObject()
    {
        if (mouseButtonReleased)
        {
            Transform slotTransform = FindSlot();
            if (slotTransform)
            {
                if (slotTransform.childCount == 0)
                    InserteInSlot(slotTransform);
                else
                {
                    if(slotTransform.transform.GetChild(0).GetComponent<ElementMovement>().Merge(transform))
                        return;
                    else
                        transform.position = basePos;
                }    
            }
            else
            {
                hit = Physics2D.Raycast(transform.position, -Vector2.up);
                if (hit.transform && hit.transform.GetComponent<ElementMovement>())
                {
                    if (!hit.transform == transform) { return; }
                    hit.transform.GetComponent<ElementMovement>().Merge(transform);
                    return;
                }
                else
                    transform.position = basePos;
            }
        }
    }

    //Фушкция, осуществляющая посик слота под бъектом
    //Возвращает: компонент Transform найденного слота или значение null
    public Transform FindSlot()
    {
        //Застовляем предмет игнорировать рейкаст

        hit = Physics2D.Raycast(transform.position, -Vector2.up);

        //Отменяем игнор рейкаста


        //Если во что-то попали и если это что-то - слот, возвращаем Transform этого слота
        //Иначе возвращаем значение null
        return hit && (hit.transform.tag == "Slot") ? hit.transform : null;
    }


    public void OnMouseDown()
    {
        gameObject.layer = 2;
        mouseButtonReleased = false;
        basePos = transform.position;
    }

    public void OnMouseUp()
    {
        mouseButtonReleased = true;
        PlaceObject();
        gameObject.layer = 0;
    }

    private void InserteInSlot(Transform slot)
    {
        transform.position = slot.position;
        basePos = transform.position;
    }

    private void Awake()
    {
        gameObject.layer = 2;
    }



    private void Start()
    {
        basePos = transform.position;
        PlaceObject();
        gameObject.layer = 0;
    }

    //Позиционитруем объект каждый фрейм
    //чтобы избежать блуждания объекта
    void Update()
    {

        PlaceObject();
    }
}
