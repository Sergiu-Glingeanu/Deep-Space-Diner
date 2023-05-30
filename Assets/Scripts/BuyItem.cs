using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public Game_Manager gm;

    public int ID, price;

    public void Buy()
    {
        if (price <= Game_Manager.money)
        {
            switch (gameObject.tag)
            {
                case "shop_seed":
                    gm.BuySeed(ID);
                    Destroy(gameObject);
                    break;

                case "shop_recipe":
                    gm.BuyRecipe(ID);
                    Destroy(gameObject);
                    break;

                case "shop_farm":
                    gm.BuyDecoration(ID);
                    break;

                case "shop_upgrade":
                    gm.BuyUpgrade(ID);
                    Destroy(gameObject);
                    break;
            }

            Game_Manager.money -= price;
        }
    }
}
