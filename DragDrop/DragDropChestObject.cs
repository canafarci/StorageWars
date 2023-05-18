using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropChestObject : DragDropObject
{
    Animator _animator;
    private void Awake() => _animator = GetComponent<Animator>();
    protected override IEnumerator RotationRoutine()
    {
        _animator.enabled = false;
        return base.RotationRoutine();
    }
}
