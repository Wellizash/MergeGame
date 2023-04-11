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
    
    public bool Merge(Transform mergeItem)
    {
        spriteGameObj = GetComponentInChildren<SpriteRenderer>();
        spriteCollisionObj = mergeItem.GetComponentInChildren<SpriteRenderer>();



        if (!(spriteGameObj && spriteCollisionObj))
            return false;

        if (mouseButtonReleased && spriteGameObj.sprite == spriteCollisionObj.sprite && mergeItem.transform != transform)
        {
            Debug.Log("Merge: " + transform.name + " and " + mergeItem.name);
            numberPosition += 1;
            spriteGameObj.sprite = mergeContainerSO.mergeSprites[numberPosition];
            mouseButtonReleased = false;
            Destroy(mergeItem.gameObject);
            return true;
        }
        else
            return false;
    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        //Merge(collision.transform);
    }
}
