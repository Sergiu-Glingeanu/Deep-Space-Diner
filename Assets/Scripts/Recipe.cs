using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Recipe : MonoBehaviour
{
    public List<TextMeshProUGUI> text;
    public Cooking_Manager cm;
    public Dish_Info dish;

    public void Update()
    {
        for (int i = 0; i < text.Count; i++)
        {
            text[i].text = Game_Manager.plants[dish.plantID[i]] + "/" + dish.amount[i];
        }
    }

    public void Cook()
    {
        cm.AddDishToQueue(dish.dishID);
    }
}
