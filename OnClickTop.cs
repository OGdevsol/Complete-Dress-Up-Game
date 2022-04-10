using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickTop : MonoBehaviour
{
    [HideInInspector] public ClassTops tops;
    private SpriteRenderer topReference;
    private GameObject defaultTop;
    private GameObject dressReference;
    private GameObject dressReferenceSr;
    private GameObject defaultBottom;
    private GameObject bottomReference;
    private GameObject BuyPanel;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;
    private int adCount;

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }

    private void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Top" + tops.index)) return;
        tops.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > tops.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-tops.priceInCoins);

            PlayerPrefs.SetInt("Top" + tops.index, 0);
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
            PlayerPrefs.SetInt("Top" + tops.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (topReference.sprite != tops.topsItem || topReference.sprite == null)
        {
            topReference.GetComponent<SpriteRenderer>().sprite = tops.topsItem;
            dressReference.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            defaultTop.SetActive(false);
            if (bottomReference.GetComponent<SpriteRenderer>().sprite == null)
            {
                defaultBottom.SetActive(true);
            }
        }
        else if (topReference.sprite == tops.topsItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!tops.locked) return;
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
        if (!tops.locked) return;
        topReference.sprite = null;
        defaultTop.SetActive(true);
    }


    private void GetReferences()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = tops.topsIcon;
        topReference = References.instance.topReference;
        defaultTop = References.instance.defaultTop;
        dressReference = References.instance.dressReference.gameObject;
        defaultBottom = References.instance.defaultBottom;
        bottomReference = References.instance.bottomReference.gameObject;
        adCount = tops.adCount;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.top.Add(tops.topsItem);
    }
}