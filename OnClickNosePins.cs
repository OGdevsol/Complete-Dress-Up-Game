using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickNosePins : MonoBehaviour
{
    [HideInInspector] public ClassNosePins nosepins;

    private int adCount;
    public GameObject BuyPanel;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;
    private SpriteRenderer nosepinReference;

    private void Start()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }

    private void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Nosepins" + nosepins.index)) return;
        nosepins.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > nosepins.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-nosepins.priceInCoins);
            PlayerPrefs.SetInt("Nosepins" + nosepins.index, 0);
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
            PlayerPrefs.SetInt("Nosepins" + nosepins.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (nosepinReference.sprite != nosepins.nosePinsItem || nosepinReference.sprite == null)
        {
            nosepinReference.sprite = nosepins.nosePinsItem;
        }
        else if (nosepinReference.sprite == nosepins.nosePinsItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }


    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!nosepins.locked) return;
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
        if (!nosepins.locked) return;
        nosepinReference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = nosepins.adCount;

        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = nosepins.nosePinsIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(nosepins.locked);
        nosepinReference = References.instance.nosepinsReference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.nosepins.Add(nosepins.nosePinsItem);
    }
}