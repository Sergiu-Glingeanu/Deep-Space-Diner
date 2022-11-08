using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag_From_Shop : MonoBehaviour, IPointerDownHandler
{

    public bool seedBag;

    public GameObject ui, item;

    private void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject temp = Instantiate(item, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        temp.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        temp.GetComponent<SeedBag>().ui = ui;
        ui.SetActive(false);
        
    }
}
