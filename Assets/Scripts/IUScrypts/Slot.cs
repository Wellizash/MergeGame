using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] public Transform content;


    private void OnTriggerStay2D(Collider2D collision)
    {
        Arranger colisionArranger = collision.transform.GetComponent<Arranger>();

        //игонорируес столкновения с коллайдерами без компонента Arranger в tramsform
        if (colisionArranger == null || colisionArranger.mouseReleased)
            return;
        else
        {
            // если в слоте нет контента, вставляем объект в данный слот
            if (content == null) 
            {
                colisionArranger.InserteInSlot(transform);
                content = colisionArranger.transform;
                return;
            }
            //если произошло столкновение со своим же контентом
            //перемещаем объект к базовой точке
            if (content == colisionArranger.transform) 
            {
                colisionArranger.goBase();
                return;
            }
            //если в слоте есть предмет сливаемы предмет и объект столкновения слимваем
            //позиционируем объект столкновения для коллизии с контентом этого слота
            //стейтмент не выполнится если произошло столкновение со своим же контентом
            //и если в слоте нет контента, тка как эти ситуации обработаны выше
            if (content && content.GetComponent<ElementMovement>() != null && colisionArranger.GetComponent<ElementMovement>() != null)
            {
                colisionArranger.transform.position = transform.position;                
            }

        }
    }
}
