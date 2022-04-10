using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickLens : MonoBehaviour
{
    [HideInInspector] public ClassLens lens;
    private int adCount;
    private SpriteRenderer lens1Reference;
    private SpriteRenderer lens2Reference;
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
        if (!PlayerPrefs.HasKey("Lens" + lens.index)) return;
        lens.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > lens.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-lens.priceInCoins);
            PlayerPrefs.SetInt("Lens" + lens.index, 0);
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
            PlayerPrefs.SetInt("Lens" + lens.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (lens1Reference.sprite != lens.lensItem ||
            lens1Reference.sprite == null && lens2Reference.sprite != lens.lensItem || lens2Reference.sprite == null)
        {
            lens1Reference.sprite = lens.lensItem;
            lens2Reference.sprite = lens.lensItem;
        }
        else if (lens1Reference.sprite == lens.lensItem && lens2Reference.sprite == lens.lensItem)
        {
            Undo1.instance.undo();
        }


        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!lens.locked) return;
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
        if (!lens.locked) return;
        lens1Reference.sprite = null;
        lens2Reference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = lens.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = lens.lensIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(lens.locked);
        lens1Reference = References.instance.lens1Reference;
        lens2Reference = References.instance.lens2Reference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.lens.Add(lens.lensItem);
    }
}