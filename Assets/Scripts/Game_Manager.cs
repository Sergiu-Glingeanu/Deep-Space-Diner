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

    public Grid grid;
    public Transform clock;
    public TextMeshProUGUI moneyText;

    public static List<Farm_Tile> farmTiles;
    public static int money;

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
}