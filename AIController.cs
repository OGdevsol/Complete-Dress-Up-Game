using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIController : MonoBehaviour
{ 
   

    public static AIController instance;
    private int lvlNum;
    private int AIScore;
   
    public SpriteRenderer AIDressRef;
    public SpriteRenderer AITopRef;
    public SpriteRenderer AIBottomRef;
    public SpriteRenderer AIPurseRef;
    public SpriteRenderer AIShoesRef;
    public SpriteRenderer AILipstickRef;
    public SpriteRenderer AIEyeLinerRef;
    public SpriteRenderer AIEyeShadowRef;
    public SpriteRenderer AIFoundationRef;
    
    public SpriteRenderer AILensRef;
    public SpriteRenderer AIHairRef;
    public SpriteRenderer AIBlushRef;
    public SpriteRenderer AIEyeBrowsRef;
    public SpriteRenderer AIEyeLashesRef;
    public SpriteRenderer AIEarringsRef;
    public SpriteRenderer AINecklaceRef;
    public SpriteRenderer AINosePinsRef;
    private LevelsSO.AIState aistateAssign;
    public GameObject defaultAITop;
    public GameObject defaultAIBottom;


    private void Awake()
    {
        instance = this;
        
    }


    private void Start()
    {
        aistateAssign = (LevelsSO.AIState) Random.Range(0, 9);
        lvlNum = InGameplayUIManager.instance.lvlNum;
        Debug.Log(lvlNum);
        Debug.Log(aistateAssign);
        ChooseRandomlyAccordingToRandomAiState();
    }

    public void ChooseRandomlyAccordingToRandomAiState()
    {
        defaultAITop.SetActive(false);
        defaultAIBottom.SetActive(false);
        switch (aistateAssign)
        {
            case LevelsSO.AIState.onlyFullDress:
                ChooseRandomDress();
                Debug.Log(aistateAssign);
                AIScore =  18;
                break;
            case LevelsSO.AIState.onlyTop_Bottom:
                ChooseRandomTop();
                ChooseRandomBottom();
                Debug.Log(aistateAssign);
                AIScore = 15 ;
                break;
            case LevelsSO.AIState.fullDressWith2Makeup:
                ChooseRandomDress();
                ChooseRandomLipstick();
                ChooseRandomNecklace();
                Debug.Log(aistateAssign);
                AIScore = 25 ;
                break;
            case LevelsSO.AIState.fullDressWith4Makeup:
                ChooseRandomDress();
                ChooseRandomLipstick();
                ChooseRandomEyeShadow();
                ChooseRandomEarrings();
                Debug.Log(aistateAssign);
                AIScore = 30 ;
                break;

            case LevelsSO.AIState.fullDressWith6Makeup:
                ChooseRandomDress();
                ChooseRandomLipstick();
                ChooseRandomEyeShadow();
                ChooseRandomEarrings();
                ChooseRandomNosePins();
                ChooseRandomNecklace();
                Debug.Log(aistateAssign);
                AIScore = 45 ;
                break;
            case LevelsSO.AIState.onlyFullDress2_Shoes_Bags:
                ChooseRandomDress();
                ChooseRandomPurse();
                ChooseRandomShoes();
                Debug.Log(aistateAssign);
                AIScore = 25 ;
                break;
            case LevelsSO.AIState.onlyTop_Bottom2_Shoes_Bags:
                ChooseRandomTop();
                ChooseRandomBottom();
                ChooseRandomShoes();
                ChooseRandomPurse();
                Debug.Log(aistateAssign);
                AIScore = 22 ;
                break;
            case LevelsSO.AIState.fullDressWith2Makeup_Shoes_Bags:
                ChooseRandomDress();
                ChooseRandomShoes();
                ChooseRandomPurse();
                ChooseRandomLipstick();
                ChooseRandomEyeShadow();
                Debug.Log(aistateAssign);
                AIScore = 40 ;
                break;
            case LevelsSO.AIState.fullDressWith4Makeup_Shoes_Bags:
                Debug.Log(aistateAssign);
                ChooseRandomDress();
                ChooseRandomShoes();
                ChooseRandomPurse();
                ChooseRandomLipstick();
                ChooseRandomEyeShadow();
                ChooseRandomEarrings();
                ChooseRandomNosePins();
                AIScore = 45 ;
                break;
            case LevelsSO.AIState.fullDressWith6Makeup_Shoes_Bags:
                ChooseRandomDress();
                ChooseRandomPurse();
                ChooseRandomShoes();
                ChooseRandomLipstick();
                ChooseRandomEyeShadow();
                ChooseRandomNecklace();
                ChooseRandomEarrings();
                ChooseRandomNosePins();
                Debug.Log(aistateAssign);
                AIScore = 55 ;
                break;
        }
    }

    private void ChooseRandomDress()
    {
        AIDressRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .dress[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.dress.Count)];
    }

    private void ChooseRandomTop()
    {
        AITopRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .top[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.top.Count)];
    }

    private void ChooseRandomBottom()
    {
        AIBottomRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .bottom[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.bottom.Count)];
    }

    private void ChooseRandomPurse()
    {
        AIPurseRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .purse[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.purse.Count)];
    }

    private void ChooseRandomShoes()
    {
        AIShoesRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .shoes[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.shoes.Count)];
    }

    public void ChooseRandomFoundation()
    {
        AIFoundationRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .foundation[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.foundation.Count)];
    }

    private void ChooseRandomLipstick()
    {
        AILipstickRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .lipstick[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.lipstick.Count)];
    }

    private void ChooseRandomEyeLiner()
    {
        AIEyeLinerRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .lipstick[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.lipstick.Count)];
    }

    private void ChooseRandomLens()
    {
        AILensRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .lens[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.lens.Count)];
    }

    private void ChooseRandomHair()
    {
        AIHairRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .hair[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.hair.Count)];
    }

    private void ChooseRandomBlush()
    {
        AIBlushRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .blush[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.blush.Count)];
    }

    private void ChooseRandomEyeShadow()
    {
        AIEyeShadowRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .eyeshadow[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.eyeshadow.Count)];
    }

    private void ChooseRandomEyeBrows()
    {
        AIEyeBrowsRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .eyebrows[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.eyebrows.Count)];
    }

    private void ChooseRandomEarrings()
    {
        AIEarringsRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .earrings[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.earrings.Count)];
    }

    private void ChooseRandomNecklace()
    {
        AINecklaceRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .earrings[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.earrings.Count)];
    }

    private void ChooseRandomNosePins()
    {
        AINosePinsRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .nosepins[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.nosepins.Count)];
    }
    private void ChooseRandomEyeLash()
    {
        AIEyeLashesRef.sprite = InGameplayUIManager.instance.level[lvlNum].AiItemsassign
            .eyelashes[Random.Range(0, InGameplayUIManager.instance.level[lvlNum].AiItemsassign.eyelashes.Count)];
    }
}