using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{
    void OnDrag(Vector3 position);
    void OnDragEnd();
    void OnDragEnd(Vector3 position);
}
