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
        Transform slotTransform = FindSlot();
        if (slotTransform)
            InserteInSlot(slotTransform);
        else
            transform.position = basePos;
    }

    //Фушкция, осуществляющая посик слота под бъектом
    //Возвращает: компонент Transform найденного слота или значение null
    public Transform FindSlot()
    {
        //Застовляем предмет игнорировать рейкаст
        gameObject.layer = 2;
        hit = Physics2D.Raycast(transform.position, -Vector2.up);

        //Отменяем игнор рейкаста
        gameObject.layer = 0;

        //Если во что-то попали и если это что-то - слот, возвращаем Transform этого слота
        //Иначе возвращаем значение null
        return hit && (hit.transform.tag == "Slot") ? hit.transform : null;
    }


    public void OnMouseDown()
    {
        mouseButtonReleased = false;
        basePos = transform.position;
    }

    public void OnMouseUp()
    {
        mouseButtonReleased = true;
        PlaceObject();
    }

    private void InserteInSlot(Transform slot)
    {
        transform.position = slot.position;
        basePos = transform.position;
    }

    private void Start()
    {
        basePos = transform.position;
    }

    //Позиционитруем объект каждый фрейм
    //чтобы избежать блуждания объекта
    void Update()
    {
        if (mouseButtonReleased)
            PlaceObject();
    }
}
