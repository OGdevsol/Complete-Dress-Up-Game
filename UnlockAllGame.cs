using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockAllGame : MonoBehaviour
{
    public static UnlockAllGame instance;
    public LevelsSO[]  level;
    private int lvlNum;

    private void Awake()
    {
        instance = this;

    }

    public void UnlockCompleteGame()
    {
        UnlockFoundation();
        UnlockAlEyelashes();
        UnlockAllBlush();
        UnlockAllBottoms();
        UnlockAllDresses();
        UnlockAllEarrings();
        UnlockAllEyebrows();
        UnlockAllEyeliner();
        UnlockAllEyeshadows();
        UnlockAllFoundation();
        UnlockAllHair();
        UnlockAllLens();
        UnlockAllLipsticks();
        UnlockAllNecklace();
        UnlockAllNosepins();
        UnlockAllPurse();
        UnlockAllShoes();
        UnlockAllTops();
     //   SceneManager.LoadScene("GirlGame/Scene/Game");

    }

   
    private  void UnlockAllDresses()
    {
        int i;
        int levellength=level.Length;
        
        for ( i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].fullDress.Count; j++)
            {
                if (level[i].fullDress[j].locked)
                {
                    level[i].fullDress[j].locked = false;
                    Debug.Log(level[i].fullDress[j].index);
                    level[i].AiItemsassign.dress.Add(level[i].fullDress[j].dressItem);
                }
            }
        }
    }
    private  void UnlockAllTops()
    {
        int i;
        int levellength=level.Length;
        
        for ( i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].tops.Count; j++)
            {
                if (level[i].tops[j].locked)
                {
                    level[i].tops[j].locked = false;
                    Debug.Log(level[i].tops[j].index);
                    level[i].AiItemsassign.top.Add(level[i].tops[j].topsItem);
                }
            }
        }
    }
    private  void UnlockAllBottoms()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].bottoms.Count; j++)
            {
                if (level[i].bottoms[j].locked)
                {
                    level[i].bottoms[j].locked = false;
                    Debug.Log(level[i].bottoms[j].index);
                    level[i].AiItemsassign.bottom.Add(level[i].bottoms[j].bottomsItem);
                }
            }
        }
    }
    private  void UnlockAllShoes()
    {
        int i;
        int levellength=level.Length;
        for ( i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].shoes.Count; j++)
            {
                if (level[i].shoes[j].locked)
                {
                    level[i].shoes[j].locked = false;
                    Debug.Log(level[i].shoes[j].index);
                    level[i].AiItemsassign.shoes.Add(level[i].shoes[j].shoesItem);
                }
            }
        }
    }
    private  void UnlockAllPurse()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].purse.Count; j++)
            {
                if (level[i].purse[j].locked)
                {
                    level[i].purse[j].locked = false;
                    Debug.Log(level[i].purse[j].index);
                    level[i].AiItemsassign.purse.Add(level[i].purse[j].purseItem);
                }
            }
        }
    }
    private  void UnlockAllLipsticks()
    {
        int i;
        int levellength=level.Length;
        
        for ( i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].lipStick.Count; j++)
            {
                if (level[i].lipStick[j].locked)
                {
                    level[i].lipStick[j].locked = false;
                    Debug.Log(level[i].lipStick[j].index);
                    level[i].AiItemsassign.lipstick.Add(level[i].lipStick[j].lipstickItem);
                }
            }
        }
    }
    private  void UnlockFoundation()
    {
        int i;
        int levellength=level.Length;
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].foundation.Count; j++)
            {
                if (level[i].foundation[j].locked)
                {
                    level[i].foundation[j].locked = false;
                    Debug.Log(level[i].foundation[j].index);
                    level[i].AiItemsassign.foundation.Add(level[i].foundation[j].foundationItem);
                }
            }
        }
    }
    private  void UnlockAllBlush()
    {
        int i;
        int levellength=level.Length;
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].blush.Count; j++)
            {
                if (level[i].blush[j].locked)
                {
                    level[i].blush[j].locked = false;
                    Debug.Log(level[i].blush[j].index);
                    level[i].AiItemsassign.blush.Add(level[i].blush[j].blushItem);
                }
            }
        }
    }
    private  void UnlockAllEarrings()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].earrings.Count; j++)
            {
                if (level[i].earrings[j].locked)
                {
                    level[i].earrings[j].locked = false;
                    Debug.Log(level[i].earrings[j].index);
                    level[i].AiItemsassign.earrings.Add(level[i].earrings[j].earringsItem);
                }
            }
        }
    }
    private  void UnlockAllEyebrows()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyebrows.Count; j++)
            {
                if (level[i].eyebrows[j].locked)
                {
                    level[i].eyebrows[j].locked = false;
                    Debug.Log(level[i].eyebrows[j].index);
                    level[i].AiItemsassign.eyebrows.Add(level[i].eyebrows[j].eyebrowsItem);
                }
            }
        }
    }
    private  void UnlockAllEyeshadows()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyeShadow.Count; j++)
            {
                if (level[i].eyeShadow[j].locked)
                {
                    level[i].eyeShadow[j].locked = false;
                    Debug.Log(level[i].eyeShadow[j].index);
                    level[i].AiItemsassign.eyeshadow.Add(level[i].eyeShadow[j].eyeshadowItem);
                }
            }
        }
    }
    private  void UnlockAllEyeliner()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyeLiner.Count; j++)
            {
                if (level[i].eyeLiner[j].locked)
                {
                    level[i].eyeLiner[j].locked = false;
                    Debug.Log(level[i].eyeLiner[j].index);
                    level[i].AiItemsassign.eyeliner.Add(level[i].eyeLiner[j].eyelinerItem);
                }
            }
        }
    }
    private  void UnlockAlEyelashes()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].eyelashes.Count; j++)
            {
                if (level[i].eyelashes[j].locked)
                {
                    level[i].eyelashes[j].locked = false;
                    Debug.Log(level[i].eyelashes[j].index);
                    level[i].AiItemsassign.dress.Add(level[i].eyelashes[j].eyeLashesItem);
                }
            }
        }
    }
    private  void UnlockAllFoundation()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].foundation.Count; j++)
            {
                if (level[i].foundation[j].locked)
                {
                    level[i].foundation[j].locked = false;
                    Debug.Log(level[i].foundation[j].index);
                    level[i].AiItemsassign.foundation.Add(level[i].foundation[j].foundationItem);
                }
            }
        }
    }
    private  void UnlockAllHair()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].hair.Count; j++)
            {
                if (level[i].hair[j].locked)
                {
                    level[i].hair[j].locked = false;
                    Debug.Log(level[i].hair[j].index);
                    level[i].AiItemsassign.hair.Add(level[i].hair[j].hairItem);
                }
            }
        }
    }
    private  void UnlockAllNecklace()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < level.Length; i++)
        {
            for (int j = 0; j < level[i].neckLace.Count; j++)
            {
                if (level[i].neckLace[j].locked)
                {
                    level[i].neckLace[j].locked = false;
                    Debug.Log(level[i].neckLace[j].index);
                    level[i].AiItemsassign.necklace.Add(level[i].neckLace[j].necklaceItem);
                }
            }
        }
    }
    private  void UnlockAllNosepins()
    {
        int i;
        int levellength=level.Length;
        
        for (i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].nosePins.Count; j++)
            {
                if (level[i].nosePins[j].locked)
                {
                    level[i].nosePins[j].locked = false;
                    Debug.Log(level[i].nosePins[j].index);
                    level[i].AiItemsassign.nosepins.Add(level[i].nosePins[j].nosePinsItem);
                }
            }
        }
    }
    private  void UnlockAllLens()
    {
        int i;
        int levellength=level.Length;
        
        for ( i = 0; i < levellength; i++)
        {
            for (int j = 0; j < level[i].lens.Count; j++)
            
                if (level[i].lens[j].locked)
                {
                    level[i].lens[j].locked = false;
                    Debug.Log(level[i].lens[j].index);
                    level[i].AiItemsassign.lens.Add(level[i].lens[j].lensItem);
                }
        }
    }
    
   
    private IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }




}



