using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class common : MonoBehaviour {

    public static Sprite GetSpriteByCardID(ulong id)
    {
        return Resources.Load<Sprite>("card/" + id.ToString());
    }

    public static Sprite GetSpriteByHeroIndex(int index)
    {
        return Resources.Load<Sprite>("hero/0" + index.ToString());
    }

    public static List<ulong> GetRandCardList(int num)
    {
        List<ulong> list = new List<ulong>();
        for (int i = 0; i < num ;i++)
        {
            ulong l = ulong.Parse(Random.Range(10000001, 10000051).ToString());
            list.Add(l);

        }
        return list;
    }

}
