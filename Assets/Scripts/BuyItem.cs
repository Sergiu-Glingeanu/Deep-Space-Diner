using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public Game_Manager gm;

    public int tag;

    public void SetTag(int tag)
    {
        this.tag = tag;
    }
    public void Buy(int ID)
    {
        switch (tag)
        {
            case 0:
                gm.BuySeed(ID);
                break;

            case 1:
                gm.BuyRecipe(ID);
                break;

            case 2:
                gm.BuyUpgrade(ID);
                break;
        }
    }
}
