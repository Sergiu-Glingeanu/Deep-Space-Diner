using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order_Manager : MonoBehaviour
{
    public List<Sprite> characterImages;

    public List<Transform> orderLocations;

    public List<GameObject> allowedDishes;
    public GameObject characterPrefab;

    public int maxDishes, maxAmountDishes, maxOrders, timeToGetAnOrder, maxOrderDuration;

    private float _timePassed;
    private List<GameObject> _currentOrders = new List<GameObject>();
    void Start()
    {
        
    }

    void Update()
    {
        if (_currentOrders.Count < maxOrders)
        {
            _timePassed += Time.deltaTime;
        }

        if (_timePassed >= timeToGetAnOrder && _currentOrders.Count < maxOrderDuration)
        {
            CreateNewOrder();
            _timePassed = 0f;
        }

        Debug.Log(_currentOrders.Count);
    }

    public void CreateNewOrder()
    {
        GameObject temp = Instantiate(characterPrefab, orderLocations[_currentOrders.Count]);
        temp.transform.position = orderLocations[_currentOrders.Count].position;
        Character_Info ci = temp.GetComponent<Character_Info>();
        ci.om = this;
        ci.orderDuration = maxOrderDuration;
        ci.orderLocation = _currentOrders.Count;
        _currentOrders.Add(temp);

    }

    public void CompleteOrder(bool expired, int orderLocation)
    {
        Destroy(_currentOrders[orderLocation]);
        _currentOrders.RemoveAt(orderLocation);
        foreach (GameObject a in _currentOrders)
        {
            if (a.GetComponent<Character_Info>().orderLocation > orderLocation)
            {
                a.GetComponent<Character_Info>().orderLocation -= 1;
                a.transform.SetParent(orderLocations[a.GetComponent<Character_Info>().orderLocation], false);
            }
        }
    }
}
