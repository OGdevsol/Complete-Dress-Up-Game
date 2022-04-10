using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class References : MonoBehaviour
{
    public static References instance;
    [Space(10)]
    [Header("_____Defaults_____")]
    public GameObject defaultTop;
    public GameObject defaultBottom;
    [Space(10)]
    [Header("_____Dressup_____")]
    public SpriteRenderer dressReference;
    public SpriteRenderer topReference;
    public SpriteRenderer bottomReference;
    public SpriteRenderer shoesReferences;
    public SpriteRenderer purseReference;
    [Header("_____MakeUp_____")]  
    public SpriteRenderer lipStickReference;
    public SpriteRenderer blush1Reference;
    public SpriteRenderer blush2Reference;
    public SpriteRenderer earrings1Reference;
    public SpriteRenderer earrings2Reference;
    public SpriteRenderer eyebrowsReference;
    public SpriteRenderer eyelashes1Reference;
    public SpriteRenderer eyelashes2Reference;
    // public SpriteRenderer eyelinerReference;
    public SpriteRenderer eyeshadow1Reference;
    public SpriteRenderer eyeshadow2Reference;
    public SpriteRenderer hairReference;
    public SpriteRenderer necklaceReference;
    public SpriteRenderer nosepinsReference;
    public SpriteRenderer lens1Reference;
    public SpriteRenderer lens2Reference;
    public Sprite defaulteyebrowSprite;
    
    
  
    private void Awake()
    {
        if(!instance)
            instance = this;
    }
}
