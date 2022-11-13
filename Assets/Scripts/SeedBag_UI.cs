using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Comparer : IComparer<GameObject>
{
    public int Compare(GameObject x, GameObject y)
    {
        if (x == null || y == null) return 0;

        return x.name.CompareTo(y.name);
    }
}

public class SeedBag_UI : MonoBehaviour
{
    public List<GameObject> seeds;

    public Transform content;

    public int difference;

    private Comparer c = new Comparer();

    public void UpdateUI()
    {
        seeds.Sort(c);
        for (int i = 0; i < seeds.Count; i++)
        {
            GameObject temp = Instantiate(seeds[i], content);
            temp.transform.localPosition = new Vector3(100 + (difference * i), -100, 0);
        }
    }
}
