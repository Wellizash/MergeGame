using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    public static bool mouseButtonReleased = true;
    private RaycastHit2D hit;


    //�������� �������
    //�������� ������� ����������� ������� � ����
    //������� � ��� ��������� ���������� ������� ������ ����� ��� ��������
    public void PlaceObject()
    {
        Transform slotTransform = FindSlot();
        if(slotTransform)
            InserteInSlot(FindSlot());
    }

    //�������, �������������� ����� ����� ��� �������
    //����������: ��������� Transform ���������� ����� ��� �������� null
    public Transform FindSlot()
    {
        //���������� ������� ������������ �������
        gameObject.layer = 2;
        hit = Physics2D.Raycast(transform.position, -Vector2.up);

        //�������� ����� ��������
        gameObject.layer = 0;

        //���� �� ���-�� ������ � ���� ��� ���-�� - ����, ���������� Transform ����� �����
        //����� ���������� �������� null
        return hit && (hit.transform.tag == "Slot") ? hit.transform : null;
    }


    public void OnMouseDown()
    {
        mouseButtonReleased = false;
    }

    public void OnMouseUp()
    {
        mouseButtonReleased = true;
        PlaceObject();
    }

    private void InserteInSlot(Transform slot)
    {
        transform.position = slot.position;
    }

    //�������������� ������ ������ �����
    //����� �������� ��������� �������
    void Update()
    {
        if (mouseButtonReleased)
            PlaceObject();
    }
}
