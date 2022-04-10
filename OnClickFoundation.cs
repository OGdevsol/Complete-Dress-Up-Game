using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickFoundation : MonoBehaviour
{
    [HideInInspector] public ClassFoundation foundation;
    private int adCount;
    private SpriteRenderer foundationReference;
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
        if (!PlayerPrefs.HasKey("Foundation" + foundation.index)) return;
        foundation.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > foundation.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-foundation.priceInCoins);
            PlayerPrefs.SetInt("Foundation" + foundation.index, 0);
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
            PlayerPrefs.SetInt("Foundation" + foundation.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }


    public void Switch()
    {
        if (foundationReference.sprite != foundation.foundationItem || foundationReference.sprite == null)
        {
            foundationReference.sprite = foundation.foundationItem;
        }
        else if (foundationReference.sprite == foundation.foundationItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!foundation.locked) return;
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
        if (!foundation.locked) return;
        foundationReference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = foundation.adCount;
        /*adIndicator = gameObject.transform.GetChild(1).gameObject;
        buyingOptions = gameObject.transform.GetChild(2).gameObject;*/
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = foundation.foundationIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(foundation.locked);
        // foundationReference = References.instance.foundationReference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.foundation.Add(foundation.foundationItem);
    }
}