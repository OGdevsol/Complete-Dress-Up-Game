using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Level/NewLevel")]
public class LevelsSO : ScriptableObject
{
    [Space(10)] [Header("_______LevelNumber_______")]
    public int LevelNumber;

    [Space(10)] [Header("_______LevelRewards_______")]
    public int levelCoinsReward;

    [Space(10)] [Header("_______LevelObjective_______")] [Space] [TextArea]
    public string objectiveText;

    [Space(10)] [Header("_______LevelBGTheme_______")]
    public Sprite levelBackground;

    [Space(10)] [Header("_______Dress Up Items_______")] [Space]
    public List<ClassFullDress> fullDress;

    public List<ClassTops> tops;
    public List<ClassBottoms> bottoms;
    public List<ClassShoes> shoes;
    public List<ClassPurse> purse;

    [Space(10)] [Header("_______Make Up Items________")] [SerializeField]
    public List<ClassLipstick> lipStick;

    public List<ClassBlush> blush;
    public List<ClassEarrings> earrings;

    //   public List<ClassContour> contour;
    public List<ClassEyeBrows> eyebrows;
    public List<ClassEyeLashes> eyelashes;
    public List<ClassEyeLiner> eyeLiner;
    public List<ClassEyeShadow> eyeShadow;
    public List<ClassFoundation> foundation;
    public List<ClassHair> hair;
    public List<ClassNecklace> neckLace;
    public List<ClassNosePins> nosePins;
    public List<ClassLens> lens;

    public enum AIState
    {
        //Foundation is must
        // 2 makeup == lipstick+mascara+Foundation
        // 4 makeup == lipstick+mascara+Hair+Eyeshadow+Foundation
        // 6 makeup == lipstick+mascara+Lens+Eyeshadow+Blush+Hair+Foundation
        onlyFullDress,
        onlyFullDress2_Shoes_Bags,
        onlyTop_Bottom,
        onlyTop_Bottom2_Shoes_Bags,
        fullDressWith2Makeup,
        fullDressWith2Makeup_Shoes_Bags,
        fullDressWith4Makeup,
        fullDressWith4Makeup_Shoes_Bags,
        fullDressWith6Makeup,
        fullDressWith6Makeup_Shoes_Bags,
    }

    [Header("_________________AI___________________")]
    public AiItemsAssign AiItemsassign;
}

[Serializable]
public class ClassFullDress
{
    [HideInInspector] public int index;
    public Sprite dressIcon;
    public Sprite dressItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassTops
{
    [HideInInspector] public int index;
    public Sprite topsIcon;
    public Sprite topsItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassBottoms
{
     public int index;
    public Sprite bottomsIcon;
    public Sprite bottomsItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassShoes
{
    [HideInInspector] public int index;
    public Sprite shoesIcon;
    public Sprite shoesItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassPurse
{
    [HideInInspector] public int index;
    public Sprite purseIcon;
    public Sprite purseItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassFoundation
{
    [HideInInspector] public int index;

    public Sprite foundationIcon;
    public Sprite foundationItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassLipstick
{
    [HideInInspector] public int index;

    public Sprite lipstickIcon;
    public Sprite lipstickItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassEyeLiner
{
    [HideInInspector] public int index;
    public Sprite eyelinerIcon;
    public Sprite eyelinerItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassHair
{
    [HideInInspector] public int index;
    public Sprite hairIcon;
    public Sprite hairItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassLens
{
    [HideInInspector] public int index;

    public Sprite lensIcon;
    public Sprite lensItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public bool UnlockedAfter7Days;
    public int adCount;
}

[Serializable]
public class ClassContour
{
    [HideInInspector] public int index;
    public Sprite contourIcon;
    public Sprite contourItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassBlush
{
    [HideInInspector] public int index;

    public Sprite blushIcon;
    public Sprite blushItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassEyeShadow
{
    [HideInInspector] public int index;

    public Sprite eyeshadowIcon;
    public Sprite eyeshadowItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassEyeBrows
{
    [HideInInspector] public int index;

    public Sprite eyebrowsIcon;
    public Sprite eyebrowsItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassEarrings
{
    [HideInInspector] public int index;

    public Sprite earringsIcon;
    public Sprite earringsItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassNecklace
{
    [HideInInspector] public int index;

    public Sprite necklaceIcon;
    public Sprite necklaceItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassNosePins
{
    [HideInInspector] public int index;
    public Sprite nosePinsIcon;
    public Sprite nosePinsItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class ClassEyeLashes
{
    [HideInInspector] public int index;

    public Sprite eyeLashesIcon;
    public Sprite eyeLashesItem;
    public int priceInCoins;
    public bool locked;
    public bool lockedAfter7DaysIfPremiumBought;
    public bool isDaiyOffer;
    public int adCount;
}

[Serializable]
public class AiItemsAssign
{
    //  [HideInInspector] public LevelsSO.AIState AI_state;

    [Header("_____DressUp_____")] [Space(10)]
    public List<Sprite> dress;

    public List<Sprite> top;
    public List<Sprite> bottom;
    public List<Sprite> shoes;
    public List<Sprite> purse;

    [Header("_____MakeUp_____")] [Space(10)]
    public List<Sprite> lipstick;

    public List<Sprite> foundation;
    public List<Sprite> eyebrows;
    public List<Sprite> eyeliner;
    public List<Sprite> eyeshadow;
    public List<Sprite> nosepins;
    public List<Sprite> necklace;
    public List<Sprite> lens;
    public List<Sprite> hair;
    public List<Sprite> blush;
    public List<Sprite> earrings;
    public List<Sprite> eyelashes;
}