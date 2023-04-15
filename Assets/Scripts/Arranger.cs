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
        //���� ��� ���������� ������ ���� ���������� ������������
        //�� �� ������ � �� � ��������� ������������ � ������� �����
        //����������� �� ������ ��������������� � �����
        //� �������� - � element movement; 
        if (collision.transform.GetComponent<Arranger>() == null && collision.transform.GetComponent<Slot>() == null)
            goBase();
    }

    public void OnMouseDown()
    {
        //���������� ������ � ������� ���������
        sortingGroup.sortingLayerID = SortingLayer.NameToID("DruggingItems");

        //��������� ������������
        transform.GetComponent<BoxCollider2D>().isTrigger = false;

        //������������� ������� �����

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
        //�� ����������� � ���� �� ����(�� ������)
        if(mSlot == slot)
            return;

        //������ ������ �� ���������� ������� ������ ������ null
        if (mSlot)
            mSlot.GetComponent<Slot>().content = null;

        //������������� ������ �� ���� ������� � �������� ������ �� ���������� ������ �����
        slot.GetComponent<Slot>().content = transform;

        //�������������� ����� ���� ������ �������
        mSlot = slot;

        //������������� ������� ����� � ������������ � ��
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
