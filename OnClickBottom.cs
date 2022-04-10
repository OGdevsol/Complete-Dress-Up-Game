using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickBottom : MonoBehaviour
{
    [HideInInspector] public ClassBottoms bottoms;

    public int adCount;

    /*
    private int coins; // Add coins playerpref here
    */

  
    public GameObject BuyPanel;
    private Button AdsButton;
    private Button coinsButton;
    private Button closeButton;
    private GameObject scrollView;


    void Start()
    {
        Initialization();
        CheckIfItemBoughtOrNot();
    }



    public void Initialization()
    {
        GetReferences();
    }


    public void CheckIfItemBoughtOrNot()
    {
        if (!PlayerPrefs.HasKey("Bottoms" + bottoms.index)) return;
        bottoms.locked = false;
        AddItemToAiWhenUnlocked();

       
    }


    private void BuyWithCoins()
    {
        if (PlayerPrefs.GetInt("Coins") > bottoms.priceInCoins)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - bottoms.priceInCoins); ;
            PlayerPrefs.SetInt("Bottoms" + bottoms.index, 0);
            Debug.Log("Bought");
        }
        else
        {
            Debug.Log("Unaffordable");
        }

        CheckIfItemBoughtOrNot();
        Debug.Log(PlayerPrefs.GetInt("Coins"));
    }
   
    private void BuyWithAds()
    {
        adCount--;
        if (adCount == 0)
        {
            PlayerPrefs.SetInt("Bottoms" + bottoms.index, 0);
        }

        CheckIfItemBoughtOrNot();
    }

    public void Switch()
    {
        if (References.instance.bottomReference.sprite != bottoms.bottomsItem ||
            References.instance.bottomReference.sprite == null)
        {
            References.instance.bottomReference.sprite = bottoms.bottomsItem;
            References.instance.defaultBottom.SetActive(false);
            References.instance.dressReference.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (References.instance.bottomReference.sprite == bottoms.bottomsItem)
        {
            Undo1.instance.undo();
        }

        if (References.instance.topReference.sprite == null || !References.instance.defaultTop.activeInHierarchy &&
            References.instance.topReference.sprite == null)
        {
            References.instance.defaultTop.SetActive(true);
        }

        ShowBuyingOptionsIfItemLocked();
    }

    private void ShowBuyingOptionsIfItemLocked()
    {
        if (!bottoms.locked) return;
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
        ResetIfItemNotBought();
    }

    private void ResetIfItemNotBought()
    {
        if (!bottoms.locked) return;
        References.instance.defaultBottom.SetActive(true);
        References.instance.bottomReference.sprite = null;


    }
    public void GetReferences()
    {
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = bottoms.bottomsIcon;
        adCount = bottoms.adCount;
      
    }

    private void AddItemToAiWhenUnlocked()
    {
        InGameplayUIManager.instance.level[0].AiItemsassign.bottom.Add(bottoms.bottomsItem);
    }
}