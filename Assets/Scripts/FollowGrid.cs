using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGrid : MonoBehaviour
{
    public Grid grid;

    private bool _moving;
    private Vector3 _oldLocation;
    private bool _insideObject;

    void Start()
    {
        Vector3Int cp = grid.LocalToCell(transform.localPosition);
        transform.localPosition = grid.GetCellCenterLocal(cp); // Snap object to nearest cell in grid
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _moving = false;
            if (_insideObject) transform.position = _oldLocation;
        }

        if (_moving) FollowMouse();
    }

    private void OnMouseDown()
    {
        if (!Game_Manager.dayTime)
        {
            _moving = true;
            _oldLocation = transform.position;
        }
    }

    private void FollowMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cp = grid.LocalToCell(mousePos);
        transform.localPosition = grid.GetCellCenterLocal(cp); // Snap object to nearest cell in grid
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _insideObject = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _insideObject = false;
    }
}
