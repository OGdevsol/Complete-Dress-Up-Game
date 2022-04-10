using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEyeLiner : MonoBehaviour
{
    [HideInInspector] public ClassEyeLiner eyeliner;
    public int adCount;
    private SpriteRenderer eyelinerReference;
    public GameObject BuyPanel;
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
        if (!PlayerPrefs.HasKey("Eyeliner" + eyeliner.index)) return;
        eyeliner.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > eyeliner.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-eyeliner.priceInCoins);
            PlayerPrefs.SetInt("Eyeliner" + eyeliner.index, 0);
            Debug.Log("Bought");
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
            PlayerPrefs.SetInt("Eyeliner" + eyeliner.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (eyelinerReference.sprite != eyeliner.eyelinerItem || eyelinerReference.sprite == null)
        {
            eyelinerReference.sprite = eyeliner.eyelinerItem;
        }
        else if (eyelinerReference.sprite == eyeliner.eyelinerItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }


    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!eyeliner.locked) return;
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
        if (!eyeliner.locked) return;
        eyelinerReference.sprite = null;
    }


    private void GetReferences()
    {
        adCount = eyeliner.adCount;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = eyeliner.eyelinerIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(eyeliner.locked);
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.eyeliner.Add(eyeliner.eyelinerItem);
    }
}