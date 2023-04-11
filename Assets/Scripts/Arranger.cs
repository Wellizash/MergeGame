using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arranger : MonoBehaviour
{
    public static bool mouseButtonReleased = true;
    private RaycastHit2D hit;
    private Vector2 basePos;

    //�������� �������
    //�������� ������� ����������� ������� � ����
    //������� � ��� ��������� ���������� ������� ������ ����� ��� ��������
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

    //�������, �������������� ����� ����� ��� �������
    //����������: ��������� Transform ���������� ����� ��� �������� null
    public Transform FindSlot()
    {
        //���������� ������� ������������ �������

        hit = Physics2D.Raycast(transform.position, -Vector2.up);

        //�������� ����� ��������


        //���� �� ���-�� ������ � ���� ��� ���-�� - ����, ���������� Transform ����� �����
        //����� ���������� �������� null
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

    //�������������� ������ ������ �����
    //����� �������� ��������� �������
    void Update()
    {

        PlaceObject();
    }
}
