using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character_Info : MonoBehaviour
{
    public Image dish1, dish2, characterPic;
    public TextMeshProUGUI dish1Amount, dish2Amount;

    public int orderDuration;
    public Order_Manager om;
    public int orderLocation;

    private float _timePassed;

    private void Update()
    {
        _timePassed += Time.deltaTime;

        if (_timePassed >= orderDuration)
        {
            om.CompleteOrder(true, orderLocation);
        }
    }
}
