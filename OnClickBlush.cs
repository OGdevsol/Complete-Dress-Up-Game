using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickBlush : MonoBehaviour
{
    [HideInInspector] public ClassBlush blush;
    private int adCount;
    


    private SpriteRenderer blush1Reference;
    private SpriteRenderer blush2Reference;
    public GameObject BuyPanel;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;

    private void Start()
    {
        GetReferences();
        
    }

    public void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Blush" + blush.index)) return;

        blush.locked = false;
        AddItemToAiWhenUnlocked();
    }


    public void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > blush.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-blush.priceInCoins);
            PlayerPrefs.SetInt("Blush" + blush.index, 0);
            Debug.Log("Bought");
        }
        else
        {
            Debug.Log("Unaffordable");
        }

        CheckIfItemBoughtOrNot();
    }

   

    public void BuyWithAds()
    {
        adCount--;
        if (adCount == 0)
        {
            PlayerPrefs.SetInt("Blush" + blush.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (blush1Reference.sprite != blush.blushItem && blush2Reference.sprite != blush.blushItem ||
            blush1Reference.sprite == null && blush2Reference.sprite == null)
        {
            blush1Reference.sprite = blush.blushItem;
            blush2Reference.sprite = blush.blushItem;
        }
        else if (blush1Reference.sprite == blush.blushItem && blush2Reference.sprite == blush.blushItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    void ShowBuyingOptionsIfItemLocked()
    {
        if (!blush.locked) return;
        BuyPanel = InGameplayUIManager.instance.itemScrollViewMain.transform.GetChild(1).gameObject;
        AdsButton = BuyPanel.transform.GetChild(0).gameObject.GetComponent<Button>();
        coinsButton = BuyPanel.transform.GetChild(1).gameObject.GetComponent<Button>();
        closeButton = BuyPanel.transform.GetChild(2).gameObject.GetComponent<Button>();

        AdsButton.onClick.RemoveAllListeners();
        coinsButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();

        AdsButton.onClick.AddListener(delegate { BuyWithAds(); });
        coinsButton.onClick.AddListener(delegate { BuyWithCoins(); });
        closeButton.onClick.AddListener(delegate { CloseBuyPanel(); });
        BuyPanel.SetActive(true);
    }


    void CloseBuyPanel()
    {
        InGameplayUIManager.instance.itemScrollViewMain.transform.GetChild(1).gameObject.SetActive(false);
        ResetItemIfNotBought();
    }

    private void ResetItemIfNotBought()
    {
        if (!blush.locked) return;
        blush1Reference.sprite = null;
        blush2Reference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = blush.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = blush.blushIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(blush.locked);
        blush1Reference = References.instance.blush1Reference;
        blush2Reference = References.instance.blush2Reference;
    }

    void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.blush.Add(blush.blushItem);
    }
}