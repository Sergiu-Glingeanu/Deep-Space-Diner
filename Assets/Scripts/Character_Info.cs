using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Character_Info : MonoBehaviour, IPointerDownHandler
{
    public Image characterPic;
    public Image[] dishes;
    public TextMeshProUGUI[] dishAmount;

    public int orderDuration;
    public Order_Manager om;
    public int orderLocation;

    public List<int> dishIDs;

    public Dictionary<int, int> order = new Dictionary<int, int>();

    private float _timePassed;

    private void Update()
    {
        _timePassed += Time.deltaTime;

        if (_timePassed >= orderDuration)
        {
            om.CompleteOrder(true, orderLocation);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        bool hasEnough = true;

        for (int i = 0; i < order.Count; i++)
        {
            if (Game_Manager.dishes[dishIDs[i]] < order[dishIDs[i]])
            {
                hasEnough = false;
            }
        }

        if (hasEnough)
        {
            for (int i = 0; i < order.Count; i++)
            {
                Game_Manager.dishes[dishIDs[i]] -= order[dishIDs[i]];
            }
            om.CompleteOrder(false, orderLocation);
        }
    }
}
