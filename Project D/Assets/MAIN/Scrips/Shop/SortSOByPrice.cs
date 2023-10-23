using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortSOByPrice : IComparer<SO_CharacterInforMantion>, IComparer<SO_CharacterInforMantionRANGER>, IComparer<SO_Active_Skill>
{
    public int Compare(SO_CharacterInforMantion x, SO_CharacterInforMantion y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        // So sánh theo thuộc tính PriceBuy
        return x.PriceBuy.CompareTo(y.PriceBuy);
    }

    public int Compare(SO_CharacterInforMantionRANGER x, SO_CharacterInforMantionRANGER y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        // So sánh theo thuộc tính PriceBuy
        return x.PriceBuy.CompareTo(y.PriceBuy);
    }

    public int Compare(SO_Active_Skill x, SO_Active_Skill y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        // So sánh theo thuộc tính PriceBuy
        return x.PriceBuy.CompareTo(y.PriceBuy);
    }
}
