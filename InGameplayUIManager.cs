using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class InGameplayUIManager : MonoBehaviour
{
    public static InGameplayUIManager instance;

    public GameObject comingSoon;

    #region Variables Declaration

    [Tooltip("Place Levels' Scriptables here")]
    [Space(10)] [Header("____Levels Scriptable Objects With Data____")]
    public LevelsSO[] level;


    [Space(10)] [Header("____Buttons/Panels/Windows____")]
    // public GameObject lvlBG;
    [Tooltip("Content window where items will be created according to their categories")]
    public GameObject ItemScrollView;
    [Tooltip("Parent of content window where items will be created according to their categories")]
    public GameObject itemScrollViewMain;
    public Animator makeUpScroll;
    public Animator dressUpScroll;
    // public GameObject girlCharacter;
    public Animator _girl;
    [HideInInspector] public List<GameObject> totalButtons;
    [HideInInspector] public int lvlNum;
    private int lockIndex;
    [HideInInspector] public PlayerState playerState;
    public Button[] categoryButtons;
    private GameState gameState;

    #endregion

    private void Awake()
    {
        instance = this;
        lvlNum = level[1].LevelNumber;
        Debug.Log(lvlNum);
        if(!PlayerPrefs.HasKey("Coins"))
            PlayerPrefs.SetInt("Coins",1000);
        Debug.Log("Coins Current ==   " + PlayerPrefs.GetInt("Coins"));
 // LockAllGame.instance.LockCompleteGame();
    }

    void Start()
    {
        GetFaceAnimator();
        CreateStateButtons();
        CreateTopsButtons();
    }


    #region ButtonsOnRuntime

    #region TopsButtons

    public void CreateTopsButtons()
    {
        playerState = PlayerState.Top;
        AddTops();
        PlayItemsAnimation();
    }

    [Space(20)] [Header("____DressUp Buttons Prefabs With Attached OnClicks_____")]
    [Tooltip("Place Top Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickTop topBtn;
    [HideInInspector] public List<OnClickTop> topButtonsInLevel;

    void AddTops()
    {
        if (topButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].tops.Count; i++)
            {
                OnClickTop b = Instantiate(topBtn, ItemScrollView.transform);
                b.tops = level[lvlNum].tops[i];
                level[lvlNum].tops[i].index = i;
                
                topButtonsInLevel.Add(b);
                totalButtons.Add(b.gameObject);
            }
        }
    }

    #endregion

    #region BottomsButtons
    [Tooltip("Place Bottom Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickBottom bottomBtn;
    [HideInInspector] public List<OnClickBottom> bottomButtonsInLevel;

    public void CreateBottomsButtons()
    {
        playerState = PlayerState.Bottom;
        AddBottoms();
        PlayItemsAnimation();
    }

    void AddBottoms()
    {
        if (bottomButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].bottoms.Count; i++)
            {
                OnClickBottom b = Instantiate(bottomBtn, ItemScrollView.transform);
                b.bottoms = level[lvlNum].bottoms[i];
                level[lvlNum].bottoms[i].index = i;
                bottomButtonsInLevel.Add(b);
                totalButtons.Add(b.gameObject);
            }
        }
    }

    #endregion

    #region DressButtons
    [Tooltip("Place Dress Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickDress dressBtn;
    [HideInInspector] public List<OnClickDress> dressButtonsInLevel;

    public void CreateDressButtons()
    {
        playerState = PlayerState.Dress;
        AddDresses();
        PlayItemsAnimation();
    }

    void AddDresses()
    {
        if (dressButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].fullDress.Count; i++)
            {
                OnClickDress b = Instantiate(dressBtn, ItemScrollView.transform);
                b.fullDress = level[lvlNum].fullDress[i];
                level[lvlNum].fullDress[i].index = i;
                dressButtonsInLevel.Add(b);
                totalButtons.Add(b.gameObject);
            }
        }
    }

    #endregion

    #region Shoes
    [Tooltip("Place Top Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickShoes shoesBtn;
    [HideInInspector] public List<OnClickShoes> shoesButtonsInLevel;

    public void CreateShoesButtons()
    {
        playerState = PlayerState.Shoes;
        AddShoes();
        PlayItemsAnimation();
    }

    public void AddShoes()
    {
        if (shoesButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].shoes.Count; i++)
            {
                OnClickShoes a = Instantiate(shoesBtn, ItemScrollView.transform);
                a.shoes = level[lvlNum].shoes[i];
                level[lvlNum].shoes[i].index = i;
                shoesButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Purse
    [Tooltip("Place Purse Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickPurse purseBtn;
    [HideInInspector] public List<OnClickPurse> purseButtonsInLevel;

    public void CreatePurseButtons()
    {
        playerState = PlayerState.Purse;
        AddPurse();
        PlayItemsAnimation();
    }

    public void AddPurse()
    {
        if (purseButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].purse.Count; i++)
            {
                OnClickPurse a = Instantiate(purseBtn, ItemScrollView.transform);
                a.purse = level[lvlNum].purse[i];
                level[lvlNum].purse[i].index = i;
                purseButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region LipStickButtons

    [Space(20)] [Header("____MakeUp Buttons With Attached OnClicks______")]
    [Tooltip("Place Lipstick Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickLipstick lipStickBtn;

    [HideInInspector] public List<OnClickLipstick> lipStickButtonsInLevel;

    public void CreateLipStickButtons()
    {
        playerState = PlayerState.Lipstick;
        AddLipSticks();
        PlayItemsAnimation();
    }

    public void AddLipSticks()
    {
        if (lipStickButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].lipStick.Count; i++)
            {
                OnClickLipstick b = Instantiate(lipStickBtn, ItemScrollView.transform);
                b.lipStick = level[lvlNum].lipStick[i];
                level[lvlNum].lipStick[i].index = i;
                lipStickButtonsInLevel.Add(b);
                totalButtons.Add(b.gameObject);
            }
        }
    }

    #endregion

    #region Foundation
    [Tooltip("Place Foundation Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickFoundation foundationBtn;
    [HideInInspector] public List<OnClickFoundation> foundationButtonsInLevel;

    public void CreateFoundationButtons()
    {
        playerState = PlayerState.Foundation;
        AddFoundation();
        PlayItemsAnimation();
    }

    public void AddFoundation()
    {
        if (foundationButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].foundation.Count; i++)
            {
                OnClickFoundation a = Instantiate(foundationBtn, ItemScrollView.transform);
                a.foundation = level[lvlNum].foundation[i];
                level[lvlNum].foundation[i].index = i;
                foundationButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Necklace
    [Tooltip("Place Necklace Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickNecklace necklaceBtn;
    [HideInInspector] public List<OnClickNecklace> necklaceButtonsInLevel;

    public void CreateNecklaceButtons()
    {
        playerState = PlayerState.Necklace;
        AddNecklace();
        PlayItemsAnimation();
    }

    public void AddNecklace()
    {
        if (necklaceButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].neckLace.Count; i++)
            {
                OnClickNecklace a = Instantiate(necklaceBtn, ItemScrollView.transform);
                a.necklace = level[lvlNum].neckLace[i];
                level[lvlNum].neckLace[i].index = i;
                necklaceButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Eyrbrows
    [Tooltip("Place Eyebrows Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickEyeBrows eyeBrowsBtn;
    [HideInInspector] public List<OnClickEyeBrows> eyeBrowsButtonsInLevel;

    public void CreateEyebrowsButtons()
    {
        playerState = PlayerState.EyeBrows;
        AddEyebrows();
        PlayItemsAnimation();
    }

    public void AddEyebrows()
    {
        if (eyeBrowsButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].eyebrows.Count; i++)
            {
                OnClickEyeBrows a = Instantiate(eyeBrowsBtn, ItemScrollView.transform);
                a.eyebrows = level[lvlNum].eyebrows[i];
                level[lvlNum].eyebrows[i].index = i;
                eyeBrowsButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Lens
    [Tooltip("Place Lens Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickLens lensBtn;
    [HideInInspector] public List<OnClickLens> lensButtonsInLevel;

    public void CreateLensButtons()
    {
        playerState = PlayerState.Lens;
        AddLens();
        PlayItemsAnimation();
    }

    public void AddLens()
    {
        if (lensButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].lens.Count; i++)
            {
                OnClickLens a = Instantiate(lensBtn, ItemScrollView.transform);
                a.lens = level[lvlNum].lens[i];
                level[lvlNum].lens[i].index = i;
                lensButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Eyeliner
    [Tooltip("Place Eyeliner Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickEyeLiner eyeLinerBtn;
    [HideInInspector] public List<OnClickEyeLiner> eyeLinerButtonsInLevel;

    public void CreateEyelinerButtons()
    {
        playerState = PlayerState.Eyeliner;
        AddEyeliner();
        PlayItemsAnimation();
    }

    public void AddEyeliner()
    {
        if (eyeLinerButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].eyeLiner.Count; i++)
            {
                OnClickEyeLiner a = Instantiate(eyeLinerBtn, ItemScrollView.transform);
                a.eyeliner = level[lvlNum].eyeLiner[i];
                level[lvlNum].eyeLiner[i].index = i;
                eyeLinerButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Contour
    [Tooltip("Place Contour Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickContour contourBtn;
    [HideInInspector] public List<OnClickContour> contourButtonsInLevel;

    /*public void CreateContourButtons()
    {
        playerState = PlayerState.Contour;
        AddContour();
        PlayItemsAnimation();
    }

    public void AddContour()
    {
        if (contourButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].contour.Count; i++)
            {
                OnClickContour a = Instantiate(contourBtn, ItemScrollView.transform);
                a.contour = level[lvlNum].contour[i];
                contourButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }*/

    #endregion

    #region EyeShadow
    [Tooltip("Place Eyeshadow Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickEyeShadow eyeShadowBtn;
    [HideInInspector] public List<OnClickEyeShadow> eyeShadowButtonsInLevel;

    public void CreateEyeShadowButtons()
    {
        playerState = PlayerState.EyeShadow;
        AddEyeShadow();
        PlayItemsAnimation();
    }

    public void AddEyeShadow()
    {
        if (eyeShadowButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].eyeShadow.Count; i++)
            {
                OnClickEyeShadow a = Instantiate(eyeShadowBtn, ItemScrollView.transform);
                a.eyeShadow = level[lvlNum].eyeShadow[i];
                level[lvlNum].eyeShadow[i].index = i;
                eyeShadowButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Blush
    [Tooltip("Place Blush Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickBlush blushBtn;
    [HideInInspector] public List<OnClickBlush> blushButtonsInLevel;

    public void CreateBlushButtons()
    {
        playerState = PlayerState.Blush;
        AddBlush();
        PlayItemsAnimation();
    }

    public void AddBlush()
    {
        if (blushButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].blush.Count; i++)
            {
                OnClickBlush a = Instantiate(blushBtn, ItemScrollView.transform);
                a.blush = level[lvlNum].blush[i];
                level[lvlNum].blush[i].index = i;
                blushButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region NosePins
    [Tooltip("Place Nosepins Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickNosePins nosePinsBtn;
    [HideInInspector] public List<OnClickNosePins> nosePinsButtonsInLevel;

    public void CreateNosePinsButtons()
    {
        playerState = PlayerState.NosePins;
        AddNosePins();
        PlayItemsAnimation();
    }

    public void AddNosePins()
    {
        if (nosePinsButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].nosePins.Count; i++)
            {
                OnClickNosePins a = Instantiate(nosePinsBtn, ItemScrollView.transform);
                a.nosepins = level[lvlNum].nosePins[i];
                level[lvlNum].nosePins[i].index = i;
                nosePinsButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Hair
    [Tooltip("Place Hair Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickHair hairBtn;
    [HideInInspector] public List<OnClickHair> hairButtonsInLevel;

    public void CreateHairButtons()
    {
        playerState = PlayerState.Hair;
        AddHair();
        PlayItemsAnimation();
    }

    public void AddHair()
    {
        if (hairButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].hair.Count; i++)
            {
                OnClickHair a = Instantiate(hairBtn, ItemScrollView.transform);
                a.hair = level[lvlNum].hair[i];
                level[lvlNum].hair[i].index = i;
                hairButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Earrings
    [Tooltip("Place Earrings Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickEarrings earringsBtn;
    [HideInInspector] public List<OnClickEarrings> earringsButtonsInLevel;

    public void CreateEarringsButtons()
    {
        playerState = PlayerState.Earrings;
        AddEarrings();
        PlayItemsAnimation();
    }

    public void AddEarrings()
    {
        if (earringsButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].earrings.Count; i++)
            {
                OnClickEarrings a = Instantiate(earringsBtn, ItemScrollView.transform);
                a.earrings = level[lvlNum].earrings[i];
                level[lvlNum].earrings[i].index = i;
                earringsButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #region Eyelashes
    [Tooltip("Place Eyelashes Button prefab with attached OnClickScript and Switch() Method")]
    public OnClickEyeLashes eyelashesBtn;
    [HideInInspector] public List<OnClickEyeLashes> eyelashesButtonsInLevel;

    public void CreateEyelashesButtons()
    {
        playerState = PlayerState.Eyelashes;
        AddEyelashes();
        PlayItemsAnimation();
    }

    public void AddEyelashes()
    {
        if (eyelashesButtonsInLevel.Count == 0)
        {
            for (int i = 0; i < level[lvlNum].eyelashes.Count; i++)
            {
                OnClickEyeLashes a = Instantiate(eyelashesBtn, ItemScrollView.transform);
                a.eyelashes = level[lvlNum].eyelashes[i];
                level[lvlNum].eyelashes[i].index = i;
                eyelashesButtonsInLevel.Add(a);
                totalButtons.Add(a.gameObject);
            }
        }
    }

    #endregion

    #endregion

    #region Misc

    public void CreateStateButtons()
    {
        for (int i = 0; i < totalButtons.Count; i++)
        {
            totalButtons[i].SetActive(false);
        }

        switch (playerState)
        {
            case PlayerState.Top:
            {
                for (int i = 0; i < topButtonsInLevel.Count; i++)
                {
                    topButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Bottom:
            {
                for (int i = 0; i < bottomButtonsInLevel.Count; i++)
                {
                    bottomButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Dress:
            {
                for (int i = 0; i < dressButtonsInLevel.Count; i++)
                {
                    dressButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Lipstick:
            {
                for (int i = 0; i < lipStickButtonsInLevel.Count; i++)
                {
                    lipStickButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Blush:
            {
                for (int i = 0; i < blushButtonsInLevel.Count; i++)
                {
                    blushButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            /*case PlayerState.Contour:
            {
                for (int i = 0; i < contourButtonsInLevel.Count; i++)
                {
                    contourButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }*/
            case PlayerState.Earrings:
            {
                for (int i = 0; i < earringsButtonsInLevel.Count; i++)
                {
                    earringsButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Eyeliner:
            {
                for (int i = 0; i < eyeLinerButtonsInLevel.Count; i++)
                {
                    eyeLinerButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Foundation:
            {
                for (int i = 0; i < foundationButtonsInLevel.Count; i++)
                {
                    foundationButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Hair:
            {
                for (int i = 0; i < hairButtonsInLevel.Count; i++)
                {
                    hairButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Lens:
            {
                for (int i = 0; i < lensButtonsInLevel.Count; i++)
                {
                    lensButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Necklace:
            {
                for (int i = 0; i < necklaceButtonsInLevel.Count; i++)
                {
                    necklaceButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Purse:
            {
                for (int i = 0; i < purseButtonsInLevel.Count; i++)
                {
                    purseButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Shoes:
            {
                for (int i = 0; i < shoesButtonsInLevel.Count; i++)
                {
                    shoesButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.EyeBrows:
            {
                for (int i = 0; i < eyeBrowsButtonsInLevel.Count; i++)
                {
                    eyeBrowsButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.Eyelashes:
            {
                for (int i = 0; i < eyelashesButtonsInLevel.Count; i++)
                {
                    eyelashesButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.EyeShadow:
            {
                for (int i = 0; i < eyeShadowButtonsInLevel.Count; i++)
                {
                    eyeShadowButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
            case PlayerState.NosePins:
            {
                for (int i = 0; i < nosePinsButtonsInLevel.Count; i++)
                {
                    nosePinsButtonsInLevel[i].gameObject.SetActive(true);
                }

                break;
            }
        }
    }

    public void OnDressUpClick()
    {
        playerState = PlayerState.Top;
        CreateStateButtons();
        _girl.Play("GirlDressup");
        makeUpScroll.Play("MakeupScrollHide");
        dressUpScroll.Play("DressUpScrollShow");
        gameState = GameState.DressUp;
    }

    public void OnMakeUpClick()
    {
        playerState = PlayerState.Lipstick;
        CreateLipStickButtons();
        CreateStateButtons();
        _girl.Play("GirlMakeup");
        makeUpScroll.Play("MakeupScrollShow");
        dressUpScroll.Play("DressUpScrollIHide");
        gameState = GameState.MakeUp;
    }

    public void GetFaceAnimator()
    {
        // _zoomAnim = girlCharacter.GetComponent<Animator>();
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
    }

    public void PlayItemsAnimation()
    {
        // itemScrollViewMain.SetActive(false);
//        StartCoroutine(Wait(.25f));
        itemScrollViewMain.SetActive(true);
    }

    public void DisableCurrentlySelectedButton(int index)
    {
        for (int i = 0; i < categoryButtons.Length; i++)
        {
            categoryButtons[i].gameObject.GetComponent<Button>().interactable = true;
        }

        categoryButtons[index].gameObject.GetComponent<Button>().interactable = false;
    }

    public void showComingSoon()
    {
        StopCoroutine(hideComingSoon());
        comingSoon.SetActive(true);
        StartCoroutine(hideComingSoon());
    }

    IEnumerator hideComingSoon()
    {
        yield return new WaitForSeconds(1f);
        comingSoon.SetActive(false);
    }

    #region States

    public enum PlayerState
    {
        Top,
        Bottom,
        Dress,
        Shoes,
        Purse,
        Necklace,
        Lipstick,

        //Contour,
        Foundation,
        Eyeliner,
        EyeShadow,
        EyeBrows,
        Lens,
        Hair,
        Blush,
        Earrings,
        NosePins,
        Eyelashes
    }

    private enum GameState
    {
        MakeUp,
        DressUp,
    }

    #endregion

    #endregion
}