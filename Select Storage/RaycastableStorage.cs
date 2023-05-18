using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastableStorage : MonoBehaviour, IRaycastable
{
    [SerializeField] GameObject[] _objectsToDisable;
    public int StoragePrice;
    public bool OnRaycast()
    {
        //deduct price
        GameManager.Instance.ResourceManager.OnMoneyChange( -1 * StoragePrice);

        foreach (GameObject go in _objectsToDisable)
        {
            go.SetActive(false);
        }
                StartCoroutine(FindObjectOfType<OpenStorage>().OpenGate());

        AudioConfig audioConfig = GameManager.Instance.References.GameConfig.StorageBuyConfig;
        GameManager.Instance.AudioManager.PlaySFX(audioConfig.Audio, audioConfig.Volume);


        return true;
    }
}
