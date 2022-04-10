using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickLipstick : MonoBehaviour
{
    private GameObject BuyPanel;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;

    [HideInInspector] public ClassLipstick lipStick;
    private int adCount;



    private SpriteRenderer lipstickReference;

    private void Start()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }

    public void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Lipstick" + lipStick.index)) return;
        lipStick.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > lipStick.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-lipStick.priceInCoins);
            PlayerPrefs.SetInt("Lipstick" + lipStick.index, 0);
            Debug.Log("Bought");
            CloseBuyPanel();
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
            PlayerPrefs.SetInt("Lipstick" + lipStick.index, 0);
            CloseBuyPanel();
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (lipstickReference.sprite != lipStick.lipstickItem || lipstickReference.sprite == null)
        {
            lipstickReference.sprite = lipStick.lipstickItem;
        }
        else if (lipstickReference.sprite == lipStick.lipstickItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!lipStick.locked) return;
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
        if (!lipStick.locked) return;
        lipstickReference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = lipStick.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = lipStick.lipstickIcon;
        lipstickReference = References.instance.lipStickReference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.lipstick.Add(lipStick.lipstickItem);
    }
}