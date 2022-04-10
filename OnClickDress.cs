using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class OnClickDress : MonoBehaviour
{
    [HideInInspector] public ClassFullDress fullDress;
    private GameObject topReference;
    private GameObject defaultTop;
    private GameObject defaultBottom;
    private GameObject bottomReference;
 
    private SpriteRenderer dressReference;

    public int adCount;


    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;
    private GameObject BuyPanel;


    private void Start()
    {
        Initialization();
    }


    public void SwitchDress()
    {
        Switch();
    }

    public void Initialization()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }


    public void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Dress" + fullDress.index)) return;
        fullDress.locked = false;
        AddItemToAiWhenUnlocked();
    }

    public void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > fullDress.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-fullDress.priceInCoins);
            PlayerPrefs.SetInt("Dress" + fullDress.index, 0);
            fullDress.locked = false;
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
            PlayerPrefs.SetInt("Dress" + fullDress.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    void GetReferences()
    {
        adCount = fullDress.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = fullDress.dressIcon;
        topReference = References.instance.topReference.gameObject;
        defaultTop = References.instance.defaultTop;
        defaultBottom = References.instance.defaultBottom;
        dressReference = References.instance.dressReference;
        bottomReference = References.instance.bottomReference.gameObject;
    }

    public void CloseBuyPanel()
    {
        InGameplayUIManager.instance.itemScrollViewMain.transform.GetChild(1).gameObject.SetActive(false);
        ResetItemIfNotBought();
    }

    private void ResetItemIfNotBought()


    {
        if (!fullDress.locked) return;
        dressReference.sprite = null;
        defaultTop.SetActive(true);
        defaultBottom.SetActive(true);
    }


    void Switch()
    {
        if (dressReference.sprite != fullDress.dressItem || dressReference.sprite == null)
        {
            dressReference.sprite = fullDress.dressItem;
            bottomReference.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            topReference.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            defaultBottom.SetActive(false);
            defaultTop.SetActive(false);
        }
        else if (dressReference.sprite == fullDress.dressItem)
        {
            Undo1.instance.undo();
        }

        

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!fullDress.locked) return;
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


    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.dress.Add(fullDress.dressItem);
    }
}