using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBag : MonoBehaviour
{
    public GameObject plant, ui;

    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);

        if (Input.GetMouseButtonUp(0))
        {
            ui.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
