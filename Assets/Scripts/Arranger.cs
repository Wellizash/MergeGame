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
        basePos = transform.position;

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
    }

    public void goBase()
    {
        transform.position = basePos;
    }

    private void Start()
    {
        sortingGroup = GetComponent<SortingGroup>();
        elementMovement = GetComponent<ElementMovement>();
        basePos = transform.position;
    }
}
