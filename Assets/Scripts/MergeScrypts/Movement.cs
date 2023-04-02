using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offSetX, offSetY;
    private RaycastHit2D hit;
    public static bool mouseButtonReleased;

    private void OnMouseDown()
    {
        hit = Physics2D.Raycast(transform.position, -Vector2.up);

        mouseButtonReleased = false;

        offSetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offSetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offSetX, mousePosition.y - offSetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true; 
    }

}
