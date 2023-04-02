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
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        spriteGameObj = GetComponentInChildren<SpriteRenderer>();
        spriteCollisionObj = collision.GetComponentInChildren<SpriteRenderer>();
        
        if (!(spriteGameObj && spriteCollisionObj))
            return;

        if (mouseButtonReleased && spriteGameObj.sprite == spriteCollisionObj.sprite)
        {
            numberPosition += 1;
            spriteGameObj.sprite = mergeContainerSO.mergeSprites[numberPosition];
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
        }
    }
}
