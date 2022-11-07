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
    private List<GameObject> _tempList = new List<GameObject>();
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
            _tempList.Clear(); // Used to make sure no duplicate dishes in order
            _tempList.AddRange(allowedDishes);
            CreateNewOrder(); // creates a new order
            _timePassed = 0f; // resets the time
        }
    }

    public void CreateNewOrder()
    {
        GameObject temp = Instantiate(characterPrefab, orderLocations[_currentOrders.Count]);   // Instantiates the order object
        temp.transform.position = orderLocations[_currentOrders.Count].position;                // Moves it to the right position
        Character_Info ci = temp.GetComponent<Character_Info>();                                // Gets a reference to the character info script
        ci.om = this;                                                                           // gives the character a reference to this script
        ci.orderDuration = maxOrderDuration;                                                    // Gives the order a time limit
        ci.orderLocation = _currentOrders.Count;                                                // puts the order in a list that tracks the locations of orders
        

        for (int i = 0; i < maxDishes; i++) // Loop to select a random dish for each slot
        {
            int chosenDish = Random.Range(0, _tempList.Count);                                  // Choses random dish from available ones
            int amount = Random.Range(1, maxAmountDishes);                                      // Choses random amount of the dish
            ci.order.Add(_tempList[chosenDish].GetComponent<Dish_Info>().dishID, amount);       // Adds the dish to the character dictionary with the amount wanted
            ci.dishes[i].gameObject.SetActive(true);                                            // Activates the Image object in the character prefab
            ci.dishes[i].sprite = _tempList[chosenDish].GetComponent<Dish_Info>().dishImage;    // Changes the image to the selected dish image
            ci.dishAmount[i].text = amount.ToString();                                          // Changes the text beside the image to show how many the customer wants

            _tempList.RemoveAt(chosenDish); // removes the dish from the temp list to make sure it doesn't get picked a second time
            if (_tempList.Count < 1) break; // If the list is empty it will break out of the loop
        }
        _currentOrders.Add(temp); // Adds the order to the orders List
    }

    public void CompleteOrder(bool expired, int orderLocation)
    {
        Destroy(_currentOrders[orderLocation]); // Deletes the order from the game
        _currentOrders.RemoveAt(orderLocation); // Removes the order from the orders list
        foreach (GameObject a in _currentOrders)
        {
            if (a.GetComponent<Character_Info>().orderLocation > orderLocation) // Moves the orders below this one one space up
            {
                a.GetComponent<Character_Info>().orderLocation -= 1;
                a.transform.SetParent(orderLocations[a.GetComponent<Character_Info>().orderLocation], false);
            }
        }
    }
}
