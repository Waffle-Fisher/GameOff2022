using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    Collider2D _collider;
    bool _objectClicked = false;


    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        Debug.Log("I'm getting clied/dragged");
        _objectClicked = true;
    }

    private void OnMouseUp()
    {
        _objectClicked = false;
    }

    private void Update()
    {
        if( _objectClicked || IsOverlapping())
        {
            MoveObject();
        }
    }

    private void MoveObject()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float snappedWorldPosX = Mathf.Round(worldPos.x);
        float snappedWorldPosY = Mathf.Round(worldPos.y);
        Vector3 snappedWorldPos = new Vector3(snappedWorldPosX, snappedWorldPosY, 0);
        transform.position = snappedWorldPos;
        Debug.Log("Pos: " + transform.position);
    }

    private bool IsOverlapping()
    {
        ContactFilter2D filter = new();
        filter.SetLayerMask(LayerMask.GetMask("Default"));
        List<Collider2D> overlappedColliders = new();
        int numOverlaps = _collider.OverlapCollider(filter, overlappedColliders);
        Debug.Log("Num overlapping objs" + numOverlaps);
        return (numOverlaps > 0);
    }
}
