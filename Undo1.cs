using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undo1 : MonoBehaviour
{
    private InGameplayUIManager.PlayerState playerState;
    private SpriteRenderer top;
    private GameObject defaultTop;
    private SpriteRenderer bottom;
    private GameObject defaultBottom;
    private SpriteRenderer dress;
    private SpriteRenderer shoes;
    private SpriteRenderer purse;
    private SpriteRenderer lipstick;
    // private SpriteRenderer foundation;
    // private SpriteRenderer eyeliner;
    private SpriteRenderer eyeshadow;
    private SpriteRenderer eyeshadow2;
    private SpriteRenderer eyebrows;
    private SpriteRenderer eyelashes;
    private SpriteRenderer eyelashes2;
    private SpriteRenderer necklace;
    private SpriteRenderer earrings;
    private SpriteRenderer earrings2;
    private SpriteRenderer nosepins;
    private SpriteRenderer hair;
    private SpriteRenderer lens;
    private SpriteRenderer lens2;
    private SpriteRenderer blush;
    private SpriteRenderer blush2;

     public static Undo1 instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetReferences();
    }


    public void undo()
    {
        playerState = InGameplayUIManager.instance.playerState;

        Debug.Log("Player STATE IN Undo " + playerState);
        switch (playerState)
        {
            case InGameplayUIManager.PlayerState.Top:
                UnDoTop();
                break;
            case InGameplayUIManager.PlayerState.Bottom:
                UnDoBottom();
                break;
            case InGameplayUIManager.PlayerState.Dress:
                UnDoDress();
                break;
            case InGameplayUIManager.PlayerState.Purse:
                UnDoPurse();
                break;
            case InGameplayUIManager.PlayerState.Shoes:
                UnDoShoes();
                break;
            case InGameplayUIManager.PlayerState.Blush:
                UnDoBlush();
                break;

            case InGameplayUIManager.PlayerState.Earrings:
                UnDoEarrings();
                break;
            case InGameplayUIManager.PlayerState.Eyelashes:
                UnDoEyelashes();
                break;
            // case InGameplayUIManager.PlayerState.Eyeliner:
            //     UnDoEyeliner();
            //     break;
            // case InGameplayUIManager.PlayerState.Foundation:
            //     UnDoFoundation();
            //     break;
            case InGameplayUIManager.PlayerState.Hair:
                UnDoHair();
                break;
            case InGameplayUIManager.PlayerState.Lens:
                UnDoLens();
                break;
            case InGameplayUIManager.PlayerState.Lipstick:
                UnDoLipstick();
                break;
            case InGameplayUIManager.PlayerState.Necklace:
                UnDoNecklace();
                break;

            case InGameplayUIManager.PlayerState.EyeBrows:
                UnDoEyebrows();
                break;
            case InGameplayUIManager.PlayerState.EyeShadow:
                UnDoEyeshadow();
                break;
        }
    }


     void UnDoTop()
    {
        top.sprite = null;
        defaultTop.gameObject.SetActive(true);
    }

     void UnDoBottom()
    {
        bottom.sprite = null;
        defaultBottom.gameObject.SetActive(true);
    }

     void UnDoDress()
    {
        dress.sprite = null;
        defaultTop.gameObject.SetActive(true);
        defaultBottom.SetActive(true);
    }

     void UnDoShoes()
    {
        shoes.sprite = null;
    }

     void UnDoPurse()
    {
        purse.sprite = null;
    }

     void UnDoLipstick()
    {
        lipstick.sprite = null;
    }


    //  void UnDoFoundation()
    // {
    //     foundation.sprite = null;
    // }

    //  void UnDoEyeliner()
    // {
    //     eyeliner.sprite = null;
    // }

     void UnDoEyelashes()
    {
        eyelashes.sprite = null;
        eyelashes2.sprite = null;
    }

     void UnDoEyebrows()
    {
        eyebrows.sprite = References.instance.defaulteyebrowSprite;
    }

     void UnDoEyeshadow()
    {
        eyeshadow.sprite = null;
        eyeshadow2.sprite = null;
    }

     void UnDoNecklace()
    {
        necklace.sprite = null;
    }

     void UnDoEarrings()
    {
        earrings.sprite = null;
        earrings2.sprite = null;
    }

     void UnDoNosepins()
    {
        nosepins.sprite = null;
    }

     void UnDoHair()
    {
        hair.sprite = null;
    }

     void UnDoLens()
    {
        lens.sprite = null;
        lens2.sprite = null;
    }

     void UnDoBlush()
    {
        blush.sprite = null;
        blush2.sprite = null;
    }

    private void GetReferences()
    {
        top = References.instance.topReference;
        defaultTop = References.instance.defaultTop;
        bottom = References.instance.bottomReference;
        defaultBottom = References.instance.defaultBottom;
        shoes = References.instance.shoesReferences;
        dress = References.instance.dressReference;
        purse = References.instance.purseReference;
        lipstick = References.instance.lipStickReference;
        // foundation = References.instance.foundationReference;
        eyebrows = References.instance.eyebrowsReference;
        eyelashes = References.instance.eyelashes1Reference;
        eyelashes2 = References.instance.eyelashes2Reference;
        // eyeliner = References.instance.eyelinerReference;
        eyeshadow = References.instance.eyeshadow1Reference;
        eyeshadow2 = References.instance.eyeshadow2Reference;
        necklace = References.instance.necklaceReference;
        earrings = References.instance.earrings1Reference;
        earrings2 = References.instance.earrings2Reference;
        nosepins = References.instance.nosepinsReference;
        hair = References.instance.hairReference;
        lens = References.instance.lens1Reference;
        lens2 = References.instance.lens2Reference;
        blush = References.instance.blush1Reference;
        blush2 = References.instance.blush2Reference;
    }
}