using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    public static bool dayTime;

    public int dayDuraton;

    public GameObject dayUI, nightUI;

    private float _timePassed;

    public int plantsInGame, dishesInGame;
    public static Dictionary<int, int> plants = new Dictionary<int, int>();
    public static Dictionary<int, int> dishes = new Dictionary<int, int>();

    public List<GameObject> dishesPrefabs;
    public List<GameObject> seeds, recipes, upgardes;

    public Grid grid;
    public Transform clock;
    public TextMeshProUGUI moneyText;

    public static List<Farm_Tile> farmTiles;
    public static int money;

    public Order_Manager om;
    public Cooking_Manager cm;
    public Shop_UI shop;

    public List<GameObject> shopSeeds, shopRecipes, shopUpgrades;

    void Start()
    {
        for(int i = 0; i < plantsInGame; i++)
        {
            plants.Add(i, 0);
        }

        for (int i = 0; i < dishesInGame; i++)
        {
            dishes.Add(i, 0);
        }
    }
    void Update()
    {
        if (dayTime)
        {
            _timePassed += Time.deltaTime;

            clock.rotation = Quaternion.Euler(clock.rotation.x, clock.rotation.y, 184f + ((_timePassed / (float)dayDuraton)) * 360f);
            if (_timePassed >= dayDuraton)
            {
                EndDay();
;           }
        }

        moneyText.text = money.ToString();
    }

    public void StartDay()
    {
        nightUI.SetActive(false);
        dayUI.SetActive(true);
        dayTime = true;
        _timePassed = 0f;
    }

    public void EndDay()
    {
        nightUI.SetActive(true);
        dayUI.SetActive(false);
        dayTime = false;
        foreach (Farm_Tile a in farmTiles)
        {
            Destroy(a.plant.gameObject);
            a.empty = true;
            StopCoroutine(a.GrowPlant());
        }

        for (int i = 0; i < plants.Count; i++)
        {
            plants[i] = 0;
        }

        for (int i = 0; i < dishes.Count; i++)
        {
            dishes[i] = 0;
        }
    }

    public void BuySeed(int seedID)
    {
        shop.seeds.Remove(shopSeeds[seedID]);
        shop.ShowSeeds();
    }

    public void BuyRecipe(int recipeID)
    {
        shop.recipes.Remove(shopRecipes[recipeID]);
        shop.ShowRecipes();
    }

    public void BuyUpgrade(int upgradeID)
    {
        shop.upgrades.Remove(shopUpgrades[upgradeID]);
        shop.ShowUpgrades();
    }
}