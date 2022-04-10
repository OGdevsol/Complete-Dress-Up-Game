using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEyeBrows : MonoBehaviour
{
    [HideInInspector] public ClassEyeBrows eyebrows;
    private int adCount;

    private SpriteRenderer eyebrowsReference;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;
    private GameObject BuyPanel;

    private void Start()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }

    private void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Eyebrows" + eyebrows.index)) return;
        eyebrows.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > eyebrows.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-eyebrows.priceInCoins);
            PlayerPrefs.SetInt("Eyebrows" + eyebrows.index, 0);
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
            PlayerPrefs.SetInt("Eyebrows" + eyebrows.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (eyebrowsReference.sprite != eyebrows.eyebrowsItem || eyebrowsReference.sprite == null)
        {
            eyebrowsReference.sprite = eyebrows.eyebrowsItem;
        }
        else if (eyebrowsReference.sprite == eyebrows.eyebrowsItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }


    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!eyebrows.locked) return;
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

    private void ResetItemIfNotBought()
    {
        if (!eyebrows.locked) return;
        eyebrowsReference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = eyebrows.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = eyebrows.eyebrowsIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(eyebrows.locked);
        eyebrowsReference = References.instance.eyebrowsReference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.eyebrows.Add(eyebrows.eyebrowsItem);
    }
}