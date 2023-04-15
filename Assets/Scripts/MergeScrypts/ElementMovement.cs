using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class ElementMovement : Movement
{

    public int numberPosition;
    private SpriteRenderer spriteGameObj;
    private SpriteRenderer spriteCollisionObj;
    public MergeContainer mergeContainerSO;
    private Arranger arranger;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.transform.GetComponent<Arranger>() == null)
            return;


        if(collision.transform.GetComponent<Arranger>() != null)
        {
            if (collision.transform.GetComponent<ElementMovement>() == null)
            {
                collision.transform.GetComponent<Arranger>().goBase();
                return;
            }
        }

        spriteGameObj = transform.GetComponentInChildren<SpriteRenderer>();
        spriteCollisionObj = collision.transform.GetComponentInChildren<SpriteRenderer>();


        if (!(spriteGameObj && spriteCollisionObj))
        {
            collision.transform.GetComponent<Arranger>().goBase();
            return;
        }

        if (mouseButtonReleased && spriteGameObj.sprite == spriteCollisionObj.sprite && collision.transform != transform)
        {
            numberPosition += 1;
            spriteGameObj.sprite = mergeContainerSO.mergeSprites[numberPosition];
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
        }
    }


    private void Start()
    {
        numberPosition = 0;
        arranger = GetComponent<Arranger>();
    }


    public void SetMergeContainer(MergeContainer newNergeContainer)
    {
        spriteGameObj = transform.GetComponentInChildren<SpriteRenderer>();
        mergeContainerSO = newNergeContainer;
        spriteGameObj.sprite = mergeContainerSO.mergeSprites[numberPosition];
    }





}
