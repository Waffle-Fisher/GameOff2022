using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private void OnMouseDrag()
    {
        Debug.Log("I'm getting clied/dragged");
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float snappedWorldPosX = Mathf.Round(worldPos.x);
        float snappedWorldPosY = Mathf.Round(worldPos.y);
        Vector3 snappedWorldPos = new Vector3(snappedWorldPosX, snappedWorldPosY, 0);
        transform.position = snappedWorldPos;
    }
}
