using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Arranger : MonoBehaviour
{
    private RaycastHit2D hit;
    private Vector2 basePos;
    private ElementMovement elementMovement;
    public bool mouseReleased;
    private SortingGroup sortingGroup;
    [SerializeField] private Transform mSlot;
    public List<Transform> mGridSlots;
    private List<List<float>> mSlots;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //если при отпушенной кномке мыши происходит столкновение
        //не со слотои и не с предметом возвращаемся в базовую точку
        //стлкновения со слотом обрабаитываются в слоте
        //с объектом - в element movement; 
        if (collision.transform.GetComponent<Arranger>() == null && collision.transform.GetComponent<Slot>() == null)
            goBase();
    }

    public void OnMouseDown()
    {
        //перемешаем объект в очереди отривовки
        sortingGroup.sortingLayerID = SortingLayer.NameToID("DruggingItems");

        //отключаем столкновение
        transform.GetComponent<BoxCollider2D>().isTrigger = false;

        //устанавливаем базовую точку

        mouseReleased = false;
    }

    public void OnMouseUp()
    {
        sortingGroup.sortingLayerID = SortingLayer.NameToID("Items");
        transform.GetComponent<BoxCollider2D>().isTrigger = true;
        mouseReleased = true;
    }

    public void InserteInSlot(Transform slot)
    {
        //не вставляемся в свой же слот(на всякий)
        if(mSlot == slot)
            return;

        //делаем ссылку на содержимое старого слолта равным null
        if (mSlot)
            mSlot.GetComponent<Slot>().content = null;

        //устанавливаем ссылку на этот предмет в качестве ссылки на содержимое нового слота
        slot.GetComponent<Slot>().content = transform;

        //устонгавливает новый слот вместо старого
        mSlot = slot;

        //устанавливаем базовую точку и отправляемся в неё
        basePos = mSlot.position;
        goBase();
        Debug.Log("Insert");
    }

    public void goInEmptySlot()
    {
        for (int i = 0; i < mGridSlots.Count; i++)
        {
            for (int j = 0; j < mGridSlots.Count - 1; j++)
            {
                float slotJDistasce = Vector2.Distance(transform.position, mGridSlots[j].position);
                float slotJJDistasce = Vector2.Distance(transform.position, mGridSlots[j + 1].position);
                if (slotJDistasce > slotJJDistasce)
                {
                    Transform temp = mGridSlots[j + 1];
                    mGridSlots[j + 1] = mGridSlots[j];
                    mGridSlots[j] = temp;
                }
            }
        }
    }





    public void goBase()
    {
        transform.position = basePos;
    }
    private void Start()
    {
        mouseReleased = true;
        mGridSlots = FindObjectOfType<MainGrid>().slots;
        sortingGroup = GetComponent<SortingGroup>();
        elementMovement = GetComponent<ElementMovement>();
        basePos = transform.position;




        if(GetComponent<Dispenser>() != null)
            goInEmptySlot();
    }
}
