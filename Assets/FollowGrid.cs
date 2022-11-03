using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGrid : MonoBehaviour
{
    public Grid grid;

    private bool _moving;

    // Start is called before the first frame update
    void Start()
    {
        Vector3Int cp = grid.LocalToCell(transform.localPosition);
        transform.localPosition = grid.GetCellCenterLocal(cp); // Snap object to nearest cell in grid
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)) _moving = false;

        if (_moving) FollowMouse();
    }

    private void OnMouseDown()
    {
        _moving = true;
    }

    private void FollowMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cp = grid.LocalToCell(mousePos);
        transform.localPosition = grid.GetCellCenterLocal(cp); // Snap object to nearest cell in grid
    }
}
