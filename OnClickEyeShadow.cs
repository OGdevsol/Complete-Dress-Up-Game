using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickEyeShadow : MonoBehaviour
{
    [HideInInspector] public ClassEyeShadow eyeShadow;
    private int adCount;
    private SpriteRenderer eyeShadow1Reference;
    private SpriteRenderer eyeShadow2Reference;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;
    public GameObject BuyPanel;

    private void Start()
    {
        GetReferences();
        CheckIfItemBoughtOrNot();
    }

    private void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Eyeshadow" + eyeShadow.index)) return;
        eyeShadow.locked = false;
        AddItemToAiWhenUnlocked();
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > eyeShadow.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-eyeShadow.priceInCoins);
            PlayerPrefs.SetInt("Eyeshadow" + eyeShadow.index, 0);
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
            PlayerPrefs.SetInt("Eyeshadow" + eyeShadow.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (eyeShadow1Reference.sprite != eyeShadow.eyeshadowItem ||
            eyeShadow1Reference.sprite == null && eyeShadow2Reference.sprite != eyeShadow.eyeshadowItem ||
            eyeShadow2Reference.sprite == null)
        {
            eyeShadow1Reference.sprite = eyeShadow.eyeshadowItem;
            eyeShadow2Reference.sprite = eyeShadow.eyeshadowItem;
        }
        else if (eyeShadow1Reference.sprite == eyeShadow.eyeshadowItem &&
                 eyeShadow2Reference.sprite == eyeShadow.eyeshadowItem)
        {
            Undo1.instance.undo();
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!eyeShadow.locked) return;
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
    }

    private void ResetItemIfNotBought()
    {
        if (!eyeShadow.locked) return;
        eyeShadow1Reference.sprite = null;
        eyeShadow2Reference.sprite = null;
    }

    private void GetReferences()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = eyeShadow.eyeshadowIcon;
        gameObject.transform.GetChild(1).gameObject.SetActive(eyeShadow.locked);
        eyeShadow1Reference = References.instance.eyeshadow1Reference;
        eyeShadow2Reference = References.instance.eyeshadow2Reference;
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.eyebrows.Add(eyeShadow.eyeshadowItem);
    }
}