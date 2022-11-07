using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_UI : MonoBehaviour
{
    public List<GameObject> seeds, recipes, farm, upgrades;

    public Transform scrollView;

    private List<GameObject> _currentItemsInShop = new List<GameObject>();

    public int differenceX, differenceY;
    public int itemsPerRow;

    public void ShowSeeds()
    {
        foreach (GameObject a in _currentItemsInShop)
        {
            Destroy(a);
        }
        _currentItemsInShop.Clear();

        int rows = Mathf.CeilToInt((float)seeds.Count / (float)itemsPerRow);
        int itemsPlaced = 0;

        for (int i = 0; i < rows; i ++)
        {
            for (int j = 0; j < itemsPerRow; j ++)
            {
                GameObject seedBag = Instantiate(seeds[i], scrollView);
                seedBag.transform.localPosition = new Vector3(200 + j * differenceX, -100 - differenceY * i, 0);
                _currentItemsInShop.Add(seedBag);
                itemsPlaced += 1;

                if (itemsPlaced == seeds.Count) break;
            }
        }
    }

    public void ShowRecipes()
    {
        foreach (GameObject a in _currentItemsInShop)
        {
            Destroy(a);
        }
        _currentItemsInShop.Clear();

        int rows = Mathf.CeilToInt((float)recipes.Count / (float)itemsPerRow);
        int itemsPlaced = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < itemsPerRow; j++)
            {
                GameObject recipe = Instantiate(recipes[i], scrollView);
                recipe.transform.localPosition = new Vector3(200 + j * differenceX, -100 - differenceY * i, 0);
                _currentItemsInShop.Add(recipe);
                itemsPlaced += 1;

                if (itemsPlaced == recipes.Count) break;
            }
        }
    }

    public void ShowFarm()
    {
        foreach (GameObject a in _currentItemsInShop)
        {
            Destroy(a);
        }
        _currentItemsInShop.Clear();

        int rows = Mathf.CeilToInt((float)farm.Count / (float)itemsPerRow);
        int itemsPlaced = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < itemsPerRow; j++)
            {
                GameObject farmItem = Instantiate(farm[i], scrollView);
                farmItem.transform.localPosition = new Vector3(200 + j * differenceX, -100 - differenceY * i, 0);
                _currentItemsInShop.Add(farmItem);
                itemsPlaced += 1;

                if (itemsPlaced == farm.Count) break;
            }
        }
    }

    public void ShowUpgrades()
    {
        foreach (GameObject a in _currentItemsInShop)
        {
            Destroy(a);
        }
        _currentItemsInShop.Clear();

        int rows = Mathf.CeilToInt((float)upgrades.Count / (float)itemsPerRow);
        int itemsPlaced = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < itemsPerRow; j++)
            {
                GameObject upgrade = Instantiate(upgrades[i], scrollView);
                upgrade.transform.localPosition = new Vector3(200 + j * differenceX, -100 - differenceY * i, 0);
                _currentItemsInShop.Add(upgrade);
                itemsPlaced += 1;

                if (itemsPlaced == upgrades.Count) break;
            }
        }
    }
}
