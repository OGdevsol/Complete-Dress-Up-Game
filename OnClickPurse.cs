using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPurse : MonoBehaviour
{
    [HideInInspector] public ClassPurse purse;
    private int adCount;
    private SpriteRenderer purseReference;
    private GameObject BuyPanel;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;

    void Start()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }


    private void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Purse" + purse.index)) return;
        purse.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > purse.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-purse.priceInCoins);

            PlayerPrefs.SetInt("Purse" + purse.index, 0);
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
            PlayerPrefs.SetInt("Purse" + purse.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }


    public void SwitchPurse()
    {
        if (purseReference.sprite != purse.purseItem || purseReference.sprite == null)
        {
            purseReference.sprite = purse.purseItem;
        }
        else if (purseReference.sprite == purse.purseItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!purse.locked) return;
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
        if (!purse.locked) return;
        purseReference.sprite = null;
    }


    private void GetReferences()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = purse.purseIcon;
        adCount = purse.adCount;
        purseReference = References.instance.purseReference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.purse.Add(purse.purseItem);
    }
}