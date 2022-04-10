using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEyeLashes : MonoBehaviour
{
    [HideInInspector] public ClassEyeLashes eyelashes;

    private int adCount;
    private SpriteRenderer eyelashes1Reference;
    private SpriteRenderer eyelashes2Reference;
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
        if (!PlayerPrefs.HasKey("Eyelashes" + eyelashes.index)) return;
        eyelashes.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > eyelashes.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-eyelashes.priceInCoins);
            PlayerPrefs.SetInt("Eyelashes" + eyelashes.index, 0);
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
            PlayerPrefs.SetInt("Eyelashes" + eyelashes.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (eyelashes1Reference.sprite != eyelashes.eyeLashesItem ||
            eyelashes1Reference.sprite == null && eyelashes2Reference.sprite != eyelashes.eyeLashesItem ||
            eyelashes2Reference.sprite == null)
        {
            eyelashes1Reference.sprite = eyelashes.eyeLashesItem;
            eyelashes2Reference.sprite = eyelashes.eyeLashesItem;
        }
        else if (eyelashes1Reference.sprite == eyelashes.eyeLashesItem &&
                 eyelashes2Reference.sprite == eyelashes.eyeLashesItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!eyelashes.locked) return;
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
        if (!eyelashes.locked) return;
        eyelashes1Reference.sprite = null;
        eyelashes2Reference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = eyelashes.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = eyelashes.eyeLashesIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(eyelashes.locked);
        eyelashes1Reference = References.instance.eyelashes1Reference;
        eyelashes2Reference = References.instance.eyelashes2Reference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.eyelashes.Add(eyelashes.eyeLashesItem);
    }
}