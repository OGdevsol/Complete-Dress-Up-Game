using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickNecklace : MonoBehaviour
{
    [HideInInspector] public ClassNecklace necklace;
    private int adCount;
    private SpriteRenderer necklaceReference;
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

    public void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Necklace" + necklace.index)) return;
        necklace.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > necklace.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-necklace.priceInCoins);
            PlayerPrefs.SetInt("Necklace" + necklace.index, 0);
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
            PlayerPrefs.SetInt("Necklace" + necklace.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (necklaceReference.sprite != necklace.necklaceItem || necklaceReference.sprite == null)
        {
            necklaceReference.sprite = necklace.necklaceItem;
        }
        else if (necklaceReference.sprite == necklace.necklaceItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }


    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!necklace.locked) return;
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
        if (!necklace.locked) return;
        necklaceReference.sprite = null;
    }

    private void GetReferences()
    {
        adCount = necklace.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = necklace.necklaceIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(necklace.locked);
        necklaceReference = References.instance.necklaceReference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.eyebrows.Add(necklace.necklaceItem);
    }
}