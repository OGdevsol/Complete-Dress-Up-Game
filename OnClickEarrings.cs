using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEarrings : MonoBehaviour
{
    [HideInInspector] public ClassEarrings earrings;
    private int adCount;
    private SpriteRenderer earrings1Reference;
    private SpriteRenderer earrings2Reference;
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
        if (!PlayerPrefs.HasKey("Earrings" + earrings.index)) return;
        earrings.locked = false;
        AddItemToAiWhenUnlocked();
        
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > earrings.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-earrings.priceInCoins);
            PlayerPrefs.SetInt("Earrings" + earrings.index, 0);
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
            PlayerPrefs.SetInt("Earrings" + earrings.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (earrings1Reference.sprite != earrings.earringsItem && earrings2Reference.sprite != earrings.earringsItem ||
            earrings1Reference.sprite == null && earrings2Reference.sprite == null)
        {
            earrings1Reference.sprite = earrings.earringsItem;
            earrings2Reference.sprite = earrings.earringsItem;
        }
        else if (earrings1Reference.sprite == earrings.earringsItem &&
                 earrings2Reference.sprite == earrings.earringsItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!earrings.locked) return;
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
        if (!earrings.locked) return;
        earrings1Reference.sprite = null;
        earrings2Reference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = earrings.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = earrings.earringsIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(earrings.locked);
        earrings1Reference = References.instance.earrings1Reference;
        earrings2Reference = References.instance.earrings2Reference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.earrings.Add(earrings.earringsItem);
    }
}