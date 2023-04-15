using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] public Transform content;


    private void OnTriggerStay2D(Collider2D collision)
    {
        Arranger colisionArranger = collision.transform.GetComponent<Arranger>();

        //����������� ������������ � ������������ ��� ���������� Arranger � tramsform
        if (colisionArranger == null || colisionArranger.mouseReleased)
            return;
        else
        {
            // ���� � ����� ��� ��������, ��������� ������ � ������ ����
            if (content == null) 
            {
                colisionArranger.InserteInSlot(transform);
                content = colisionArranger.transform;
                return;
            }
            //���� ��������� ������������ �� ����� �� ���������
            //���������� ������ � ������� �����
            if (content == colisionArranger.transform) 
            {
                colisionArranger.goBase();
                return;
            }
            //���� � ����� ���� ������� �������� ������� � ������ ������������ ��������
            //������������� ������ ������������ ��� �������� � ��������� ����� �����
            //��������� �� ���������� ���� ��������� ������������ �� ����� �� ���������
            //� ���� � ����� ��� ��������, ��� ��� ��� �������� ���������� ����
            if (content && content.GetComponent<ElementMovement>() != null && colisionArranger.GetComponent<ElementMovement>() != null)
            {
                colisionArranger.transform.position = transform.position;                
            }

        }
    }
}
