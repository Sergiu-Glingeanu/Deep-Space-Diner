using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character_Info : MonoBehaviour
{
    public Image characterPic;
    public Image[] dishes;
    public TextMeshProUGUI[] dishAmount;

    public int orderDuration;
    public Order_Manager om;
    public int orderLocation;

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
}
