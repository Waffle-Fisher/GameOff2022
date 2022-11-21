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
        if (_objectClicked || IsOverlapping(LayerMask.GetMask("Default")))
        {
            MoveObject();
        }
        if (IsOverlapping(LayerMask.GetMask("Grid")))
        {
            Debug.Log("I'm in a good spot");
        }
        else
        {
            Debug.Log("I'm not in a good spot");
        }
    }

    private void MoveObject()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float snappedWorldPosX = Mathf.Round(worldPos.x);
        float snappedWorldPosY = Mathf.Round(worldPos.y);
        Vector3 snappedWorldPos = new Vector3(snappedWorldPosX, snappedWorldPosY, 0);
        transform.position = snappedWorldPos;
    }

    private bool IsOverlapping(LayerMask layers)
    {
        ContactFilter2D filter = new();
        filter.SetLayerMask(layers);
        List<Collider2D> overlappedColliders = new();
        int numOverlaps = Physics2D.OverlapCollider(_collider,filter, overlappedColliders);
        Debug.Log("Num overlapping objs " + numOverlaps);
        return (numOverlaps > 0);
    }
}
