using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{   private SpriteRenderer spriteRenderer;
    
    public void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    
}

