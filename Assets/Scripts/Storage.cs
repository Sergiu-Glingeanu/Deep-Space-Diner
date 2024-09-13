using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Storage : MonoBehaviour
{
    public List<GameObject> items;
    public List<int> amount;
    public TextMeshProUGUI baseText;

    public int differenceX, differenceY;
    public int itemsPerRow;
    public RectTransform scrollView;

    List<GameObject> _currentItems = new List<GameObject>();

    public Game_Manager gm;

    public void Start()
    {
        UpdateStorage();
    }
    public void UpdateStorage()
    {
        foreach (GameObject a in _currentItems)
        {
            Destroy(a);
        }
        _currentItems.Clear();
        int rows = Mathf.CeilToInt((float)items.Count / (float)itemsPerRow);
        int itemsAdded = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < itemsPerRow; j++)
            {
                GameObject temp = Instantiate(items[itemsAdded], scrollView);
                temp.transform.localPosition = new Vector3(100 + differenceX * j, -100 - differenceY * i, 0);
                TextMeshProUGUI text = Instantiate(baseText, temp.transform);
                text.text = amount[itemsAdded].ToString();
                itemsAdded++;
                _currentItems.Add(temp);

                if (itemsAdded >= items.Count) break;
            }
        }
    }

    public void AddToStorage(GameObject x)
    {
        if (items.Contains(x))
        {
            amount[items.IndexOf(x)]++;
        } else
        {
            items.Add(x);
            amount.Add(1);
        }
        UpdateStorage();
    }

    public void RemoveFromStorage(GameObject x)
    {
        amount[items.IndexOf(x)]--;
        if (amount[items.IndexOf(x)] <= 0)
        {
            amount.RemoveAt(items.IndexOf(x));
            items.Remove(x);
        }
        UpdateStorage();
    }
}
