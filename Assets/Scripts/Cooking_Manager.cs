using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking_Manager : MonoBehaviour
{
    public List<GameObject> queue;
    public List<Image> images;
    public List<GameObject> recipes;
    public Transform content;
    public int difference;
    public Image circle;
    public int maxQueue;

    public Game_Manager gm;

    private float _timePassed;

    private void Start()
    {
        UpdateRecipes();
    }

    public void AddDishToQueue(int dishID)
    {
        if (queue.Count < maxQueue)
        {
            bool hasEnough = true;
            Dish_Info di = gm.dishesPrefabs[dishID].GetComponent<Dish_Info>();
            for (int i = 0; i < di.plantID.Length; i++)
            {
                if (Game_Manager.plants[di.plantID[i]] < di.amount[i])
                {
                    hasEnough = false;
                }
            }

            if (hasEnough)
            {
                images[queue.Count].sprite = di.dishImage;
                images[queue.Count].gameObject.SetActive(true);
                queue.Add(gm.dishesPrefabs[dishID]);
                if (queue.Count < 2) StartCoroutine(CookDishes());

                for (int i = 0; i < di.plantID.Length; i++)
                {
                    Game_Manager.plants[di.plantID[i]] -= di.amount[i];
                }
            }
        }
    }

    IEnumerator CookDishes()
    {
        float cookingTime = queue[0].GetComponent<Dish_Info>().cookingTime;
        _timePassed = 0f;

        while(_timePassed <= cookingTime)
        {
            _timePassed += Time.deltaTime;
            circle.fillAmount = _timePassed / cookingTime;

            yield return null;
        }
        FinishCooking(queue[0].GetComponent<Dish_Info>().dishID);
        circle.fillAmount = 0f;

    }

    void FinishCooking(int dishID)
    {
        Game_Manager.dishes[dishID] += 1;
        queue.RemoveAt(0);
        images[queue.Count].gameObject.SetActive(false);
        for (int i = 0; i < queue.Count; i++)
        {
            images[i].sprite = images[i + 1].sprite;
        }
        if (queue.Count > 0) StartCoroutine(CookDishes());
    }

    public void UpdateRecipes()
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            GameObject temp = Instantiate(recipes[i], content);
            temp.transform.localPosition = new Vector3(250, -100 - (difference * i), 0);
        }
    }
}
