using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMouseControl : MonoBehaviour
{
    Vector3 MousePosition;

    void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = 0;
    }
    private void OnMouseDrag()
    {
        transform.position = MousePosition;
    }
}
