using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickShoes : MonoBehaviour
{
    [HideInInspector] public ClassShoes shoes;
    private int adCount;
    private SpriteRenderer shoesReferences;
    private GameObject BuyPanel;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;


    private void Start()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }


    private void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Shoes" + shoes.index)) return;
        shoes.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > shoes.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-shoes.priceInCoins);

            PlayerPrefs.SetInt("Shoes" + shoes.index, 0);
            Debug.Log("Bought");
        }
        else
        {
            Debug.Log("Unaffordable");
        }

        CheckIfItemBoughtOrNot();
    }

    private void BuyWithAds()
    {
        adCount--;
        if (adCount == 0)
        {
            PlayerPrefs.SetInt("Shoes" + shoes.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    private void GetReferences()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = shoes.shoesIcon;
        shoesReferences = References.instance.shoesReferences;
        adCount = shoes.adCount;
    }

    public void Switch()
    {
        if (shoesReferences.sprite != shoes.shoesItem || shoesReferences.sprite == null)
        {
            shoesReferences.sprite = shoes.shoesItem;
        }
        else if (shoesReferences.sprite == shoes.shoesItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!shoes.locked) return;
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

    private void CloseBuyPanel()
    {
        InGameplayUIManager.instance.itemScrollViewMain.transform.GetChild(1).gameObject.SetActive(false);
        ResetItemIfNotBought();
    }

    void ResetItemIfNotBought()
    {
        if (!shoes.locked) return;
        shoesReferences.sprite = null;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.shoes.Add(shoes.shoesItem);
    }
}