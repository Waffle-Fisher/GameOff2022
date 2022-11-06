using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnMouseDrag()
    {
        Debug.Log("I'm getting clied/dragged");
        MoveObject();
        CheckOverlap();
    }

    private void MoveObject()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float snappedWorldPosX = Mathf.Round(worldPos.x);
        float snappedWorldPosY = Mathf.Round(worldPos.y);
        Vector3 snappedWorldPos = new Vector3(snappedWorldPosX, snappedWorldPosY, 0);
        transform.position = snappedWorldPos;
    }

    private void CheckOverlap()
    {
        ContactFilter2D filter = new();
        filter.SetLayerMask(LayerMask.GetMask("Default"));
        List<Collider2D> overlappedColliders = new();
        
        Debug.Log(this.name + " has overlapped with " + _collider.OverlapCollider(filter, overlappedColliders) + " objects!");
    }
}
