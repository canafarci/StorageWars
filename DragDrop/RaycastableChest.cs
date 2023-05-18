using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastableChest : MonoBehaviour, IRaycastable
{
    ChestFX _chestFX;
    

    private void Awake()
    {
        _chestFX = GetComponent<ChestFX>();
        
    }

    public bool OnRaycast()
    {
        _chestFX.PlayFX();
        return false;
    }

    
}
