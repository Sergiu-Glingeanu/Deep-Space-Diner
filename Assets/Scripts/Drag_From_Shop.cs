using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drag_From_Shop : MonoBehaviour
{

    public bool seedBag;

    public GameObject ui, item;
    public Button button;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(Input.mousePosition, transform.position) < 30f)
        {
            GameObject temp = Instantiate(item, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            temp.transform.position = new Vector3(transform.position.x, transform.position.y, 1);
            temp.GetComponent<SeedBag>().ui = ui;
            ui.SetActive(false);
        }
    }
}
