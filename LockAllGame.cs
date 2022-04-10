using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockAllGame : MonoBehaviour
{
    public LevelsSO[] level;
    public static LockAllGame instance;

    private void Awake()
    {
        instance = this;
    }

    public void LockCompleteGame()
    {
        LockAllBlushAfter7Days();
        LockAllBottomsAfter7Days();
        LockAllDressesAfter7Days();
        LockAllEarringsAfter7Days();
        LockAllEyebrowsAfter7Days();
        LockAllEarringsAfter7Days();
        LockAllEyelashesAfter7Days();
        LockAllEyeshadowsAfter7Days();
        LockAllFoundationAfter7Days();
        LockAllHairAfter7Days();
        LockAllLensAfter7Days();
        LockAllLinerAfter7Days();
        LockAllLipstickAfter7Days();
        LockAllNecklaceAfter7Days();
        LockAllNosepinsAfter7Days();
        LockAllPurseAfter7Days();
        LockAllShoesAfter7Days();
        LockAllTopsAfter7Days();
        //SceneManager.LoadScene("GirlGame/Scene/Game");
    }

    private void LockAllDressesAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].fullDress.Count; j++)
            {
                if (level[i].fullDress[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].fullDress[j].locked = true;
                    Debug.Log(level[i].fullDress[j].index);
                    level[i].AiItemsassign.dress.Remove(level[i].fullDress[j].dressItem);
                }
            }
        }
    }

    private void LockAllTopsAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].tops.Count; j++)
            {
                if (level[i].tops[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].tops[j].locked = true;
                    Debug.Log(level[i].tops[j].index);
                    level[i].AiItemsassign.top.Remove(level[i].tops[j].topsItem);
                }
            }
        }
    }

    private void LockAllBottomsAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].bottoms.Count; j++)
            {
                if (level[i].bottoms[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].bottoms[j].locked = true;
                    Debug.Log(level[i].bottoms[j].index);
                    level[i].AiItemsassign.bottom.Remove(level[i].bottoms[j].bottomsItem);
                }
            }
        }
    }

    private void LockAllShoesAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].shoes.Count; j++)
            {
                if (level[i].shoes[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].shoes[j].locked = true;
                    Debug.Log(level[i].shoes[j].index);
                    level[i].AiItemsassign.shoes.Remove(level[i].shoes[j].shoesItem);
                }
            }
        }
    }

    private void LockAllPurseAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].purse.Count; j++)
            {
                if (level[i].purse[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].purse[j].locked = true;
                    Debug.Log(level[i].purse[j].index);
                    level[i].AiItemsassign.purse.Remove(level[i].purse[j].purseItem);
                }
            }
        }
    }

    private void LockAllLipstickAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].lipStick.Count; j++)
            {
                if (level[i].lipStick[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].lipStick[j].locked = true;
                    Debug.Log(level[i].lipStick[j].index);
                    level[i].AiItemsassign.lipstick.Remove(level[i].lipStick[j].lipstickItem);
                }
            }
        }
    }

    private void LockAllFoundationAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].foundation.Count; j++)
            {
                if (level[i].foundation[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].foundation[j].locked = true;
                    Debug.Log(level[i].foundation[j].index);
                    level[i].AiItemsassign.foundation.Remove(level[i].foundation[j].foundationItem);
                }
            }
        }
    }

    private void LockAllEyelashesAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyelashes.Count; j++)
            {
                if (level[i].eyelashes[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].eyelashes[j].locked = true;
                    Debug.Log(level[i].eyelashes[j].index);
                    level[i].AiItemsassign.eyelashes.Remove(level[i].eyelashes[j].eyeLashesItem);
                }
            }
        }
    }

    private void LockAllEyebrowsAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyebrows.Count; j++)
            {
                if (level[i].eyebrows[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].eyebrows[j].locked = true;
                    Debug.Log(level[i].eyebrows[j].index);
                    level[i].AiItemsassign.eyebrows.Remove(level[i].eyebrows[j].eyebrowsItem);
                }
            }
        }
    }

    private void LockAllEyeshadowsAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyeShadow.Count; j++)
            {
                if (level[i].eyeShadow[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].eyeShadow[j].locked = true;
                    Debug.Log(level[i].eyeShadow[j].index);
                    level[i].AiItemsassign.eyeshadow.Remove(level[i].eyeShadow[j].eyeshadowItem);
                }
            }
        }
    }

    private void LockAllLinerAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyeLiner.Count; j++)
            {
                if (level[i].eyeLiner[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].eyeLiner[j].locked = true;
                    Debug.Log(level[i].eyeLiner[j].index);
                    level[i].AiItemsassign.eyeliner.Remove(level[i].eyeLiner[j].eyelinerItem);
                }
            }
        }
    }

    private void LockAllLensAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].lens.Count; j++)
            {
                if (level[i].lens[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].lens[j].locked = true;
                    Debug.Log(level[i].lens[j].index);
                    level[i].AiItemsassign.lens.Remove(level[i].lens[j].lensItem);
                }
            }
        }
    }

    private void LockAllHairAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].hair.Count; j++)
            {
                if (level[i].hair[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].hair[j].locked = true;
                    Debug.Log(level[i].hair[j].index);
                    level[i].AiItemsassign.hair.Remove(level[i].hair[j].hairItem);
                }
            }
        }
    }

    private void LockAllNecklaceAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].neckLace.Count; j++)
            {
                if (level[i].neckLace[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].neckLace[j].locked = true;
                    Debug.Log(level[i].neckLace[j].index);
                    level[i].AiItemsassign.necklace.Remove(level[i].neckLace[j].necklaceItem);
                }
            }
        }
    }

    private void LockAllEarringsAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].earrings.Count; j++)
            {
                if (level[i].earrings[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].earrings[j].locked = true;
                    Debug.Log(level[i].earrings[j].index);
                    level[i].AiItemsassign.earrings.Remove(level[i].earrings[j].earringsItem);
                }
            }
        }
    }

    private void LockAllNosepinsAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].nosePins.Count; j++)
            {
                if (level[i].nosePins[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].nosePins[j].locked = true;
                    Debug.Log(level[i].nosePins[j].index);
                    level[i].AiItemsassign.nosepins.Remove(level[i].nosePins[j].nosePinsItem);
                }
            }
        }
    }

    private void LockAllBlushAfter7Days()
    {
        int i;
        int levellength = level.Length;

        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].blush.Count; j++)
            {
                if (level[i].blush[j].lockedAfter7DaysIfPremiumBought)
                {
                    level[i].blush[j].locked = true;
                    Debug.Log(level[i].blush[j].index);
                    level[i].AiItemsassign.blush.Remove(level[i].blush[j].blushItem);
                }
            }
        }
    }
}