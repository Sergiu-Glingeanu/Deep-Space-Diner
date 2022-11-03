using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static bool dayTime;

    public int dayDuraton;

    public GameObject dayUI, nightUI;

    private float _timePassed;

    public int plantsInGame, dishesInGame;
    public static Dictionary<int, int> plants = new Dictionary<int, int>();
    public static Dictionary<int, int> dishes = new Dictionary<int, int>();

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
            if (_timePassed >= dayDuraton)
            {
                EndDay();
;           }
        }
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
    }
}